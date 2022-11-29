using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level_Selection : MonoBehaviour
{
    [SerializeField] private Button[] _levelButtons;

    private void Update()
    {
        for (int i = 0; i < SaveData.instance.LevelUnlocked; i++)
        {
            _levelButtons[i].interactable = true;
        }
    }
}
