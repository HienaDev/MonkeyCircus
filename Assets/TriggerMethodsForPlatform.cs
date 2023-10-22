using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMethodsForPlatform : MonoBehaviour
{

    [SerializeField] private CollapsingPlatform platform;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fall()
    {
        platform.Fall();
    }

    public void GoUp()
    {
        platform.GoUp();
    }
}
