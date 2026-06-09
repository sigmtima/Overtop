using ShopScripts;
using UnityEngine;

public class CoinItem : BaseItem
{
    [SerializeField] private CoinData coinData;

    public override void Pickup()
    {
        WalletManager.Instance.AddMoney(coinData.value);
    }
}