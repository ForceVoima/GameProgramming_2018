using UnityEngine;
using System.Collections;

namespace TankGame
{
    public class CollectableSpawner : MonoBehaviour
    {
        [SerializeField, Range(0f, 6f)]
        private float _timer = 0f;

        [SerializeField]
        private float _spawnDelay = 5f;

        [SerializeField]
        private GameObject _corner1;

        [SerializeField]
        private GameObject _corner2;

        [SerializeField]
        private GameObject _collectablePrefab;

        private void Update()
        {
            _timer += Time.deltaTime;

            if (_timer > _spawnDelay)
            {
                SpawnCollectable();
                _timer = 0f;
            }
        }

        private void SpawnCollectable()
        {
            float minX = Mathf.Min(_corner1.transform.position.x, _corner2.transform.position.x);
            float maxX = Mathf.Max(_corner1.transform.position.x, _corner2.transform.position.x);

            float minZ = Mathf.Min(_corner1.transform.position.z, _corner2.transform.position.z);
            float maxZ = Mathf.Max(_corner1.transform.position.z, _corner2.transform.position.z);

            Vector3 pos = new Vector3(Random.Range(minX, maxX), 10f, Random.Range(minZ, maxZ));
            Instantiate(_collectablePrefab, pos, new Quaternion(), transform);
        }
    }
}
