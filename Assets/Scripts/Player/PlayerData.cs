using UnityEngine;
using Weapon;

namespace Player
{
    public class PlayerData : MonoBehaviour
    {
        [SerializeField] private WeaponData playerWeaponData;
        [SerializeField] private PlayerMovementData playerMovementData;
        [SerializeField] private PlayerHealthData playerHealthData;
        [SerializeField] private WeaponData playerWeaponDataStart;
        [SerializeField] private PlayerMovementData playerMovementDataStart;
        [SerializeField] private PlayerHealthData playerHealthDataStart;

        public WeaponData PlayerWeaponData => playerWeaponData;
        public PlayerMovementData PlayerMovementData => playerMovementData;
        public PlayerHealthData PlayerHealthData => playerHealthData;

        public void Start()
        {
            Initialize();
        }

        public void Initialize()
        {
            playerWeaponData.damage = playerWeaponDataStart.damage;
            playerMovementData.walkSpeed = playerMovementDataStart.walkSpeed;
            playerHealthData.Health = playerHealthDataStart.Health;
        }
    
    }
}
