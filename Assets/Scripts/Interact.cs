using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public EventUi eventUi;
    public PlayerManager playerManager;

    private void Start()
    {
        playerManager = GameObject.Find("Player").GetComponent<PlayerManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<EventUi>())
        {
            if(eventUi != null || eventUi.Id != GetComponent<EventUi>().Id)
            {
                eventUi=GetComponent<EventUi>();
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                eventUi.CanInteract.Invoke();
                playerManager.AnimationInteract();
            }
        }
    }
}
