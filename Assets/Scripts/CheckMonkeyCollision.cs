using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckMonkeyCollision : MonoBehaviour
{

    [SerializeField] private LayerMask monkeyLayer;
    [SerializeField] private float jumpSpeed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        int x = 1 << collision.gameObject.layer;

        Debug.Log("COLLISIONS");

        if (x == monkeyLayer.value)
        {
            Debug.Log("AKSJHDKAS");
            collision.gameObject.GetComponent<Player>().SetDead();
            
        }
    }
}
