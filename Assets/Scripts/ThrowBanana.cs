using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBanana : MonoBehaviour
{
    private Player player;

    [SerializeField] private GameObject banana;
    [SerializeField] private GameObject firePoint;

    [SerializeField] private float initialXVelocity;
    [SerializeField] private float initialYVelocity;

    [SerializeField] private AudioSource throwBananaSound;

    private GameObject bananaManager;

    private bool readyToThrow = true;

    // Start is called before the first frame update
    private void Start()
    {
        bananaManager = FindAnyObjectByType<BananaManager>().gameObject;
        player = gameObject.GetComponent<Player>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(player.interactionInput) && readyToThrow)
        {
            Banana();
            throwBananaSound.Play();
        }
    }

    private void Banana()
    {
        readyToThrow = false;

        GameObject temp = Instantiate(banana, firePoint.transform.position, Quaternion.identity, bananaManager.transform);

        temp.GetComponent<Rigidbody2D>().velocity = new Vector3(initialYVelocity * gameObject.transform.right.x, initialYVelocity, 0f);
    }

    public void ReadyBanana() => readyToThrow = true;

    public bool GetReadyBanana() => readyToThrow;
}
