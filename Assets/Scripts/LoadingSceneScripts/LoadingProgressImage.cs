using UnityEngine;
using UnityEngine.UI;

public class LoadingProgressImage : MonoBehaviour
{
    private static Image _loadingImage;

    private void Awake()
    {
        _loadingImage = GetComponent<Image>();
    }

    /// <summary>
    /// percent from 0 to 1.
    /// </summary>
    /// <param name="caller"></param>
    /// <param name="percent"></param>

    public static void SetFillOfImage(System.Object caller, float percent)
    {
        if (caller is IGameState && percent >= 0 && percent <= 1)
        {
            _loadingImage.fillAmount = percent;
        }
    }
}