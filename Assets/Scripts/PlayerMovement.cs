using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float                                       moveSpeed;
    [SerializeField]
    private float                                       jumpSpeed;
    [SerializeField]
    private float                                       bouncySpeed;

    private Rigidbody2D                                 rb;
    [SerializeField] private GroundChecker              groundChecker;

    private bool                                        grounded;
    private bool                                        bouncy;
    private bool                                        jumpStart;

    private float                                       velocity_x;
    private float                                       added_velocity_y;

    private bool                                        isFacingRight = true;

    private SpriteRenderer                              playerSprite;

    [SerializeField] private Animator                   playerAnimator;
    [SerializeField] private Sprite                     deadSprite;

    private bool dead = false;

    private float justDied;
    [SerializeField] float frozenScreenTime;

    // Start is called before the first frame update
    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();



        playerSprite = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        if(!dead)
        { 
            CheckGround();
            ReadInput();
            Move();
            Flip();
            Animations();
        }
        else if (Time.realtimeSinceStartup - justDied > frozenScreenTime)
        {
            Time.timeScale = 1.0f;   
        }

    }

    private void ReadInput()
    {
        if(Input.GetKeyDown("escape"))
            Application.Quit(); 

        if (!(Input.GetKey("a") || Input.GetKey("d")))
            velocity_x = 0;
        if (Input.GetKey("a") && !(Input.GetKey("d")))
            velocity_x = -moveSpeed;
        if (Input.GetKey("d") && !(Input.GetKey("a")))
            velocity_x = moveSpeed;

        if(groundChecker.bouncy)
        {
            bouncy = true;
            grounded = false;
            groundChecker.ResetBouncy();
        }
        
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
            
        if(bouncy)
        {
            added_velocity_y = bouncySpeed;
            rb.velocity = new Vector2(velocity_x, added_velocity_y);
            bouncy = false;
        }
        else
            rb.velocity = new Vector2(velocity_x, rb.velocity.y + added_velocity_y);
    }

    private void CheckGround()
    {
        grounded = groundChecker.grounded;
    }

    public void SetDead()
    {
        dead = true;
        rb.velocity = new Vector3(0f, jumpSpeed, 0f);

        playerAnimator.SetTrigger("dead");

        gameObject.GetComponent<BoxCollider2D>().enabled = false;

        justDied = Time.realtimeSinceStartup;
        Time.timeScale = 0.0f;
    }

}
