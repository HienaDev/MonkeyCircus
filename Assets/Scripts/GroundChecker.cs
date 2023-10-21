using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    public bool grounded {get; private set;}

    private void Start()
    {
        grounded = false;
    }
    private void Update()
    {
        Debug.Log(grounded);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Ground")
            grounded = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Ground")
            grounded = false;
    }
}
