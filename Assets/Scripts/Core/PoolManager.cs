using System;
using UnityEngine;
using UnityEngine.Serialization;
using Weapon;

public class PoolManager : MonoBehaviour
{
    [SerializeField] private BulletPool playerBulletPool;
    [SerializeField] private BulletPool enemyBulletPool;
    public static PoolManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        
        Instance = this;
    }

    public Bullet GetBullet(WeaponData.BulletTypes type)
    {
        return type switch
        {
            WeaponData.BulletTypes.Player => playerBulletPool.GetBullet(),
            WeaponData.BulletTypes.Enemy => enemyBulletPool.GetBullet(),
        };
    }
}