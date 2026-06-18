using Core;
using Player;
using ShopScripts;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;

    public void BuyUpgrade(BaseUpgrade upgrade)
    {
        if (WalletManager.Instance.playerBalance >= upgrade.price)
        {
            WalletManager.Instance.RemoveMoney(upgrade.price);
            upgrade.LevelUp(playerData);
        }
    }
}