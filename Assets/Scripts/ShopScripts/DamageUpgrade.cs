using Core;

namespace ShopScripts
{
    public class DamageUpgrade : BaseUpgrade
    {
        
         
      
        
        public override void LevelUp(PlayerController playerController)
        {
            playerController.weaponController.WeaponData.damage *= DamageMultiplier;
            CurrentLevel++;
            Price = CalculateNextPrice();

        }
    }
}
