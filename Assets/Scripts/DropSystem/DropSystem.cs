using EnemyAI;
using UnityEngine;

public class DropSystem : MonoBehaviour
{
    [SerializeField] private GameObject enemyDropPrefab;

    public void OnEnable()
    {
        EnemyController.OnEnemyDeath += SpawnCoin;
    }

    public void OnDisable()
    {
        EnemyController.OnEnemyDeath -= SpawnCoin;
    }

    public void SpawnCoin(Vector3 position)
    {
        if (enemyDropPrefab != null) Instantiate(enemyDropPrefab, position, Quaternion.identity);
    }
}