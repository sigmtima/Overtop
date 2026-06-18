using Player;
using UnityEngine;

namespace Core

{
    public abstract class BaseUpgrade : MonoBehaviour

    {
        public int CurrentLevel;
        public UpgradeData UpgradeData { get; set; }
        public float price;
        public float PriceMultiplier { get; set; }
        public float upgradeMultiplier { get; set; }
        

        public virtual void Initialize(UpgradeData upgradeData)
        {
            UpgradeData = upgradeData;
            price = UpgradeData.startPrice;
            PriceMultiplier = UpgradeData.priceMultiplier;
            upgradeMultiplier = UpgradeData.statMultiplier;
        }

        public abstract void LevelUp(PlayerData data);

        public virtual float CalculateNextPrice()
        {
            var nextPrice = price * PriceMultiplier;
            price = nextPrice;

            return nextPrice;
        }
    }
}