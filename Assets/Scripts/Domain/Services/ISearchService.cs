using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Model;
using Assets.Scripts.Models;

namespace Assets.Scripts.Domain.Services
{
    public interface ISearchService
    {
        SearchLog InsertSearchLog(Case caseObject);
        IEnumerable<SearchLog> GetLogs();
    }
}
