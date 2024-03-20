using TMPro;
using UnityEngine;

public class PlayerSessionData
{
    private int _aquaScore;
    private int _scoreScore;
    private int _baitsScore;
    private int _rocketsScore;
    private GameObject _aqua;
    private GameObject _score;
    private GameObject _baits;
    private GameObject _rockets;

    public TextMeshProUGUI AquaText { get { return _aqua.GetComponent<TextMeshProUGUI>(); } set { } }
    public TextMeshProUGUI ScoreText { get { return _score.GetComponent<TextMeshProUGUI>(); } set { } }
    public TextMeshProUGUI BaitsText { get { return _baits.GetComponent<TextMeshProUGUI>(); } set { } }
    public int AquaScore { get { return _aquaScore; } private set { } }
    public int BaitsScore { get { return _baitsScore; } private set { } }
    public int RocketsScore { get { return _rocketsScore; } private set { } }

    public PlayerSessionData(GameObject aqua, GameObject score, GameObject baits, GameObject rocket)
    {
        _aqua = aqua;
        _score = score;
        _baits = baits;
        _rockets = rocket;
    }

    public void RecountWater(int points)
    {
        _aquaScore += points;
        _aqua.GetComponent<TextMeshProUGUI>().text = $"{_aquaScore}";
    }

    public void RecountScore(int points)
    {
        _scoreScore += points;
        _score.GetComponent<TextMeshProUGUI>().text = $"{_scoreScore}";
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
        _scoreScore = 0;
        _baitsScore = 10;
        _rocketsScore = 10;
        _aqua.GetComponent<TextMeshProUGUI>().text = $"{_aquaScore}";
        _score.GetComponent<TextMeshProUGUI>().text = $"{_scoreScore}";
        _baits.GetComponent<TextMeshProUGUI>().text = $"{_baitsScore}";
        _rockets.GetComponent<TextMeshProUGUI>().text = $"{_rocketsScore}";
    }
}
