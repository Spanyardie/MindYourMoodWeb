using MindYourMoodWeb.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MindYourMoodWeb.Interfaces
{
    public interface IRepository<T, TDto> where T : Entity where TDto : class
    {
        void Update(T t);
        Task<IEnumerable<TDto>> GetItemsAsync(Expression<Func<T, bool>> predicate);
        Task<T> GetItemAsync(int Id);
        void AddItem(T t);
        void RemoveItem(T t);
    }
}
