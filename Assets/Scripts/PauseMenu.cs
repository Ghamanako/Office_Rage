using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    SaveData levelUpdate;

    public GameObject pauseMenuUI;

    public string nextLevel;
    void Awake()
    {
        //GetComponent<SaveData>().UpdateLevel();
    }

    private void Start()
    {
        Resume();
    }
    
    void Update()
    {
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
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(1);
    }

    public void Level1()
    {
        SceneManager.LoadScene("Level 1 Tutorial");
    }

    public void Level2()
    {
        SceneManager.LoadScene("Level 2 PostPro");
    }

    public void Level3()
    {
        SceneManager.LoadScene("Level 3 PostPro");
    }

    public void restart()
    {
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
        Time.timeScale = 1;
    }
}
