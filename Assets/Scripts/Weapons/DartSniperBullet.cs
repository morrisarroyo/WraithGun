using System;
using UnityEngine;

public class DartSniperBullet : MonoBehaviour
{
    [SerializeField] private float lifetime;
    private float _timer = 0f;
    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= lifetime)
        {
            DartSniperBulletPool.Instance.ReturnToPool(this);
            _timer = 0;
        }
    }
}