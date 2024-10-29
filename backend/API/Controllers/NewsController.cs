using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using static API.Middleware.ErrorHandlerMiddleware;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NewsController : ControllerBase
    {
        private readonly INewsService _newsService;
        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }
        /// <summary>
        /// Gets all news articles.
        /// </summary>
        /// <returns>A list of news articles.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var articles = await _newsService.GetAllNewsAsync();
            return Ok(articles);
        }
        /// <summary>
        /// Gets a news article by ID.
        /// </summary>
        /// <param name="id">The ID of the news article.</param>
        /// <returns>The requested news article, or 404 if not found.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(string id)
        {
            var articles = await _newsService.GetNewsByIdAsync(id);
            if (articles == null) return NotFound();
            return Ok(articles);
        }
        /// <summary>
        /// Creates a new news article.
        /// </summary>
        /// <param name="newsArticle">The news article to create.</param>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(NewsArticle newsArticle)
        {
            await _newsService.AddNewsAsync(newsArticle);
            return CreatedAtAction(nameof(GetById), new { id = newsArticle.Id }, newsArticle);
        }
        /// <summary>
        /// Updates a news article.
        /// </summary>
        /// <param name="id">The ID of the article to update.</param>
        /// <param name="newsArticle">The updated article data.</param>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(string id, [FromBody] NewsArticle newsArticle)
        {
            if (newsArticle == null) return BadRequest("News article cannot be null.");
            try
            {
                await _newsService.UpdateNewsAsync(newsArticle);
                return NoContent();
            }
            catch (NewsArticleNotFoundException)
            {

                return NotFound();
            }
        }
        /// <summary>
        /// Deletes a news article by ID.
        /// </summary>
        /// <param name="id">The ID of the article to delete.</param>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                await _newsService.DeleteNewsAsync(id);
                return NoContent();
            }
            catch (NewsArticleNotFoundException)
            {
                return NotFound();
            }
        }
    }
}