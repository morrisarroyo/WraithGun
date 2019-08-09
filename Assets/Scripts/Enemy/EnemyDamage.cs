using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    //[SerializeField] private int health;

    // Number to minus material's color red value by
    [SerializeField] private float DarkenValue;

    public delegate void DarkenEnemyColor();
    public static event DarkenEnemyColor onEnemyKilled;


    // Start is called before the first frame update
    void Start()
    {
        EnemyDamage.onEnemyKilled += DarkenColor;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void DarkenColor()
    {
        Debug.Log("Enemy DarkenColor");
        if (onEnemyKilled != null)
        {
            Material mat = GetComponent<Renderer>().material;
            Color color = mat.color;
            color.r -= .20f;
            mat.color = color;

        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            onEnemyKilled();
            Destroy(gameObject);
            Debug.Log("Hit");
        }
    }

    private void OnDisable()
    {
        onEnemyKilled -= DarkenColor;
    }
}
