using _Project.Scripts.Core;
using Core;
using Player;

namespace ShopScripts
{
   public class SpeedUpgrade : BaseUpgrade
   {
       public override void LevelUp(PlayerData data)
       {
           data.MovementData.walkSpeed *= upgradeMultiplier;
           CurrentLevel++;
           price = CalculateNextPrice();
       }
   }
}
