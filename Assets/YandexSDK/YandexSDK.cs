using UnityEngine;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Networking;

public class YandexSDK : MonoBehaviour
{
    //[DllImport("__Internal")]
    //private static extern void SetPlayerData();

    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] private RawImage _avatarImage;

    //public void TEST()
    //{
    //    SetPlayerData();
    //}

    public void SetName(string name)
    {
        _nameText.text = name;
    }

    public void SetAvatar(string url)
    {
        StartCoroutine(DownloadAvatar(url));
    }

    IEnumerator DownloadAvatar(string avatarURL)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(avatarURL);
        yield return request.SendWebRequest();
        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.Log(request.error);
        }
        else
        {
            _avatarImage.texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
        }  
        
    }
}