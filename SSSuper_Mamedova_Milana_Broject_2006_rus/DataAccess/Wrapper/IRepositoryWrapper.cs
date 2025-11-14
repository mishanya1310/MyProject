using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interfaces;

namespace DataAccess.Wrapper
{
    public interface IRepositoryWrapper
    {
        IUserRepository User { get; }
        IActiveRepository Active { get; }
        IPoolsRepository Pools { get; }
        IPriceHistoryRepository PriceHistory { get; }
        IPortfoliosRepository Portfolios { get; }
        IProtocolsRepository Protocols { get; }
        IRiskProfileRepository RiskProfile { get; }
        IRecommendationsRepository Recommendations { get; }
        ICompositionRepository Composition { get; }
        ITypesRepository Types { get; }
        ITransactionsRepository Transactions { get; }

        void Save();
    }
}
