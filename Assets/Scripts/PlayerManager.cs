using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    CharacterController characterController;
    [SerializeField] float RageMeter;

    public GameObject RageMeterBar;
    public Image RageMeterIMG;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        RageMeterBar.SetActive(false);
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        RageBar();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            RageBarCount(50);
        }
    }

    public void RageBarCount(float rage)
    {
        RageMeter += rage;
        RageMeterIMG.fillAmount = RageMeter / 100f;
    }

    public void Movement()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        Vector3 move = transform.right * moveX + transform.forward * moveY;

        characterController.Move(move * speed * Time.deltaTime);
    }


    

    public void RageBar()
    {
        
        RageMeter = Mathf.Clamp(RageMeter, 0, 100);

        RageMeterIMG.fillAmount = RageMeter / 100f;

        if (RageMeter < 1)
        {
            RageMeterBar.SetActive(false);
        }
        else
        {
            RageMeterBar.SetActive(true);
        }
    }
}
