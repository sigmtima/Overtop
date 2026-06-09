using Core;
using TMPro;
using UnityEngine;

namespace ShopScripts
{
    public class UpgradeButton : MonoBehaviour

    {
        [SerializeField] private BaseUpgrade upgrade;
        [SerializeField] private UpgradeData upgradeData;
        [SerializeField] private TextMeshProUGUI priceText;
        [SerializeField] private TextMeshProUGUI levelText;
        [SerializeField] private ShopManager shopManager;

        public void Start()
        {
            upgrade.Initialize(upgradeData);

            levelText.text = $"{upgrade.CurrentLevel}";
            priceText.text = $"{upgrade.Price}";
        }

        public void TryBuyUpgrade()
        {
            shopManager.BuyUpgrade(upgrade);
        }
    }
}