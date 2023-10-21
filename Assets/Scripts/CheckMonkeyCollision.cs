using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckMonkeyCollision : MonoBehaviour
{

    [SerializeField] private LayerMask monkeyLayer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        int x = 1 << collision.gameObject.layer;



        if (x == monkeyLayer.value)
            Debug.Log("MONKEY!!");
    }
}
