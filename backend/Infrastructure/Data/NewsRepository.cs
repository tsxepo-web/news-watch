using Core.Entities;
using Core.Interfaces;
using MongoDB.Driver;

namespace Infrastructure.Data;
public class NewsRepository(MongoDbContext mongoDbContext) : INewsRepository
{
    private readonly MongoDbContext _mongoDbContext = mongoDbContext;

    public async Task AddAsync(NewsArticle newsArticle) => await _mongoDbContext.NewsArticles.InsertOneAsync(newsArticle);

    public async Task DeleteAsync(string id) => await _mongoDbContext.NewsArticles.DeleteOneAsync(id);

    public async Task<IEnumerable<NewsArticle>> GetAllAsync() => await _mongoDbContext.NewsArticles.Find(_ => true).ToListAsync();

    public async Task<NewsArticle> GetByIdAsync(string id) => await _mongoDbContext.NewsArticles.Find(x => x.Id.ToString() == id).FirstOrDefaultAsync();

    public async Task UpdateAsync(NewsArticle newsArticle) => await _mongoDbContext.NewsArticles.ReplaceOneAsync(x => x.Id == newsArticle.Id, newsArticle);
}
