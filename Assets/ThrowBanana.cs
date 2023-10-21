using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBanana : MonoBehaviour
{

    [SerializeField] private GameObject banana;
    [SerializeField] private GameObject firePoint;

    private GameObject bananaManager;

    // Start is called before the first frame update
    private void Start()
    {
        bananaManager = FindAnyObjectByType<BananaManager>().gameObject;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Banana();
        }
    }

    private void Banana()
    {
        Instantiate(banana, firePoint.transform.position, Quaternion.identity, bananaManager.transform);
    }
}
