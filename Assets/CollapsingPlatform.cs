using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollapsingPlatform : MonoBehaviour
{
    [SerializeField] private GameObject balloon1;
    [SerializeField] private GameObject balloon2;

    [SerializeField] private LayerMask playerLayer;

    [SerializeField] private float timeToExplode;
    private bool exploding = false;
    private float startExplosion;

    private Vector3 startPosition;

    private bool isFalling = false;
    private bool backInPlace = true;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(backInPlace);
        if (Time.time - startExplosion > timeToExplode && exploding)
        {
            balloon1.GetComponent<Animator>().SetTrigger("explode");
            balloon2.GetComponent<Animator>().SetTrigger("explode");
            exploding = false;
        }



        if (!isFalling && Vector3.Distance(transform.position, startPosition) < 2)
        {
            rb.velocity = Vector3.zero;

            // Spaghetii
            if (Time.time - startExplosion > 4)
                backInPlace = true;
        }

        if (rb.velocity == Vector2.zero && isFalling)
        {
            isFalling = false;
            balloon1.GetComponent<Animator>().SetTrigger("fill");
            balloon2.GetComponent<Animator>().SetTrigger("fill");
        }
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        int x = 1 << collision.gameObject.layer;



        if (x == playerLayer.value && backInPlace)
        {


            startExplosion = Time.time;

            exploding = true;
            backInPlace = false;



        }
    }

    public void Fall()
    {
        rb.velocity = new Vector3(0f, -50f, 0f);
        isFalling = true;
    }

    public void GoUp()
    {
        rb.velocity = new Vector3(0f, 20f, 0f);
    }
}
