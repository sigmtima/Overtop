using Player;
using UnityEngine;

namespace Enemy_AI
{
    public class EnemyDetector : MonoBehaviour
    {
        public Transform FindPlayer()
        {
            var player = FindAnyObjectByType<PlayerController>();
            if (player == null)
            {
                Debug.LogError("Player not found");
                enabled = false;
            }
            return player != null
                ? player.transform
                : null;
        }
  
    }
}
