using BusinessLogic.Interfaces;
using DataAccess.Models;
using DataAccess.Wrapper;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services
{
    public class TransactionsService : ITransactionsService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public TransactionsService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public Task<List<Транзакции>> GetAll()
        {
            return _repositoryWrapper.Transactions.FindAll().ToListAsync();
        }

        public Task<Транзакции> GetById(int id)
        {
            var Transactions = _repositoryWrapper.Transactions
                .FindByCondition(x => x.IdТранзакции == id).First();
            return Task.FromResult(Transactions);
        }

        public Task Create(Транзакции model)
        {
            _repositoryWrapper.Transactions.Create(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Update(Транзакции model)
        {
            _repositoryWrapper.Transactions.Update(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Delete(int id)
        {
            var Transactions = _repositoryWrapper.Transactions
                .FindByCondition(x => x.IdТранзакции == id).First();

            _repositoryWrapper.Transactions.Delete(Transactions);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }
    }
}