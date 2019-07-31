using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementFactor;
    public float rotationFactor;
    public GameObject ammo;


    Rigidbody rb;

    Vector3 pos;
    bool onFloor;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        pos = Vector3.zero;
        pos.y = transform.position.y;
        onFloor = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (onFloor)
        {

            float hr = Input.GetAxis("Horizontal") * movementFactor;
            pos += hr * transform.right;
            float vr = Input.GetAxis("Vertical") * movementFactor;

            pos += vr * transform.forward;
            pos.y = transform.position.y;
            transform.position = pos;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.velocity = Vector3.up * 5;
                //pos.y = 1.0f;
                //transform.position = pos;
            }
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("Reset");
            pos = Vector3.zero;
            transform.position = pos;
            transform.rotation = Quaternion.identity;
        }
        float roty = Input.GetAxis("RotationalY") * rotationFactor;
        transform.RotateAround(transform.position, Vector3.up, roty);




        if (Input.GetMouseButtonDown(0))
        {
            GameObject bullet = Instantiate(ammo, transform.position + transform.forward * .6f, Quaternion.identity);
            bullet.GetComponent<Rigidbody>().velocity = transform.forward * 50;
        }



    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Floor"))
        {
            Debug.Log("On Floor");
            onFloor = true;
        }


    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Floor"))
        {
            Debug.Log("Off Floor");
            onFloor = false;
        }


    }
}
