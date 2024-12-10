using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponReader : MonoBehaviour
{
    Arma arma;
    PistolaDos pistola2;

    public Transform shootSpawn;
    public GameObject[] bulletPrefabs;

    public bool shooting;

    public float lastShootTime = 0f;

    private int selectedBulletIndex = 0;

    // Método virtual ?

    private void Start()
    {
        //arma = shootgun;
        arma.GetBulletDamage();
    }
    public virtual void Shoot()
    {
        if (Time.time - lastShootTime > arma.GetshootDelay() && arma.Getbullets() > 0)
        {
            switch (arma.GetcurrentShootType())
            {
                case ShootType.Single:
                    InstantiateBullet();
                    break;
                case ShootType.Burst:
                    StartCoroutine(ShootBurst());
                    break;
                case ShootType.Auto:
                    StartCoroutine(ShootAuto());
                    break;
            }
            int bulletsar = arma.Getbullets();
            arma.SetBullets(bulletsar--);
            lastShootTime = Time.time;
        }
    }

    public void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            shooting = true;
        }
        if (Input.GetButtonUp("Fire1"))
        {
            shooting = false;
        }

        // aqui
        if (shooting)
        {
            Shoot();
        }
    }

    public void InstantiateBullet()
    {
        if (bulletPrefabs.Length > 0 && selectedBulletIndex >= 0 && selectedBulletIndex < bulletPrefabs.Length)
        {
            Instantiate(bulletPrefabs[selectedBulletIndex], shootSpawn.position, shootSpawn.rotation);
        }
    }

    public IEnumerator ShootBurst()
    {
        int bulletCount = 3;
        float burstDelay = 0.1f;

        for (int i = 0; i < bulletCount; i++)
        {
            InstantiateBullet();
            yield return new WaitForSeconds(burstDelay);
        }
    }

    public IEnumerator ShootAuto()
    {
        while (shooting)
        {
            InstantiateBullet();
            yield return new WaitForSeconds(arma.GetshootDelay());
        }
    }
}

