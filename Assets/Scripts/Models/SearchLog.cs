using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Database;
using SQLiteUnity;
using UnityEditor;

namespace Assets.Scripts.Models
{
    public class SearchLog : Entity
    {
        public string Text { get; set; }
        public string ServiceName { get; set; }

        public override string ToString()
        {
            return $"[Person: Id={Id}, Name={Text},  Surname={ServiceName}]";
        }
    }
}
