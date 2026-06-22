using Core;
using UnityEngine;

namespace Player
{
    public class PlayerMoveState : BaseState<PlayerContext>
    {
        private Vector2 _currentVelocity;
        private MovementData _data;
    
        public PlayerMoveState(PlayerContext context) : base(context)
        {
        }

        public override void Enter()
        {
            _data = Context.Controller.PlayerData.MovementData;
            _currentVelocity = Context.Rb.linearVelocity;
            Context.Controller.SetAnimationBool("isMoving", true);
        }

        public override void Update()
        {
            if (Context.InputManager.MoveInput.x == 0f && Context.InputManager.MoveInput.y == 0f) Context.Controller.ChangeState(Context.Controller.IdleState);
        }

        public override void FixedUpdate()
        {
            var targetVelocity = Context.InputManager.MoveInput * _data.walkSpeed;
            var currentSpeedDiff = Context.InputManager.MoveInput.magnitude > 0f ? _data.acceleration : _data.deceleration;

            _currentVelocity =
                Vector2.MoveTowards(_currentVelocity, targetVelocity, currentSpeedDiff * Time.fixedDeltaTime);
            Context.Rb.linearVelocity = _currentVelocity;
        }

        public override void Exit()
        {
        }
    }
}