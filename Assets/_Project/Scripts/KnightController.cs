using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace LeonBrave{

public class KnightController : MonoBehaviour
{
    
    [SerializeField]
    private Joystick _joystick;

    [SerializeField] private float moveSpeed = 5f;

    private Animator _animator;

    private float _walkSpeed;
    

    private bool isWalking = false;
    private void Awake()
    {
        _animator = transform.GetChild(0).GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        Vector2 inputDirection = _joystick.Direction;

        _walkSpeed = inputDirection.magnitude;
        _animator.SetFloat("WalkSpeed",_walkSpeed);
        Vector3 moveVector = new Vector3(inputDirection.x, 0f, inputDirection.y);

        if (moveVector != Vector3.zero)
        {
            Quaternion newRotation = Quaternion.LookRotation(moveVector, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, 10f * Time.fixedDeltaTime);
            
    
        }
        transform.position += moveVector * moveSpeed * Time.deltaTime;
    }
    }
}


