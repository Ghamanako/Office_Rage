using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerTask : MonoBehaviour
{
    Ragebar ragebar;
    [SerializeField] float addRagePoint = 20f;
    public GameObject ComputerTaskUi;
    public GameObject[] prefabs;
    float maxX = 490;
    float maxY = 350;
    public bool isActive = false;
    public Transform SpawnP;
    // Start is called before the first frame update
    void Start()
    {
        isActive = true;
        ragebar = GameObject.Find("Player").GetComponent<Ragebar>();
        InvokeRepeating("SpawnPrefabs", 0.1f, 1f);
    }

    public void ClickToFill()
    {
        ragebar.CurrentRageMeter += addRagePoint;
    }

    public void ClickDontFill()
    {
        ragebar.CurrentRageMeter -= addRagePoint;
    }

    public void BackToGameplay()
    {
        ComputerTaskUi.SetActive(false);
    }

    public void SpawnPrefabs()
    {
        float randomPosX = Random.Range(-maxX, maxX);
        float randomPosY = Random.Range(-maxY, maxY);
        Vector3 position = new Vector3(randomPosX, randomPosY, -50f);
        int index = Random.Range(0, prefabs.Length);
        if (isActive)
        {
        GameObject Wbject = Instantiate(prefabs[index], position, transform.rotation) as GameObject;
        Wbject.transform.SetParent(SpawnP.transform, false);

        }
    }

}
