using Assets.Scripts;
using Assets.Scripts.Database;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Domain.Services;
using Assets.Scripts.Models;
using Assets.Scripts.Utility;
using UnityEngine;
using UnityEngine.UI;

public class SearchPanel : MonoBehaviour, IPanel
{
    public Button btnSearch;
    public InputField inpCaseNumber;
    public LocationPanel locationPanel;
    public LogPanel logPanel;
    private ConnectionTester _connectionTester;
    public Text FeedbackText;

    public void ProcessInfo()
    {
        var myText = inpCaseNumber.text;

        if (string.IsNullOrEmpty(myText))
        {
            Debug.LogWarning("Input alanı boş geçilemez.");
            ShowFeedback("Input alanı boş geçilemez.");
        }
        else
        {
            var newCase = UiManager.Instance.CreateCase(myText, "ONENT");

            ISearchService searchService = new SearchService(new Repository<SearchLog>(UiManager.Instance.DataContext));

            _connectionTester = ConnectionTester
                .GetInstance(gameObject)
                .ipToTest("www.google.com");


            ShowFeedback("Starting test");
            // Internet connection checked basically
            //if (Application.internetReachability == NetworkReachability.NotReachable)
            //{
            //    newCase.Text = "Internet Connection is not available";
            //}
            _connectionTester.TestInternet(hasInternet =>
            {
                if (hasInternet)
                {
                    searchService.InsertSearchLog(newCase);

                    locationPanel.gameObject.SetActive(true);
                }
                ShowFeedback($"Has internet connection: {hasInternet}");
            });
        }

        void ShowFeedback(string text)
        {
            FeedbackText.text = text;
        }
    }

}
