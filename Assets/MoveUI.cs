using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveUI : MonoBehaviour
{

    [SerializeField] private GameObject courtin;
    [SerializeField] private GameObject ui;

    private bool above = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position.y >= 82 && !above)
        {
            above = true;
            courtin.transform.position = new Vector3(courtin.transform.position.x, courtin.transform.position.y + 120, courtin.transform.position.z);
            ui.transform.position = new Vector3(ui.transform.position.x, ui.transform.position.y + 120, ui.transform.position.z);
            Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y + 120, Camera.main.transform.position.z);
        }
        else if (gameObject.transform.position.y < 82 && above)
        {
            above = false;
            courtin.transform.position = new Vector3(courtin.transform.position.x, courtin.transform.position.y - 120, courtin.transform.position.z);
            ui.transform.position = new Vector3(ui.transform.position.x, ui.transform.position.y - 120, ui.transform.position.z);
            Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y - 120, Camera.main.transform.position.z);
        }
    }
}
