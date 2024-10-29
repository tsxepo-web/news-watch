using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface INewsService
    {

        Task<IEnumerable<NewsArticle>> GetAllNewsAsync();
        Task<NewsArticle> GetNewsByIdAsync(string id);
        Task AddNewsAsync(NewsArticle newsArticle);
        Task UpdateNewsAsync(NewsArticle newsArticle);
        Task DeleteNewsAsync(string id);
    }
}