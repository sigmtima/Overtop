using UnityEngine;

namespace Enemy_AI
{
    public class EnemyHealth : MonoBehaviour
    { 
        public float CurrentHealth { get; private set; }
        public void TakeDamage(float damage)
        {
            CurrentHealth = Mathf.Max(0, CurrentHealth - damage);
        }

        public void Initialize(float health)
        {
            CurrentHealth = health;
        }
    }
}
