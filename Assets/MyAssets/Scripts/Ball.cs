using System;
using UnityEngine;

namespace MyAssets.Scripts
{
    public class Ball : MonoBehaviour
    {
        public Wallet wallet;
        
        private Movement _movement;        
        private Vector3 _startPosition;

        private void Awake()
        {
            _movement = GetComponent<Movement>();
            _startPosition = transform.position;
        }

        public void Reset()
        {
            _movement.Reset();
            wallet.Reset();
            transform.position = _startPosition;
        }
    }
}
