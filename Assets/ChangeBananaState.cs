using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBananaState : MonoBehaviour
{
    [SerializeField] private ThrowBanana        monkey;

    [SerializeField] private SpriteRenderer     banana_on;
    [SerializeField] private SpriteRenderer     banana_off;

    // Update is called once per frame
    void Update()
    {
        if (monkey.GetReadyBanana())
        {
            banana_on.enabled = true;
            banana_off.enabled = false;
        }
        else
        {
            banana_on.enabled = false;
            banana_off.enabled = true;
        }
    }
}
