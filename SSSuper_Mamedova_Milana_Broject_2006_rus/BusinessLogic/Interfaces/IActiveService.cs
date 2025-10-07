using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;

namespace BusinessLogic.Interfaces
{
    public interface IActiveService
    {
        Task<List<Активы>> GetAll();
        Task<Активы> GetById(int id);
        Task Create(Активы model);
        Task Update(Активы model);
        Task Delete(int id);
    }
}
