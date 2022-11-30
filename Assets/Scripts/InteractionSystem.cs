using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionSystem : MonoBehaviour
{
   
    [SerializeField] LayerMask InteracbleLayer;
    [SerializeField]float rangeForInteraction = 3f;
    [SerializeField] EventUi eventUi;
    RaycastHit hit;
    public PlayerManager playerManager;

    private void Start()
    {
        playerManager = GameObject.Find("Player").GetComponent<PlayerManager>();
    }

    private void Update()
    {
        Interaction();
    }

    private void Interaction()
    {
        
        Ray CenterRay=new Ray(transform.position, transform.forward);

        if(Physics.Raycast(CenterRay,out hit, rangeForInteraction, InteracbleLayer))
        {
            if (hit.collider.GetComponent<EventUi>() != false)
            {
                if(eventUi == null||eventUi.Id != hit.collider.GetComponent<EventUi>().Id)
                {
                    eventUi = hit.collider.GetComponent<EventUi>();
                }
            }
           

            if (Input.GetKeyDown(KeyCode.E))
            {
                eventUi.CanInteract.Invoke();
            }

        }

        Debug.DrawRay(transform.position,transform.forward*rangeForInteraction, Color.yellow);
    }
}
