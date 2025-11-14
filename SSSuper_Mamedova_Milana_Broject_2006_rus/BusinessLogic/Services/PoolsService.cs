using BusinessLogic.Interfaces;
using DataAccess.Models;
using DataAccess.Wrapper;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services
{
    public class PoolsService : IPoolsService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public PoolsService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public Task<List<ВалютныеПулы>> GetAll()
        {
            return _repositoryWrapper.Pools.FindAll().ToListAsync();
        }

        public Task<ВалютныеПулы> GetById(int id)
        {
            var Pools = _repositoryWrapper.Pools
                .FindByCondition(x => x.IdПары == id).First();
            return Task.FromResult(Pools);
        }

        public Task Create(ВалютныеПулы model)
        {
            _repositoryWrapper.Pools.Create(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Update(ВалютныеПулы model)
        {
            _repositoryWrapper.Pools.Update(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Delete(int id)
        {
            var Pools = _repositoryWrapper.Pools
                .FindByCondition(x => x.IdПары == id).First();

            _repositoryWrapper.Pools.Delete(Pools);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }
    }
}