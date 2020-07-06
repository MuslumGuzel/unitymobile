using Assets.Scripts;
using Assets.Scripts.Database;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogPanel : MonoBehaviour, IPanel
{
    public Text listLog;

    public void OnEnable()
    {

        Database database = new Database();

        listLog.text = database.ReadAllLog();
    }

    public void ProcessInfo()
    {
    }
}
