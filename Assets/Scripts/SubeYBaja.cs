using UnityEngine;

public class ObjectMoveUpDown : MonoBehaviour
{
    public float speed = 2f; 
    public Transform topPoint; 
    public Transform bottomPoint; 

    private Vector3 targetPosition; 
    private bool movingUp = true; 

    private void Start()
    {
        
        targetPosition = topPoint.position;
    }

    private void Update()
    {
        MoveUpDown();
    }

    private void MoveUpDown()
    {
        
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        
        if (transform.position == topPoint.position && movingUp)
        {
            targetPosition = bottomPoint.position;
            movingUp = false; 
        }
        else if (transform.position == bottomPoint.position && !movingUp)
        {
            targetPosition = topPoint.position; 
            movingUp = true;
        }
    }
}
