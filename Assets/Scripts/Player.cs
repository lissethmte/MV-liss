using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    private bool isGrounded;

    private CharacterController controller;
    private Vector3 moveDirection;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical"); 

       
        Vector3 move = transform.right * moveHorizontal + transform.forward * moveVertical;

       
        controller.Move(move * moveSpeed * Time.deltaTime);
    }

    void Jump()
    {
       
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            moveDirection.y = jumpForce;
            isGrounded = false;
        }

        
        moveDirection.y += Physics.gravity.y * Time.deltaTime;

       
        controller.Move(moveDirection * Time.deltaTime);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
      
        if (hit.collider.CompareTag("Ground"))
        {
            isGrounded = true;
            moveDirection.y = 0f;
        }

       
        if (hit.collider.CompareTag("End"))
        {
          
            SceneManager.LoadScene("MenuInicial"); 
        }
    }
}