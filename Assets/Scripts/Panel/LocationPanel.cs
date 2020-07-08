using Assets.Scripts;
using Assets.Scripts.Database;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Domain.Services;
using Assets.Scripts.Models;
using UnityEngine;
using UnityEngine.UI;

public class LocationPanel : MonoBehaviour, IPanel
{
    public Text caseNumber;
    public Text fullName;
    public Text logData;

    public void OnEnable()
    {
        caseNumber.text = $"CASE NUMBER {UiManager.Instance.myCase.Text}";
        fullName.text = UiManager.Instance.myCase.ServiceName;

        ISearchService searchService = new SearchService(new Repository<SearchLog>(UiManager.Instance.DataContext));
        var logs = searchService.GetLogs();

        var logText = logs.Aggregate(string.Empty, (current, searchLog) => current + $"{searchLog.Id} - {searchLog.Text} - {searchLog.ServiceName}\n");

        logData.text = logText;
    }

    public void ProcessInfo()
    {

    }

}
