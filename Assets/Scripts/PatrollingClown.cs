using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.U2D;
using UnityEngine;

public class PatrollingClown : MonoBehaviour
{

    private Vector3 initialPosition;
    [SerializeField] private Transform PointA;
    [SerializeField] private Transform PointB;
    [SerializeField] private float speed;

    [SerializeField] private float distance;

    private bool isFacingRight = true;

    private Rigidbody2D rb;

    private Transform currentPoint;

    private Animator clownAnim;


    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector3(speed, 0f, 0f);
        currentPoint = PointB;

        clownAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(initialPosition);
        Vector2 point = currentPoint.position - transform.position;

        if(currentPoint == PointB.transform)
        {
            rb.velocity = new Vector3(speed, 0f, 0f);
        }
        else
        {
            rb.velocity = new Vector3(-speed, 0f, 0f);
        }

        if (Vector2.Distance(transform.position, currentPoint.position) < distance && currentPoint == PointB.transform)
        {
               currentPoint = PointA;
        }

        if (Vector2.Distance(transform.position, currentPoint.position) < distance && currentPoint == PointA.transform)
        {
            currentPoint = PointB;
        }

        Flip();

    }

    private void Flip()
    {
        if (isFacingRight && rb.velocity.x < 0f || !isFacingRight && rb.velocity.x > 0f)
        {
            isFacingRight = !isFacingRight;

            transform.Rotate(0f, 180f, 0f);
        }
    }

    private void Animations()
    {
        clownAnim.SetFloat("moveSpeedX", Mathf.Abs(rb.velocity.x));
    }
}
