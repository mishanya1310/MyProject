using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;

namespace BusinessLogic.Interfaces
{
    public interface ITransactionsService
    {
        Task<List<Транзакции>> GetAll();
        Task<Транзакции> GetById(int id);
        Task Create(Транзакции model);
        Task Update(Транзакции model);
        Task Delete(int id);
    }
}
