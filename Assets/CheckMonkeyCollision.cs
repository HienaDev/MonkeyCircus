using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckMonkeyCollision : MonoBehaviour
{

    [SerializeField] private LayerMask monkeyLayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        int x = 1 << collision.gameObject.layer;



        if (x == monkeyLayer.value)
            Debug.Log("MONKEY!!");
    }
}
