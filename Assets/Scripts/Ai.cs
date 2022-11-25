using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
public class Ai : MonoBehaviour
{
    [SerializeField] float timeToMoveNodeMode;
    [SerializeField] float timeRageMode;
   [SerializeField] Ragebar ragebar;
    public Transform CentrePoint;
    public float range;
    public int targetI;
    public float dspeed = 5f;
    public float RageTime;
    public Vector3 TargetV;
    public NavMeshAgent nav;
    public UnityEvent eevent;
    public UnityEvent kelar;
    // Start is called before the first frame update
    void Start()
    {
        ragebar = GetComponent<Ragebar>();
        nav = gameObject.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        moveRandom();
        LockYAxis();
    } 

    public void LockYAxis()
    {
        if (transform.rotation.y > 0&& transform.rotation.y<0)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
        }
    }

    public void moveRandom()
    {
            
        if (ragebar.RageModeOn)
        {
            eevent?.Invoke();
            if (nav.remainingDistance <= nav.stoppingDistance) //done with path
            {
                Vector3 point;
                if (RandomPoint(CentrePoint.position, range, out point)) //pass in our centre point and radius of area
                {
                    Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f); //so you can see with gizmos
                    nav.SetDestination(point);
                }
            }
        }
        if (ragebar.RageModeOn == false)
        {
            kelar?.Invoke();
        }
    }
    //public void MoveRandom()
   // {
        //if(ragebar.RageModeOn)
        //{
        // eevent?.Invoke();
        // timeToMoveNodeMode += Time.deltaTime;
          // if (timeToMoveNodeMode >= targetI)
          // {
           // NewTarget();
            //timeToMoveNodeMode = 0;

           //}

       // }
         //if (ragebar.RageModeOn == false) 
        // {
          //timeRageMode = 0;
         // kelar?.Invoke();
         //}

    //}
    

    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {

        Vector3 randomPoint = center + Random.insideUnitSphere * range; //random point in a sphere 
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas)) //documentation: https://docs.unity3d.com/ScriptReference/AI.NavMesh.SamplePosition.html
        {
            //the 1.0f is the max distance from the random point to a point on the navmesh, might want to increase if range is big
            //or add a for loop like in the documentation
            result = hit.position;
            return true;
        }

        result = Vector3.zero;
        return false;
    }
}
