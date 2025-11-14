using BusinessLogic.Interfaces;
using DataAccess.Models;
using DataAccess.Wrapper;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services
{
    public class ActiveService : IActiveService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public ActiveService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public Task<List<Активы>> GetAll()
        {
            return _repositoryWrapper.Active.FindAll().ToListAsync();
        }

        public Task<Активы> GetById(int id)
        {
            var Active = _repositoryWrapper.Active
                .FindByCondition(x => x.IdАктива == id).First();
            return Task.FromResult(Active);
        }

        public Task Create(Активы model)
        {
            _repositoryWrapper.Active.Create(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Update(Активы model)
        {
            _repositoryWrapper.Active.Update(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Delete(int id)
        {
            var Active = _repositoryWrapper.Active
                .FindByCondition(x => x.IdАктива == id).First();

            _repositoryWrapper.Active.Delete(Active);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }
    }
}