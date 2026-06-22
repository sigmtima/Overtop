using UnityEngine;
using UnityEngine.Serialization;

namespace Enemy_AI
{
    [CreateAssetMenu(fileName = "EnemyData")]
    public class EnemyData : ScriptableObject
    {
        public float minPatrolRadius;
        public float maxPatrolRadius;
        [FormerlySerializedAs("viewRadiusie")] public float viewRadius;
        public float attackRadius;
        public float minMoveInterval;
        public float maxMoveInterval;
        public float enemyHealth;
    }
}