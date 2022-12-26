using SaveSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Custom/LevelScriptable")]
public class LevelScriptable: ScriptableObject, ISaveId
{    
    public string SceneName;
    public WaveScriptable[] waves;

    public string Id => name;
}
