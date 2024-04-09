using TMPro;
using UnityEngine;

public class InternationalText : MonoBehaviour
{

    public void SetLanguage(string lang)
    {
        if (lang == "be")
        {
            string text = Resources.Load<TextAsset>("Texts/Be_Rules").text;
            GetComponent<TextMeshProUGUI>().text = text;
        }
        else if (lang == "en")
        {
            string text = Resources.Load<TextAsset>("Texts/En_Rules").text;
            GetComponent<TextMeshProUGUI>().text = text;
        }
        else if (lang == "ru")
        {
            string text = Resources.Load<TextAsset>("Texts/Ru_Rules").text;
            GetComponent<TextMeshProUGUI>().text = text;
        }
        else if (lang == "tr")
        {
            string text = Resources.Load<TextAsset>("Texts/Tr_Rules").text;
            GetComponent<TextMeshProUGUI>().text = text;
        }
        else
        {
            string text = Resources.Load<TextAsset>("Texts/En_Rules").text;
            GetComponent<TextMeshProUGUI>().text = text;
        }
    }
}
