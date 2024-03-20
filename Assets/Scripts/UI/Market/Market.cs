using UnityEngine;
using UnityEngine.UI;

public class Market : MonoBehaviour
{
    private GameObject _market;
    private GameInterpretator _interpretator;
    private PlayerSessionData _playerSessionData;
    private bool _enabled;

    public PlayerSessionData PlayerSessionData { get { return _playerSessionData; } private set { } }

    public void SetMarketData(GameInterpretator interpretator, PlayerSessionData playerSessionData)
    {
        _market = transform.GetChild(0).gameObject;
        _interpretator = interpretator;
        _playerSessionData = playerSessionData;
        gameObject.GetComponent<Button>().onClick.AddListener(() => OpenCloseMarket());
    }
    public void OpenCloseMarket()
    {
        if (!_enabled)
        {
            _enabled = true;
            _market.SetActive(_enabled);
            _interpretator.ChangePauseValue(1);
        }
        else if (_enabled)
        {
            _enabled = false;
            _market.SetActive(_enabled);
            _interpretator.ChangePauseValue(-1);
        }
    }

    public void AddWaterForYans()
    {
        _playerSessionData.RecountWater(3);
    }

    public void AddBaitsForYans()
    {
        _playerSessionData.RecountBaits(1);
    }

    public void AddRocketsForYans()
    {
        _playerSessionData.RecountRockets(2);
    }

    public void AddWaterForReclam()
    {
        _playerSessionData.RecountWater(3);
    }

    public void AddBaitsForReclam()
    {
        _playerSessionData.RecountBaits(1);
    }

    public void AddRocketsForReclam()
    {
        _playerSessionData.RecountRockets(2);
    }
}