using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Threading;
using System.Threading.Tasks;

public class SceneLoadManager : MonoBehaviour
{
    [SerializeField] private Image _loadingBar;
    [SerializeField] private TextMeshProUGUI _loadingText;

    private void Start()
    {
        _loadingBar.fillAmount = 0;
    }

    public void SetProgressBarValue(System.Object caller, float value)
    {
        if (_loadingBar != null && value >=0 && value <= 1 && caller is IGameState)
        {
            _loadingBar.fillAmount = value;
        }
    }

    public void SetStateText(System.Object caller, string state)
    {
        if (_loadingText != null && caller is IGameState)
        {
            _loadingText.text = state;
            Debug.Log("state: " + state + " progress: " + _loadingBar.fillAmount * 100.0f + "%." );
        }
    }

    public async void LoadSceneAsync(System.Object caller, string sceneName)
    {
        if (caller is IGameState)
        {
            float time = 0.0f;
            float limitTime = 1.0f;
            do
            {
                await Task.Delay(10);
                _loadingBar.fillAmount = Mathf.Lerp(0, limitTime, time);
                _loadingText.text = $"Initialize loading {(int)(_loadingBar.fillAmount * 100)}%";
                time += 0.01f;
            } while (time < limitTime);

            var loadScene = SceneManager.LoadSceneAsync(sceneName);

            do
            {
                await Task.Delay(10);
                if (loadScene.progress < 1)
                {
                    _loadingBar.fillAmount = loadScene.progress;
                    _loadingText.text = $"Progress of {sceneName} loading.";
                }
            } while (loadScene.progress < 1.0f);

            loadScene.completed += scene =>
            {
                var state = (IGameState)caller;
                state.StateMachine.TransitionToState(typeof(MenuState));
            };

            await Task.Delay(10);
        }
    }
}