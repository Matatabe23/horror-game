using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelManager : MonoBehaviour
{
  [SerializeField] private List<GameObject> panels;


  public void ShowPanel(int index)
  {
    for (int i = 0; i < panels.Count; i++)
    {
      if (i == index)
      {
        panels[i].SetActive(true);
      }
      else
      {
        panels[i].SetActive(false);
      }
    }
  }

  public void HideAllPanels()
  {
    foreach (GameObject panel in panels)
    {
      panel.SetActive(false);
    }
  }

  public void ExitGame()
  {
    Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
  }

  public void LoadScene(string sceneName)
  {
    SceneManager.LoadScene(sceneName);
  }
}
