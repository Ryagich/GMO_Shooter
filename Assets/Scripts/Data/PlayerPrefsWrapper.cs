using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerPrefsWrapper
{
    private const string PlayerPrefsKey = "save";

    public static Data LoadPrefs()
    {
        if (PlayerPrefs.HasKey(PlayerPrefsKey))
        {
            var json = PlayerPrefs.GetString(PlayerPrefsKey);
            return JsonUtility.FromJson<Data>(json);
        }
        return Data.GetDefault();
    }

    public static void SavePrefs(Data data)
    {
        var json = JsonUtility.ToJson(data);
        PlayerPrefs.SetString(PlayerPrefsKey, json);
        PlayerPrefs.Save();
    }

}
