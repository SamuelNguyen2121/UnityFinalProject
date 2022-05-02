using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour 
   
{
    float hAxis;
    float vAxis;
    bool run;
    public float speed;

    Vector3 moveVec;
    
    private  Animator anim;
    NavMeshAgent agent;

    public Transform[] waypoints;
    int waypointIndex;
    Vector3 target;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        UpdateDestination();
    }

    // Update is called once per frame
    void Update()
    {
        hAxis = Input.GetAxisRaw("HorizontalEnemy");
        vAxis = Input.GetAxisRaw("VerticalEnemy");
        run = Input.GetButton("Run");
      

        moveVec = new Vector3(hAxis, 0, vAxis);

        transform.position += moveVec * speed * Time.deltaTime;

        anim.SetBool("isWalking", moveVec != Vector3.zero);
        anim.SetBool("isRunning", run);

        transform.LookAt(waypoints[waypointIndex]);
        if (Vector3.Distance(transform.position, target) < 1)
        {
            IterateWaypointIndex();
            UpdateDestination();
        }
       
        
    }
    void UpdateDestination()
    {
        target = waypoints[waypointIndex].position;
        agent.SetDestination(target);
    }
    void IterateWaypointIndex()
    {
        waypointIndex++;
        if(waypointIndex == waypoints.Length)
        {
            waypointIndex = 0;
        }
    }
}
