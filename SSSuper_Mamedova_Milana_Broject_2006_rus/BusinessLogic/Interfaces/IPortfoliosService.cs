using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;

namespace BusinessLogic.Interfaces
{
    public interface IPortfoliosService
    {
        Task<List<Портфели>> GetAll();
        Task<Портфели> GetById(int id);
        Task Create(Портфели model);
        Task Update(Портфели model);
        Task Delete(int id);
    }
}
