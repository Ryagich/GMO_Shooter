using SaveSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;


namespace SaveSystem
{
    [CreateAssetMenu(fileName = "Custom/Save")]
    partial class SaveManager : ScriptableObject
    {
        private static SaveManager instance;

        public event Action OnSave;
        public event Action OnLoad;

        public int Money;
        public LevelScriptable MaxLevel;
        public WaveScriptable MaxWave;

        public List<WeaponInfo> AvailableWeapons;
        public WeaponInfo SelectedPistol, SelectedRifle, SelectedShotgun;

        public List<StatUpdate> AvailableStatUpdates;
        public List<BoxUpdate> AvailableBoxUpdates;

        private ScriptableObjectSerializer serializer;

        private void OnEnable()
        {
            serializer = ScriptableObjectSerializer.GetInstance();
            instance = this;
        }

        public static SaveManager GetInstance()
        {
            if (instance == null)
                instance = Instantiate(instance = Resources.LoadAll<SaveManager>(String.Empty).First());
            return instance;
        }

        public void Load()
        {
            if (!PlayerPrefs.HasKey("save"))
            {
                Save();
                return;
            }
            var json = PlayerPrefs.GetString("save");
            Debug.Log("Load:");
            Debug.Log(json);
            var model = JsonUtility.FromJson<Models.SaveModel>(json);
            LoadModel(model);
            OnLoad?.Invoke();
        }

        public void Save()
        {
            var model = SaveModel();
            var json = JsonUtility.ToJson(model, true);
            Debug.Log("Save:");
            Debug.Log(json);
            PlayerPrefs.SetString("save", json);
            PlayerPrefs.Save();
            OnSave?.Invoke();
        }
    }
}
