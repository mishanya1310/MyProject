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
