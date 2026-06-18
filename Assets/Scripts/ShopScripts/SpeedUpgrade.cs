using Core;
using Player;

namespace ShopScripts
{
   public class SpeedUpgrade : BaseUpgrade
   {
       public override void LevelUp(PlayerData data)
       {
           data.PlayerMovementData.walkSpeed *= upgradeMultiplier;
           CurrentLevel++;
           price = CalculateNextPrice();
       }
   }
}
