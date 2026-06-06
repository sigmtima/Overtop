using UnityEngine;

public class DropSystem : MonoBehaviour
{
[SerializeField] private GameObject enemyDropPrefab;


public void OnEnable()
{
    EnemyAI.EnemyController.OnEnemyDeath += SpawnCoin;
}

public void OnDisable()
{
    EnemyAI.EnemyController.OnEnemyDeath -= SpawnCoin;
}
      
public void SpawnCoin(Vector3 position)
{
      if (enemyDropPrefab != null)
      {
            Instantiate(enemyDropPrefab, position, Quaternion.identity);
      }
}

}
