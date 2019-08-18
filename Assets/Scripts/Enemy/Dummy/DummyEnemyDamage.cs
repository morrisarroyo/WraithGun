using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy.Dummy
{
    [RequireComponent(typeof(DummyEnemyMovement))]
    public class DummyEnemyDamage : EnemyDamage
    {
        public delegate void DummyDeath(DummyEnemyDamage dummy);
        public event DummyDeath OnDummyKilled;
        
        protected override void Die()
        {
            base.Die();
            if (DummyEnemyPool.Instance != null)
                DummyEnemyPool.Instance.ReturnToPool(gameObject.GetComponent<DummyEnemyMovement>());
            OnDummyKilled?.Invoke(this);
        }
    }
}