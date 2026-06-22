using Enemy_AI;
using UnityEngine;
using Weapon;

namespace Enemy_AI
{
    public class EnemyRuntimeData : MonoBehaviour
    {
        [SerializeField] private EnemyData startEnemyData;
        [SerializeField] private EnemyData enemyData;
        [SerializeField] private WeaponData startWeaponData;
        [SerializeField]  private WeaponData weaponData;
        public EnemyData EnemyData => enemyData;
        public WeaponData WeaponData => weaponData;
        
        private void Awake()
        {
            Initialize();
        }

        private void Initialize()
        {
            enemyData.enemyHealth = startEnemyData.enemyHealth;
            weaponData.damage = startWeaponData.damage;
        }
    }
}
