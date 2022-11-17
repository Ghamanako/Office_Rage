using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseRageFloatingObject : MonoBehaviour
{
    float points = 20f;
    Ragebar ragebar;
    private void Start()
    {
        ragebar = GameObject.Find("Player").GetComponent<Ragebar>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            ragebar.CurrentRageMeter += 20f;
        }
    }
}
