using System.Collections;
using UnityEngine;

public class PistolaDos : Arma
{
    private int cartuchos = 2;
    private float recargaTiempo = 5f;
    private bool enRecarga = false;
    private float tiempoUltimoDisparo;

    public void Start()
    {
        PlayerSpeed = 10;
        BulletDamage = 15;
        bullets = 15;
        shootDelay = 0.3f;
        currentShootType = ShootType.Single;
        tiempoUltimoDisparo = -recargaTiempo;
    }

    void Update()
    {
        // Verifica si se han agotado las balas y el arma no está en recarga
        if (bullets <= 0 && !enRecarga)
        {
            cartuchos--;
            if (cartuchos > 0)
            {
                StartCoroutine(RecargarArma());
            }
            else
            {
                enRecarga = true;
                tiempoUltimoDisparo = Time.time;
            }
        }

        // Si está en recarga y el tiempo ha pasado, restablece los cartuchos y balas
        if (enRecarga && Time.time - tiempoUltimoDisparo >= recargaTiempo)
        {
            cartuchos = 2;
            bullets = 15;
            enRecarga = false;
        }
    }

    private IEnumerator RecargarArma()
    {
        enRecarga = true;
        yield return new WaitForSeconds(recargaTiempo);
        bullets = 15;
        enRecarga = false;
        Debug.Log("Cartucho recargado, balas disponibles: " + bullets);
    }

    public override void Shoot()
    {
        if (!enRecarga && bullets > 0)
        {
            base.Shoot();
        }
        else if (enRecarga)
        {
            Debug.Log("En recarga, espera unos segundos.");
        }
    }
}

