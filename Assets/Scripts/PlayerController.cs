using System;
using System.Collections;
using System.Collections.Generic;
using Input;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    [SerializeField] private float speed = 6.0f;
    [SerializeField] private float rotationSpeed = 100.0f;
    
    private Vector3 playerVelocity;
    private bool groundedPlayer;

    private InputManager inputManager;

    private void Start()
    {
        inputManager = GetComponent<InputManager>();
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        // Handle Movement
        var move = new Vector3(inputManager.move.x, 0, inputManager.move.y);
        controller.Move(move * (Time.deltaTime * speed));

        // Handle Rotation
        transform.Rotate(0, inputManager.look.x * rotationSpeed * Time.deltaTime, 0);

        // Handle Gravity
        if (!controller.isGrounded)
        {
            playerVelocity.y += Physics.gravity.y * Time.deltaTime;
            controller.Move(playerVelocity * Time.deltaTime);
        }
        else
        {
            playerVelocity.y = 0;
        }
    }
}
