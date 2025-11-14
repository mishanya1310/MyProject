using BusinessLogic.Interfaces;
using DataAccess.Models;
using DataAccess.Wrapper;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services
{
    public class CompositionService : ICompositionService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public CompositionService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public Task<List<СоставПортфеля>> GetAll()
        {
            return _repositoryWrapper.Composition.FindAll().ToListAsync();
        }

        public Task<СоставПортфеля> GetById(int id)
        {
            var Composition = _repositoryWrapper.Composition
                .FindByCondition(x => x.IdЗаписиСоставаПортфеля == id).First();
            return Task.FromResult(Composition);
        }

        public Task Create(СоставПортфеля model)
        {
            _repositoryWrapper.Composition.Create(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Update(СоставПортфеля model)
        {
            _repositoryWrapper.Composition.Update(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Delete(int id)
        {
            var Composition = _repositoryWrapper.Composition
                .FindByCondition(x => x.IdЗаписиСоставаПортфеля == id).First();

            _repositoryWrapper.Composition.Delete(Composition);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }
    }
}