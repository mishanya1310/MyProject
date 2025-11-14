using BusinessLogic.Interfaces;
using DataAccess.Models;
using DataAccess.Wrapper;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services
{
    public class RiskProfileService : IRiskProfileService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public RiskProfileService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public Task<List<ПрофилиРиска>> GetAll()
        {
            return _repositoryWrapper.RiskProfile.FindAll().ToListAsync();
        }

        public Task<ПрофилиРиска> GetById(int id)
        {
            var RiskProfile = _repositoryWrapper.RiskProfile
                .FindByCondition(x => x.IdПрофиляРиска == id).First();
            return Task.FromResult(RiskProfile);
        }

        public Task Create(ПрофилиРиска model)
        {
            _repositoryWrapper.RiskProfile.Create(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Update(ПрофилиРиска model)
        {
            _repositoryWrapper.RiskProfile.Update(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Delete(int id)
        {
            var RiskProfile = _repositoryWrapper.RiskProfile
                .FindByCondition(x => x.IdПрофиляРиска == id).First();

            _repositoryWrapper.RiskProfile.Delete(RiskProfile);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }
    }
}