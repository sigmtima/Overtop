using UnityEngine;
using UnityEngine.AI;

namespace Enemy_AI
{
    public class EnemyContext
    {
        public readonly NavMeshAgent Agent;
        public readonly EnemyController Controller;
        public readonly Animator EnemyAnimator;
        
        public EnemyContext(EnemyController controller, Animator enemyAnimator,
             NavMeshAgent agent)
        {
            Controller = controller;
            EnemyAnimator = enemyAnimator;

     
            Agent = agent;
        }
    }
}