using Assets.Scripts;
using Assets.Scripts.Database;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocationPanel : MonoBehaviour, IPanel
{
    public Text caseNumber;
    public Text fullName;
    public Text logData;

    public void OnEnable()
    {
        caseNumber.text = $"CASE NUMBER {UIManager.Instance.myCase.CaseNo}";
        fullName.text = UIManager.Instance.myCase.FullName;

        Database database = new Database();
        logData.text = database.ReadAllLog();
    }

    public void ProcessInfo()
    {

    }

}
