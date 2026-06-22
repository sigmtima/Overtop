using System;
using UnityEngine;

namespace ShopScripts
{
    public class WalletManager : MonoBehaviour
    {
        public static WalletManager Instance;
        public float playerBalance;
        public event Action<float> OnBalanceChanged;
        private void Awake()
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        public void AddMoney(float amount)
        {
            Debug.Log("Добавил денег: " + playerBalance);
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