using System.Collections;
using UnityEngine;

public class Disparar : MonoBehaviour
{
    public GameObject BalaInicio; // Posición de inicio de la bala
    public float BalaVelocidad; // Velocidad de la bala

    public Arma arma; // Referencia al arma actual

    private void Update()
    {
        if (arma != null && arma.shooting) // Comprobar si el arma está en modo disparo
        {
            DispararBala();
        }
    }

    public void DispararBala()
    {
        if (arma.bulletPrefabs.Length > 0) // Asegurarse de que hay balas disponibles
        {
            // Obtener el prefab de la bala
            GameObject balaPrefab = arma.bulletPrefabs[0]; // Usa el primer prefab por defecto, o cambia la lógica según necesites

            // Instanciar la bala
            GameObject balaTemporal = Instantiate(balaPrefab, BalaInicio.transform.position, BalaInicio.transform.rotation);

            // Obtener el componente Rigidbody y aplicar la fuerza
            Rigidbody rb = balaTemporal.GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * BalaVelocidad, ForceMode.VelocityChange);

            // Destruir la bala después de 5 segundos
            Destroy(balaTemporal, 5.0f);
        }
    }
}
