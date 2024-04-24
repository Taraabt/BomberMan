using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{

    public void StartGame()
    {
        Time.timeScale = 1.0f;
        InputController.instance.input.Enable();
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }


    public void Quit()
    {
        Application.Quit();
    }
}
