using UnityEngine;
using UnityEngine.AI;

namespace EnemyAI
{
    public class EnemyContext
    {

        public readonly EnemyAI.EnemyController Controller;
        public readonly Rigidbody2D Rb;
        public readonly Animator EnemyAnimator;
        public readonly Transform PlayerTransform;
        public readonly NavMeshAgent Agent;

        public EnemyContext(EnemyAI.EnemyController controller, Rigidbody2D rb, Animator enemyAnimator,
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
