using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Cecil;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelSelector : MonoBehaviour
{
    public static int SelectedWave { get; private set; } = -1;

    [SerializeField] private SceneAsset _level;
    [SerializeField] private int _wave;

    private void OnMouseDown()
    {
        SelectedWave = _wave;
        SceneManager.LoadSceneAsync(_level.name, LoadSceneMode.Single);
    }
}