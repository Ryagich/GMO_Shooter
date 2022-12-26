using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Cecil;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelSelector : MonoBehaviour
{
    public static int SelectedWave { get; private set; } = -1;

    [SerializeField] private string _level;
    [SerializeField] private int _wave;

    private void OnMouseDown()
    {
        SelectedWave = _wave;
        SceneManager.LoadSceneAsync(_level, LoadSceneMode.Single);
    }
}