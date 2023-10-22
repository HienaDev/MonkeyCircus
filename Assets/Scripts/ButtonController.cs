using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ButtonController : MonoBehaviour
{
    private TextMeshProUGUI tmp;
    private bool modern = false;

    private void Start()
    {
        tmp = GameObject.Find("Controls").GetComponentInChildren<TextMeshProUGUI>();
    }
    
    public void StartGame()
    {
        Player.SetControls(modern);
        SceneManager.LoadScene("Tutorial");  
    }

    public void ControlTypeToggle()
    {
        if(modern)
        {
            modern = false;
            tmp.text = "CLASSIC CONTROLS";
        }
        else
        {
            modern = true;
            tmp.text = "MODERN CONTROLS";
        } 
    }

    public void Quit()
    {
        Application.Quit();
    }
}