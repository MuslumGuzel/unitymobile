using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SearchPanel : MonoBehaviour, IPanel
{
    public Button btnSearch;
    public InputField inpCaseNumber;
    public LocationPanel locationPanel;

    public void ProcessInfo()
    {
        var myText = inpCaseNumber.text;
        if (string.IsNullOrEmpty(myText))
        {
            Debug.LogWarning("Input alanı boş geçilemez.");
        }
        else
        {

            UIManager.Instance.CreateCase(myText, "ONENT");
            locationPanel.gameObject.SetActive(true);
        }
    }

}
