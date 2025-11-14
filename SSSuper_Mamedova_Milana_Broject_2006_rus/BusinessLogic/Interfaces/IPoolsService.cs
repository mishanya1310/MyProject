using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;

namespace BusinessLogic.Interfaces
{
    public interface IPoolsService
    {
        Task<List<ВалютныеПулы>> GetAll();
        Task<ВалютныеПулы> GetById(int id);
        Task Create(ВалютныеПулы model);
        Task Update(ВалютныеПулы model);
        Task Delete(int id);
    }
}
