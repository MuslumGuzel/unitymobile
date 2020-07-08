using Assets.Scripts;
using Assets.Scripts.Database;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Domain.Services;
using Assets.Scripts.Models;
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
            var newCase = UiManager.Instance.CreateCase(myText, "ONENT");

            ISearchService searchService = new SearchService(new Repository<SearchLog>(UiManager.Instance.DataContext));
            if (Application.internetReachability == NetworkReachability.NotReachable)
            {
                newCase.Text = "Internet Connection is not available";
                searchService.InsertSearchLog(newCase);

            }
            else
            {
                searchService.InsertSearchLog(newCase);
            }

            locationPanel.gameObject.SetActive(true);
        }
    }

}
