using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    public static SaveData instance;

    private const string _prefsKey = "SaveData";
    [SerializeField] private int _levelUnlocked = 0;

    public int LevelUnlocked => _levelUnlocked;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        Load();
    }

    public void Save()
    {
        string json = JsonUtility.ToJson(this);
        PlayerPrefs.SetString(_prefsKey, json);

        Debug.Log(json);
    }

    private void Load()
    {
        if (PlayerPrefs.HasKey(_prefsKey))
        {
            string json = PlayerPrefs.GetString(_prefsKey);
            JsonUtility.FromJsonOverwrite(json, this);
        }
        else
        {
            Save();
        }
    }

    [ContextMenu("Increase Level")]
    public void UpdateLevel()
    {
        _levelUnlocked++;
        Save();
    }
}
