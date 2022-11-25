using System.Collections;
using System.Collections.Generic;
using UnityEditor.EditorTools;
using UnityEngine;

public class Jawaban : MonoBehaviour
{
    public bool IsCorret = false;
    public QuizManager quizManager;
    
    public void Answer()
    {
        if (IsCorret)
        {
            Debug.Log("Jawaban Benar");
            
            quizManager.Benar();
        }
        else
        {
            Debug.Log("Jawaban Salah");
            quizManager.Salah();
        }
    }
}
