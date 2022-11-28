using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabComputerTask : MonoBehaviour
{
    public float speed;
    public Vector3 direction = Vector3.zero;
    bool running = false;
    Vector3 destination;
    public GameObject notif;
    public Transform insta;
    private void Start()
    {
        insta = GameObject.Find("GameObject (1)").GetComponent<Transform>();
    }

    private void Update()
    {
        if (!running)
        {
            StartCoroutine(changingDirection());
        }
        destination = transform.position + direction * speed;
        transform.position = Vector3.Lerp(transform.position, destination, Time.deltaTime);
    }

    IEnumerator changingDirection()
    {
        running = true;
        yield return new WaitForSeconds(1.5f);
        direction.x = Random.Range(-1, 2);
        direction.y = Random.Range(-1, 2);
        running = false;
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
        GameObject s = Instantiate(notif, gameObject.transform.position, Quaternion.identity) as GameObject;
        s.transform.SetParent(insta,false);
      
    }


}
