using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Web.Api.Data.Infrastructure.Repository
{
    public interface IUnitOfWork<TEntity> where TEntity : class
    {
        Task<TEntity> UpdateAsync(CancellationToken cancellationToken, TEntity entity);

        Task CommitAsync(CancellationToken cancellationToken);
    }
}
