using System;
using UnityEngine;
using Weapon;

public class PoolManager : MonoBehaviour
{
    [SerializeField] private BulletsPool playerBulletPool;
    [SerializeField] private BulletsPool enemyBulletPool;
    public static PoolManager Instance { get; private set; }

    public void Awake()
    {
        Instance = this;
    }

    public Bullet GetBullet(WeaponData.BulletTypes type)
    {
        return type switch
        {
            WeaponData.BulletTypes.Player => playerBulletPool.GetBullet(),
            WeaponData.BulletTypes.Enemy => enemyBulletPool.GetBullet(),
            _ => throw new ArgumentException($"Тип пули {type} не имеет назначенного пула!")
        };
    }
}