using System;
using System.Collections.Generic;
using System.Security.Policy;
using UnityEngine;

public abstract class GenericObjectPool<T> : MonoBehaviour where T : Component
{
    [SerializeField] private T prefab;

    public static GenericObjectPool<T> Instance { get; private set; }
    private Queue<T> pool = new Queue<T>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    public T GetFromPool()
    {
        if (pool.Count == 0)
            AddToPool(1);
        return pool.Dequeue();
    }
    
    public void ReturnToPool(T objectToReturn)
    {
        objectToReturn.gameObject.SetActive(false);
        pool.Enqueue(objectToReturn);
    }
    
    private void AddToPool(int count = 1)
    { 
        T newObject = GameObject.Instantiate(prefab);
        newObject.gameObject.SetActive(false);
        pool.Enqueue(newObject);
    }
}