using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    public static event Action OnPause;

    [SerializeField] private Canvas _pauseCanvas;

    private void Awake()
    {
        Hero.OnHeroDeied += OpenPauseCanvas;
    }

    public void OpenPauseCanvas()
    {
        OnPause?.Invoke();
        _pauseCanvas.gameObject.SetActive(true);
    }
}
