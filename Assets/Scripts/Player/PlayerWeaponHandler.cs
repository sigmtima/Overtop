using UnityEngine;

namespace Player
{
    public class PlayerWeaponHandler : MonoBehaviour
    {
        [SerializeField] private Weapon.WeaponController weaponController;
        [SerializeField] private InputManager inputManager;

        public void Attack()
        {
            var mouseWorld =
                Camera.main.ScreenToWorldPoint(inputManager.MousePosition);
       
            var bulletDirection = (Vector2)mouseWorld - (Vector2)transform.position;
            bulletDirection = bulletDirection.normalized;
            weaponController.TryShoot(bulletDirection);
       
        }

        public void OnEnable()
        {
            inputManager.ShootPressed += Attack;
        }

        public void OnDisable()
        {
            inputManager.ShootPressed-= Attack;
        }
    }
}
