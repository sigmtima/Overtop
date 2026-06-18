using Core;
using Player;

namespace ShopScripts
{
    public class HealthUpgrade : BaseUpgrade
    {
        public override void LevelUp(PlayerData data)
        {
            data.PlayerHealthData.Health *= upgradeMultiplier;
            CurrentLevel++;
            price = CalculateNextPrice();
        }
    }
}