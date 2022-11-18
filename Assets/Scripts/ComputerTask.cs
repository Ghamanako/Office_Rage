using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerTask : MonoBehaviour
{
    Ragebar ragebar;
    [SerializeField] float addRagePoint = 20f;
    public GameObject ComputerTaskUi;
    // Start is called before the first frame update
    void Start()
    {
        ragebar = GameObject.Find("Player").GetComponent<Ragebar>();
    }

   public void ClickToFill()
    {
        ragebar.CurrentRageMeter+=addRagePoint;
    }

    public void ClickDontFill()
    {
        ragebar.CurrentRageMeter-=addRagePoint;
    }

    public void BackToGameplay()
    {
        ComputerTaskUi.SetActive(false);
    }
}
