using TMPro;
using UnityEngine;

public class LoadingStateText : MonoBehaviour
{
    private static TextMeshProUGUI _textOfLoading;

    private void Awake()
    {
        _textOfLoading = GetComponent<TextMeshProUGUI>();
    }
    public static void SetLoadingText(System.Object caller, string sceneName)
    {
        if (caller is IGameState)
        {
            _textOfLoading.text = $"Loading {sceneName}.";
        }
    }
}