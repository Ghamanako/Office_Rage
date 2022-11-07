using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvent : MonoBehaviour
{
    public static GameEvent current;
    public static event Action<int> EventGames;
  
    private void Awake()
    {
        if (current == null)
        {
            current = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
       
      
    }

    public static void InActiveObject(int id)
    {
       
        EventGames?.Invoke(id);
    }

}
