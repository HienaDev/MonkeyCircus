using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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

    private bool swapping = false;
    private float justStopped;

    [SerializeField] private float timeStopped;

    private bool tripped = false;


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
        if (!tripped)
        {

        
            Vector2 point = currentPoint.position - transform.position;

            if (!swapping)
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
                if (!swapping)
                {
                    swapping = true;
                    justStopped = Time.time;
                    rb.velocity = Vector3.zero;
                }
                if (Time.time - justStopped > timeStopped)
                { 
                    currentPoint = PointA;
                    swapping = false;
                }
            }

            if (Vector2.Distance(transform.position, currentPoint.position) < distance && currentPoint == PointA.transform)
            {
                if (!swapping)
                {
                    swapping = true;
                    justStopped = Time.time;
                    rb.velocity = Vector3.zero;
                }
                if (Time.time - justStopped > timeStopped)
                {
                    currentPoint = PointB;
                    swapping = false;
                }
            }

            Flip();
            Animations();
        }

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

    public void SetTripped(bool trip)
    {
        tripped = trip;
        rb.velocity = Vector3.zero;
    }
}
