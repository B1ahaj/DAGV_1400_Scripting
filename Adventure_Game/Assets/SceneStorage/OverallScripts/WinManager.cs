using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinManager : MonoBehaviour
{
    public GameObject winPanelUI;
    public int winnerSceneName = 3;
    
    private void Start()
    {
        winPanelUI.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TriggerWin();
        }
    }

    void TriggerWin()
    {
        winPanelUI.SetActive(true);
        Time.timeScale = 0f; // Pause the game
    }
    
    public void ResumeGame()
    {
        winPanelUI.SetActive(false);
        Time.timeScale = 1f;
    }
    
    public void LoadNextLevel()
    {
        Time.timeScale = 1f;
        
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (currentSceneIndex == 2) // Level 2 is your last gameplay scene
        {
            SceneManager.LoadScene(winnerSceneName); // Go to winner screen
        }
        else
        {
            SceneManager.LoadScene(currentSceneIndex + 1); // Next level in order
        }
    }
}
