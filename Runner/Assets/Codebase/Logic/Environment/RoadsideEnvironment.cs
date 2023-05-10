using System.Collections.Generic;
using UnityEngine;

namespace Codebase.Logic.Environment
{
    public class RoadsideEnvironment : MonoBehaviour
    {
        [SerializeField]
        private GameObject _environmentPrefab;
        private int _tileSize = 30;
        private int _poolSize = 7;
        public Transform HeroTransform;
        private Queue<GameObject> _poolTiles = new Queue<GameObject>();

        public virtual void Construct(Transform heroTransform)
        {
            HeroTransform = heroTransform;
            for (int i = 0; i < _poolSize; i++)
            {
                var roadTile = Instantiate<GameObject>(_environmentPrefab, Vector3.forward * i * _tileSize, Quaternion.identity, this.transform);
                _poolTiles.Enqueue(roadTile);
            }
        }

        private void Update()
        {
            RotatePoolByHeroMove();
        }

        private void RotatePoolByHeroMove()
        {
            var firstTile = _poolTiles.Peek();
            if (HeroTransform.position.z > firstTile.transform.position.z + _tileSize)
            {
                firstTile.transform.position = firstTile.transform.position + Vector3.forward * (_poolTiles.Count * _tileSize);
                _poolTiles.Dequeue();
                _poolTiles.Enqueue(firstTile);
            }
        }
    }
}