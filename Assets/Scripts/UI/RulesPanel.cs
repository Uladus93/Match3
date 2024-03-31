using UnityEngine;
using UnityEngine.UI;

public class RulesPanel : MonoBehaviour
{
    [SerializeField] private GameObject _rulesPanel;
    private bool _enabled;

    private void Start()
    {
        _enabled = false;
        gameObject.GetComponent<Button>().onClick.AddListener(() => OpenCloseRulesPanel());
    }
    public void OpenCloseRulesPanel()
    {
        if (!_enabled)
        {
            _enabled = true;
            _rulesPanel.SetActive(_enabled);
        }
        else if (_enabled)
        {
            _enabled = false;
            _rulesPanel.SetActive(_enabled);
        }
    }
}
