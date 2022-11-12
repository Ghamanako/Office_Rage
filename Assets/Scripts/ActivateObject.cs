using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateObject : MonoBehaviour
{
   [SerializeField] bool Aktif=false;
    public GameObject computerTask, Task;
    public int triggerangka;
    // Start is called before the first frame update
    void Start()
    {
        GameEvent.EventGames += Activate;
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        if (Aktif == true&& triggerangka<2)
        {
                computerTask.SetActive(true) ;
        } 
        else if (Aktif == true&& triggerangka>1)
        {
                Task.SetActive(true) ;
        }
    }

    private void Activate(int trigger)
    {

        if(trigger==triggerangka)
        Aktif=true;
    }

    private void OnDisable()
    {
        GameEvent.EventGames -= Activate;
    }
}
