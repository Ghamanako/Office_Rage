using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
public class Ai : MonoBehaviour
{
    [SerializeField] float timeToMoveNodeMode;
    [SerializeField] float timeRageMode;
    public PlayerManager player;
    public int targetI;
    public float dspeed = 5f;
    public float RageTime;
    public Vector3 TargetV;
    public NavMeshAgent nav;
    public UnityEvent eevent;
    // Start is called before the first frame update
    void Start()
    {
       
        nav = gameObject.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveRandom();
    } 


    public void MoveRandom()
    {
        if(player.RageMeter == 100)
        {
            eevent?.Invoke();
            timeRageMode -= Time.deltaTime;
            if (timeRageMode > 0)
            {
             timeToMoveNodeMode += Time.deltaTime;
                if (timeToMoveNodeMode >= targetI)
                {
                    NewTarget();
                timeToMoveNodeMode = 0;

                }

            }
                 
        }
    }

    public void NewTarget()
    {
        float PlayerX = gameObject.transform.position.x;
        float PlayerZ = gameObject.transform.position.z;

        float xPos = PlayerX + Random.Range(PlayerX - 100, PlayerX + 100);
        float ZPos = PlayerZ + Random.Range(PlayerZ - 100, PlayerZ + 100);
        TargetV = new Vector3(xPos, gameObject.transform.position.y, ZPos );

        nav.SetDestination(TargetV);
    }
}
