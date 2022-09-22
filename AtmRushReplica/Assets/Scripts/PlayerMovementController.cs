using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float horizontalSpeed;
    [SerializeField] private float horizontalLimit;
    private float _horizontal;


    private void Update()
    {
        HorizontalMovementInput();
        ForwardMovement();
    }

    private void HorizontalMovementInput()
    {
        float _newX;
        
        if (Input.GetMouseButton(0))
        {
            _horizontal = Input.GetAxisRaw("Mouse X");      
        }
        
        _newX = transform.position.x + _horizontal * horizontalSpeed * Time.deltaTime;
        _newX = Math.Clamp(_newX, -horizontalLimit, horizontalLimit);

        transform.position = new Vector3(
            _newX,
            transform.position.y,
            transform.position.z
        );
    }

    private void ForwardMovement()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }
}
