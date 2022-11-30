using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour
{
    Timer timer;
    public float value;
    public float destroyvalue;
    public GameObject gameOver,gameWin;
    public float TaskComplete;
    public float PointToWin;

    [Header("UI Object")]
    public TextMeshProUGUI valueT, ValueS;
    public Image BarObject;
    public Image bar;

    // Start is called before the first frame update
    void Start()
    {
        timer=GetComponent<Timer>();
        value = 0;
        destroyvalue = destroyvalue;
        PointToWin = PointToWin;
        TaskComplete = 0;
    }

    // Update is called once per frame
    void Update()
    {
        valueT.text = value + "/" + destroyvalue;
        ValueS.text = TaskComplete + "/" + PointToWin;
        Bar();
        if (value >= destroyvalue)
        {
            gameOver.SetActive(true);
        }   

        //if(timer.CurrentTime==0 && value==0)
            //gameOver.SetActive(true);

        if (TaskComplete >= PointToWin)
        {
            gameWin.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void Bar()
    {
        BarObject.fillAmount = value / destroyvalue;
        bar.fillAmount = TaskComplete / PointToWin;
    }

    public void updatevalue(int Addvalue)
    {
        value += Addvalue;
      
    }

    public void UpdateProgressTask(int AddComplete)
    {
        TaskComplete += AddComplete;
    }
}
