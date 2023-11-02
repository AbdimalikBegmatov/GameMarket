using GameMarket.Models;
using GameMarket.Models.Page;

namespace GameMarket.Repositories.Interfaces
{
    public interface IArticleRepository
    {
        PagedList<Article> GetAll(QueryOption option);
        IEnumerable<Article> GetArticles();
        Article GetArticle(int id);
        void DeleteArticle(Article article);
        void AddArticle(Article article);
        void UpdateArticle(Article article);
    }
}
