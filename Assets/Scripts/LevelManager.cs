using UnityEngine;
using UnityEngine.Events;

public class LevelManager : MonoBehaviour
{
    public static LevelManager main;

    public Transform startPoint;
    public Transform[] path;

    public int currency;
    private void Awake()
    {
        main = this;
    }
    public void Start()
    {
        currency = 100;
    }
    public void IncreaseCurrency(int amount)
    {
        currency += amount;
    }
    public bool SpendCurrency(int amount)
    {
        if(amount <= currency)
        {
            //Buy
            currency -= amount;
            return true;
        }
        else
        {
            Debug.Log("Get ur moneh up not ur funny up.");
            return false;
        }
    }
}
