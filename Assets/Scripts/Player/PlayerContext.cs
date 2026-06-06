using UnityEngine;

public class PlayerContext
{
 
  public readonly PlayerController Controller;
  public readonly Rigidbody2D Rb;
  public readonly Animator PlayerAnimator;
    public PlayerContext(PlayerController controller, Rigidbody2D rb, Animator playerAnimator)
    {
        Controller = controller;
        Rb = rb;
        PlayerAnimator = playerAnimator;
    }
   
}  
