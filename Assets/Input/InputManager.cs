using UnityEditor.Search;
using UnityEngine;
using Weapons;

namespace Input
{
    public class InputManager : MonoBehaviour
    {
        private PlayerControls controls;
        public Vector2 move;
        public Vector2 look;

        private void Awake()
        {
            controls = new PlayerControls();
        
            //Registering callbacks for movement
            controls.Gameplay.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
            controls.Gameplay.Move.canceled += ctx => move = Vector2.zero;

            controls.Gameplay.Look.performed += ctx => look = ctx.ReadValue<Vector2>();
            controls.Gameplay.Look.canceled += ctx => look = Vector2.zero;

            controls.Gameplay.Shoot.performed += ctx => Shoot();
        }

        private void OnEnable()
        {
            controls.Gameplay.Enable();
        }

        private void OnDisable()
        {
            controls.Gameplay.Disable();
        }

        private void Shoot()
        {
            GetComponent<WeaponManager>().ShootWithCurrentWeapon();
            Debug.Log("Shoot action performed");
        }
    }
}
