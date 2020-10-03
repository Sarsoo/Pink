using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void HandleStart()
    {
        SceneManager.LoadScene("main");
    }

    public void HandleSettings()
    {
        
    }

    public void HandleExit()
    {
        Application.Quit();
    }
}
