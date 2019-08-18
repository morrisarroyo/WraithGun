using System;
using System.Collections;
using System.Collections.Generic;
using Enemy.Dummy;
using UnityEngine;

public abstract class EnemyDamage : MonoBehaviour
{
    //[SerializeField] private int health;

    [SerializeField] private EnemyCharacter enemyCharacter;
    // Number to minus material's color red value by
    [Range(0f,1f)]
    [SerializeField] private float darkenValue;
    public delegate void DarkenEnemyColor();
    public static  event DarkenEnemyColor OnEnemyKilled;


    // Start is called before the first frame update
    void Start()
    {
        EnemyDamage.OnEnemyKilled += DarkenColor;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void DarkenColor()
    {
        if (OnEnemyKilled != null)
        {
            Material mat = GetComponent<Renderer>().material;
            Color color = mat.color;
            color.r -= darkenValue;
            mat.color = color;
        }
    }

    private void ResetColor()
    {
        Material mat = GetComponent<Renderer>().material;
        Color color = mat.color;
        color.r = 1f;
        mat.color = color;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            Die();
            //Debug.Log("Hit");
        }
    }

    protected virtual void Die()
    {
        OnEnemyKilled?.Invoke();
        StatsManager.instance.AddKills(1);
        StatsManager.instance.AddScore(enemyCharacter.KillScore);
        ResetColor();
        gameObject.SetActive(false);
    }
    
    private void OnDisable()
    {
        OnEnemyKilled -= DarkenColor;
    }
}
