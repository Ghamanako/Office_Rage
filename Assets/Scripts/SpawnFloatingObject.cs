using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFloatingObject : MonoBehaviour
{
    public GameObject[] floatingObjects;
    bool isGameOn;
    float Posx=20f;
    float Posz=20f;
    // Start is called before the first frame update
    void Start()
    {
        isGameOn = true;
        InvokeRepeating("SpawnPrefabs", 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnPrefabs()
    {
        float randomx = Random.Range(-Posx, Posx);
        float randomz = Random.Range(-Posz, Posz);

        Vector3 spawnObject = new Vector3(randomx, .5f, randomz);
        int indexPrefab=Random.Range(0, floatingObjects.Length);

        if (isGameOn)
        {
            Instantiate(floatingObjects[indexPrefab], spawnObject, Quaternion.identity);
        }
    }
}
