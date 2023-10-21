using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    [SerializeField]
    public Scene game;

    public void StartGame()
    {
        SceneManager.LoadScene("Tutorial");  
    }

    public void Quit()
    {
        Application.Quit();
    }
}
