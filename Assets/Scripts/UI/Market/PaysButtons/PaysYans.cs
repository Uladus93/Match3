using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class PaysYans : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void WaterYans(int points);

    [DllImport("__Internal")]
    private static extern void RocketsYans(int points);

    [DllImport("__Internal")]
    private static extern void BaitsYans(int points);

    [DllImport("__Internal")]
    private static extern void MultiplyYans(int points);


    public delegate void AddSomeBonuses(int points);
    public AddSomeBonuses _addSomeBonuses;
    private int _cost;

    public int Cost { get { return _cost; } private set { } }

    private void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(() => AddBonuses());
    }

    public void AddBonuses()
    {
        if (_cost == 17)
        {
            WaterYans(_cost);
        }
        else if (_cost == 15)
        {
            RocketsYans(_cost);
        }
        else if (_cost == 10)
        {
            BaitsYans(_cost);
        }
        else if (_cost == 200)
        {
            Debug.Log("Multi");
            MultiplyYans(_cost);
        }
    }

    public void SetCost(int points)
    {
        if (points > 0 && points < 1001)
        {
            _cost = points;
        }
    }
}