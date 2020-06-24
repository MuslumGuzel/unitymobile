using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocationPanel : MonoBehaviour, IPanel
{
    public Text caseNumber;
    public Text fullName;

    public void OnEnable()
    {
        caseNumber.text = $"CASE NUMBER {UIManager.Instance.myCase.CaseNo}";
        fullName.text = UIManager.Instance.myCase.FullName;
    }

    public void ProcessInfo()
    {

    }

}
