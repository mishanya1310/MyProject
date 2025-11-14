using BusinessLogic.Interfaces;
using DataAccess.Models;
using DataAccess.Wrapper;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services
{
    public class RecommendationsService : IRecommendationsService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public RecommendationsService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public Task<List<Рекомендации>> GetAll()
        {
            return _repositoryWrapper.Recommendations.FindAll().ToListAsync();
        }

        public Task<Рекомендации> GetById(int id)
        {
            var Recommendations = _repositoryWrapper.Recommendations
                .FindByCondition(x => x.IdРекомендации == id).First();
            return Task.FromResult(Recommendations);
        }

        public Task Create(Рекомендации model)
        {
            _repositoryWrapper.Recommendations.Create(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Update(Рекомендации model)
        {
            _repositoryWrapper.Recommendations.Update(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Delete(int id)
        {
            var Recommendations = _repositoryWrapper.Recommendations
                .FindByCondition(x => x.IdРекомендации == id).First();

            _repositoryWrapper.Recommendations.Delete(Recommendations);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }
    }
}