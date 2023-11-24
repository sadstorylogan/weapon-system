using System;
using UnityEditor.Search;
using UnityEngine;

namespace Input
{
    public class InputManager : MonoBehaviour
    {
        public event Action OnShoot;
        
        private PlayerControls controls;
        
        public Vector2 move;
        public Vector2 look;
        public bool shoot;

        private void Awake()
        {
            controls = new PlayerControls();
        
            //Registering callbacks for movement
            controls.Gameplay.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
            controls.Gameplay.Move.canceled += ctx => move = Vector2.zero;

            controls.Gameplay.Look.performed += ctx => look = ctx.ReadValue<Vector2>();
            controls.Gameplay.Look.canceled += ctx => look = Vector2.zero;

            controls.Gameplay.Shoot.performed += ctx => OnShoot?.Invoke();
        }

        private void OnEnable()
        {
            controls.Gameplay.Enable();
        }

        private void OnDisable()
        {
            controls.Gameplay.Disable();
        }
    }
}
