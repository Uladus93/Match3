using UnityEngine;
using UnityEngine.UI;

public class WaterYans : MonoBehaviour
{
    [SerializeField] private GameObject _market;

    private void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(() => AddWater());
    }

    public void AddWater()
    {
        _market.GetComponent<Market>().PlayerSessionData.RecountWater(3);
    }
}
