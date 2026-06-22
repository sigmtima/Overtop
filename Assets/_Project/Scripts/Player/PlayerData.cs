using UnityEngine;
using UnityEngine.Serialization;
using Weapon;

namespace Player
{
    public class PlayerData : MonoBehaviour
    {
        [SerializeField] private WeaponData playerWeaponData;
         private MovementData _movementData;
         private PlayerHealthData _playerHealthData;
        [SerializeField] private WeaponData playerWeaponDataStart;
        [FormerlySerializedAs("playerMovementDataStart")] [SerializeField] private MovementData movementDataStart;
        [SerializeField] private PlayerHealthData playerHealthDataStart;

        public WeaponData PlayerWeaponData => playerWeaponData;
        public MovementData MovementData => _movementData;
        public PlayerHealthData PlayerHealthData => _playerHealthData;

        public void Awake()
        {
            Initialize();
        }

        public void Initialize()
        {
            playerWeaponData.damage = playerWeaponDataStart.damage;
            _movementData = Instantiate(movementDataStart);
            _playerHealthData = Instantiate(playerHealthDataStart);
        }
    
    }
}
