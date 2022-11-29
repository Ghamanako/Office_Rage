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

    public Animator animator;
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
       
        LockYaxis();
    }

    public void FixedUpdate()
    {
        Movement();

    }

    public void Movement()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
      
        Vector3 move = new Vector3(moveX, 0, moveY);

        characterController.Move(move * speed * Time.deltaTime);

        if (move != Vector3.zero)
        {
            animator.SetTrigger("Walking");
            transform.forward = move;
        }
       
    }

    public void LockYaxis()
    {
        if (transform.position.y > 0.453f)
        {
            transform.position = new Vector3(transform.position.x, 0.453f, transform.position.z);
        }

        
    }

    public void AnimationInteract()
    {
        animator.SetTrigger("Interact");
    }

    public void AnimationRage()
    {
        animator.SetBool("Rage", true);
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
