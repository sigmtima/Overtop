using System.Collections.Generic;
using Core;
using UnityEngine;

namespace Weapon
{
    public class BulletPool : MonoBehaviour, IBulletProvider

    {
        [SerializeField] private GameObject prefab;
        [SerializeField] private int poolSize = 55;
        private readonly Stack<Bullet> _bulletPool = new(100);

        public void Awake()
        {
            Initialize();
        }

        public Bullet GetBullet()
        {
            if (_bulletPool.Count > 0)
            {
                var bullet = _bulletPool.Pop();

                return bullet;
            }
            
            return CreateBullet();
        }

        public void Initialize()
        {
            for (var i = 0; i < poolSize; i++)
            {
                var createdBullet = Instantiate(prefab, transform.position, Quaternion.identity);
                createdBullet.SetActive(false);
                var bulletScript = createdBullet.GetComponent<Bullet>();
                bulletScript.SetProvider(this);
                _bulletPool.Push(bulletScript);
            }
        }

        public void Release(Bullet bullet)
        {
            bullet.gameObject.SetActive(false);

            _bulletPool.Push(bullet);
        }

        public Bullet CreateBullet()
        {
            var createdBullet = Instantiate(prefab, transform.position, Quaternion.identity);
            createdBullet.SetActive(false);
            var bulletScript = createdBullet.GetComponent<Bullet>();
            bulletScript.SetProvider(this);
            return bulletScript;
        }
    }
}