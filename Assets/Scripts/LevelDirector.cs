using System;
using EnemyAI;
using UnityEngine;

public class LevelDirector : MonoBehaviour
{
    public static LevelDirector Instance;
    [SerializeField] private string enemyTag;

    public Transform PlayerTransform;
    private int _enemyCount;

    private void Awake()
    {
        Instance = this;

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

    public static event Action OnLevelCleared;

    public void HandleEnemyDeath(Vector3 position)
    {
        _enemyCount--;
        if (_enemyCount <= 0)
        {
        }
    }
}