using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ShopScripts
{
    public class BalanceUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI balanceText;

        private void OnEnable()
        {
            if (WalletManager.Instance != null)
            {
                WalletManager.Instance.OnBalanceChanged += UpdateBalance;
                UpdateBalance(WalletManager.Instance.playerBalance);
            }

            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        private void OnDisable()
        {
            if (WalletManager.Instance != null)
            {
                WalletManager.Instance.OnBalanceChanged -= UpdateBalance;
            }
        
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            if (WalletManager.Instance != null)
            {
                WalletManager.Instance.OnBalanceChanged -= UpdateBalance;
                WalletManager.Instance.OnBalanceChanged += UpdateBalance;
                UpdateBalance(WalletManager.Instance.playerBalance);
            }
        }

        public void UpdateBalance(float money)
        {
            if (balanceText != null)
            {
                balanceText.text = money.ToString("N0");
            }
        }
    }
}