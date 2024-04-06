using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class PaysReclam : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void PlayReclam(int points);


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
        PlayReclam(_cost);
    }

    public void SetCost(int points)
    {
        if (points > 0 && points < 1001)
        {
            _cost = points;
        }
    }
}