using UnityEngine;
using UnityEngine.UI;

public class ComplexPaysButton : MonoBehaviour
{
    [SerializeField] private GameObject _market;

    private void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(() => AddComplex());
    }

    public void AddComplex()
    {
        _market.GetComponent<Market>().PlayerSessionData.RecountWater(17);
        _market.GetComponent<Market>().PlayerSessionData.RecountRockets(17);
        _market.GetComponent<Market>().PlayerSessionData.RecountBaits(17);
    }
}