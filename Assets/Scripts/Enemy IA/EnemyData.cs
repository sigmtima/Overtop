using UnityEngine;

namespace EnemyAI
{
    [CreateAssetMenu(fileName = "EnemyData")]
    public class EnemyData : ScriptableObject
    {
        public float minPatrolRadius;
        public float maxPatrolRadius;
        public float viewRadiusie;
        public float attackRadius;
        public float minMoveInterval;
        public float maxMoveInterval;
        public float enemyHealth;

    }
}
