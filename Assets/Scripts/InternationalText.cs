using TMPro;
using UnityEngine;

public class InternationalText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _rulesText;


    public void SetLanguage(string lang)
    {
        if (lang == "be")
        {
            string rulesText = Resources.Load<TextAsset>("Texts/Be_Rules").text;
            _rulesText.text = rulesText;
        }
        else if (lang == "en")
        {
            string text = Resources.Load<TextAsset>("Texts/En_Rules").text;
            _rulesText.text = text;
        }
        else if (lang == "ru")
        {
            string text = Resources.Load<TextAsset>("Texts/Ru_Rules").text;
            _rulesText.text = text;
        }
        else if (lang == "tr")
        {
            string text = Resources.Load<TextAsset>("Texts/Tr_Rules").text;
            _rulesText.text = text;
        }
        else
        {
            string text = Resources.Load<TextAsset>("Texts/En_Rules").text;
            _rulesText.text = text;
        }
    }
}