using System;
using Core;
using Enemy_AI;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;
using Weapon;

namespace Enemy_AI
{
    public class EnemyController : StateMachine<EnemyContext>, ITakeDamage
    {
        [SerializeField] private Animator enemyAnimator;

        private Transform _playerTransform;
        [SerializeField]
        private EnemyWeaponHandler weaponHandler;
        
        [FormerlySerializedAs("_enemyHealth")] [FormerlySerializedAs("health")] [SerializeField] private EnemyHealth enemyHealth;
        
        public static event Action<Vector3> OnEnemyDeath;

        [field: SerializeField] public EnemyData Data { get; private set; }
        
        [SerializeField] private NavMeshAgent agent;
        [SerializeField] private LayerMask playerMask;
        
        [SerializeField] private EnemyDetector detector;
        
        private EnemyContext _context;
        
        public EnemyChaseState ChaseState { get; private set; }
        public EnemyWanderState WanderState { get; private set; }

        public void Awake()
        {
          enemyHealth.Initialize(Data.enemyHealth);
            agent.updateRotation = false;
            agent.updateUpAxis = false;
            _playerTransform = detector.FindPlayer();
            _context = new EnemyContext(this, enemyAnimator, agent);

            ChaseState = new EnemyChaseState(_context);
            WanderState = new EnemyWanderState(_context);
        }

        public void Start()
        {
            ChangeState(WanderState);
        }

        public void TakeDamage(float damage)
        {
            Debug.Log("Мне больно" + damage);

            enemyHealth.TakeDamage(damage);
            if (enemyHealth.CurrentHealth <= 0) Die();
        }
        
        public void AttackPlayer()
        {
            var direction = ((Vector2)_playerTransform.position - (Vector2)transform.position).normalized;
            weaponHandler.Attack(direction);
        }

        public void ApproachPlayer()
        {
            MoveTo(CalculateAttackPosition());
 
        }

        public void TryDetectPlayer()
        {
            var hit = Physics2D.OverlapCircle(transform.position,
                _context.Controller.Data.viewRadius, playerMask);
            if (hit == null)
                return;

            var rayHit = Physics2D.Linecast(transform.position,
                _playerTransform.position, ~0);

            if (rayHit.collider == null)
                return;

            if (!rayHit.collider.CompareTag("Player"))
                return;

            ChangeState(ChaseState);
        }

        private void Die()
        {
            
                OnEnemyDeath?.Invoke(gameObject.transform.position);
                Destroy(gameObject);
            
        }

        public Vector2 CalculateAttackPosition()
        {
            Vector2 playerPos = _playerTransform.position;
            Vector2 enemyPos = transform.position;

            var target = playerPos + (enemyPos - playerPos).normalized * Data.attackRadius;
            return target;
          
        }

        public void MoveTo(Vector2 target)
        {
            NavMeshHit hit;

            if (NavMesh.SamplePosition(target, out hit, 3f, NavMesh.AllAreas))
            {
                agent.SetDestination(hit.position);
            }
        }
    }
}