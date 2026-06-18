using UnityEngine;
using UnityEngine.EventSystems;
using Weapon;
using UnityEngine.SceneManagement;

public class PlayerController : StateMachine<PlayerContext>, ITakeDamage
{


    public PlayerMovementData movementData;
    [SerializeField] private InputManager inputManager;
    
    [SerializeField] private PlayerHealth health;
    
    [SerializeField] private DeathScreenUI deathScreenUI;

    [Header("Visuals & Animation Sync")] [SerializeField]
    private Animator bodyAnimator;

   [SerializeField] private PlayerHealthData playerHealthData;
    
    [SerializeField] private Transform visualParent;
    [SerializeField] private float animationSpeed = 1;

    [SerializeField] private Transform bulletTransformPosition;
    private PlayerContext _context;

    private Rigidbody2D _playerRigidbody2D;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        health.Initialize(playerHealthData.Health);
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
    
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
      
        GameObject spawnPoint = GameObject.FindWithTag("SpawnPoint");

        if (spawnPoint != null)
        {
            
            if (_playerRigidbody2D != null)
            {
                _playerRigidbody2D.linearVelocity = Vector2.zero; 
            }
            
            transform.position = spawnPoint.transform.position;
            
            ChangeState(new PlayerIdleState(_context));
        }
    }
    
    public void SetAnimationBool(string name, bool value)
    {
        bodyAnimator.SetBool(name, value);
    }

    public void TakeDamage(float damage)
    {
        Debug.Log("Я ИГРОК И ПОЛУЧИЛ СТОЛЬКО" + damage);
        health.TakeDamage(damage);
        Debug.Log("Мое здоровье -"+ health.CurrentHealth);
        if (health.CurrentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Time.timeScale = 0f;
        deathScreenUI.OnScreenChange();
    }
}