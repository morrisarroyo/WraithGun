using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;

    NavMeshAgent agent;
    int currentWaypoint;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        currentWaypoint = 1;
        agent.autoRepath = true;
        agent.SetDestination(waypoints[currentWaypoint % waypoints.Length].position);
    }

    // Update is called once per frame
    void Update()
    {

        if (Vector3.Distance(transform.position, waypoints[currentWaypoint].position) < 1f)
        {
            currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
            agent.SetDestination(waypoints[currentWaypoint].position);

            //Debug.Log("EnemyMovement-Update-Stopped");
        }
    }
}
