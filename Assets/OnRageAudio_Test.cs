using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnRageAudio_Test : MonoBehaviour
{
    public static bool onRageMode = false;

    public GameObject onRageAudio;
    public GameObject onCalmAudio;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (onRageMode)
            {
                Debug.Log(1);
                onRage();
            }
            else
            {
                Debug.Log(2);
                onCalm();
            }

        }
    }

    void onRage()
    {
        onRageAudio.SetActive(true);
        onCalmAudio.SetActive(false);
        onRageMode = false;
    }

    void onCalm()
    {
        onCalmAudio.SetActive(true);
        onRageAudio.SetActive(false);
        onRageMode = true;
    }
}
