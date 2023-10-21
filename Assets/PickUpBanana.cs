using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpBanana : MonoBehaviour
{

    [SerializeField] private LayerMask bananaOnFloorLayer;
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



        // Trigger Clown Falling
        if (x == bananaOnFloorLayer.value)
        {
            gameObject.GetComponent<ThrowBanana>().ReadyBanana();

            Destroy(collision.gameObject.transform.parent.gameObject);
        }
    }
}
