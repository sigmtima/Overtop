using UnityEngine;
using UnityEngine.InputSystem;
using System;
[DefaultExecutionOrder(-100)]
public class InputManager : MonoBehaviour
{
    private Controls _controls;

    public Vector2 MoveInput { get; private set; }
    public Vector2 MousePosition { get; private set; }

    public event Action ShootPressed;
    public event Action ShootReleased;

    private void Awake()
    {

        _controls = new Controls();
    }

    private void OnEnable()
    {
        _controls.Enable();

        _controls.Player.Move.performed += OnMove;
        _controls.Player.Move.canceled += OnMove;

        _controls.Player.Attack.started += OnShootStarted;
        _controls.Player.Attack.canceled += OnShootCanceled;
    }

    private void OnDisable()
    {
        _controls.Player.Move.performed -= OnMove;
        _controls.Player.Move.canceled -= OnMove;

        _controls.Player.Attack.started -= OnShootStarted;
        _controls.Player.Attack.canceled -= OnShootCanceled;
    }

    private void Update()
    {
        MousePosition = Mouse.current.position.ReadValue();
    }

    private void OnMove(InputAction.CallbackContext ctx)
    {
        MoveInput = ctx.ReadValue<Vector2>();
    }

    private void OnShootStarted(InputAction.CallbackContext ctx)
    {
        ShootPressed?.Invoke();
    }

    private void OnShootCanceled(InputAction.CallbackContext ctx)
    {
        ShootReleased?.Invoke();
    }
}