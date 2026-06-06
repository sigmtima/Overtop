using UnityEngine;
using System.Collections.Generic;

namespace Weapon
{
    public class BulletsPool : MonoBehaviour, IBulletProvider

    {
  
        [SerializeField] private GameObject prefab;                       




        [SerializeField] private int poolSize = 55;
        Stack<Bullet> _bulletPool = new Stack<Bullet>(100);



        public void Awake()
        {
            Initialize();
        }
        public Bullet GetBullet()
        {



            if (_bulletPool.Count > 0)
            {
                {
                    Bullet bullet = _bulletPool.Pop();

                   
                    
                    return bullet;
                    

                }
           


            }

            if (_bulletPool.Count == 0)
            {
             Bullet createdBullet = CreateBullet();
             
             return createdBullet;
            }
            return null;
            
            


        }

        public void Initialize()
        {
            for (int i = 0; i < poolSize; i++)
            {
                GameObject createdBullet = Instantiate(prefab, transform.position, Quaternion.identity);
                createdBullet.SetActive(false);
                Bullet bulletScript = createdBullet.GetComponent<Bullet>();
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
            GameObject createdBullet = Instantiate(prefab, transform.position, Quaternion.identity);
            createdBullet.SetActive(false);
            Bullet bulletScript = createdBullet.GetComponent<Bullet>();
            bulletScript.SetProvider(this);
            return bulletScript;
        }
    }


}

