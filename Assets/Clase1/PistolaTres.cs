using System.Collections;
using UnityEngine;


public class PistolaTres : Arma
{
    public Arma arma;
    public void Start()
    {
        PlayerSpeed = 7;
        BulletDamage = 15;
        bullets = 4;
        shootDelay = 0.3f;
        currentShootType = ShootType.Single;
    }


}

