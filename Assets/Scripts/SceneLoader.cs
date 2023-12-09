using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader
{
    private GameObject _loadingCanvas;
    private Image _loadindBar;
    private Text _loadingText;

    public async void LoadSceneAsync(System.Object caller, GameObject canvas)
    {
        if (caller is IGameState)
        {
            _loadingCanvas = canvas;
            _loadingText = _loadingCanvas.GetComponentInChildren<Text>();
            //_loadindBar = _loadingCanvas.GetComponentsInChildren<Image>().FirstOrDefault(image => image.name == "Whiter Image");

            Image[] images = new Image[_loadingCanvas.GetComponentsInChildren<Image>().Length];
            images = _loadingCanvas.GetComponentsInChildren<Image>();
            foreach (var image in images)
            {
                if (image.name == "Whiter Image")
                {
                    _loadindBar = image;
                }
            }

            var scene = SceneManager.LoadSceneAsync("LoadingScene");
            _loadingCanvas.SetActive(true);
            scene.completed += scene =>
            {
                GameObject.Instantiate(_loadingCanvas);
                _loadingCanvas.SetActive(true);
                _loadindBar.fillAmount = 0;
            };

            await Task.Delay(1);
        }
    }

    public void SetProgressBarValue(System.Object caller, float value)
    {
        if (_loadindBar != null && value >=0 && value <= 1 && caller is IGameState)
        {
            _loadindBar.fillAmount = value;
        }
    }

    public void SetStateText(System.Object caller, string state)
    {
        if (_loadingText != null && caller is IGameState)
        {
            _loadingText.text = state;
            Debug.Log("state: " + state + " progress: " + _loadindBar.fillAmount * 100.0f + "%." );
        }
    }
}