using UnityEngine;

public class PlayerMoveState : BaseState<PlayerContext>
{
    private Vector2 _currentVelocity;
    private PlayerMovementData _data;

  

    public PlayerMoveState(PlayerContext context) : base(context)
    {
    }

    public override void Enter()
    {
        _data = Context.Controller.movementData;
        _currentVelocity = Context.Rb.linearVelocity;
        Context.Controller.SetAnimationBool("isMoving", true);
    }

    public override void Update()
    {
        
 
       

        if (Context.InputManager.MoveInput.x == 0f && Context.InputManager.MoveInput.y == 0f) Context.Controller.ChangeState(new PlayerIdleState(Context));
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