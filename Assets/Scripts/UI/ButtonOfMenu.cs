using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ButtonOfMenu : MonoBehaviour
{
    [SerializeField] private GameObject _menu;
    [SerializeField] private GameInterpretator _interpretator;
    private bool _enabled;

    private void Start()
    {
        _enabled = false;
        gameObject.GetComponent<Button>().onClick.AddListener(() => StartCoroutine(ActivateMenu()));
    }

    private IEnumerator ActivateMenu()
    {
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
    }

    public void ShowCloseMenu()
    {
        StartCoroutine(ActivateMenu());
    }
}