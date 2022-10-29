using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class WeaponsManager : MonoBehaviour
{
    public WeaponInfo[] WeaponTypes;
    [SerializeField] private Outline[] _indicators;
    [SerializeField] private Image _currentImage;
    [SerializeField] private Image _signalImage;
    [SerializeField] private Button _buyButton;
    [SerializeField] private CashManager _cashManager;
    [SerializeField] private Image _speedBar;
    [SerializeField] private Image _damageBar;
    [SerializeField] private MaximumTakerFromWeapons _maximumTaker;

    private Data data;
    private float maxWeaponAttackSpeed;
    private float maxWeaponDamage;
    private int lastOpenIndex;
    private int selectedIndex;

    private void Awake()
    {
        maxWeaponAttackSpeed = _maximumTaker.GetMaxSpeed();
        maxWeaponDamage = _maximumTaker.GetMaxDamage();
        lastOpenIndex = GetLastOpen();
        selectedIndex = lastOpenIndex;
        data = PlayerPrefsWrapper.LoadPrefs();

        UpdateInterface();
    }

    public void SelectPrevious()
    {
        if (selectedIndex - 1 < 0)
            return;
        selectedIndex--;
        UpdateInterface();
    }

    public void SelectNext()
    {
        if (selectedIndex == WeaponTypes.Length - 1)
            return;
        selectedIndex++;
        UpdateInterface();
    }

    public void Buy()
    {
        lastOpenIndex++;
        selectedIndex = lastOpenIndex;
        WeaponTypes[lastOpenIndex].IsOpen = true;
        _cashManager.SubtractMoney(WeaponTypes[lastOpenIndex].Cost);

        UpdateInterface();
    }

    private void UpdateInterface()
    {
        UpdateSprite();
        UpdateIndicators();
        UpdateBuyButton();
        UpdateSignalImage();
        UpdateBars();
    }

    private void UpdateBars()
    {
        _speedBar.fillAmount = WeaponTypes[selectedIndex].Weapon.AttackCooldown / maxWeaponAttackSpeed;
        _damageBar.fillAmount = WeaponTypes[selectedIndex].Weapon.Damage / maxWeaponDamage;
    }

    private int GetLastOpen()
    {
        for (int i = WeaponTypes.Length - 1; i >= 0; i--)
            if (WeaponTypes[i].IsOpen)
                return i;
        throw new System.Exception("No open weapons");
    }

    private void UpdateSignalImage()
    {
        for (int i = lastOpenIndex; i < WeaponTypes.Length; i++)
            if (WeaponTypes[i].Cost <= data.CurrentCash && !WeaponTypes[i].IsOpen)
            {
                _signalImage.gameObject.SetActive(true);
                return;
            }
        _signalImage.gameObject.SetActive(false);
    }

    private void UpdateBuyButton()
    {
        _buyButton.gameObject.SetActive(selectedIndex - 1 == lastOpenIndex
                                     && WeaponTypes[selectedIndex].Cost <= data.CurrentCash);
    }

    private void UpdateIndicators()
    {
        for (int i = 0; i < _indicators.Length; i++)
            _indicators[i].effectColor = Color.black;
        _indicators[selectedIndex].effectColor = Color.green;
    }

    private void UpdateSprite()
    {
        _currentImage.sprite = WeaponTypes[selectedIndex].WeaponSprite;
    }

    public Weapon GetSelectedWeapon() => WeaponTypes[selectedIndex].Weapon;
}
