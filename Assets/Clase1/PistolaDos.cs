using System.Collections;
using System.Threading;
using UnityEngine;

public class PistolaDos : Arma
{
    private int cartuchos = 2;
    private int maxBullets = 15;
    private float recargaTiempo = 5f;
    private bool needReload = false;
    private float lastShootTime;


    public PistolaDos()
    {
        PlayerSpeed = 10;
        BulletDamage = 15;
        bullets = 15;
        maxBullets = bullets;
        shootDelay = 0.3f;
        currentShootType = ShootType.Single;
    }

    private void TimeGun(float time)
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            if (cartuchos > 0)
            {
                bullets = maxBullets;
                cartuchos--;
                needReload = false;
            }
        }

    }

    public override void Shoot()
    {
        if (Time.time - lastShootTime >= shootDelay && bullets > 0)
        {

            bullets--;
            lastShootTime = Time.time;

            if (bullets <= 0)

                needReload = true;
            TimeGun(5);
        }
    }
}
