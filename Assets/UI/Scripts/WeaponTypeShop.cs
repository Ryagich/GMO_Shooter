using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;
using UnityEngine.UIElements;

public class WeaponTypeShop : VisualElement
{
    [UnityEngine.Scripting.Preserve]
    public new class UxmlFactory : UxmlFactory<WeaponTypeShop> { };

    private const string styleSheetResource = "UI/StyleSheets/WeaponShop";
    private const string treeAssetResource = "UI/Layouts/WeaponTypeShop";

    private const string weaponKnobClass = "weapon_knob";
    private const string weaponKnobSelectedClass = "weapon_knob_selected";
    private const string weaponBaseClass = "weapon_shop_type_base";

    private VisualElement buyButton;
    private VisualElement nextButton;
    private VisualElement prevButton;
    private VisualElement weaponSprite;

    private Label weaponDescription;
    private Label weaponPrice;

    private VisualElement indicatorsParent;
    private VisualElement[] indicators;
    private WeaponInfo[] weapons;
    private WeaponType weaponType;
    private int selectedIndex = 0;

    private SaveSystem.SaveManager save;

    public WeaponTypeShop() : base()
    {
        RegisterCallback<GeometryChangedEvent>(Init);
    }

    public void Init(GeometryChangedEvent e)
    {
        LoadSave();
        LoadWeaponList();
        InitializeUxml();
        FindElements();
        InstantiateIndicators(weapons.Length);
        RegisterCallbacks();
        Update();
        UnregisterCallback<GeometryChangedEvent>(Init);
    }

    private void LoadSave()
    {
        save = SaveSystem.SaveManager.GetInstance();
        save.OnSave += Update;
        save.OnLoad += Update;
    }

    private void LoadWeaponList()
    {
        weaponType = 0; //default
        var n = name;
        if (n.Contains("pistol"))
            weaponType = WeaponType.Pistol;
        if (n.Contains("rifle"))
            weaponType = WeaponType.Rifle;
        if (n.Contains("shotgun"))
            weaponType = WeaponType.Shotgun;
        var s = SaveSystem.ScriptableObjectSerializer.GetInstance();
        var l = s.GetAll<WeaponInfo>().Where(s => s.WeaponType == weaponType).ToList();
        l.Sort((a, b) => a.Cost.CompareTo(b.Cost));
        weapons = l.ToArray();
    }

    private void InitializeUxml()
    {
        var tStyle = Resources.Load<StyleSheet>(styleSheetResource);
        var tAsset = Resources.Load<VisualTreeAsset>(treeAssetResource);

        styleSheets.Add(tStyle);
        AddToClassList(weaponBaseClass);

        var t = tAsset.Instantiate();
        t.AddToClassList(weaponBaseClass);
        hierarchy.Add(t);
    }

    private void FindElements()
    {
        buyButton = this.Q("buy_button");
        nextButton = this.Q("next");
        prevButton = this.Q("prev");

        indicatorsParent = this.Q("knobs");
        weaponDescription = this.Q<Label>("weapon_text");
        weaponPrice = this.Q<Label>("weapon_price");
        weaponSprite = this.Q("pic");
    }

    private void InstantiateIndicators(int count)
    {
        indicators = new VisualElement[count];
        for (int i = 0; i < count; i++)
        {
            var indicator = new VisualElement();
            indicators[i] = indicator;
            indicator.AddToClassList(weaponKnobClass);
            indicatorsParent.hierarchy.Add(indicator);
        }
        indicators[selectedIndex].AddToClassList(weaponKnobSelectedClass);
    }

    private void RegisterCallbacks()
    {
        buyButton.RegisterCallback<ClickEvent>(e => BuyCurrent());
        nextButton.RegisterCallback<ClickEvent>(e => Scroll(1));
        prevButton.RegisterCallback<ClickEvent>(e => Scroll(-1));
        UnregisterCallback<GeometryChangedEvent>(e => Update());
    }

    private void BuyCurrent()
    {
        var w = weapons[selectedIndex];

        var enoughMoney = w.Cost <= save.Money;
        var hasWeapon = save.AvailableWeapons.Contains(w);
        var canBuy = enoughMoney && !hasWeapon;

        if (hasWeapon)
        {
            switch (weaponType)
            {
                case WeaponType.Pistol:
                    save.SelectedPistol = w; break;
                case WeaponType.Rifle:
                    save.SelectedRifle = w; break;
                case WeaponType.Shotgun:
                    save.SelectedShotgun = w; break;
            }
            save.Save();
        }
        else if (canBuy)
        {
            save.AvailableWeapons.Add(w);
            save.Money -= w.Cost;
            save.Save();
        }
        Update();
    }

    private void Scroll(int delta)
    {
        selectedIndex += delta;
        if (selectedIndex < 0)
            selectedIndex = 0;
        if (selectedIndex >= weapons.Length)
            selectedIndex = weapons.Length - 1;
        Debug.Log($"Screlled {delta}");
        Update();
    }

    private void Update()
    {
        UpdateIndicators();
        UpdateSprite();
        UpdateDescription();
        UpdatePrice();
        UpdateBuy();
    }

    private void UpdateBuy()
    {
        var w = weapons[selectedIndex];

        var enoughMoney = w.Cost <= save.Money;
        var hasWeapon = save.AvailableWeapons.Contains(w);
        var isSelected = save.SelectedRifle == w || save.SelectedShotgun == w || save.SelectedPistol == w;
        var canBuy = enoughMoney && !hasWeapon;

        var t = buyButton.Children().First() as Label;

        if (hasWeapon)
        {
            t.text = "Use";
            buyButton.style.backgroundColor = isSelected ? Color.gray : Color.yellow;
            return;
        }

        t.text = "Buy";
        buyButton.style.backgroundColor = canBuy ? Color.green : Color.red;
    }

    private void UpdatePrice()
    {
        var w = weapons[selectedIndex];
        weaponPrice.text = (w.Cost == 0) ? "Free" : w.Cost.ToString();
    }

    private void UpdateDescription()
    {
        var w = weapons[selectedIndex];
        weaponDescription.text = $"{w.name} \n" +
                                 $"Damage {w.Weapon.Damage} \n" +
                                 $"Speed {w.Weapon.Speed * 10:0.}";
    }

    private void UpdateSprite()
    {
        weaponSprite.style.backgroundImage = new StyleBackground(weapons[selectedIndex].WeaponSprite);
    }

    private void UpdateIndicators()
    {
        foreach (var i in indicators)
        {
            if (i.ClassListContains(weaponKnobSelectedClass))
                i.RemoveFromClassList(weaponKnobSelectedClass);
        }
        indicators[selectedIndex].AddToClassList(weaponKnobSelectedClass);
    }
}
