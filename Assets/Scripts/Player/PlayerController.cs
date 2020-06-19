using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    Vector2 playerInput;
    Rigidbody2D rb;
    float maxSpeedY = 13f;
    float maxSpeedX = 5f;
    float maxAccelerationY = 10f;
    float maxAccelerationX = 50f;
    Vector3 velocity;

    float power = 3f;

    bool paused = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        playerInput.x = Input.GetAxis("Horizontal");
        playerInput.y = Input.GetAxis("Vertical");
        playerInput = Vector2.ClampMagnitude(playerInput, 1f);

        
  

        

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!paused)
            {
                Time.timeScale = 0;
                paused = true;
            }
            else
            {
                Time.timeScale = 1;
                paused = false;
            }
        }
    }
    private void FixedUpdate()
    {
        velocity = rb.velocity;
        float maxSpeedChangeY = maxAccelerationY * Time.deltaTime;
        float maxSpeedChangeX = maxAccelerationX * Time.deltaTime;
        var desiredVelocityY = new Vector3(0, playerInput.y, 0) * maxSpeedY;
        var desiredVelocityX = new Vector3(playerInput.x, 0, 0) * maxSpeedX;

        if(playerInput.x != 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, desiredVelocityX.x, maxSpeedChangeX);
        }
        if(playerInput.y != 0)
        {
            velocity.y = Mathf.MoveTowards(velocity.y, desiredVelocityY.y, maxSpeedChangeY);
        }

        rb.velocity = velocity;
    }
}
