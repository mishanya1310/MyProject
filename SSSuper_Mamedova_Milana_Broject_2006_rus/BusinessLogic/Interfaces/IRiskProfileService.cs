using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;

namespace BusinessLogic.Interfaces
{
    public interface IRiskProfileService
    {
        Task<List<ПрофилиРиска>> GetAll();
        Task<ПрофилиРиска> GetById(int id);
        Task Create(ПрофилиРиска model);
        Task Update(ПрофилиРиска model);
        Task Delete(int id);
    }
}
