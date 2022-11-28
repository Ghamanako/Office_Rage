using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ragebar : MonoBehaviour
{
    [SerializeField] public float CurrentRageMeter;
    public Sprite[] sprites;
    public Image emot;
    float MaxRagemeter = 100f;
    public bool RageModeOn = false;
    public Slider slider;
    
    [SerializeField] float delaytime;
    IEnumerator coroutine;
    int index;

    //ihsan script
    //public static bool onRageMode = false;

    public GameObject onRageAudio;
    public GameObject onCalmAudio;
    //ihsan script

    // Start is called before the first frame update
    void Start()
    {
       
        CurrentRageMeter = MaxRagemeter;
        CurrentRageMeter = 0;
        coroutine = DecreaseValue();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSlider();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            CurrentRageMeter += 20f;
        }
        if (CurrentRageMeter == MaxRagemeter)
        {
            CurrentRageMeter = 100f;
            RageModeOn = true;
            StartCoroutine(DecreaseValue());
            //ihsan
            onRage();
        }

        if (CurrentRageMeter >= MaxRagemeter)
        {
            CurrentRageMeter = 100f;
        }

        if (CurrentRageMeter <= 0)
        {
            CurrentRageMeter = 0;
            RageModeOn = false;
            StopCoroutine("DecreaseValue");
            //ihsan
            onCalm();
        }

        perubahanEmot();
    }

    IEnumerator DecreaseValue()
    {
            while (RageModeOn)
            {
                CurrentRageMeter--;
                yield return new WaitForSeconds(delaytime);
               
            }
       
    }


   public void UpdateSlider()
    {
        slider.value = CurrentRageMeter;
    }

    public void perubahanEmot()
    {
        if(sprites.Length>=index)
        emot.sprite=sprites[index];

        if (CurrentRageMeter == 0)
        {
            emot.sprite = sprites[0];
            //onCalm();
        }
        if (CurrentRageMeter > 19)
        {
            emot.sprite = sprites[1];
        }
        if (CurrentRageMeter > 39)
        {
            emot.sprite = sprites[2];
        }
        if (CurrentRageMeter > 59)
        {
            emot.sprite = sprites[3];
        }
        if (CurrentRageMeter > 79)
        {
            emot.sprite = sprites[4];
        }
        // ihsan script
        if (CurrentRageMeter > 100)
        {
            //onRage();//
        }
    }


    // ihsan script
    void onRage()
    {
        onRageAudio.SetActive(true);
        onCalmAudio.SetActive(false);
        //onRageMode = false;
    }

    void onCalm()
    {
        onCalmAudio.SetActive(true);
        onRageAudio.SetActive(false);
        //onRageMode = true;
    }



}
