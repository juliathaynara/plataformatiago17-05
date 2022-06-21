using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class playerControle : MonoBehaviour
{
    private Controls _gameControls;
    private PlayerInput _playerInput;
    private Camera _mainCamera;
    private Vector2 _moveInput;
    private Rigidbody _rigidbody;
    private bool _isGrounded;
    
    public float moveMultiplier;
    
    public float maxVelocity;
    
    public float rayDistance;
    
    public LayerMask layerMask;
    
    //public jumpForce;
    
    private void OnEnable()
    {
        _rigidbody = GetComponent<Rigidbody>();
        
        _gameControls = new Controls ();
        
        _playerInput = GetComponent <PlayerInput> ();
        
        _mainCamera = Camera.main;

        _playerInput.onActionTriggered += OnActionTriggered;
        
    }

    private void OnDisable()
    {
        _playerInput.onActionTriggered -= OnActionTriggered;
        
    }

    private void OnActionTriggered(InputAction.CallbackContext obj)
    {
        if (obj.action.name.CompareTo(_gameControls.Gameplay.Move.name) == 0)
        {
            _moveInput = obj.ReadValue<Vector2>();
        }
        //if (obj).Action.name
    }

    private void Move()
    {
        Vector3 camForward = _mainCamera.transform.forward;
        Vector3 camRight = _mainCamera.transform.right;
        camForward.y = 0;
        camRight.y = 0;
       _rigidbody.AddForce((_mainCamera.transform.forward * _moveInput.y + _mainCamera.transform.right * _moveInput.x) * (float) moveMultiplier * Time.deltaTime); 
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void LimitVerlocity()
    {
        Vector3 velocity = _rigidbody.velocity;

        if (Mathf.Abs(velocity.x) > maxVelocity) velocity.x = Mathf.Sign(velocity.x) * maxVelocity;
        if (Mathf.Abs(velocity.z) > maxVelocity) velocity.z = Mathf.Sign(velocity.z) * maxVelocity;

        _rigidbody.velocity = velocity;
    }
    
     
    
    
    
    
    
    
    
}
