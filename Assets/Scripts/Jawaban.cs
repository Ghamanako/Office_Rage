using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jawaban : MonoBehaviour
{
    public bool IsCorret = false;
    public QuizManager quizManager;
    int pointValue = 1;
    public void Answer()
    {
        if (IsCorret)
        {
            Debug.Log("Jawaban Benar");
            quizManager.UpdateScore(pointValue);
            quizManager.Benar();
        }
        else
        {
            Debug.Log("Jawaban Salah");
            quizManager.Salah();
        }
    }
}
