using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CashManager : MonoBehaviour
{
    public readonly UnityEvent<int> OnCashCountUpdated = new UnityEvent<int>();

    [SerializeField] private Text _cashText;

    private void Awake()
    {
        UpdateMoney();
    }

    private void UpdateMoney()
    {
        _cashText.text = "Cash: " + Data.CurrentCash.ToString();
    }

    public void SubtractMoney(int value)
    {
        Data.CurrentCash -= value;
        UpdateMoney();
    }
}
