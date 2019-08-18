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
            /*
            Transform[] childTransforms = GetComponentsInChildren<Transform>();
            
            
            foreach (Transform childTransform in childTransforms.Skip(1).ToArray())
            {
                _path.Add(childTransform);
            }
            */
            SpawnDummy();
            /*
            foreach (var tr in _path)
            {
                Debug.Log(gameObject.name + " " + tr.position.ToString());
            }
            */
        }

        // Update is called once per frame
        void Update()
        {
            if (_dummyCount < dummiesToSpawn)
            {
                _spawnTimer += Time.deltaTime;
                if (_spawnTimer >= spawnTime)
                {
                    SpawnDummy();
                    _spawnTimer = 0;
                }
            }
        }

        private void SpawnDummy()
        {
            DummyEnemyMovement dummy = DummyEnemyPool.Instance.GetFromPool();
            dummy.gameObject.SetActive(true);
            dummy.Path = _path;
            //Debug.Log(dummy.Waypoints.Count);
            dummy.gameObject.GetComponent<DummyEnemyDamage>().OnDummyKilled += DecrementDummyCountOnDeath;
            dummy.Reset();
            ++_dummyCount;

        }

        private void DecrementDummyCountOnDeath()
        {
            --_dummyCount;
        }
    }
}