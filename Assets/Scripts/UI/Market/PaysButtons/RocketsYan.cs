using UnityEngine;
using UnityEngine.UI;

public class RocketsYan : MonoBehaviour
{
    [SerializeField] private GameObject _market;

    private void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(() => AddRockets());
    }

    public void AddRockets()
    {
        _market.GetComponent<Market>().PlayerSessionData.RecountRockets(2);
    }
}
