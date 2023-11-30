using UnityEngine;

public class Match3SceneManager
{
    private Field _gameFeld;
    public Field GameField { get { return _gameFeld; } private set{} }
    public void Initialize()
    {
        _gameFeld = new Field(5, 7);
        _gameFeld.FillField();
    }
}