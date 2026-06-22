using _Project.Scripts.Core;
using Core;
using Player;

namespace ShopScripts
{
    public class HealthUpgrade : BaseUpgrade
    {
        private bool _isUpgraded = false;
        public override void LevelUp(PlayerData data)
        {
            if (_isUpgraded == true)
            {
                return;
            }
            data.PlayerHealthData.startMaxHealth *= upgradeMultiplier;
            CurrentLevel++;
            price = CalculateNextPrice();
            _isUpgraded = true;
        }
    }
}