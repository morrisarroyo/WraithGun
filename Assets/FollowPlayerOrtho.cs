using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerOrtho : MonoBehaviour
{

    [SerializeField] private Transform playerTransform;

    
    // Start is called before the first frame update
    void Start()
    {
        Transform tr = transform;
        Vector3 playerPosition = playerTransform.position;
        tr.position = new Vector3(playerPosition.x, tr.position.y, playerPosition.z);
    }

    // Update is called once per frame
    void Update()
    {       
        Transform tr = transform;
        Vector3 playerPosition = playerTransform.position;
        tr.position = new Vector3(playerPosition.x, tr.position.y, playerPosition.z);
    }
}
