using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.Rendering;

namespace Core

{
    public abstract class BaseUpgrade:MonoBehaviour

    {
    public UpgradeData UpgradeData { get; set; }
    public float Price { get; set; }

    public int CurrentLevel;
    public float PriceMultiplier { get; set; }
    public float DamageMultiplier { get; set; }

    public virtual void Initialize(UpgradeData upgradeData)
    {
        UpgradeData = upgradeData;
        Price = UpgradeData.startPrice;
        PriceMultiplier = UpgradeData.priceMultiplier;
        DamageMultiplier = UpgradeData.statMultiplier;
    }

    public abstract void LevelUp(PlayerController playerController);

    public virtual float CalculateNextPrice()
    {
        float nextPrice = Price * PriceMultiplier;

        return nextPrice;
    }





    }
}
