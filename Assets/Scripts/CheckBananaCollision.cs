using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckBananaCollision : MonoBehaviour
{
    [SerializeField] private LayerMask bananaOnFloorLayer;

    private Animator clownAnim;
    private PatrollingClown clownScript;

    private void Start()
    {
        clownAnim = GetComponentInParent<Animator>();
        clownScript = GetComponentInParent<PatrollingClown>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        int x = 1 << collision.gameObject.layer;



        // Trigger Clown Falling
        if (x == bananaOnFloorLayer.value)
        {
            clownScript.SetTripped(true);
            clownAnim.SetTrigger("Tripped");
        }
    }
}
