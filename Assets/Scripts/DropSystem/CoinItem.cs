using ShopScripts;
using UnityEngine;

public class CoinItem : BaseItem
{
    [SerializeField] private CoinData coinData;

    public override void Pickup()
    {
        Debug.Log("Монета подобрана");
        WalletManager.Instance.AddMoney(coinData.value);
    }
}