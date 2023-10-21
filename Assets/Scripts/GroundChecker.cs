using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    public bool grounded {get; private set;}
    public bool bouncy {get; private set;}

    private void Start()
    {
        grounded = false;
        bouncy = false;
    }
    private void Update()
    {
        //Debug.Log(grounded);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Ground")
            grounded = true;

        if(other.gameObject.tag == "Bouncy")
            bouncy = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Ground")
            grounded = false;
    }

    public void ResetBouncy()
    {
        bouncy = false;
    }
}
