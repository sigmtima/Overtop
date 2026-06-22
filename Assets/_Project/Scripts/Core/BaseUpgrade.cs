using System.Collections.Generic;
using Player;
using ShopScripts;
using UnityEngine;

namespace _Project.Scripts.Core
{
    public abstract class BaseUpgrade : MonoBehaviour
    {
        public int CurrentLevel;
        public UpgradeData UpgradeData { get; set; }
        public float price;
        public float PriceMultiplier { get; set; }
        public float upgradeMultiplier { get; set; }
        
        private static Dictionary<string, int> savedLevels = new Dictionary<string, int>();
        private static Dictionary<string, float> savedPrices = new Dictionary<string, float>();

        public virtual void Initialize(UpgradeData upgradeData)
        {
            UpgradeData = upgradeData;
            PriceMultiplier = upgradeData.priceMultiplier;
            upgradeMultiplier = upgradeData.statMultiplier;

            string key = upgradeData.name;
            
            if (savedLevels.ContainsKey(key))
            {
                CurrentLevel = savedLevels[key];
                price = savedPrices[key];
            }
            else
            {
                // Если зашли самый первый раз
                CurrentLevel = 1;
                price = upgradeData.startPrice;

                savedLevels[key] = CurrentLevel;
                savedPrices[key] = price;
            }
        }
        
        public static void ResetAllUpgradesForNewRun()
        {
            savedLevels.Clear();
            savedPrices.Clear();
        }

        public abstract void LevelUp(PlayerData data);

        public virtual float CalculateNextPrice()
        {
            var nextPrice = price * PriceMultiplier;
            price = nextPrice;

            if (UpgradeData != null)
            {
                savedPrices[UpgradeData.name] = price;
            }

            return nextPrice;
        }
        
        public void SaveCurrentState()
        {
            if (UpgradeData != null)
            {
                savedLevels[UpgradeData.name] = CurrentLevel;
                savedPrices[UpgradeData.name] = price;
            }
        }
    }
}
