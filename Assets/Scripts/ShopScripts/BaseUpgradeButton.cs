using Core;
using TMPro;
using UnityEngine;

namespace ShopScripts
{
    public class BaseUpgradeButton : MonoBehaviour

    {
        [SerializeField] private BaseUpgrade upgrade;
        [SerializeField] private UpgradeData upgradeData;
        [SerializeField] private TextMeshProUGUI priceText;
        [SerializeField] private TextMeshProUGUI levelText;
        [SerializeField] private ShopManager shopManager;

        public virtual void Start()
        {
            upgrade.Initialize(upgradeData);
            
            levelText.text = "Lvl " + upgrade.CurrentLevel;
            
            priceText.text = "Price " + upgrade.price;
        }

        public void TryBuyUpgrade()
        {
            shopManager.BuyUpgrade(upgrade);
            
            levelText.text = "Lvl " + upgrade.CurrentLevel;
            
            priceText.text = "Price " + upgrade.price;
        }
        
    }
}