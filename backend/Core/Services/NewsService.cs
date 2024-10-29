using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;

namespace Core.Services
{
    public class NewsService : INewsService
    {
        private readonly INewsRepository _newsRepository;
        public NewsService(INewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }
        public async Task AddNewsAsync(NewsArticle newsArticle)
        {
            await _newsRepository.AddAsync(newsArticle);
        }

        public async Task DeleteNewsAsync(string id)
        {
            await _newsRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<NewsArticle>> GetAllNewsAsync()
        {
            return await _newsRepository.GetAllAsync();
        }

        public async Task<NewsArticle> GetNewsByIdAsync(string id)
        {
            return await _newsRepository.GetByIdAsync(id);
        }

        public async Task UpdateNewsAsync(NewsArticle newsArticle)
        {
            await _newsRepository.UpdateAsync(newsArticle);
        }
    }
}