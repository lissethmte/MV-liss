using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float speed = 2f;
    public Transform pointA; 
    public Transform pointB;

    private Vector3 targetPosition; 
    private bool movingToB = true; 

    private void Start()
    {
        
        targetPosition = pointB.position;
    }

    private void Update()
    {
        Patrol();
    }

    private void Patrol()
    {
        
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        
        if (transform.position == pointB.position && movingToB)
        {
            targetPosition = pointA.position; 
            movingToB = false;
            Flip(); 
        }
        else if (transform.position == pointA.position && !movingToB)
        {
            targetPosition = pointB.position; 
            movingToB = true; 
            Flip(); 
        }
    }

    private void Flip()
    {
        
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
}
