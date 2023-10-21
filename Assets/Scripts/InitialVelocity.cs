using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialVelocity : MonoBehaviour
{

    private Rigidbody2D rb;

    [SerializeField] private float rotationSpeed;

    [SerializeField] private GameObject deadBanana;

    private GameObject bananaManager;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        bananaManager = FindAnyObjectByType<BananaManager>().gameObject;

       // rb.velocity = new Vector3(initialYVelocity, initialYVelocity, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        rb.rotation += rotationSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        Instantiate(deadBanana, transform.position, Quaternion.identity, bananaManager.transform);
        Destroy(gameObject);
    }
}
