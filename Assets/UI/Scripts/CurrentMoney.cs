using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UIElements;

public class CurrentMoney : VisualElement
{
    [UnityEngine.Scripting.Preserve]
    public new class UxmlFactory : UxmlFactory<CurrentMoney> { };

    private const string defaultPanelClass = "default_panel";
    private const string roundElementClass = "round_element";
    private const string bigLabelClass = "label_big";
    private const string bigLabelHolderClass = "label_big_holder";
    private const string coinIconClass = "coin_icon";

    private readonly Label text;

    private readonly SaveSystem.SaveManager save;

    public CurrentMoney() : base()
    {
        var frame = new VisualElement();
        frame.AddToClassList(defaultPanelClass);
        frame.AddToClassList(roundElementClass);
        frame.AddToClassList(bigLabelHolderClass);

        var coin = new VisualElement();
        coin.AddToClassList(coinIconClass);
        frame.Add(coin);

        text = new Label();
        text.AddToClassList(bigLabelClass);
        frame.Add(text);

        hierarchy.Add(frame);

        save = SaveSystem.SaveManager.GetInstance();
        save.OnSave += Update;
        save.OnLoad += Update;

        Update();
    }

    private void Update()
    {
        text.text = save.Money.ToString();
    }
}
