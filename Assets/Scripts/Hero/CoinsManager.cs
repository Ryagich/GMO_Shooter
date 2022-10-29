using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsManager : MonoBehaviour
{
    [SerializeField] private Text _coinsCount;

    [SerializeField] [Min(0)] private int coins = 0;

    public void AddCoins(int value)
    {
        coins += value;
        UpdateCoinsCount();
    }

    public void WriteCoins()
    {
        //Data.CurrentCash += coins;
    }

    private void UpdateCoinsCount()
    {
        _coinsCount.text = coins.ToString();
    }
}
