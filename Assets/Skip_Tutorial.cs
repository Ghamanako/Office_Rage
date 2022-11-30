using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Skip_Tutorial : MonoBehaviour
{
public void SkipDialogue()
    {
        SceneManager.LoadScene("Level 1 PostPro");
    }
}
