using UnityEngine;
using Weapon;

public class EnemyWeaponHandler : MonoBehaviour
{
    [SerializeField] private WeaponController weaponController;

    public void Attack(Vector3 direction)
    {
        weaponController.TryShoot(direction);
    }
}
