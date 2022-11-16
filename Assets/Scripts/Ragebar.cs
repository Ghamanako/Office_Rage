using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ragebar : MonoBehaviour
{
    [SerializeField] public float CurrentRageMeter;
    float MaxRagemeter = 100f;
    public GameObject RageMeterBar;
    public bool RageModeOn = false;
    public Image RageMeterIMG;
    [SerializeField] float delaytime;
    IEnumerator coroutine;
    // Start is called before the first frame update
    void Start()
    {
        RageMeterBar.SetActive(false);
        CurrentRageMeter = MaxRagemeter;
        CurrentRageMeter = 0;
        coroutine = DecreaseValue();
    }

    // Update is called once per frame
    void Update()
    {
        RageBar();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            CurrentRageMeter += 20f;
        }
        if (CurrentRageMeter == MaxRagemeter)
        {
            CurrentRageMeter = 100f;
            RageModeOn = true;
            StartCoroutine(DecreaseValue());
        }

        if (CurrentRageMeter <= 0)
        {
            CurrentRageMeter = 0;
            RageModeOn = false;
            StopCoroutine("DecreaseValue");
        }
    }

    IEnumerator DecreaseValue()
    {
            while (RageModeOn)
            {
                CurrentRageMeter--;
                yield return new WaitForSeconds(delaytime);
            }
       
    }

    public void RageBar()
    {

        CurrentRageMeter = Mathf.Clamp(CurrentRageMeter, 0, MaxRagemeter);

        RageMeterIMG.fillAmount = CurrentRageMeter / MaxRagemeter;

        if (CurrentRageMeter < 1)
        {
            RageMeterBar.SetActive(false);
        }
        else
        {
            RageMeterBar.SetActive(true);
        }
    }


}
