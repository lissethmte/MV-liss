using System.Collections;
using UnityEngine;

public abstract class Arma : MonoBehaviour
{
    public Transform shootSpawn;
    public GameObject[] bulletPrefabs;
    public int BulletDamage;
    public bool shooting;
    public int bullets;
    public int PlayerSpeed;

    public float lastShootTime = 0f;
    public float shootDelay = 0.2f;

    public enum ShootType
    {
        Single,
        Burst,
        Auto
    }

    public ShootType currentShootType = ShootType.Single;
    private int selectedBulletIndex = 0;

    // Método virtual ?
    public virtual void Shoot()
    {
        if (Time.time - lastShootTime > shootDelay && bullets > 0)
        {
            switch (currentShootType)
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
            bullets--;
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
            yield return new WaitForSeconds(shootDelay);
        }
    }
}
