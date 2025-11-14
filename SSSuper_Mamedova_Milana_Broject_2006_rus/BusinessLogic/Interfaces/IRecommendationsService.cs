using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;

namespace BusinessLogic.Interfaces
{
    public interface IRecommendationsService
    {
        Task<List<Рекомендации>> GetAll();
        Task<Рекомендации> GetById(int id);
        Task Create(Рекомендации model);
        Task Update(Рекомендации model);
        Task Delete(int id);
    }
}
