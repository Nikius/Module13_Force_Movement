using System;
using UnityEngine;

namespace MyAssets.Scripts
{
    public class Movement : MonoBehaviour
    {
        private const string HorizontalAxis = "Horizontal";
        private const string VerticalAxis = "Vertical";
        private const float MinMove = 0.05f;
        
        [SerializeField] private float _speed;

        private Rigidbody _rigidbody;
        private Vector3 _startPosition;
        private Vector3 _direction = Vector3.zero;
        private bool _isMove = false;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _startPosition = transform.position;
        }

        private void Update()
        {
            if (_isMove)
                return;
            
            float inputX = -Input.GetAxis(HorizontalAxis);
            float inputZ = -Input.GetAxis(VerticalAxis);

            if (new Vector3(inputX, 0, inputZ).magnitude >= MinMove)
            {
                _isMove = true;
                _direction = new Vector3(inputX, 0, inputZ).normalized;
            }
        }

        private void FixedUpdate()
        {
            if (_isMove)
            {
                _rigidbody.AddForce(_direction * _speed, ForceMode.Acceleration);
                _isMove = false;
            }
        }

        public void Reset()
        {
            transform.position = _startPosition;
            _isMove = false;
        }
    }
}
