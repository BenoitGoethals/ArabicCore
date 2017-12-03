using System;
using System.Data.Entity;
using System.Threading.Tasks;

namespace ArabicCore.repository
{
    public interface IUnitOfWork: IDisposable
    {
        void Commit();

        Task CommitAsync();
    }
}