using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
public class GameManager : MonoBehaviour
{
    Timer timer;
    [SerializeField]int value;
    [SerializeField] int destroyvalue;
    public GameObject gameOver,gameWin;
    int TaskComplete;

    // Start is called before the first frame update
    void Start()
    {
        timer=GetComponent<Timer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (value >= destroyvalue)
        {
            gameOver.SetActive(true);
        }   

        if(timer.CurrentTime==0 && value==0)
            gameOver.SetActive(true);

        if (TaskComplete > 1)
        {
            gameWin.SetActive(true);
        }
    }

    public void updatevalue(int Addvalue)
    {
        value += Addvalue;
    }
}
