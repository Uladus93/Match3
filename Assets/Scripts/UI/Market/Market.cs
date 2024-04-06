using UnityEngine;
using UnityEngine.UI;

public class Market : MonoBehaviour
{
    private GameObject _marketWindow;
    private GameInterpretator _interpretator;
    private PlayerSessionData _playerSessionData;
    private bool _enabled;
    [SerializeField] private PaysReclam _waterForReclam;
    [SerializeField] private PaysReclam _rocketForReclam;
    [SerializeField] private PaysReclam _baitForReclam;
    [SerializeField] private PaysYans _waterForYans;
    [SerializeField] private PaysYans _rocketForYans;
    [SerializeField] private PaysYans _baitForYans;
    [SerializeField] private PaysYans _multiBonusesForYans;

    public PlayerSessionData PlayerSessionData { get { return _playerSessionData; } private set { } }

    public void SetMarketData(GameInterpretator interpretator, PlayerSessionData playerSessionData)
    {
        _enabled = false;
        _marketWindow = transform.GetChild(0).gameObject;
        _interpretator = interpretator;
        _playerSessionData = playerSessionData;
        gameObject.GetComponent<Button>().onClick.AddListener(() => OpenCloseMarket());
        _waterForReclam.SetCost(3);
        _waterForReclam._addSomeBonuses = new PaysReclam.AddSomeBonuses(_playerSessionData.RecountWater);
        _rocketForReclam.SetCost(2);
        _rocketForReclam._addSomeBonuses = new PaysReclam.AddSomeBonuses(_playerSessionData.RecountRockets);
        _baitForReclam.SetCost(1);
        _baitForReclam._addSomeBonuses = new PaysReclam.AddSomeBonuses(_playerSessionData.RecountBaits);
        _waterForYans.SetCost(17);
        _waterForYans._addSomeBonuses = new PaysYans.AddSomeBonuses(_playerSessionData.RecountWater);
        _rocketForYans.SetCost(15);
        _rocketForYans._addSomeBonuses = new PaysYans.AddSomeBonuses(_playerSessionData.RecountRockets);
        _baitForYans.SetCost(10);
        _baitForYans._addSomeBonuses = new PaysYans.AddSomeBonuses(_playerSessionData.RecountBaits);
        _multiBonusesForYans.SetCost(200);
        _multiBonusesForYans._addSomeBonuses = new PaysYans.AddSomeBonuses(_playerSessionData.RecountWater);
        _multiBonusesForYans._addSomeBonuses += _playerSessionData.RecountRockets;
        _multiBonusesForYans._addSomeBonuses += _playerSessionData.RecountBaits;
    }
    public void OpenCloseMarket()
    {
        if (!_enabled)
        {
            _enabled = true;
            _marketWindow.SetActive(_enabled);
            _interpretator.ChangePauseValue(1);
        }
        else if (_enabled)
        {
            _enabled = false;
            _marketWindow.SetActive(_enabled);
            _interpretator.ChangePauseValue(-1);
        }
    }

    public void PlusSomeBonusesForReclam(int points)
    {
        if (points == _waterForReclam.Cost) 
        {
            _waterForReclam._addSomeBonuses(_waterForReclam.Cost);
        }
        else if (points == _rocketForReclam.Cost)
        {
            _rocketForReclam._addSomeBonuses(_rocketForReclam.Cost);
        }
        else if (points == _baitForReclam.Cost)
        {
            _baitForReclam._addSomeBonuses(_baitForReclam.Cost);
        }
    }

    public void PlusSomeBonusesForYans(int points)
    {
        if (points == _waterForYans.Cost)
        {
            _waterForYans._addSomeBonuses(_waterForYans.Cost);
        }
        else if (points == _rocketForYans.Cost)
        {
            _rocketForYans._addSomeBonuses(_rocketForYans.Cost);
        }
        else if (points == _baitForYans.Cost)
        {
            _baitForYans._addSomeBonuses(_baitForYans.Cost);
        }
        else if (points == _multiBonusesForYans.Cost)
        {
            _multiBonusesForYans._addSomeBonuses(_multiBonusesForYans.Cost);
        }
    }
}