using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Database;
using Assets.Scripts.Model;
using Assets.Scripts.Models;

namespace Assets.Scripts.Domain.Services
{
    public class SearchService : ISearchService
    {
        private readonly IRepository<SearchLog> _searchLogRepository;

        public SearchService(IRepository<SearchLog> searchLogRepository)
        {
            _searchLogRepository = searchLogRepository;
        }

        public SearchLog InsertSearchLog(Case caseObject)
        {

            var p = new SearchLog
            {
                Text = caseObject.Text,
                ServiceName = caseObject.ServiceName
            };
            _searchLogRepository.Insert(p);
            return p;
        }

        public IEnumerable<SearchLog> GetLogs()
        {
            var logs=_searchLogRepository.GetAll();
            return logs;
        }
    }
}
