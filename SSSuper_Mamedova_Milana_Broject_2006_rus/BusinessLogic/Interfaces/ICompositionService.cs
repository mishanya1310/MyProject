using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;

namespace BusinessLogic.Interfaces
{
    public interface ICompositionService
    {
        Task<List<СоставПортфеля>> GetAll();
        Task<СоставПортфеля> GetById(int id);
        Task Create(СоставПортфеля model);
        Task Update(СоставПортфеля model);
        Task Delete(int id);
    }
}
