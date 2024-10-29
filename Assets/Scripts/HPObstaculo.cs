using UnityEngine;

public class HPObstaculo : MonoBehaviour
{
    
    public int maxHealth = 5;
    public int currentHealth;

    
    void Start()
    {
        currentHealth = maxHealth;
    }

   
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    
    public void Heal(int healAmount)
    {
        currentHealth += healAmount;

        
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

   
    void Die()
    {
        Debug.Log(gameObject.name + " ha muerto.");
        Destroy(gameObject);
    }
}
