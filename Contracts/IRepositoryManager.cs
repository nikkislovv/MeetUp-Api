using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositoryManager
    {
        IEventRepository Event { get; }
        void Save();
        Task SaveAsync();
    }
}
