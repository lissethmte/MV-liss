using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Arma;

public class PistolaNormie : Arma
{
    public Arma arma;
    public void Start()
    {
        PlayerSpeed = 10;
        BulletDamage = 10;
        bullets = 10;
        shootDelay = 0.3f;
        currentShootType = ShootType.Single;
    }
}
