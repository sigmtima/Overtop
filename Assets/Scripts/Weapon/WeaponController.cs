using System.Collections;
using UnityEngine;


namespace Weapon{
public class WeaponController : MonoBehaviour
{
      [SerializeField] private BulletsPool bulletsPoolObject;

      public WeaponData WeaponData;
    private int _currentAmmo;
    private bool _isReloading;

    private float _nextAttackTime;

   
    public void Start()
    {
   
        _currentAmmo = WeaponData.magazineSize;
       
        
        
    }

    public void TryShoot(Vector2 direction)
    {

        if (_isReloading == true || _currentAmmo <= 0)
        {
            StartReload();
            return;
        }


        if (Time.time >= _nextAttackTime)
        {
          

            Bullet bullet = PoolManager.Instance.GetBullet(WeaponData.bulletType);
         
         


            
            bullet.Setup(WeaponData.bulletDistance,  WeaponData.damage,transform.position, direction,WeaponData.bulletSpeed);

            if (bullet.Rb != null)
            {
                _currentAmmo--;
                _nextAttackTime = Time.time + WeaponData._attackCooldown;
            }
        }
    }

    private void StartReload()
    {
        if (_isReloading || _currentAmmo == WeaponData.magazineSize)
        {
            return;
        }

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

