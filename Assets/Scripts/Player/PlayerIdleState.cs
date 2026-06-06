using Unity.VisualScripting;
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
        if (Input.GetAxis("Horizontal") != 0f || Input.GetAxis("Vertical") != 0f)
        {
            Context.Controller.ChangeState(new PlayerMoveState(Context));
        }
    }

    public override void FixedUpdate()
    {
        Context.Rb.linearVelocity = new Vector2(0, 0);
    }
}