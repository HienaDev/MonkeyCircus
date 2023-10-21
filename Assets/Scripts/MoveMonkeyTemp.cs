using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MoveMonkeyTemp : MonoBehaviour
{

    private Rigidbody2D rb;
    [SerializeField] private float speed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3 (Input.GetAxis("Horizontal") * speed, 0f, 0f);
    }
}
