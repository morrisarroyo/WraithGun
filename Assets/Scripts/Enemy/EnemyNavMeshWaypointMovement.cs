using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    
    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.SetDestination((path.First.Next ?? path.First).Value);
    }

    private void OnEnable()
    {
    }

    // Update is called once per frame
    void Update()
    {

        if (HasArrivedAtWaypoint())
        {
            ChangeDestinationToNextWaypoint();
            //Debug.Log("EnemyMovement-Update-Stopped");
        }
    }

    private bool HasArrivedAtWaypoint()
    {
        return Vector3.Distance(transform.position, _currentNode.Value) < waypointAreaRadius;
    }

    private void ChangeDestinationToNextWaypoint()
    {
        Debug.Log(gameObject.name + path.Count);
        _currentNode = _currentNode.Next ?? path.First;
        if (!HasArrivedAtWaypoint())
            _agent.SetDestination(_currentNode.Value);
    }

    public void Reset()
    {
        Transform tr = transform;
        tr.position =  path.First.Value;
        tr.rotation = Quaternion.identity;
        _currentNode = path.First.Next;
        Debug.Log(_currentNode.Value.ToString());
    }

    public bool IsDestinationReachable(Vector3 destination)
    {
        return NavMesh.SamplePosition(destination, out NavMeshHit hit, waypointAreaRadius, NavMesh.AllAreas);
    }
}
