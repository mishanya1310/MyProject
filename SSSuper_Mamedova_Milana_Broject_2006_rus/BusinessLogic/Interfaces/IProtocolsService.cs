using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;

namespace BusinessLogic.Interfaces
{
    public interface IProtocolsService
    {
        Task<List<ПротоколыСтейкинг>> GetAll();
        Task<ПротоколыСтейкинг> GetById(int id);
        Task Create(ПротоколыСтейкинг model);
        Task Update(ПротоколыСтейкинг model);
        Task Delete(int id);
    }
}
