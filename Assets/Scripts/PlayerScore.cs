using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void SavePlayerScore(string score);

    [DllImport("__Internal")]
    private static extern void LoadPlayerData();

    [DllImport("__Internal")]
    private static extern void SetToLeaderboard(int spiceScore);

    [DllImport("__Internal")]
    public static extern void CheckPurchase();

    private PlayerJSONScore _playerScore;
    private Field _field;
    private PlayerSessionData _sessionData;
    public PlayerJSONScore PlayerJSONScore { get { return _playerScore; } private set { } }

    private void Awake()
    {
        _playerScore = new PlayerJSONScore();
    }
    public void SaveToJson()
    {
        _playerScore._aquaScore = _sessionData.AquaScore;
        _playerScore._spiceScore = _sessionData.SpiceScore;
        _playerScore._rocketsScore = _sessionData.RocketsScore;
        _playerScore._baitsScore = _sessionData.BaitsScore;
        _playerScore._tiles = criptoTiles();
        string jsonString = JsonUtility.ToJson(_playerScore);
        SavePlayerScore(jsonString);
        SetToLeaderboard(_sessionData.SpiceScore);
        string[] criptoTiles()
        {
            List<string> tiles = new List<string>();
            for (byte i = 0; i < _field.RowCount; i++)
            {
                for (byte j = 0; j < _field.ColumnCount; j++)
                {
                    List<char> criptFieldElement = new List<char>();
                    char tileType;
                    char fieldObjectType;
                    if (_field.Tiles[j, i].TileType == TilesState.open)
                    {
                        tileType = 'p';
                        criptFieldElement.Add(tileType);
                    }
                    else if (_field.Tiles[j, i].TileType == TilesState.closed)
                    {
                        tileType = 'c';
                        criptFieldElement.Add(tileType);
                    }
                    if (_field.Tiles[j, i].ElementOfField.ElementType == TypesOfFieldElements.Token)
                    {
                        Token token = _field.Tiles[j, i].ElementOfField as Token;
                        switch (token.TokenType)
                        {
                            case TokenType.sand:
                                fieldObjectType = 'd';
                                criptFieldElement.Add(fieldObjectType);
                                break;
                            case TokenType.spice:
                                fieldObjectType = 'i';
                                criptFieldElement.Add(fieldObjectType);
                                break;
                            default:
                                break;
                        }
                    }
                    else if (_field.Tiles[j, i].ElementOfField.ElementType == TypesOfFieldElements.Bonus)
                    {
                        Bonus bonus = _field.Tiles[j, i].ElementOfField as Bonus;
                        switch (bonus.BonusType)
                        {
                            case BonusType.bait:
                                fieldObjectType = 'b';
                                criptFieldElement.Add(fieldObjectType);
                                break;
                            case BonusType.water:
                                fieldObjectType = 'w';
                                criptFieldElement.Add(fieldObjectType);
                                break;
                            case BonusType.rocket:
                                fieldObjectType = 'r';
                                criptFieldElement.Add(fieldObjectType);
                                break;
                            default:
                                break;
                        }
                    }
                    else if (_field.Tiles[j, i].ElementOfField.ElementType == TypesOfFieldElements.Enemy)
                    {
                        Enemy enemy = _field.Tiles[j, i].ElementOfField as Enemy;
                        switch (enemy.EnemyType)
                        {
                            case EnemyType.solders:
                                fieldObjectType = 'h';
                                criptFieldElement.Add(fieldObjectType);
                                if (enemy.Lives == 3)
                                {
                                    criptFieldElement.Add('z');
                                }
                                else if (enemy.Lives == 2)
                                {
                                    criptFieldElement.Add('y');
                                }
                                else if (enemy.Lives == 1)
                                {
                                    criptFieldElement.Add('x');
                                }
                                if (enemy.OccupationTime == 1)
                                {
                                    criptFieldElement.Add('k');
                                }
                                else if (enemy.OccupationTime == 2)
                                {
                                    criptFieldElement.Add('l');
                                }
                                else if (enemy.OccupationTime == 3)
                                {
                                    criptFieldElement.Add('m');
                                }
                                else if (enemy.OccupationTime == 4)
                                {
                                    criptFieldElement.Add('n');
                                }
                                else if (enemy.OccupationTime == 5)
                                {
                                    criptFieldElement.Add('o');
                                }
                                break;
                            case EnemyType.worm:
                                fieldObjectType = 'a';
                                criptFieldElement.Add(fieldObjectType);
                                break;
                            default:
                                break;
                        }
                    }
                    tiles.Add(new string(criptFieldElement.ToArray()));
                }
            }
            return tiles.ToArray();
        }
    }

    public void LoadGame()
    {
        LoadPlayerData();
    }

    public void LoadFromJson(string score)
    {
        _playerScore = JsonUtility.FromJson<PlayerJSONScore>(score);
        if (_playerScore._spiceScore != 0 || _playerScore._aquaScore != 0 || _playerScore._rocketsScore != 0 || _playerScore._baitsScore != 0)
        {
            _sessionData.LoadData();
        }
        else
        {
            _sessionData.RefreshData();
        }

        if (_playerScore._tiles != null)
        {
            _field.LoadFieldFromJSON(_playerScore._tiles);
        }
        else
        {
            _field.FieldObjectGenerator.CreateAllNewField(_field.Tiles);
        }
    }

    public void SetDataForJSON(Field field, PlayerSessionData playerSessionData)
    {
        _field = field;
        _sessionData = playerSessionData;
    }

    public void CreateNewGame()
    {
        _sessionData.RefreshData();
        _field.FieldObjectGenerator.CreateAllNewField(_field.Tiles);
    }

}

[System.Serializable]
public class PlayerJSONScore
{
    public int _aquaScore;
    public int _spiceScore;
    public int _baitsScore;
    public int _rocketsScore;
    public string[] _tiles;
}