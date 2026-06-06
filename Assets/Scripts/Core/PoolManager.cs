
using UnityEngine;

public class PoolManager : MonoBehaviour
{
   [SerializeField] private Weapon.BulletsPool playerBulletPool;
   [SerializeField] private Weapon.BulletsPool enemyBulletPool;
   public static PoolManager Instance { get; private set; }

   public void Awake()
   {
      Instance = this;
   }
   public Bullet GetBullet(Weapon.WeaponData.BulletTypes type)
   {
      return type switch
      {
         Weapon.WeaponData.BulletTypes.Player => playerBulletPool.GetBullet(),
         Weapon.WeaponData.BulletTypes.Enemy => enemyBulletPool.GetBullet(),
         _ => throw new System.ArgumentException($"Тип пули {type} не имеет назначенного пула!")
      };
   }
}
