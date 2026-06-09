using JetBrains.Annotations;
using UnityEngine;

public class PlayerContext
{
    public readonly PlayerController Controller;
    public readonly Animator PlayerAnimator;
    public readonly Rigidbody2D Rb;
    public InputManager InputManager;

    public PlayerContext(PlayerController controller, Rigidbody2D rb, [CanBeNull] Animator playerAnimator, InputManager inputManager)
    {
        Controller = controller;
        Rb = rb;
        PlayerAnimator = playerAnimator;
        InputManager = inputManager;
    }
}