using UnityEngine;

namespace EnemyAI
{
    public class EnemyChaseState : BaseState<EnemyContext>
    {
        private readonly float _nextPathUpdateInterval = 0.2f;
        private float _nextPathUpdateTime;

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
                _nextPathUpdateTime = Time.time + _nextPathUpdateInterval;
            }
        }

        public override void Exit()
        {
        }
    }
}