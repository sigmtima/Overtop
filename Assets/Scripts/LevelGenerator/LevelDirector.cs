using System;
using Enemy_AI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelDirector : MonoBehaviour
{

    [SerializeField] private string enemyTag;
    
    private int _enemyCount;
    
    public event Action OnLevelCleared;

    private void Awake()
    {
        _enemyCount = GameObject.FindGameObjectsWithTag(enemyTag).Length;
    }

    public void OnEnable()
    {
        EnemyController.OnEnemyDeath += HandleEnemyDeath;
  
    }

    public void OnDisable()
    {
        EnemyController.OnEnemyDeath -= HandleEnemyDeath;

    }
    
    public void HandleEnemyDeath(Vector3 position)
    {
        Debug.Log("Я увидел что убили "+ _enemyCount);
        _enemyCount--;
        if (_enemyCount <= 0)
        {
            OnLevelCleared?.Invoke();
            Debug.Log("Я вызвал событие");
        }
    }
}