using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIfCollideClown : MonoBehaviour
{
    [SerializeField] private LayerMask clownCollider;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        int x = 1 << collision.gameObject.layer;



        // Trigger Clown Falling
        if (x == clownCollider.value)
        {
            rb.velocity = new Vector3(-rb.velocity.x, 0f, 0f);
        }
    }
}
