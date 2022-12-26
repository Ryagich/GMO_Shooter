using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextUpdaterPauseMenu : MonoBehaviour
{
    [SerializeField] private Text _textTime;
    [SerializeField] private Text _textKillCount;

    private void Awake()
    {
        PauseButton.OnPause += UpdateText;
    }

    public void UpdateText()
    {
        _textTime.text = Stopwatch.Instance.GetTime().ToString() + "s";
    }

    private void OnDestroy()
    {
        PauseButton.OnPause -= UpdateText;
    }
}
