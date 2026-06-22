using Weapon;

namespace Core
{
    public interface ITakeDamage
    {
        void TakeDamage(float damage);
    }
    public interface IBulletProvider
    {
        public void Release(Bullet bullet);
    }
}