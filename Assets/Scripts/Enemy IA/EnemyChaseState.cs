using UnityEngine;

namespace EnemyAI
{
    public class EnemyChaseState : BaseState<EnemyContext>
    {
        private float _nextPathUpdateTime;
        private float _nextPathUpdateInterval = 0.2f ;
        public EnemyChaseState(EnemyContext context) : base(context)
        {

        }

        public override void Enter()
        {
           _nextPathUpdateTime = Time.time;
        }

        public override void FixedUpdate()
        {

        }

        public override void Update()
        {
            if (_nextPathUpdateTime < Time.time)
            {
                Context.Controller.ApproachPlayer();
                Context.Controller.AttackPlayer();
                _nextPathUpdateTime = Time.time +  _nextPathUpdateInterval;
            }
          

        }

        public override void Exit()
        {

        }

    }
}
