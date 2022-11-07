using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateObject : MonoBehaviour
{
   [SerializeField] bool Aktif=false;
    
    public int triggerangka;
    // Start is called before the first frame update
    void Start()
    {
        GameEvent.EventGames += Activate;
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        if (Aktif == true)
        {
            gameObject.SetActive(false);
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
