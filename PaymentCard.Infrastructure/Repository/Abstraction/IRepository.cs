using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PaymentCard.Infrastructure.Repository.Abstraction
{
    public interface IRepository<T>
    {
        Task Create(T input);
        void Delete(T input);
        void Update(T input);
        Task<IEnumerable<T>> GetCollectionAsync(Expression<Func<T, bool>> expression = null);
        IQueryable<T> GetQuery(Expression<Func<T, bool>> expression = null);
        Task<bool> SaveChangesAsync();

    }
}
