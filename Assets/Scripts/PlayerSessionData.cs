using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerSessionData
{
    private int _aquaScore;
    private int _scoreScore;
    private int _baitsScore;
    private GameObject _aqua;
    private GameObject _score;
    private GameObject _baits;

    public TextMeshProUGUI AquaText { get { return _aqua.GetComponent<TextMeshProUGUI>(); } set { } }
    public TextMeshProUGUI ScoreText { get { return _score.GetComponent<TextMeshProUGUI>(); } set { } }
    public TextMeshProUGUI BaitsText { get { return _baits.GetComponent<TextMeshProUGUI>(); } set { } }
    public int AquaScore { get { return _aquaScore; } private set { } }
    public int BaitsScore { get { return _baitsScore; } private set { } }

    public PlayerSessionData(GameObject aqua, GameObject score, GameObject baits)
    {
        _aqua = aqua;
        _score = score;
        _baits = baits;
        _aquaScore = 300;
        _scoreScore = 0;
        _baitsScore = 100;
        _aqua.GetComponent<TextMeshProUGUI>().text = $"Aqua: {_aquaScore}";
        _score.GetComponent<TextMeshProUGUI>().text = $"Money: {_scoreScore}";
        _baits.GetComponent<TextMeshProUGUI>().text = $"Baits: {_baitsScore}";
    }

    public void RecountAqua(int points)
    {
        _aquaScore += points;
        _aqua.GetComponent<TextMeshProUGUI>().text = $"Aqua: {_aquaScore}";
    }

    public void RecountScore(int points)
    {
        _scoreScore += points;
        _score.GetComponent<TextMeshProUGUI>().text = $"Money: {_scoreScore}";
    }

    public void RecountBaits(int points)
    {
        _baitsScore += points;
        _baits.GetComponent<TextMeshProUGUI>().text = $"Baits: {_baitsScore}";
    }
}
