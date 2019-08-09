using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerOrtho : MonoBehaviour
{

    [SerializeField] private Transform playerTransform;

    Vector3 cameraPosition;

    // Start is called before the first frame update
    void Start()
    {
        cameraPosition = new Vector3(playerTransform.position.x, transform.position.y, playerTransform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = cameraPosition;
    }
}
