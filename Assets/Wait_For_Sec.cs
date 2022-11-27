using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Wait_For_Sec : MonoBehaviour
{
    public AudioSource audioData;

    private void Awake()
    {
        AudioSplashEffect();
        Invoke("ChangeScene", 5);
    }

    void AudioSplashEffect()
    {
        audioData.PlayDelayed(3);
    }

    void ChangeScene()
    {
        SceneManager.LoadScene(1);
    }
}
