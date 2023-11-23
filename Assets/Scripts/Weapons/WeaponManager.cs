using Interfaces;
using UnityEngine;

namespace Weapons
{
    public class WeaponManager : MonoBehaviour
    {
        // handle equipping, switching, and using weapons
        // this class can hold a reference to the currently equipped weapon.

        private IWeapon currentWeapon;

        public void EquipWeapon(IWeapon weapon)
        {
            currentWeapon = weapon;
            Debug.Log("Equipped weapon: ");
            // other logic for equipping the weapon
        }

        public void ShootWithCurrentWeapon()
        {
            if (currentWeapon != null)
            {
                currentWeapon.Shoot();
                Debug.Log("Player is shooting with shotgun");
            }
        }
    }
}
