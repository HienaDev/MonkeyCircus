using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ClownCounting : MonoBehaviour
{
    [SerializeField] private UnityEvent loadToLevel2 = new UnityEvent();
    [SerializeField] private UnityEvent closeCourtin = new UnityEvent();
    [SerializeField] private Player monkey;
    [SerializeField] private float timerDancing;
    [SerializeField] private float closeCourtinTimer;


    private float justFinished;
    private bool dancing = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        if (Time.time - justFinished >= closeCourtinTimer && dancing)
        { 
            closeCourtin.Invoke();
        }
        if (Time.time - justFinished >= timerDancing && dancing)
        {
            loadToLevel2.Invoke();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        justFinished = Time.time;
        monkey.SetDance();
        dancing = true;
        
    }
}
