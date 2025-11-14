using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;

namespace BusinessLogic.Interfaces
{
    public interface IPriceHistoryService
    {
        Task<List<ИсторияЦенАктивов>> GetAll();
        Task<ИсторияЦенАктивов> GetById(int id);
        Task Create(ИсторияЦенАктивов model);
        Task Update(ИсторияЦенАктивов model);
        Task Delete(int id);
    }
}
