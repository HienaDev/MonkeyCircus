using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBanana : MonoBehaviour
{

    [SerializeField] private GameObject banana;
    [SerializeField] private GameObject firePoint;

    // Start is called before the first frame update
    private void Start()
    {
        
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
        Instantiate(banana, firePoint.transform);
    }
}
