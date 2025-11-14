using BusinessLogic.Interfaces;
using DataAccess.Models;
using DataAccess.Wrapper;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services
{
    public class PriceHistoryService : IPriceHistoryService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public PriceHistoryService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public Task<List<ИсторияЦенАктивов>> GetAll()
        {
            return _repositoryWrapper.PriceHistory.FindAll().ToListAsync();
        }

        public Task<ИсторияЦенАктивов> GetById(int id)
        {
            var PriceHistory = _repositoryWrapper.PriceHistory
                .FindByCondition(x => x.IdЗаписи == id).First();
            return Task.FromResult(PriceHistory);
        }

        public Task Create(ИсторияЦенАктивов model)
        {
            _repositoryWrapper.PriceHistory.Create(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Update(ИсторияЦенАктивов model)
        {
            _repositoryWrapper.PriceHistory.Update(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Delete(int id)
        {
            var PriceHistory = _repositoryWrapper.PriceHistory
                .FindByCondition(x => x.IdЗаписи == id).First();

            _repositoryWrapper.PriceHistory.Delete(PriceHistory);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }
    }
}