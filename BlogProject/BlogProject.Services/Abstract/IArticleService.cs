using System;
using System.Threading.Tasks;
using BlogProject.Entities.Dtos.ArticleDtos;
using BlogProject.Shared.Utilities.Results.Abstract;

namespace BlogProject.Services.Abstract
{
    public interface IArticleService
    {
        Task<IDataResult<ArticleDto>> Get(int articleId);

        Task<IDataResult<ArticleUpdateDto>> GetArticleUpdateDto(int articleId);

        Task<IDataResult<ArticleListDto>> GetAll();

        Task<IDataResult<ArticleListDto>> GetAllByNonDeleted();

        Task<IDataResult<ArticleListDto>> GetAllByNonDeletedAndActive();

        Task<IDataResult<ArticleListDto>> GetAllByDeleted();

        Task<IDataResult<ArticleListDto>> GetAllByCategory(int categoryId);

        Task<IResult> Add(ArticleAddDto articleAddDto, string createdByName, int userId);

        Task<IResult> Update(ArticleUpdateDto articleUpdateDto, string modifiedByName);

        Task<IResult> Delete(int articleId, string modifiedByName);

        Task<IResult> UndoDelete(int articleId, string modifiedByName);

        Task<IResult> HardDelete(int articleId);

        Task<IDataResult<int>> Count();

        Task<IDataResult<int>> CountByNonDeleted();
    }
}
