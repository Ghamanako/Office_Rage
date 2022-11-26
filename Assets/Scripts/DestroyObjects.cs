using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjects : MonoBehaviour
{
    public GameObject Prefab;
    int countDestroyedObjectValue = 1;
    GameManager game;

    private void Start()
    {
        game = GameObject.Find("GameEventSystem").GetComponent<GameManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            Instantiate(Prefab, transform.position, transform.rotation);
            game.updatevalue(countDestroyedObjectValue);
            Debug.Log(countDestroyedObjectValue);
        }
    }
}
