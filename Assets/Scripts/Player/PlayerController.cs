using UnityEngine;
using UnityEngine.EventSystems;
using Weapon;

public class PlayerController : StateMachine<PlayerContext>
{


    public PlayerMovementData movementData;
    [SerializeField] private InputManager inputManager;

    

    

    [Header("Visuals & Animation Sync")] [SerializeField]
    private Animator bodyAnimator;

   
    [SerializeField] private Transform visualParent;
    [SerializeField] private float animationSpeed = 1;

    [SerializeField] private Transform bulletTransformPosition;
    private PlayerContext _context;

    private Rigidbody2D _playerRigidbody2D;

    private void Awake()
    {
        _playerRigidbody2D = GetComponent<Rigidbody2D>();
        _context = new PlayerContext(this, _playerRigidbody2D, bodyAnimator,inputManager);

        if (_playerRigidbody2D == null) Debug.LogError("Rigidbody2D не найден на объекте!");
    

        if (visualParent == null) visualParent = transform;
    }

    private void Start()
    {
        ChangeState(new PlayerIdleState(_context));
        bodyAnimator.speed = animationSpeed;

     
    }


    
    public void SetAnimationBool(string name, bool value)
    {
        bodyAnimator.SetBool(name, value);

  
    }
}