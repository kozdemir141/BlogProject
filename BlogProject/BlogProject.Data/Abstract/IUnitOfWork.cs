using System;
using System.Threading.Tasks;

namespace BlogProject.Data.Abstract
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IArticleRepository Articles { get; }

        ICategoryRepository Categories { get; }

        ICommentRepository Comments { get; }

        //_unitOfWork.Articles.AddAsync();
        //_unitOfWork.Categories.AddAsync();
        //_unitOfWork.SaveAsync();

        Task<int> SaveAsync();
    }
}
