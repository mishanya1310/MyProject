using BusinessLogic.Interfaces;
using DataAccess.Interfaces;
using DataAccess.Models;
using DataAccess.Wrapper;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services
{
    public class PortfoliosService : IPortfoliosService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public PortfoliosService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public Task<List<Портфели>> GetAll()
        {
            return _repositoryWrapper.Portfolios.FindAll().ToListAsync();
        }

        public Task<Портфели> GetById(int id)
        {
            var Portfolios = _repositoryWrapper.Portfolios
                .FindByCondition(x => x.IdПортфеля == id).First();
            return Task.FromResult(Portfolios);
        }

        public Task Create(Портфели model)
        {
            _repositoryWrapper.Portfolios.Create(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Update(Портфели model)
        {
            _repositoryWrapper.Portfolios.Update(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Delete(int id)
        {
            var Portfolios = _repositoryWrapper.Portfolios
                .FindByCondition(x => x.IdПортфеля == id).First();

            _repositoryWrapper.Portfolios.Delete(Portfolios);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }
    }
}