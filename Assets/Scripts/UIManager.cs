using Assets.Scripts.Model;
using Assets.Scripts.Database;
using UnityEngine;

namespace Assets.Scripts
{
    public sealed class UiManager : MonoBehaviour
    {
        public static UiManager Instance => UiManagerSingleton.instance;

        public DataContext DataContext { get; }

        private UiManager()
        {
            DataContext = new DataContext("tempDatabase.db");
            DataContext.CreateDB();
        }

        public Case myCase;


        public Case CreateCase(string caseNumber, string fullName)
        {
            myCase = new Case
            {
                Text = caseNumber,
                ServiceName = fullName
            };

            return myCase;
        }
        private class UiManagerSingleton
        {
            // Explicit static constructor to tell C# compiler
            // not to mark type as beforefieldinit
            static UiManagerSingleton()
            {
            }

            internal static readonly UiManager instance = new UiManager();
        }
    }
}
