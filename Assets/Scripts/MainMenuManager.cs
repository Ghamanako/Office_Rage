using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public string gameplay;

    public GameObject settings;
    public GameObject abouts;
    public GameObject exit;
    public GameObject levelSelect;

    private bool onSettings;
    private bool onAbout;
    private bool onExit;
    private bool onLevel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (onSettings)
        {
            settings.SetActive(true);
            onSettings = true;
        }
        else
        {
            settings.SetActive(false);
            onSettings = false;
        }

        if (onAbout)
        {
            abouts.SetActive(true);
            onAbout = true;
        }
        else
        {
            abouts.SetActive(false);
            onAbout = false;
        }

        if (onExit)
        {
            exit.SetActive(true);
            onExit = true;
        }
        else
        {
            exit.SetActive(false);
            onExit = false;
        }

        if (onLevel)
        {
            levelSelect.SetActive(true);
            onLevel = true;
        }
        else
        {
            levelSelect.SetActive(false);
            onLevel = false;
        }
    }

    public void _LoadLevel()
    {
        if (!onLevel)
        {
            onLevel = true;
        }
        else
        {
            onLevel = false;
        }
    }
    public void _LoadGame()
    {
        SceneManager.LoadScene(gameplay);
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
    public void _LoadSettings()
    {
        if (!onSettings)
        {
            onSettings = true;
        }
        else
        {
            onSettings = false;
        }
    }

    public void _LoadAbout()
    {
        if (!onAbout)
        {
            onAbout = true;
        }
        else
        {
            onAbout = false;
        }
    }

    public void _LoadExit()
    {
        if (!onExit)
        {
            onExit = true;
        }
        else
        {
            onExit = false;
        }
    }

    public void _ExitGame()
    {
        Application.Quit();
    }
}
