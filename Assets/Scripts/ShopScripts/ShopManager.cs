using Core;
using ShopScripts;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;

    public void BuyUpgrade(BaseUpgrade upgrade)
    {
        if (WalletManager.Instance.playerBalance >= upgrade.CalculateNextPrice())
        {
            WalletManager.Instance.RemoveMoney(upgrade.Price);
            upgrade.LevelUp(playerController);
        }
    }
}