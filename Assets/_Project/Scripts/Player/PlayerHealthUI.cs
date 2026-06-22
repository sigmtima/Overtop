using TMPro;
using UnityEngine;

namespace Player
{
    public class PlayerHealthUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI healthText;
        [SerializeField] private PlayerHealth playerHealth;
   
        public void UpdateHealthText(float health)
        {
            healthText.text = health.ToString();
        }
        private void OnEnable()
        {
            playerHealth.OnHealthChanged += UpdateHealthText;
        }

        private void OnDisable()
        {
            playerHealth.OnHealthChanged -= UpdateHealthText;
        }
    }
}
