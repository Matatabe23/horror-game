using System.Collections.Generic;
using UnityEngine;

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
}
