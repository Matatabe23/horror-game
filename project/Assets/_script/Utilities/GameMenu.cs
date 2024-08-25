using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

public class GameMenu : MonoBehaviour
{
  private bool isPaused = false;
  public Player playerScript;
  public PanelManager panelManager;

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
    Time.timeScale = 1f;
    CursorManager.HideCursor();
    playerScript.blockManagement = false;
    isPaused = false;

    panelManager.HideAllPanels();
  }

  public void Pause()
  {
    panelManager.ShowPanel(0);
    Time.timeScale = 0f;
    CursorManager.ShowCursor();
    playerScript.blockManagement = true;
    isPaused = true;
  }
}
