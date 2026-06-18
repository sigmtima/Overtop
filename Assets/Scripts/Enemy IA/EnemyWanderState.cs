using UnityEngine;

namespace Enemy_AI
{
    public class EnemyWanderState : BaseState<EnemyContext>
    {

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
                Context.Controller.TryDetectPlayer();
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
         
            Context.Controller.MoveTo(target);
            _nextWanderTime = Time.time + Random.Range(Context.Controller.Data.minMoveInterval,
                Context.Controller.Data.maxMoveInterval);
        }
    }
}