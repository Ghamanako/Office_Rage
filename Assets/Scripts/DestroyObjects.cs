using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjects : MonoBehaviour
{
    public GameObject Prefab;
    int countDestroyedObjectValue = 1;
    GameManager game;
    Ragebar ragebar;
    BoxCollider colliders;
    private void Start()
    {
        game = GameObject.Find("GameEventSystem").GetComponent<GameManager>();
        ragebar = GameObject.Find("Player").GetComponent<Ragebar>();
        colliders = GetComponent<BoxCollider>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")&& ragebar.RageModeOn)
        {
            colliders.isTrigger = true;
            Destroy(gameObject);
            Instantiate(Prefab, transform.position, transform.rotation);
            game.updatevalue(countDestroyedObjectValue);
            Debug.Log(countDestroyedObjectValue);
        }
        else
        {
            if(other.CompareTag("Player"))
            colliders.isTrigger = false;
        }
    }
}
