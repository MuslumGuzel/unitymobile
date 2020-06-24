using Assets.Scripts.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class UIManager : MonoBehaviour
    {
        private static UIManager _instance;

        public static UIManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    Debug.LogWarning("Instance not found");
                }
                return _instance;
            }
        }

        public Case myCase;

        public void Awake()
        {
            _instance = new UIManager();
        }

        public void CreateCase(string caseNumber, string fullName)
        {
            myCase = new Case
            {
                CaseNo = caseNumber,
                FullName = fullName
            };
        }
    }
}
