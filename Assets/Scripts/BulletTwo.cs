using UnityEngine;

public class BulletTwo : MonoBehaviour
{
    public float speed = 6f;
    public int damage = 10;
    public Rigidbody rb;

    private void Start()
    {
        rb.velocity = transform.forward * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Enemy"))
        {

            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }

        Destroy(gameObject);
    }
}

