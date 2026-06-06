
using UnityEngine;

namespace Weapon
{
  [CreateAssetMenu(menuName = "Weapon", fileName = "WeaponData")]

  public class WeaponData : ScriptableObject
  { 
    public enum BulletTypes{Player, Enemy, Neutural} 

    [field:SerializeField] public BulletTypes bulletType { get; private set; }
    [field:SerializeField] public GameObject weaponPrefab { get; private set; }
    [field:SerializeField] public GameObject bulletPrefab { get; private set; }
    [field:SerializeField] public float fireRate { get; private set; }
    public float damage; 
    [field:SerializeField] public float bulletDistance  { get; private set; }
    [field:SerializeField] public float bulletSpeed  { get; private set; }
    [field: SerializeField] public float reloadTime  {get; private set; }
    [field: SerializeField] public int magazineSize  {get; private set; }
    [field: SerializeField] public float _attackCooldown {get; private set; }
    

  }
}

