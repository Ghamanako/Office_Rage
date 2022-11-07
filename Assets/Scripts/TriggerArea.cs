using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class TriggerArea : MonoBehaviour
{
    public int TriggerID;
    public UnityEvent ontriggerEnter;
   
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        GameEvent.InActiveObject(TriggerID);
        ontriggerEnter?.Invoke();
    }

   
}
