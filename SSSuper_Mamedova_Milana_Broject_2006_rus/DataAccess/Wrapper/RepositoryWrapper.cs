using DataAccess.Interfaces;
using DataAccess.Models;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Wrapper
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private MilanaDbContext _repoContext;

        private IUserRepository _user;

        public IUserRepository User
        {
            get {
                if (_user == null)
                {
                    _user = new UserRepository(_repoContext);
                }
                return _user; 
            }
        }

        private IActiveRepository _active;

        public IActiveRepository Active
        {
            get
            {
                if (_active == null)
                {
                    _active = new ActiveRepository(_repoContext);
                }
                return _active;
            }
        }

        private IPoolsRepository _pools;

        public IPoolsRepository Pools
        {
            get
            {
                if (_pools == null)
                {
                    _pools = new PoolsRepository(_repoContext);
                }
                return _pools;
            }
        }

        private IPriceHistoryRepository _priceHistory;

        public IPriceHistoryRepository PriceHistory
        {
            get
            {
                if (_priceHistory == null)
                {
                    _priceHistory = new PriceHistoryRepository(_repoContext);
                }
                return _priceHistory;
            }
        }

        private IPortfoliosRepository _portfolios;

        public IPortfoliosRepository Portfolios
        {
            get
            {
                if (_portfolios == null)
                {
                    _portfolios = new PortfoliosRepository(_repoContext);
                }
                return _portfolios;
            }
        }

        private IProtocolsRepository _protocols;

        public IProtocolsRepository Protocols
        {
            get
            {
                if (_protocols == null)
                {
                    _protocols = new ProtocolsRepository(_repoContext);
                }
                return _protocols;
            }
        }

        private IRiskProfileRepository _riskProfile;

        public IRiskProfileRepository RiskProfile
        {
            get
            {
                if (_riskProfile == null)
                {
                    _riskProfile = new RiskProfileRepository(_repoContext);
                }
                return _riskProfile;
            }
        }

        private IRecommendationsRepository _recommendations;

        public IRecommendationsRepository Recommendations
        {
            get
            {
                if (_recommendations == null)
                {
                    _recommendations = new RecommendationsRepository(_repoContext);
                }
                return _recommendations;
            }
        }

        private ICompositionRepository _composition;

        public ICompositionRepository Composition
        {
            get
            {
                if (_composition == null)
                {
                    _composition = new CompositionRepository(_repoContext);
                }
                return _composition;
            }
        }

        private ITypesRepository _types;

        public ITypesRepository Types
        {
            get
            {
                if (_types == null)
                {
                    _types = new TypesRepository(_repoContext);
                }
                return _types;
            }
        }

        private ITransactionsRepository _transactions;

        public ITransactionsRepository Transactions
        {
            get
            {
                if (_transactions == null)
                {
                    _transactions = new TransactionsRepository(_repoContext);
                }
                return _transactions;
            }
        }

        public RepositoryWrapper(MilanaDbContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}
