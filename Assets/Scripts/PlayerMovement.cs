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

    private bool                grounded;    
    private float               velocity_x;
    private float               velocity_y;

    // Start is called before the first frame update
    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();

        //Start Grounded as test until jumping is implemented and solved
        grounded = true;      
    }

    // Update is called once per frame
    private void Update()
    {
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

            if(Input.GetKey("w"))
                velocity_y = jumpSpeed;
        }
    }

    private void Move()
    {
        rb.velocity = new Vector2(velocity_x, velocity_y);
    }
}
