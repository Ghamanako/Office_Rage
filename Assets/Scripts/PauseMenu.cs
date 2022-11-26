using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    public AudioSource BgmGameplay;

    public AudioMixer BgmVol;

    AudioSettings audioSettings;
    public GameObject TesAudio;

    float BBgmValue;
    void Awake()
    {
        audioSettings = TesAudio.GetComponent<AudioSettings>();
        
    }

    private void Start()
    {
        Resume();
        audioSettings.BgmValue = BBgmValue;
    }
    
    void Update()
    {
        audioSettings.BgmValue = BBgmValue;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
                if (GameIsPaused)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            
        } 
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        //BgmGameplay.Play();
        //BBgmValue = BBgmValue;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        //BgmGameplay.Stop();
        //BBgmValue = -40;
    }

}
