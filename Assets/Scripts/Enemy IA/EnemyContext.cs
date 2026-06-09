using UnityEngine;
using UnityEngine.AI;

namespace EnemyAI
{
    public class EnemyContext
    {
        public readonly NavMeshAgent Agent;

        public readonly EnemyController Controller;
        public readonly Animator EnemyAnimator;
        public readonly Transform PlayerTransform;
        public readonly Rigidbody2D Rb;

        public EnemyContext(EnemyController controller, Rigidbody2D rb, Animator enemyAnimator,
            Transform playerTransform, NavMeshAgent agent)
        {
            Controller = controller;
            Rb = rb;
            EnemyAnimator = enemyAnimator;

            PlayerTransform = playerTransform;
            Agent = agent;
        }
    }
}