using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunction : MonoBehaviour
{
    public void ButtonStartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ButtonExitGame()
    {
        Application.Quit();
    }
}
