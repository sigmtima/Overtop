using UnityEngine;

public class PlayerIdleState : BaseState<PlayerContext>
{
    public PlayerIdleState(PlayerContext context) : base(context)
    {
    }

    public override void Enter()
    {
        Context.Controller.SetAnimationBool("isMoving", false);
    }

    public override void Exit()
    {
    }

    public override void Update()
    {
        if (Context.InputManager.MoveInput.x != 0 || Context.InputManager.MoveInput.y != 0)
            Context.Controller.ChangeState(new PlayerMoveState(Context));
    }

    public override void FixedUpdate()
    {
        Context.Rb.linearVelocity = new Vector2(0, 0);
    }
}