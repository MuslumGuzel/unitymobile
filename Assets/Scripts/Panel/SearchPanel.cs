using Assets.Scripts;
using Assets.Scripts.Database;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SearchPanel : MonoBehaviour, IPanel
{
    public Button btnSearch;
    public InputField inpCaseNumber;
    public LocationPanel locationPanel;
    public LogPanel logPanel;

    public void ProcessInfo()
    {
        var myText = inpCaseNumber.text;
        if (string.IsNullOrEmpty(myText))
        {
            Debug.LogWarning("Input alanı boş geçilemez.");
        }
        else
        {
            var newCase = UIManager.Instance.CreateCase(myText, "ONENT");

            Database database = new Database();

            database.InsertLog(newCase);

            locationPanel.gameObject.SetActive(true);
        }
    }

}
