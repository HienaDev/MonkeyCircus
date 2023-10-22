using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    [SerializeField] private AudioSource                jump;
    [SerializeField] private AudioSource                victoryMusic;
    [SerializeField] private AudioSource                deathSound;

    private static bool                                 modernControls;
    private string                                      verticalInput;
    private string                                      leftInput;
    private string                                      rightInput;
    public string                                       interactionInput { get; private set; }


    private bool                                        dead = false;

    private bool                                        dance = false;

    private float                                       justDied;
    [SerializeField] private float                              frozenScreenTime;
    [SerializeField] private float resetTimer;

    private CloseCourtin courtinScript;

    // Start is called before the first frame update
    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        playerSprite = gameObject.GetComponent<SpriteRenderer>();

        courtinScript = GameObject.Find("cortinas").GetComponent<CloseCourtin>();

        DefineControls(modernControls);
    }

    // Update is called once per frame
    private void Update()
    {
        if(!dead && !dance)
        { 
            CheckGround();
            ReadInput();
            Move();
            Flip();
            Animations();
        }
        else if(Time.realtimeSinceStartup - justDied > resetTimer && !dance)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else if (Time.realtimeSinceStartup - justDied > frozenScreenTime)
        {
            Time.timeScale = 1.0f;
            courtinScript.CloseCourtins();
        }

    }

    private void ReadInput()
    {
        if(Input.GetKeyDown("escape"))
            Application.Quit(); 

        if (!(Input.GetKey(leftInput) || Input.GetKey(rightInput)))
            velocity_x = 0;
        if (Input.GetKey(leftInput) && !(Input.GetKey(rightInput)))
            velocity_x = -moveSpeed;
        if (Input.GetKey(rightInput) && !(Input.GetKey(leftInput)))
            velocity_x = moveSpeed;

        if(groundChecker.bouncy)
        {
            bouncy = true;
            grounded = false;
            groundChecker.ResetBouncy();
        }
        
        if (grounded)
        {
            if (Input.GetKeyDown(verticalInput))
            {
                jump.Play();
                jumpStart = true;
                added_velocity_y = jumpSpeed;
            }
            else
                jumpStart = false;
        }
        else
        {
            added_velocity_y = 0;

            if(Input.GetKey(verticalInput))
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

        if (rb.velocity.y > 300f)
        {
            rb.velocity = new Vector2(velocity_x, 300f);
        }
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
        deathSound.Play();

        gameObject.GetComponent<BoxCollider2D>().enabled = false;

        justDied = Time.realtimeSinceStartup;
        Time.timeScale = 0.0f;
    }

    public void SetDance()
    {
        dance = true;
        playerAnimator.SetTrigger("dance");
        rb.velocity = Vector3.zero;
    }

    private void DefineControls(bool modern)
    {
        if(modern)
        {
            verticalInput = "w";
            leftInput = "a";
            rightInput = "d";
            interactionInput = "e";
        }
        else
        {
            verticalInput = "space";
            leftInput = "o";
            rightInput = "p";
            interactionInput = "z";
        }
    }

    public static void SetControls(bool modern)
    {
        modernControls = modern;
    }
}