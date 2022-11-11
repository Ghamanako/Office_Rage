using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    
    
    //Basic Player Movement
    [Space(5)]
    [Header("Basic Player Movement")]
    CharacterController characterController;
  

    public Transform SpawnPoint;
    public GameObject NotifInteraction;
    public float speed;
 
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>(); 
    }

    // Update is called once per frame
    void Update()
    {
        Movement();   
    }

    public void Movement()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        Vector3 move = transform.right * moveX + transform.forward * moveY;

        characterController.Move(move * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Interaction"))
            ShowInteractNotify();
        
    }

    public void ShowInteractNotify()
    {
        Instantiate(NotifInteraction,SpawnPoint);
    }

   
   
    

    
}
