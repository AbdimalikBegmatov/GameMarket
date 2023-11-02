using Azure.Core;
using GameMarket.Data;
using GameMarket.Models;
using GameMarket.Models.Page;
using GameMarket.Repositories.Interfaces;

namespace GameMarket.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly ApplicationDbContext _context;

        public ArticleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddArticle(Article article)
        {
            _context.Articles.Add(article);
            _context.SaveChanges();
        }

        public void DeleteArticle(Article article)
        {
            _context.Articles.Remove(article);
            _context.SaveChanges();
        }

        public PagedList<Article> GetAll(QueryOption option)
        {
            return new PagedList<Article>(_context.Articles,option);
        }

        public Article GetArticle(int id)
        {
            return _context.Articles.FirstOrDefault(a=>a.Id == id);
        }

        public IEnumerable<Article> GetArticles()
        {
            return _context.Articles;
        }

        public void UpdateArticle(Article article)
        {
            Article value = _context.Articles.FirstOrDefault(x => x.Id == article.Id);

            value.Title = article.Title;
            value.Text = article.Text;
            value.EditTime = DateTime.Now;
            value.ImageUrl = article.ImageUrl;

            _context.SaveChanges();
        }
    }
}
