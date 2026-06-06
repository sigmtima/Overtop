using UnityEngine;

public interface IBulletProvider
{

    public void Initialize();
    public Bullet GetBullet();
    public void Release(Bullet bullet);
}
    

  
