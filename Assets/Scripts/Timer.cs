using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    [SerializeField] int Waktu;
    int CurrentTime;
    float timerfloat;
    public Image image;
         
  


    private void Start()
    {
        CurrentTime = Waktu;
        timerfloat = (float)Waktu;
        StartCoroutine(timerdecrease());
    }

    private void Update()
    {
       
       
    }



   IEnumerator timerdecrease()
    {
        while (timerfloat > 0)
        {
            timerfloat -= Time.deltaTime;
            image.fillAmount = timerfloat / Waktu;

            if (CurrentTime > (int)timerfloat)
            {
                CurrentTime -= 1;
            }
            yield return null;
        }
    }

}

