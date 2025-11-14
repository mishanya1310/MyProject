using DataAccess.Interfaces;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class PriceHistoryRepository : RepositoryBase<ИсторияЦенАктивов>, IPriceHistoryRepository
    {
        public PriceHistoryRepository(MilanaDbContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
