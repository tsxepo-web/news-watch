using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface INewsRepository
    {
        Task<IEnumerable<NewsArticle>> GetAllAsync();
        Task<NewsArticle> GetByIdAsync(string id);
        Task AddAsync(NewsArticle newsArticle);
        Task UpdateAsync(NewsArticle newsArticle);
        Task DeleteAsync(string id);
    }
}