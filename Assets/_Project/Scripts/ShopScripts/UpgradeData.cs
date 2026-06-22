using UnityEngine;

namespace ShopScripts
{
    [CreateAssetMenu(menuName = "Upgrade", fileName = "UpgradeData")]
    public class UpgradeData : ScriptableObject
    {
        public float startPrice = 10;
        public float priceMultiplier = 1.10f;
        public float statMultiplier = 1.1f;
    }
}