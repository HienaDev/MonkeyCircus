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
    private GroundChecker       groundChecker;

    private bool                grounded;
    private bool                jumpStart;

    private float               velocity_x;
    private float               added_velocity_y;

    // Start is called before the first frame update
    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        groundChecker = gameObject.transform.Find("GroundChecker").GetComponent<GroundChecker>();
    }

    // Update is called once per frame
    private void Update()
    {
        CheckGround();
        ReadInput();
        Move();
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

            if(Input.GetKeyDown("w"))
            {
                jumpStart = true;
                added_velocity_y = jumpSpeed;
            }
            else
                jumpStart = false;
        }
        else
        {
            added_velocity_y = 0;
            
            if(Input.GetKey("w"))
                rb.gravityScale = 0.35f;
            else
                rb.gravityScale = 1f;
        }
    }

    private void Move()
    {
        if(added_velocity_y > 0 && !jumpStart)
            added_velocity_y = 0;

        rb.velocity = new Vector2(velocity_x, rb.velocity.y + added_velocity_y);
    }

    private void CheckGround()
    {
        grounded = groundChecker.grounded;
    }
}
