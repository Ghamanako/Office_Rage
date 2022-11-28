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
    [SerializeField]int TaskComplete;

    [Header("UI Object")]
    public TextMeshProUGUI valueT;
    public Image BarObject;
    

    // Start is called before the first frame update
    void Start()
    {
        timer=GetComponent<Timer>();
        value = 0;
        destroyvalue = destroyvalue;
    }

    // Update is called once per frame
    void Update()
    {
        valueT.text = value + "/" + destroyvalue;
        Bar();
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

    public void Bar()
    {
        BarObject.fillAmount = value / destroyvalue;
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
