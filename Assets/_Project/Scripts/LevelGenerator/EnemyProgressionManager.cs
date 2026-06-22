using Enemy_AI;
using UnityEngine;

namespace LevelGenerator
{
    public class EnemyProgressionManager : MonoBehaviour
    {
        [SerializeField] private EnemyRuntimeData enemyData;
        [SerializeField] private float healthMultiplier = 1.1f;
        [SerializeField] private float damageMultiplier = 1.05f;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }
        
        private void OnEnable()
        {
                LevelManager.Instance.OnDifficultyIncreased += UpgradeEnemies;
        }
    
        private void OnDisable()
        {
            if (LevelManager.Instance != null)
                LevelManager.Instance.OnDifficultyIncreased -= UpgradeEnemies;
        }

        private void UpgradeEnemies()
        {
            enemyData.EnemyData.enemyHealth*= healthMultiplier;
            enemyData.WeaponData.damage *= damageMultiplier;
        }
    }
}
