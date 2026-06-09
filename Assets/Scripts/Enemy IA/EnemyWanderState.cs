using UnityEngine;

namespace EnemyAI
{
    public class EnemyWanderState : BaseState<EnemyContext>
    {
        private Vector2 _currentTarget;
        private readonly float _nextCheckUpdateInterval = 1f;
        private float _nextCheckUpdateTime;
        private float _nextWanderTime;

        public EnemyWanderState(EnemyContext context) : base(context)
        {
        }

        public override void FixedUpdate()
        {
        }

        public override void Enter()
        {
            _nextCheckUpdateTime = Time.time;

            Wander();
        }

        public override void Exit()
        {
        }

        public override void Update()
        {
            if (_nextCheckUpdateTime <= Time.time)
            {
                Context.Controller.CheckPlayer();
                _nextCheckUpdateTime = Time.time + _nextCheckUpdateInterval;
            }

            if (!Context.Agent.pathPending && Context.Agent.remainingDistance <= Context.Agent.stoppingDistance)
                if (Time.time > _nextWanderTime)
                    Wander();
        }

        private void Wander()
        {
            var target = (Vector2)Context.Controller.transform.position + Random.insideUnitCircle *
                Random.Range(
                    Context.Controller.Data
                        .minPatrolRadius,
                    Context.Controller.Data
                        .maxPatrolRadius);
            _currentTarget = target;
            Context.Controller.agent.SetDestination(target);
            _nextWanderTime = Time.time + Random.Range(Context.Controller.Data.minMoveInterval,
                Context.Controller.Data.maxMoveInterval);
        }
    }
}