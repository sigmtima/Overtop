using UnityEngine;
using Weapon;

public class Bullet : MonoBehaviour
{
    [SerializeField] private BulletsPool bulletsPoolObject;
    [SerializeField] private GameObject weapon;

    [field: SerializeField] public Rigidbody2D Rb { get; private set; }
    private float _damage;
    private float _maxDistance;
    private IBulletProvider _provider;

    private Vector2 _spawnPoint;

    private void Awake()
    {
        Rb = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        var traveledSqr = ((Vector2)transform.position - _spawnPoint).sqrMagnitude;
        if (traveledSqr >= _maxDistance * _maxDistance) _provider.Release(this);
    }

    private void OnEnable()
    {
        if (Rb != null)
        {
            Rb.linearVelocity = Vector2.zero;
            Rb.angularVelocity = 0f;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var interactable = other.GetComponentInParent<ITakeDamage>();

        Debug.Log("OnTriggerEnter2D");

        if (interactable != null) interactable.TakeDamage(_damage);

        _provider.Release(this);
    }

    public void Setup(float distance, float damage, Vector2 spawnPos, Vector2 direction, float speed)
    {
        transform.position = spawnPos;
        transform.right = direction;

        _maxDistance = distance;
        _damage = damage;
        _spawnPoint = spawnPos;

        gameObject.SetActive(true);

        if (Rb != null) Rb.linearVelocity = direction * speed;
    }

    public void SetProvider(IBulletProvider provider)
    {
        _provider = provider;
    }
}