using BusinessLogic.Interfaces;
using DataAccess.Models;
using DataAccess.Wrapper;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services
{
    public class TypesService : ITypesService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public TypesService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public Task<List<ТипыАктивов>> GetAll()
        {
            return _repositoryWrapper.Types.FindAll().ToListAsync();
        }

        public Task<ТипыАктивов> GetById(int id)
        {
            var Types = _repositoryWrapper.Types
                .FindByCondition(x => x.IdТипаАктива == id).First();
            return Task.FromResult(Types);
        }

        public Task Create(ТипыАктивов model)
        {
            _repositoryWrapper.Types.Create(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Update(ТипыАктивов model)
        {
            _repositoryWrapper.Types.Update(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Delete(int id)
        {
            var Types = _repositoryWrapper.Types
                .FindByCondition(x => x.IdТипаАктива == id).First();

            _repositoryWrapper.Types.Delete(Types);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }
    }
}