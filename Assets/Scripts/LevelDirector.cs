using System;
using UnityEngine;


public class LevelDirector : MonoBehaviour
{
   public static event Action OnLevelCleared;
   private int _enemyCount;
   [SerializeField] private string enemyTag;
  public static LevelDirector Instance;
  
   public Transform PlayerTransform;
   private void Awake()
   {
      
      Instance = this;
   
      _enemyCount = GameObject.FindGameObjectsWithTag(enemyTag).Length;
   }

   public void HandleEnemyDeath(Vector3 position)
   {
      _enemyCount--;
      if (_enemyCount <= 0)
      {
      
      }
     
   }
   

   public void OnDisable()
   {
      EnemyAI.EnemyController.OnEnemyDeath -= HandleEnemyDeath;
   }

   public void OnEnable()
   {
      EnemyAI.EnemyController.OnEnemyDeath += HandleEnemyDeath;
   }
   }

