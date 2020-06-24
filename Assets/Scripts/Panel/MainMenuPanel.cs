using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuPanel : MonoBehaviour, IPanel
{
    public Button btnSearchCase;
    public SearchPanel searchPanel;
    public LayoutPanel layoutPanel;

    public void ProcessInfo()
    {
        searchPanel.gameObject.SetActive(true);
        layoutPanel.gameObject.SetActive(true);
    }


}
