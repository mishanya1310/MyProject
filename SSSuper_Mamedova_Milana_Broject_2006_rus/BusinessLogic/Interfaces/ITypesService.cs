using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;

namespace BusinessLogic.Interfaces
{
    public interface ITypesService
    {
        Task<List<ТипыАктивов>> GetAll();
        Task<ТипыАктивов> GetById(int id);
        Task Create(ТипыАктивов model);
        Task Update(ТипыАктивов model);
        Task Delete(int id);
    }
}
