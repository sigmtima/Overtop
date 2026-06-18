using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

namespace Weapon
{
    public class WeaponController : MonoBehaviour
    {
        [field: SerializeField] 
        public WeaponData WeaponData { get; private set; }
        private int _currentAmmo;
        private bool _isReloading;

        private float _nextAttackTime;

        public void Start()
        {
            if (WeaponData == null)
            {
                Debug.LogError("WeaponData missing");
                enabled = false;
                return;
            }
            _currentAmmo = WeaponData.magazineSize;
        }

        public void TryShoot(Vector2 direction)
        {
            if (_isReloading || _currentAmmo <= 0)
            {
                StartReload();
                return;
            }

            if (Time.time >= _nextAttackTime)
            {
                var bullet = PoolManager.Instance.GetBullet(WeaponData.BulletType);
                
                if (bullet == null) return;
                
                bullet.Setup(WeaponData.bulletDistance, WeaponData.damage, transform.position, direction,
                    WeaponData.bulletSpeed);
                
                    _currentAmmo--;
                    _nextAttackTime = Time.time + WeaponData.attackCooldown;
                
            }
        }

        private void StartReload()
        {
            if (_isReloading || _currentAmmo == WeaponData.magazineSize) return;

            StartCoroutine(ReloadRoutine());
        }

        private IEnumerator ReloadRoutine()
        {
            _isReloading = true;
            yield return new WaitForSeconds(WeaponData.reloadTime);
            _currentAmmo = WeaponData.magazineSize;
            _isReloading = false;
        }
    }
}