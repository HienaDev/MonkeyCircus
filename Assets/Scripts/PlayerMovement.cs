using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float               moveSpeed;
    [SerializeField]
    private float               jumpSpeed;

    private Rigidbody2D         rb;
    private CircleCollider2D    groundChecker;

    private bool                grounded;    
    private float               velocity_x;
    private float               added_velocity_y;

    private bool isFacingRight = true;

    private SpriteRenderer              playerSprite;

    // Start is called before the first frame update
    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();

        playerSprite = gameObject.GetComponent<SpriteRenderer>();

        //Start Grounded as test until jumping is implemented and solved
        grounded = true;      
    }

    // Update is called once per frame
    private void Update()
    {
        ReadInput();
        Move();
        Flip();
    }

    private void ReadInput()
    {
        if(grounded)
        {
            if(Input.GetKey("a") && !(Input.GetKey("d")))
                velocity_x = -moveSpeed;
            if(Input.GetKey("d") && !(Input.GetKey("a")))
                velocity_x = moveSpeed;
            if(!(Input.GetKey("a") || Input.GetKey("d")))
                velocity_x = 0;

            if(Input.GetKey("w"))
                added_velocity_y = jumpSpeed;
            else
            {
                added_velocity_y = 0;
            }
        }
        
    }

    private void Flip()
    {
        if (isFacingRight && velocity_x < 0f || !isFacingRight && velocity_x > 0f)
        {
            isFacingRight = !isFacingRight;

            transform.Rotate(0f, 180f, 0f);
        }
    }

    private void Move()
    {
        rb.velocity = new Vector2(velocity_x, rb.velocity.y + added_velocity_y);
    }
}
