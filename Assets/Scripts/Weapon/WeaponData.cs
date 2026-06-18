using UnityEngine;
using UnityEngine.Serialization;

namespace Weapon
{
    [CreateAssetMenu(menuName = "Weapon", fileName = "WeaponData")]
    public class WeaponData : ScriptableObject
    {
        public enum BulletTypes
        {
            Player,
            Enemy,
        }

        [field: FormerlySerializedAs("<bulletType>k__BackingField")] [field: SerializeField] public BulletTypes BulletType { get; private set; }
        [field: SerializeField] public GameObject weaponPrefab { get; private set; }
        [field: SerializeField] public GameObject bulletPrefab { get; private set; }
        public float damage;
        [field: SerializeField] public float bulletDistance { get; private set; }
        [field: SerializeField] public float bulletSpeed { get; private set; }
        [field: SerializeField] public float reloadTime { get; private set; }
        [field: SerializeField] public int magazineSize { get; private set; }
        [field: FormerlySerializedAs("<_attackCooldown>k__BackingField")] [field: SerializeField] public float attackCooldown { get; private set; }
    }
}