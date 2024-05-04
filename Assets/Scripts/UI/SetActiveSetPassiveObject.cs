using UnityEngine;
using UnityEngine.UI;

public class SetActiveSetPassiveObject : MonoBehaviour
{
    [SerializeField] private GameObject _object;
    private bool _enabled;

    private void Start()
    {
        _enabled = false;
        gameObject.GetComponent<Button>().onClick.AddListener(() => OpenCloseObject());
    }
    public void OpenCloseObject()
    {
        if (!_enabled)
        {
            _enabled = true;
            _object.SetActive(_enabled);
        }
        else if (_enabled)
        {
            _enabled = false;
            _object.SetActive(_enabled);
        }
    }
}
