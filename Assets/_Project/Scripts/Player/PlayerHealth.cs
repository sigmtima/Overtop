using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public event System.Action<float> OnHealthChanged;
    public float CurrentHealth { get; private set; }
    
    public void TakeDamage(float damage)
    {
        CurrentHealth = Mathf.Max(0, CurrentHealth - damage);
        OnHealthChanged?.Invoke(CurrentHealth);
    }

    public void Initialize(float health)
    {
        CurrentHealth = health;
        OnHealthChanged?.Invoke(CurrentHealth);
    }
    
}


