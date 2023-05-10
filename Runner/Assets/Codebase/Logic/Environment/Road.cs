using System.Collections.Generic;
using UnityEngine;

namespace Codebase.Logic.Environment
{
    public class Road : MonoBehaviour
    {
        [SerializeField] private GameObject _roadTilePrefab;
        private int _tileSize = 10;
        private int _poolSize = 15;
        public Transform HeroTransform;
        private Queue<GameObject> _poolTiles = new Queue<GameObject>();
        
        public virtual void Construct(Transform heroTransform)
        {
            HeroTransform = heroTransform;
            for (int i = 0; i < _poolSize; i++)
            {
                var roadTile = Instantiate<GameObject>(_roadTilePrefab, Vector3.forward * i * _tileSize, Quaternion.identity, this.transform);
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
            if (HeroTransform.position.z > firstTile.transform.position.z + _tileSize * 2)
            {
                firstTile.transform.position = firstTile.transform.position + Vector3.forward * (_poolTiles.Count * _tileSize);
                _poolTiles.Dequeue();
                _poolTiles.Enqueue(firstTile);
            }
        }
    }
}