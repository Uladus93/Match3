using System.Runtime.InteropServices;
using UnityEngine;

public class Language : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern string GetLanguage();

    private string _currentLanguage;
    [SerializeField] private InternationalText _interText;

    private void Awake()
    {
        _currentLanguage = GetLanguage();
    }

    private void Start()
    {
        _interText.SetLanguage(_currentLanguage);
    }
}