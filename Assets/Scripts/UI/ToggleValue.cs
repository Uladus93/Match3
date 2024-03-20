using System.Net;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ToggleValue : MonoBehaviour
{
    [SerializeField] private GameObject _soundOnImage;
    [SerializeField] private GameObject _soundOffImage;
    void Start()
    {
        gameObject.GetComponent<Toggle>().onValueChanged.AddListener(_toggleValue => ChangeSoundToggleValue());
    }

    public void ChangeSoundToggleValue()
    {
        if (gameObject.GetComponent<Toggle>().isOn == true)
        {
            _soundOffImage.SetActive(false);
            _soundOnImage.SetActive(true);
            return;
        }
        else
        {
            _soundOffImage.SetActive(true);
            _soundOnImage.SetActive(false);
            return;
        }
    }
}
