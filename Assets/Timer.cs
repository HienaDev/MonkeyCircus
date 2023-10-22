using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{

    private TMP_Text text;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.FloorToInt(Time.time % 60).ToString().Length > 1)
            text.text = "0" + Mathf.FloorToInt(Time.time / 60).ToString() + ":" + Mathf.FloorToInt(Time.time % 60).ToString();
        else
            text.text = "0" + Mathf.FloorToInt(Time.time / 60).ToString() + ":0" + Mathf.FloorToInt(Time.time % 60).ToString();
    }
}
