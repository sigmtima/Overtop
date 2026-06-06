using UnityEngine;
using Weapon;

public class PlayerController : StateMachine<PlayerContext>
{
    [Header("References")]
    public Transform cameraTransform;
    public PlayerMovementData movementData;

    [field:SerializeField] public WeaponController weaponController { get; private set; }

    [Header("Visuals & Animation Sync")]
    [SerializeField] private Animator bodyAnimator;
    [SerializeField] private Animator weaponAnimator;
    [SerializeField] private Transform visualParent;   

    private Rigidbody2D _playerRigidbody2D;
    private PlayerContext _context;
    [SerializeField] private float speed = 1;
    
    [SerializeField] private Transform bulletTransformPosition;

    private void Awake()
    {
        _playerRigidbody2D = GetComponent<Rigidbody2D>();
        _context = new PlayerContext(this, _playerRigidbody2D, bodyAnimator);

        if (_playerRigidbody2D == null) Debug.LogError("Rigidbody2D не найден на объекте!");
        if (cameraTransform == null) cameraTransform = GetComponentInChildren<Camera>()?.transform;
        
     
        if (visualParent == null) 
        {
         
            visualParent = transform;
        }
    }

    void Start()
    {
        ChangeState(new PlayerIdleState(_context));
        bodyAnimator.speed = speed;
        
  
        if (weaponAnimator != null) weaponAnimator.speed = speed;
    }

    protected override void Update()
    {
        base.Update();
        

        HandleMouseFlip();

        if (Input.GetMouseButton(0))
        {
            Vector2 bulletDirection = Inputs.mouseWorldPos - (Vector2)transform.position;
            bulletDirection = bulletDirection.normalized;
            weaponController.TryShoot(bulletDirection);
        }
    }

    private void HandleMouseFlip()
    {
        if (Camera.main == null) return;

 
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

 
        Vector3 lookDirection = mousePosition - transform.position;

     
        if (lookDirection.x > 0f)
        {
            visualParent.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (lookDirection.x < 0f)
        {
            visualParent.localScale = new Vector3(-1f, 1f, 1f);
        }
    }

    public void SetAnimationBool(string name, bool value)
    {
        // Передаем параметр в аниматор тела
        bodyAnimator.SetBool(name, value);
        
        // Дублируем этот же параметр в аниматор оружия, чтобы они шли синхронно
        if (weaponAnimator != null)
        {
            weaponAnimator.SetBool(name, value);
        }
    }
}