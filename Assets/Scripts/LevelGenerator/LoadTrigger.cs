using LevelManagement;
using UnityEngine;

public class LoadTrigger : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (LevelManager.Instance == null)
        {
            Debug.LogError("LevelManager missing");
            return;
        }
        
        if (other.CompareTag("Player"))
        {
            LevelManager.Instance.LoadNextScene();
            Debug.Log("Ты перешел!");
        }
    }
}
