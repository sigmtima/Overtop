using UnityEngine;

namespace ShopScripts
{
    public class WalletManager : MonoBehaviour
    {
        public event System.Action<float> OnBalanceChanged;
        public float playerBalance;
        public static WalletManager Instance;
        void Awake()
        {
            Instance = this;
        }

        public void AddMoney(float amount)
        {
            playerBalance += amount;
            OnBalanceChanged?.Invoke(playerBalance);
        }

        public void RemoveMoney(float amount)
        {
            playerBalance -= amount;
            OnBalanceChanged?.Invoke(playerBalance);
        }
    }
}
