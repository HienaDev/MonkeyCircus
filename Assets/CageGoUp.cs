using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CageGoUp : MonoBehaviour
{

    private GameObject gridTest;
    bool goUp = false;
    float scale = 1f;
    private GameObject cageDoorCollider;

    // Start is called before the first frame update
    void Start()
    {
        cageDoorCollider = GameObject.Find("CageDoorCollider");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(goUp)
        {
            scale -= 0.1f;
            gameObject.transform.localScale = new Vector3(1f, scale, 1f);
        }

        if(gameObject.transform.localScale.y < 0.5f)
        {
            Destroy(cageDoorCollider);
            Destroy(gameObject);
        }
    }

    public void TriggerCage() => goUp = true;
}
