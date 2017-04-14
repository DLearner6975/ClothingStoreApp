using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothingStoreApp.Web.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        int Complete();
    }
}
