using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(EnemyDamage))]
public abstract class EnemyNavMeshWaypointMovement : MonoBehaviour
{
    
    [SerializeField]
    private float waypointAreaRadius;
    private LinkedList<Vector3> path;
    public LinkedList<Vector3> Path
    {
        get => path;
        set => path = value;
    }
    private LinkedListNode<Vector3> _currentNode;

   
    NavMeshAgent _agent;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    // Start is called before the first frame update
    void Start()
    {
        _agent.SetDestination((path.First.Next ?? path.First).Value);
    }
    
    // Update is called once per frame
    void Update()
    {
        if (HasArrivedAtWaypoint())
        {
            ChangeDestinationToNextWaypoint();
        }
    }

    private bool HasArrivedAtWaypoint()
    {
        return Vector3.Distance(transform.position, _currentNode.Value) < waypointAreaRadius;
    }

    private void ChangeDestinationToNextWaypoint()
    {
        _currentNode = _currentNode.Next ?? path.First; 
        _agent.SetDestination(_currentNode.Value);
    }
    
    public void ReuseEnemy(LinkedList<Vector3> newPath)
    {
        //Debug.Log(++resetCount);
        Transform tr = transform;
        path = newPath;
        tr.position =  path.First.Value;
        tr.rotation = Quaternion.identity;
        _currentNode = path.First;
        ChangeDestinationToNextWaypoint();
    }

    public bool IsDestinationReachable(Vector3 destination)
    {
        return NavMesh.SamplePosition(destination, out NavMeshHit hit, waypointAreaRadius, NavMesh.AllAreas);
    }
}
