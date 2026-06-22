using _Project.Scripts.Core;
using Core;
using Player;

namespace ShopScripts
{
    public class DamageUpgrade : BaseUpgrade
    {
        public override void LevelUp(PlayerData data)
        {
            data.PlayerWeaponData.damage *= upgradeMultiplier;
            CurrentLevel++;
            price = CalculateNextPrice();
        }
    }
}