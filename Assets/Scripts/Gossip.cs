using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gossip : MonoBehaviour
{
    public Ragebar ragebar;
    bool IsInside = false;
    float delaYtime = .5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            IsInside = true;
            StartCoroutine(Increase());
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            IsInside = false;
            
        }
    }
    IEnumerator Increase()
    {
        while (IsInside)
        {
            ragebar.CurrentRageMeter++;
            yield return new WaitForSeconds(delaYtime);
        }
    }
}
