using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace axxis.bacco.domain.Core.Repositories
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
