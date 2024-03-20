using UnityEngine;
using UnityEngine.UI;

public class BaitReclam : MonoBehaviour
{
    [SerializeField] private GameObject _market;

    private void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(() => AddBait());
    }

    public void AddBait()
    {
        _market.GetComponent<Market>().PlayerSessionData.RecountBaits(1);
    }
}