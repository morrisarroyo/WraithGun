using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickupSpawner : MonoBehaviour
{
    [SerializeField] private HealthPickups healthPickup;
    [SerializeField] private PlayerCharacter playerCharacter;

    int healthToAdd;
    float respawnTime;
    Vector3 spawnPosition;

    // Start is called before the first frame update
    void Start()
    {
        healthToAdd = healthPickup.healthToAdd;
        respawnTime = healthPickup.respawnTime;
        spawnPosition = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerCharacter.health += healthToAdd;
            StartCoroutine(Respawn());
            gameObject.transform.position = Vector3.up * 1000;
        }
    }

    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(respawnTime);
        gameObject.transform.position = spawnPosition;
    }
}
