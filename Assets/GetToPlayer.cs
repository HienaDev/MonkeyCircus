using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetToPlayer : MonoBehaviour
{

    private GameObject player;

    private Rigidbody2D rb;

    [SerializeField] private LayerMask playerLayer;

    private GameObject cageDoor;
    

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Monkey");
        rb = GetComponent<Rigidbody2D>();
        cageDoor = GameObject.Find("CageDoor");
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(player.transform.position, gameObject.transform.position) > 0)
        {
            rb.velocity = new Vector3(-40f, rb.velocity.y, 0f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        int x = 1 << collision.gameObject.layer;



        // Trigger Clown Falling
        if (x == playerLayer.value)
        {
            cageDoor.GetComponent<CageGoUp>().TriggerCage();
            Destroy(gameObject);
        }
        
    }
}
