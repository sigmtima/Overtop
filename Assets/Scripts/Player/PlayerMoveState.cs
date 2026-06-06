using UnityEngine;

public class PlayerMoveState : BaseState<PlayerContext>
{
    private PlayerMovementData _data;
    private Vector2 _currentVelocity;
    private Vector2 _direction;
    private float _inputX;
    private float _inputY;

    public PlayerMoveState(PlayerContext context) : base(context) { }

    public override void Enter()
    {
        _data = Context.Controller.movementData;
        _currentVelocity = Context.Rb.linearVelocity;
        Context.Controller.SetAnimationBool("isMoving", true);
    }

    public override void Update()
    {
        _inputX = Input.GetAxis("Horizontal");
        _inputY = Input.GetAxis("Vertical");

        _direction = new Vector2(_inputX, _inputY).normalized;

        if (_inputX == 0f && _inputY == 0f )
        {
            Context.Controller.ChangeState(new PlayerIdleState(Context));
        }
    }

    public override void FixedUpdate()
    {
        Vector2 targetVelocity = _direction * _data.walkSpeed;
        float currentSpeedDiff = (_direction.magnitude > 0f) ? _data.acceleration : _data.deceleration;

        _currentVelocity = Vector2.MoveTowards(_currentVelocity, targetVelocity, currentSpeedDiff * Time.fixedDeltaTime);
        Context.Rb.linearVelocity = _currentVelocity;
    }

    public override void Exit()
    {
    }
}