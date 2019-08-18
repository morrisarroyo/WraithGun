using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Enemy.Dummy
{
    public class DummyEnemySpawner : MonoBehaviour
    {
        [SerializeField] private WaypointPath path;
        [SerializeField] private int dummiesToSpawn;
        [SerializeField] private float spawnTime;
        private int _dummyCount = 0;
        private LinkedList<Vector3> _path;
        private float _spawnTimer = 0;
        // Start is called before the first frame update
        void Start()
        {
            _path = path.GetPathLinkedList();
            SpawnDummy();
        }

        // Update is called once per frame
        void Update()
        {
            if (_dummyCount < dummiesToSpawn)
            {
                _spawnTimer += Time.deltaTime;
                if (_spawnTimer >= spawnTime)
                {
                    _spawnTimer = 0;
                    SpawnDummy();
                }
            }
        }

        private void SpawnDummy()
        {
            ++_dummyCount;
            DummyEnemyMovement dummy = DummyEnemyPool.Instance.GetFromPool();
            dummy.gameObject.SetActive(true);
            dummy.Path = _path;
            dummy.gameObject.GetComponent<DummyEnemyDamage>().OnDummyKilled += RemoveDummy;
            dummy.ReuseEnemy(_path);
        }

        private void RemoveDummy(DummyEnemyDamage dummy)
        {
            --_dummyCount;
            dummy.OnDummyKilled -= RemoveDummy;
        }
    }
}