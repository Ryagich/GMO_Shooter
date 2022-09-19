using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Updater : MonoBehaviour, ISerializationCallbackReceiver
{
    [SerializeField] protected IUpdate[] _updates;
    [SerializeField] private Image[] _indicators;
    [SerializeField] private Button _buyButton;
    [SerializeField] private Image _signal;
    [SerializeField] private CashManager _cashManager;

    protected int index;

    private void Start()
    {
        GetLastOpenIndex();
        UpdateInterface();
    }

    protected void SetUpdates(IUpdate[] updates)
    {
        _updates = updates;
    }

    public void Buy()
    {
        index++;
        _updates[index].IsOpen = true;
        _cashManager.SubtractMoney(_updates[index].Cost);
        UpdateInterface();
    }

    private void GetLastOpenIndex()
    {
        for (int i = _updates.Length - 1; i > 0; i--)
            if (_updates[i].IsOpen)
            {
                index = i;
                return;
            }
    }

    private void UpdateInterface()
    {
        UpdateIndicators();
        UpdateBuyButton();
        UpdateSignal();
    }

    private void UpdateBuyButton() => _buyButton.gameObject.SetActive(CanBuy());

    private void UpdateSignal() => _signal.gameObject.SetActive(CanBuy());

    private bool CanBuy() =>
            _updates.Length > index + 1 &&
            _updates[index + 1].Cost <= Data.CurrentCash;

    private void UpdateIndicators()
    {
        for (int i = 0; i < _indicators.Length; i++)
            if (_updates[i].IsOpen)
                _indicators[i].color = Color.green;
            else
                _indicators[i].color = Color.black;
    }

    protected virtual IUpdate[] GetUpdates() => null;

    public void OnBeforeSerialize() { }

    public void OnAfterDeserialize()
    {
        _updates = GetUpdates();
    }
}
