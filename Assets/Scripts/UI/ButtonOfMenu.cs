using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class ButtonOfMenu : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void RateTheGame();

    [SerializeField] private GameObject _menu;
    [SerializeField] private GameObject _estimationButton;
    private GameInterpretator _interpretator;
    private bool _enabled;
    private bool _stay;

    public GameObject EstimationButton { get { return _estimationButton; } private set { } }

    private void Start()
    {
        _enabled = false;
        _stay = true;
        gameObject.GetComponent<Button>().onClick.AddListener(() => StartCoroutine(ActivateMenu()));
        _estimationButton.GetComponent<Button>().onClick.AddListener(() => RateGameButton());
    }

    private IEnumerator ActivateMenu()
    {
        if (_stay)
        {
            _stay = false;
            const float time = 1f;
            float timer = time;
            float timeinterval = Time.fixedDeltaTime;
            float angle = -90 / (time / timeinterval);

            if (!_enabled)
            {
                _enabled = true;
                _menu.SetActive(_enabled);
                while (timer > 0 && gameObject.transform.rotation.z > -90)
                {
                    gameObject.transform.Rotate(Vector3.forward, angle);
                    timer -= Time.fixedDeltaTime;
                    yield return null;
                }
                gameObject.transform.rotation = new Quaternion(0, 0, -90, 90);
                _interpretator.ChangePauseValue(1);
            }
            else
            {
                while (timer > 0)
                {
                    gameObject.transform.Rotate(Vector3.forward, -angle);
                    timer -= Time.fixedDeltaTime;
                    yield return null;
                }
                _enabled = false;
                _menu.SetActive(_enabled);
                _interpretator.ChangePauseValue(-1);
            }

            _stay = true;
        }
    }

    public void ShowCloseMenu()
    {
        StartCoroutine(ActivateMenu());
    }

    public void SetInterpretator(GameInterpretator gameInterpretator)
    {
        _interpretator = gameInterpretator;
    }

    public void RateGameButton()
    {
        RateTheGame();
    }
}