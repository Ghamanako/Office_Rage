using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEffect : MonoBehaviour
{
    [SerializeField][Range(0f, 4f)] float lerptime;
    float t = 0f;
    public Transform home;
    // Start is called before the first frame update
    void Start()
    {
        home = GameObject.Find("Home").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, home.position, lerptime * Time.deltaTime);
        t = Mathf.Lerp(t, 1f, lerptime * Time.deltaTime);
    }
}
