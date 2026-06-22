using _Project.Scripts.Core;
using Core;
using Player;
using UnityEngine;

namespace ShopScripts
{
    internal class ShopManager : MonoBehaviour
    {
        [SerializeField] private PlayerData playerData;

        private void Awake()
        {
          playerData = Object.FindAnyObjectByType<PlayerData>();
        }
        public void BuyUpgrade(BaseUpgrade upgrade)
        {
            if (WalletManager.Instance.playerBalance >= upgrade.price)
            {
                WalletManager.Instance.RemoveMoney(upgrade.price);
                upgrade.LevelUp(playerData);
            }
        }
    }
}