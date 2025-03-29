using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    private Rigidbody _rigidbody;
    
    [SerializeField] private float _jumpForce;
    
    private bool _isNeedJump = false;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            _isNeedJump = true;
    }

    private void FixedUpdate()
    {
        if (_isNeedJump)
        {
            _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            _isNeedJump = false;
        }
    }
}
