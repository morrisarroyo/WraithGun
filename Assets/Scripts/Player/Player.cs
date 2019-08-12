using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerCharacter character;
    [SerializeField] private GameObject ammo;
    [SerializeField] private Camera cam;

    public static Player instance;

    Rigidbody rb;

    Vector3 startingPos;
    Vector3 pos;
    bool onFloor;

    int health;
    int attackDamage;

    public delegate void UpdatePlayerHealth();
    public static event UpdatePlayerHealth onHealthChanged;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        health = character.health;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startingPos = transform.position;
        pos = startingPos;
        onFloor = true;
        attackDamage = character.attackDamage;

    }

    // Update is called once per frame
    void Update()
    {
        float hr = Input.GetAxis("Horizontal");
        float vr = Input.GetAxis("Vertical");
        Vector3 movement = hr * transform.right + vr * transform.forward;
        float vely = rb.velocity.y;
        //rb.AddForce(movement * character.movementSpeed , ForceMode.VelocityChange);
        //rb.velocity = rb.velocity.normalized * character.movementSpeed * 100;
        //rb.AddForce(hr * transform.right)
        //pos.y = transform.position.y;
        //pos += (hr * transform.right + vr * transform.forward) * character.movementSpeed * Time.deltaTime;
        rb.velocity = (hr * transform.right + vr * transform.forward).normalized * character.movementSpeed ;
        rb.velocity += vely * Vector3.up;
        //transform.position = pos;

        if (onFloor)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce( Vector3.up * character.jumpFactor, ForceMode.Impulse);
                //pos.y = 1.0f;
                //transform.position = pos;
            }
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("Reset");
            pos = startingPos;
            transform.position = pos;
            transform.rotation = Quaternion.identity;
            cam.transform.rotation = Quaternion.identity;
        }



        //float roty = Input.GetAxis("RotationalY") * rotationFactor;
        float roty = Input.GetAxis("Mouse X") * character.rotationSpeed;
        transform.RotateAround(transform.position, transform.up, roty);

        float rotx = Input.GetAxis("Mouse Y") * character.rotationSpeed;
        cam.transform.RotateAround(transform.position, transform.right, rotx);




        if (Input.GetMouseButtonDown(0))
        {
            GameObject bullet = Instantiate(ammo, transform.position + cam.transform.forward * .6f, Quaternion.identity);
            bullet.GetComponent<Rigidbody>().velocity = cam.transform.forward * 50;
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

    public int GetHealth()
    {
        return health;
    }

    public void AddHealth(int healthToAdd)
    {
        health += healthToAdd;
        onHealthChanged();
    }

    public string GetCharacter()
    {
        return character.characterName;
    }
}
