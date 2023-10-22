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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time -startExplosion > timeToExplode && exploding)
        {
            balloon1.GetComponent<Animator>().SetTrigger("explode");
            balloon2.GetComponent<Animator>().SetTrigger("explode");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        int x = 1 << collision.gameObject.layer;



        // Trigger Clown Falling
        if (x == playerLayer.value)
        {

            exploding = true;
            startExplosion = Time.time;

        
        }
    }
}
