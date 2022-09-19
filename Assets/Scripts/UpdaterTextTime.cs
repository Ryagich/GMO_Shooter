using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdaterTextTime : MonoBehaviour
{
    [SerializeField] private Stopwatch _stopwatch;
    [SerializeField] private Text text;

    private void Awake()
    {
        PauseButton.OnPause += UpdateText;
    }

    public void UpdateText()
    {
        text.text = _stopwatch.GetTime().ToString();
    }
}
