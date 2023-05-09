using System;
using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Logic
{
    public class Road : MonoBehaviour
    {
        public Transform HeroTransform;
        
        [SerializeField] 
        private GameObject _roadTilePrefab;
        
        private List<GameObject> _roadTiles = new List<GameObject>();

        public void Construct(Transform heroTransform)
        {
            HeroTransform = heroTransform;
            for (int i = 0; i < 10; i++)
            {
                var roadTile = Instantiate(_roadTilePrefab, Vector3.forward * i * 10, Quaternion.identity, this.transform);
                _roadTiles.Add(roadTile);
            }
        }
    }
}