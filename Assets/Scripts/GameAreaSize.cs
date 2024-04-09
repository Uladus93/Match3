using UnityEditor;
using UnityEngine;

public class GameAreaSize : MonoBehaviour
{
    private GameObject _parentCanvas;
    private void Awake()
    {
        _parentCanvas = gameObject.transform.parent.gameObject;
    }
    void Start()
    {
        SetGameAreaSize();
    }

    private void Update()
    {
        SetGameAreaSize();
    }

    public void SetGameAreaSize()
    {
        float targetaspect = 18.0f / 11.0f;
        float windowaspect = (float)Screen.width / (float)Screen.height;
        float scaleheight = windowaspect / targetaspect;
        if (scaleheight < 1.0f)
        {
            float scale = _parentCanvas.GetComponent<RectTransform>().rect.width / (gameObject.GetComponent<RectTransform>().rect.width * gameObject.GetComponent<RectTransform>().localScale.x);
            gameObject.GetComponent<RectTransform>().localScale *= scale;
        }
        else
        {
            float scale = _parentCanvas.GetComponent<RectTransform>().rect.height / (gameObject.GetComponent<RectTransform>().rect.height * gameObject.GetComponent<RectTransform>().localScale.y);
            gameObject.GetComponent<RectTransform>().localScale *= scale;
        }
    }
}