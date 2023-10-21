using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropKey : MonoBehaviour
{
    private GameObject bananaManager;

    [SerializeField] private GameObject key;


    private void Start()
    {
        bananaManager = FindAnyObjectByType<BananaManager>().gameObject;
    }


    public void Key()
    {
        Instantiate(key, gameObject.transform.position, Quaternion.identity, bananaManager.transform);

    }
}
