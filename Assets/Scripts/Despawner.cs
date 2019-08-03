using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawner : MonoBehaviour
{
    [SerializeField] private float seconds;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Despawn());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Despawn()
    {
        yield return new WaitForSeconds(seconds);
        Destroy(gameObject);
    }
}
