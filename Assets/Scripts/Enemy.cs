using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    private void Start()
    {
       
        currentHealth = maxHealth;
    }

    
    public void TakeDamage(int damage)
    {
        
        currentHealth -= damage;
        Debug.Log("Enemigo recibió " + damage + " de daño. Salud restante: " + currentHealth);

        
        if (currentHealth <= 0)
        {
            Die();
        }
    }

 
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Bullet"))
        {
            
            Bullet bullet = other.GetComponent<Bullet>();
            if (bullet != null)
            {
                TakeDamage(bullet.damage);
            }

            
            Destroy(other.gameObject);
        }
    }

   
    private void Die()
    {
        Debug.Log("Enemigo ha muerto!");
        Destroy(gameObject);
    }
}
