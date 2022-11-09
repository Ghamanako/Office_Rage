using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventUi : MonoBehaviour
{

    public UnityEvent CanInteract;
    public int Id;
    // Start is called before the first frame update
    void Start()
    {
        Id = Random.Range(0, 9999);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
