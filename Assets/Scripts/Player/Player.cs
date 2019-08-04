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
        pos = Vector3.zero;
        pos.y = transform.position.y;
        onFloor = true;
        attackDamage = character.attackDamage;

        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (onFloor)
        {

            float hr = Input.GetAxis("Horizontal") * character.movementSpeed;
            pos += hr * transform.right;
            float vr = Input.GetAxis("Vertical") * character.movementSpeed;

            pos += vr * transform.forward;
            pos.y = transform.position.y;
            transform.position = pos;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.velocity = Vector3.up * character.jumpFactor;
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
