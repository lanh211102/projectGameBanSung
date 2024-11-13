using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerScript : MonoBehaviour
{
    [Header("Player Movement")] 
    public float playerSpeed = 1.9f; 

    [Header("Player Animator and Gravity")] 
    public CharacterController cC; 
    
    [Header("Player Jumping and velocity")] 
    public float turnCalmTime = 0.1f; 
    float turnCalmVelocity; 

    
    private void Update()
    {
        playerMove(); 
    }


    void playerMove()
    {
        
        float horizontalAxis = Input.GetAxisRaw("Horizontal");
        float verticalAxis = Input.GetAxisRaw("Vertical");

  
        Vector3 direction = new Vector3(horizontalAxis, 0f, verticalAxis).normalized;

        if (direction.magnitude > 0.1f)
        {
           
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, targetAngle, 0f);

            cC.Move(direction.normalized * playerSpeed * Time.deltaTime);
        }
    }
}
