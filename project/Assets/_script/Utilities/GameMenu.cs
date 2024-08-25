using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

public class GameMenu : MonoBehaviour
{
    private bool isPaused = false;
    public GameObject menuUI;
    public Player playerScript;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        menuUI.SetActive(false);
        Time.timeScale = 1f;
        CursorManager.HideCursor();
        playerScript.blockManagement = false;
        isPaused = false;
    }

    public void Pause()
    {
        menuUI.SetActive(true);
        Time.timeScale = 0f; 
        CursorManager.ShowCursor();
        playerScript.blockManagement = true;
        isPaused = true;
    }
}
