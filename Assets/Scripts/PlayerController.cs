using System;
using System.Collections;
using System.Collections.Generic;
using Input;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    [SerializeField] private float speed = 6.0f;
    [SerializeField] private float smoothTime = 0.1f;
    
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float turnSmoothVelocity;

    private InputManager inputManager;
    private Shoot shootAction;

    private void Start()
    {
        inputManager = GetComponent<InputManager>();
        controller = GetComponent<CharacterController>();
        shootAction = GetComponent<Shoot>();
        inputManager.OnShoot += HandleShoot;
    }

    private void Update()
    {
        // Handle Movement
        var move = new Vector3(inputManager.move.x, 0, inputManager.move.y);
        controller.Move(move * (Time.deltaTime * speed));

        // Handle Smooth Rotation
        if (inputManager.look.sqrMagnitude >= 0.1f)
        {
            var targetAngle = Mathf.Atan2(inputManager.look.x, inputManager.look.y) * Mathf.Rad2Deg;
            var angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, smoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
        }

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

    private void HandleShoot()
    {
        shootAction.ShootAction();
    }

    private void OnDestroy()
    {
        if (inputManager != null)
        {
            inputManager.OnShoot -= HandleShoot;
        }
    }
}
