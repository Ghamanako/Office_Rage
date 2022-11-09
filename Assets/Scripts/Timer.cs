using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] float Waktu;
    float CurrentTime;


    public TextMeshProUGUI TimerT;

    private void OnEnable()
    {
        Actions.TimerStarted += TimeUpdate;
    }

    private void OnDisable()
    {
        Actions.TimerStarted -= TimeUpdate;
    }

    public void TimeUpdate()
    {
        if (Waktu > 0)
            Waktu -= Time.deltaTime;
        
        CurrentTime += 1;
        float minute = Mathf.FloorToInt(Waktu / 60);
        float second = Mathf.FloorToInt(Waktu % 60);

        TimerT.text = string.Format("{0:00}:{1:00}", minute, second);
    }

}

