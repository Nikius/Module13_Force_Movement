using System;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace MyAssets.Scripts
{
    public class ItemRotator : MonoBehaviour
    {
        [SerializeField] private float _rotationSpeed;
        
        private void Awake()
        {
            transform.rotation = Quaternion.Euler(0, Random.Range(0, 180), 0);
        }

        private void Update()
        {
            transform.Rotate(Vector3.up, _rotationSpeed * Time.deltaTime);
        }
    }
}
