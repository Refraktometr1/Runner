using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Logic
{
    public class Road : MonoBehaviour
    {
        public Transform HeroTransform;
        
        [SerializeField] 
        private GameObject _roadTilePrefab;
        
        private Queue<GameObject> _roadTiles = new Queue<GameObject>();
        private const int TileSize = 10; 

        public void Construct(Transform heroTransform)
        {
            HeroTransform = heroTransform;
            for (int i = 0; i < 10; i++)
            {
                var roadTile = Instantiate(_roadTilePrefab, Vector3.forward * i * TileSize, Quaternion.identity, this.transform);
                _roadTiles.Enqueue(roadTile);
            }
        }

        private void Update()
        {
            var firstTile = _roadTiles.Peek();
            if (HeroTransform.position.z > firstTile.transform.position.z + TileSize)
            {
                firstTile.transform.position = firstTile.transform.position +  Vector3.forward * (_roadTiles.Count * TileSize);
                _roadTiles.Dequeue();
                _roadTiles.Enqueue(firstTile);
            }
        }
    }
}