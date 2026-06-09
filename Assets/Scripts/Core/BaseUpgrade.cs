using UnityEngine;

namespace Core

{
    public abstract class BaseUpgrade : MonoBehaviour

    {
        public int CurrentLevel;
        public UpgradeData UpgradeData { get; set; }
        public float Price { get; set; }
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
            var nextPrice = Price * PriceMultiplier;

            return nextPrice;
        }
    }
}