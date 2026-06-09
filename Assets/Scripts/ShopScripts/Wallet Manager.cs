using System;
using UnityEngine;

namespace ShopScripts
{
    public class WalletManager : MonoBehaviour
    {
        public static WalletManager Instance;
        public float playerBalance;

        private void Awake()
        {
            Instance = this;
        }

        public event Action<float> OnBalanceChanged;

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