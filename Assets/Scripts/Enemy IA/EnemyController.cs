using System;
using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using UnityEngine.Serialization;
using Weapon;
using Random = UnityEngine.Random;


namespace EnemyAI
{


    public class EnemyController : StateMachine<EnemyContext>, ITakeDamage
    {

        private Rigidbody2D _rb;
        [SerializeField] private Animator enemyAnimator;

        [FormerlySerializedAs("PlayerTransform")]
        public Transform playerTransform;

        private EnemyContext _context;
        [field: SerializeField] public EnemyData Data { get; private set; }
        public NavMeshAgent agent;
        private float _currentHealth;

        public static event System.Action<Vector3> OnEnemyDeath;
         [SerializeField] private LayerMask playerMask;
        private Vector2 _currentTarget;

        [SerializeField] private WeaponController weaponController;

      public EnemyChaseState enemyChaseState { get; private set; }
      public EnemyWanderState enemyWanderState  { get; private set; }
        public void Awake()
        {
         
            _currentHealth = Data.enemyHealth;
            agent.updateRotation = false;
            agent.updateUpAxis = false;

            
            
            _rb = GetComponent<Rigidbody2D>();
            _context = new EnemyContext(this, _rb, enemyAnimator, playerTransform, agent);

            enemyChaseState = new EnemyChaseState(_context);
            enemyWanderState = new EnemyWanderState(_context);
        }

        public void Start()
        {
            ChangeState(enemyWanderState);
        }


        public void AttackPlayer()
        {
            
            Vector2 directrion = ((Vector2)playerTransform.position - (Vector2)transform.position).normalized;

            weaponController.TryShoot(directrion);

        }

        public void ApproachPlayer()
        {

            GetCurrentTarget();
            agent.SetDestination(_currentTarget);
            

        }

        public void TakeDamage(float damage)
        {
            Debug.Log("Мне больно" + damage);

            _currentHealth -= damage;
            if (_currentHealth <= 0)
            {
                Die();
            }
        }



        public void CheckPlayer()
        {

            Collider2D hit = Physics2D.OverlapCircle(transform.position,
                _context.Controller.Data.viewRadiusie, playerMask);
            if (hit != null)
            {
                RaycastHit2D rayHit;
                rayHit = Physics2D.Linecast(transform.position,
                    _context.Controller.playerTransform.position, ~0);

                if (rayHit.collider != null)
                {


                    if (rayHit.collider.CompareTag("Player"))
                    {
                      
                        _context.Controller.ChangeState(enemyChaseState);
                    }
                }




            }
        }


        private void Die()
        {
         
            if (_currentHealth <= 0)
            {
          
          
                OnEnemyDeath?.Invoke(gameObject.transform.position);
                Destroy(gameObject);
            }

        }

        public void GetCurrentTarget()
        {
            Vector2 playerPos = playerTransform.position;
            Vector2 enemyPos = transform.position;


            Vector2 target = playerPos + (enemyPos - playerPos).normalized * Data.attackRadius;
            _currentTarget = target;
        }
    }

}
  


