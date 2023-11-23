using Interfaces;
using UnityEngine;

namespace Weapons
{
    public class Shotgun : MonoBehaviour, IWeapon
    {
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private Transform shootPoint;
        
        public void Shoot()
        {
            Debug.Log("Attempting to shoot with Pistol");
            // Instantiate the bullet at the muzzle's position and orientation
            Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
            
            Debug.Log("Shooting from Shotgun");
            
            // sounds effects, recoil etc.
        }
    }
}
