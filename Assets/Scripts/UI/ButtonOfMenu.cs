using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ButtonOfMenu : MonoBehaviour
{
    [SerializeField] private GameObject _menu;
    [SerializeField] private GameInterpretator _interpretator;
    [SerializeField] private GameObject _playerData;
    private bool _enabled;

    private void Start()
    {
        _enabled = false;
        gameObject.GetComponent<Button>().onClick.AddListener(() => StartCoroutine(ActivateMenu()));
        _playerData.transform.position = new Vector3(gameObject.transform.position.x, 538.37f, 0f);
    }

    private IEnumerator ActivateMenu()
    {
        const float time = 1f;
        float timer = time;
        float timeinterval = Time.fixedDeltaTime;
        float angle = 90 / (time / timeinterval);
        Vector3 startPosition = new Vector3(gameObject.transform.position.x, 538.37f, 0f);
        Vector3 finishPosition = new Vector3(gameObject.transform.position.x + _menu.GetComponent<RectTransform>().sizeDelta.x * _menu.GetComponentInParent<RectTransform>().lossyScale.x, 538.37f, 0f);

        if (!_enabled)
        {
            _enabled = true;
            _menu.SetActive(_enabled);
            while (timer > 0 && gameObject.transform.rotation.z < 90)
            {
                gameObject.transform.Rotate(Vector3.forward, angle);
                _playerData.transform.position = Vector3.Lerp(startPosition, finishPosition, (time - timer)/ time);
                timer -= Time.fixedDeltaTime;
                yield return null;
            }
            _playerData.transform.position = finishPosition;
            gameObject.transform.rotation = new Quaternion(0, 0, -90, -90);
            _interpretator.ChangePauseValue(1);
        }
        else
        {
            while (timer > 0)
            {
                gameObject.transform.Rotate(Vector3.forward, -angle);
                _playerData.transform.position = Vector3.Lerp(finishPosition, startPosition, (time - timer) / time);
                timer -= Time.fixedDeltaTime;
                yield return null;
            }
            _playerData.transform.position = startPosition;
            _enabled = false;
            _menu.SetActive(_enabled);
            _interpretator.ChangePauseValue(-1);
        }
    }

    public void ShowCloseMenu()
    {
        StartCoroutine(ActivateMenu());
    }
}