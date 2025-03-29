using System;
using UnityEngine;

namespace MyAssets.Scripts
{
    public class Platform : MonoBehaviour
    {
        private const string HorizontalAxis = "Horizontal";
        private const string VerticalAxis = "Vertical";
        private const float MinMove = 0.05f;
        
        [SerializeField] private float _rotationSpeed;
        [SerializeField] private float _maxAngle;

        private float _currentRotationX;
        private float _currentRotationZ;
        
        private Quaternion _startRotation;

        private void Awake()
        {
            _startRotation = transform.rotation;
        }

        private void Update()
        {
            float inputX = -Input.GetAxis(VerticalAxis);
            float inputZ = Input.GetAxis(HorizontalAxis);

            if (new Vector3(inputX, 0, inputZ).magnitude < MinMove)
                return;
            
            _currentRotationX += inputX * _rotationSpeed * Time.deltaTime;
            _currentRotationZ += inputZ * _rotationSpeed * Time.deltaTime;
            
            _currentRotationX = Mathf.Clamp(_currentRotationX, -_maxAngle, _maxAngle);
            _currentRotationZ = Mathf.Clamp(_currentRotationZ, -_maxAngle, _maxAngle);

            transform.rotation = Quaternion.Euler(_currentRotationX, 0, _currentRotationZ);
        }

        public void Reset()
        {
            transform.rotation = _startRotation;
            _currentRotationX = 0;
            _currentRotationZ = 0;
        }
    }
}
