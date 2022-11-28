using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class QuizManager : MonoBehaviour
{
    [System.Serializable]
    public class Soal
    {
        public string PertanyaanS;
        public string[] jawaban;
        public int Correctanswer;
       
    }


    public List<Soal> KumpulanSoal;
    GameManager gameManager;
    [Space(150)]
    public GameObject[] pilihanGanda;
    public int CurrentSoal;
    public TextMeshProUGUI soalT;
    [SerializeField] int PointToComplete;
    [SerializeField] int score;
    public GameObject QuizTask;
    int QuestComplete;
    void Start()
    {
        gameManager = GameObject.Find("GameEventSystem").GetComponent<GameManager>();
        GenerateQuestion();
       
    }

    void Update()
    {
        if (KumpulanSoal.Count == 0)
        {
            QuizTask.SetActive(false);
            if (score >= PointToComplete)
            {
                gameManager.UpdateProgressTask(QuestComplete);
            }
        }
    }

    public void Benar()
    {
        KumpulanSoal.RemoveAt(CurrentSoal);
        GenerateQuestion();
    }

    public void Salah()
    {
        KumpulanSoal.RemoveAt(CurrentSoal);
        GenerateQuestion();
    }

    IEnumerator munculPanelP()
    {
       
        yield return new WaitForSeconds(1f);
       
    }

    void SetAnswers()
    {
        for (int i = 0; i < pilihanGanda.Length; i++)
        {
            pilihanGanda[i].GetComponent<Jawaban>().IsCorret = false;
            pilihanGanda[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = KumpulanSoal[CurrentSoal].jawaban[i];


            if (KumpulanSoal[CurrentSoal].Correctanswer == i + 1)
            {
                pilihanGanda[i].GetComponent<Jawaban>().IsCorret = true;
            }
        }
    }

    void GenerateQuestion()
    {
        CurrentSoal = Random.Range(0, KumpulanSoal.Count);

        soalT.text = KumpulanSoal[CurrentSoal].PertanyaanS;
      
        SetAnswers();

    }

    public void UpdateScore(int AddScore)
    {
        score += AddScore;
    }
}
