using System.Collections;
using UnityEngine;

public abstract class Arma
{
    protected int BulletDamage;
    protected int bullets;
    protected int PlayerSpeed;
    protected float shootDelay = 0.2f;

    protected ShootType currentShootType = ShootType.Single;

    public Arma() { }

    //hacer funcion booleana de shoot public 

    public virtual void Shoot()
    {
        bullets--;
    }

    public ShootType GetcurrentShootType()
    {
        return currentShootType;
    }
    public int GetBulletDamage()
    {
        return BulletDamage;
    }

    public float GetshootDelay()
    {
        return shootDelay;
    }

    public int Getbullets()
    {
        return bullets;
    }

    public int GetPlayerSpeed()
    {
        return PlayerSpeed;
    }

    //set

    public void SetBulletDamage(int _BulletDamage)
    {
        BulletDamage = _BulletDamage;
    }
    public void SetBullets(int _bullets)
    {
        bullets = _bullets;
    }
    public void SetPlayerSpeed(int _PlayerSpeed)
    {
        PlayerSpeed = _PlayerSpeed;
    }

    public void SetshootDelay(float _shootDelay)
    {
        shootDelay = _shootDelay;
    }

    public ShootType SetcurrentShootType()
    {
        return currentShootType;
    }


}

public enum ShootType
{
    Single,
    Burst,
    Auto
}
