using TMPro;
using UnityEngine;

public class PlayerSessionData
{
    private int _aquaScore;
    private int _spiceScore;
    private int _baitsScore;
    private int _rocketsScore;
    private GameObject _aqua;
    private GameObject _score;
    private GameObject _baits;
    private GameObject _rockets;
    private PlayerScore _playerScore;
    private GameObject _playerData;

    public TextMeshProUGUI AquaText { get { return _aqua.GetComponent<TextMeshProUGUI>(); } set { } }
    public TextMeshProUGUI ScoreText { get { return _score.GetComponent<TextMeshProUGUI>(); } set { } }
    public TextMeshProUGUI BaitsText { get { return _baits.GetComponent<TextMeshProUGUI>(); } set { } }
    public TextMeshProUGUI Rockets { get { return _baits.GetComponent<TextMeshProUGUI>(); } set { } }
    public int AquaScore { get { return _aquaScore; } private set { } }
    public int SpiceScore { get { return _spiceScore; } private set { } }
    public int BaitsScore { get { return _baitsScore; } private set { } }
    public int RocketsScore { get { return _rocketsScore; } private set { } }

    public PlayerScore PlayerScore { get { return _playerScore; } private set { } }
    public PlayerSessionData(GameObject playerData, GameObject aqua, GameObject score, GameObject baits, GameObject rocket, PlayerScore playerScore)
    {
        _playerData = playerData;
        _aqua = aqua;
        _score = score;
        _baits = baits;
        _rockets = rocket;
        _playerScore = playerScore;
        playerData.SetActive(false);
    }

    public void RecountWater(int points)
    {
        _aquaScore += points;
        _aqua.GetComponent<TextMeshProUGUI>().text = $"{_aquaScore}";
    }

    public void RecountScore(int points)
    {
        _spiceScore += points;
        _score.GetComponent<TextMeshProUGUI>().text = $"{_spiceScore}";
    }

    public void RecountBaits(int points)
    {
        _baitsScore += points;
        _baits.GetComponent<TextMeshProUGUI>().text = $"{_baitsScore}";
    }

    public void RecountRockets(int points)
    {
        _rocketsScore += points;
        _rockets.GetComponent<TextMeshProUGUI>().text = $"{_rocketsScore}";
    }

    public void RefreshData()
    {
        _aquaScore = 10;
        _spiceScore = 0;
        _baitsScore = 10;
        _rocketsScore = 15;
        _aqua.GetComponent<TextMeshProUGUI>().text = $"{_aquaScore}";
        _score.GetComponent<TextMeshProUGUI>().text = $"{_spiceScore}";
        _baits.GetComponent<TextMeshProUGUI>().text = $"{_baitsScore}";
        _rockets.GetComponent<TextMeshProUGUI>().text = $"{_rocketsScore}";
        _playerData.SetActive(true);
    }

    public void LoadData()
    {
        _aquaScore = _playerScore.PlayerJSONScore._aquaScore;
        _spiceScore = _playerScore.PlayerJSONScore._spiceScore;
        _baitsScore = _playerScore.PlayerJSONScore._baitsScore;
        _rocketsScore = _playerScore.PlayerJSONScore._rocketsScore;
        _aqua.GetComponent<TextMeshProUGUI>().text = $"{_aquaScore}";
        _score.GetComponent<TextMeshProUGUI>().text = $"{_spiceScore}";
        _baits.GetComponent<TextMeshProUGUI>().text = $"{_baitsScore}";
        _rockets.GetComponent<TextMeshProUGUI>().text = $"{_rocketsScore}";
        _playerData.SetActive(true);
    }
}