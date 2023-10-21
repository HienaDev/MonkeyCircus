using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float                                       moveSpeed;
    [SerializeField]
    private float                                       jumpSpeed;

    private Rigidbody2D                                 rb;
    [SerializeField] private GroundChecker              groundChecker;

    private bool                                        grounded;
    private bool                                        jumpStart;

    private float                                       velocity_x;
    private float                                       added_velocity_y;

    private bool                                        isFacingRight = true;

    private SpriteRenderer                              playerSprite;

    [SerializeField] private Animator                   playerAnimator;

    // Start is called before the first frame update
    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();

        playerSprite = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        CheckGround();
        ReadInput();
        Move();
        Flip();
        Animations();
    }

    private void ReadInput()
    {
        if (!(Input.GetKey("a") || Input.GetKey("d")))
            velocity_x = 0;
        if (Input.GetKey("a") && !(Input.GetKey("d")))
            velocity_x = -moveSpeed;
        if (Input.GetKey("d") && !(Input.GetKey("a")))
            velocity_x = moveSpeed;
        
        if (grounded)
        {
            if (Input.GetKeyDown("w"))
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
                rb.gravityScale = 2.5f;
            else
                rb.gravityScale = 5f;
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

    private void Animations()
    {
        playerAnimator.SetFloat("moveSpeedX", Mathf.Abs(rb.velocity.x));
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
