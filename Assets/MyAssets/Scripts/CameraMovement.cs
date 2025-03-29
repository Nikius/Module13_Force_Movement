using System;
using UnityEngine;

namespace MyAssets.Scripts
{
    public class CameraMovement : MonoBehaviour
    {
        private const string MouseScrollWheelAxis = "Mouse ScrollWheel";
        private const float MinScrollValue = 0.05f;
        
        [SerializeField] private Transform _target;
        [SerializeField] private float _sensitivity;
        
        private Camera _camera;
        private Vector3 _cameraOffset;
        private Vector3 _targetOffset;

        private void Awake()
        {
            _camera = Camera.main;
            _cameraOffset = transform.position - _target.position;
        }

        private void LateUpdate()
        {
            Move();

            float scrollWheelChange = Input.GetAxis(MouseScrollWheelAxis);
            
            if (Mathf.Abs(scrollWheelChange) >= MinScrollValue)
                Zoom(scrollWheelChange);
        }

        private void Zoom(float scrollWheelChange)
        {
            _cameraOffset += _camera.transform.forward * (scrollWheelChange * _sensitivity);
        }

        private void Move()
        {
            transform.position = _target.position + _cameraOffset;
        }
    }
}
