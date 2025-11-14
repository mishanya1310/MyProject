using BusinessLogic.Interfaces;
using DataAccess.Models;
using DataAccess.Wrapper;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services
{
    public class ProtocolsService : IProtocolsService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public ProtocolsService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public Task<List<ПротоколыСтейкинг>> GetAll()
        {
            return _repositoryWrapper.Protocols.FindAll().ToListAsync();
        }

        public Task<ПротоколыСтейкинг> GetById(int id)
        {
            var Protocols = _repositoryWrapper.Protocols
                .FindByCondition(x => x.IdПротокола == id).First();
            return Task.FromResult(Protocols);
        }

        public Task Create(ПротоколыСтейкинг model)
        {
            _repositoryWrapper.Protocols.Create(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Update(ПротоколыСтейкинг model)
        {
            _repositoryWrapper.Protocols.Update(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Delete(int id)
        {
            var Protocols = _repositoryWrapper.Protocols
                .FindByCondition(x => x.IdПротокола == id).First();

            _repositoryWrapper.Protocols.Delete(Protocols);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }
    }
}