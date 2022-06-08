using System;
using System.Threading.Tasks;
using AutoMapper;
using BlogProject.Data.Abstract;
using BlogProject.Entities.Concrete;
using BlogProject.Entities.Dtos.ArticleDtos;
using BlogProject.Services.Abstract;
using BlogProject.Services.Constants;
using BlogProject.Shared.Utilities.Results.Abstract;
using BlogProject.Shared.Utilities.Results.ComplexTypes;
using BlogProject.Shared.Utilities.Results.Concrete;

namespace BlogProject.Services.Concrete
{
    public class ArticleManager : ManagerBase, IArticleService
    {
        public ArticleManager(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<IDataResult<ArticleDto>> Get(int articleId)
        {
            var article = await UnitOfWork.Articles.GetAsync(a => a.Id == articleId, a => a.User, a => a.Category);

            if (article != null)
            {
                return new DataResult<ArticleDto>(ResultStatus.Success, new ArticleDto
                {
                    Article = article
                });
            }
            return new DataResult<ArticleDto>(ResultStatus.Error, Messages.ArticleNotFound, null);
        }

        public async Task<IDataResult<ArticleUpdateDto>> GetArticleUpdateDto(int articleId)
        {
            var result = await UnitOfWork.Articles.AnyAsync(a => a.Id == articleId);

            if (result)
            {
                var article = await UnitOfWork.Articles.GetAsync(a => a.Id == articleId);

                var articleUpdateDto = Mapper.Map<ArticleUpdateDto>(article);

                return new DataResult<ArticleUpdateDto>(ResultStatus.Success, articleUpdateDto);
            }
            else
            {
                return new DataResult<ArticleUpdateDto>(ResultStatus.Error, null);
            }
        }

        public async Task<IDataResult<ArticleListDto>> GetAll()
        {
            var articles = await UnitOfWork.Articles.GetAllAsync(null, a => a.User, a => a.Category);

            if (articles.Count > -1)
            {
                return new DataResult<ArticleListDto>(ResultStatus.Success, new ArticleListDto
                {
                    Articles = articles
                });
            }
            return new DataResult<ArticleListDto>(ResultStatus.Error, Messages.NoArticles, null);
        }

        public async Task<IDataResult<ArticleListDto>> GetAllByCategory(int categoryId)
        {
            var result = await UnitOfWork.Categories.AnyAsync(c => c.Id == categoryId);

            if (result)
            {
                var articles = await UnitOfWork.Articles.GetAllAsync(a => a.CategoryId == categoryId && !a.IsDeleted && a.IsActive, a => a.User, a => a.Category);

                if (articles.Count > -1)
                {
                    return new DataResult<ArticleListDto>(ResultStatus.Success, new ArticleListDto
                    {
                        Articles = articles
                    });
                }
                return new DataResult<ArticleListDto>(ResultStatus.Error, Messages.NoArticles, null);
            }
            return new DataResult<ArticleListDto>(ResultStatus.Error, Messages.CategoryNotFound, null);
        }

        public async Task<IDataResult<ArticleListDto>> GetAllByNonDeleted()
        {
            var articles = await UnitOfWork.Articles.GetAllAsync(a => !a.IsDeleted, a => a.User, a => a.Category);

            if (articles.Count > -1)
            {
                return new DataResult<ArticleListDto>(ResultStatus.Success, new ArticleListDto
                {
                    Articles = articles
                });
            }
            return new DataResult<ArticleListDto>(ResultStatus.Error, Messages.NoArticles, null);
        }

        public async Task<IDataResult<ArticleListDto>> GetAllByDeleted()
        {
            var articles = await UnitOfWork.Articles.GetAllAsync(a => a.IsDeleted, a => a.User, a => a.Category);

            if (articles.Count > -1)
            {
                return new DataResult<ArticleListDto>(ResultStatus.Success, new ArticleListDto
                {
                    Articles = articles
                });
            }
            return new DataResult<ArticleListDto>(ResultStatus.Error, Messages.NoArticles, null);
        }

        public async Task<IDataResult<ArticleListDto>> GetAllByNonDeletedAndActive()
        {
            var articles = await UnitOfWork.Articles.GetAllAsync(a => !a.IsDeleted && a.IsActive, ar => ar.User, ar => ar.Category);

            if (articles.Count > -1)
            {
                return new DataResult<ArticleListDto>(ResultStatus.Success, new ArticleListDto
                {
                    Articles = articles,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<ArticleListDto>(ResultStatus.Error, Messages.NoArticles, null);
        }

        public async Task<IResult> Add(ArticleAddDto articleAddDto, string createdByName, int userId)
        {
            var article = Mapper.Map<Article>(articleAddDto);
            article.CreatedByName = createdByName;
            article.ModifiedByName = createdByName;
            article.UserId = userId;

            await UnitOfWork.Articles.AddAsync(article);
            await UnitOfWork.SaveAsync();
            return new Result(ResultStatus.Success, Messages.ArticleAdded);
        }

        public async Task<IResult> Delete(int articleId, string modifiedByName)
        {
            var result = await UnitOfWork.Articles.AnyAsync(a => a.Id == articleId);

            if (result)
            {
                var article = await UnitOfWork.Articles.GetAsync(a => a.Id == articleId);

                article.IsDeleted = true;
                article.IsActive = false;
                article.ModifiedByName = modifiedByName;
                article.ModifiedDate = DateTime.Now;

                await UnitOfWork.Articles.UpdateAsync(article);
                await UnitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, Messages.ArticleDeleted);
            }
            return new Result(ResultStatus.Error, Messages.ArticleNotFound);
        }

        public async Task<IResult> UndoDelete(int articleId, string modifiedByName)
        {
            var result = await UnitOfWork.Articles.AnyAsync(a => a.Id == articleId);

            if (result)
            {
                var article = await UnitOfWork.Articles.GetAsync(a => a.Id == articleId);

                article.IsDeleted = false;
                article.IsActive = true;
                article.ModifiedByName = modifiedByName;
                article.ModifiedDate = DateTime.Now;

                await UnitOfWork.Articles.UpdateAsync(article);
                await UnitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, Messages.ArticleRestored);
            }
            return new Result(ResultStatus.Error, Messages.ArticleNotFound);
        }

        public async Task<IResult> HardDelete(int articleId)
        {
            var result = await UnitOfWork.Articles.AnyAsync(a => a.Id == articleId);

            if (result)
            {
                var article = await UnitOfWork.Articles.GetAsync(a => a.Id == articleId);

                await UnitOfWork.Articles.DeleteAsync(article);
                await UnitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, Messages.ArticleCompletelyDeleted);
            }
            return new Result(ResultStatus.Error, Messages.ArticleNotFound);
        }

        public async Task<IResult> Update(ArticleUpdateDto articleUpdateDto, string modifiedByName)
        {
            var oldArticle = await UnitOfWork.Articles.GetAsync(a => a.Id == articleUpdateDto.Id);
            var article = Mapper.Map<ArticleUpdateDto, Article>(articleUpdateDto, oldArticle);
            article.ModifiedByName = modifiedByName;
            article.ModifiedDate = DateTime.Now;
            await UnitOfWork.Articles.UpdateAsync(article);
            await UnitOfWork.SaveAsync();
            return new Result(ResultStatus.Success, Messages.ArticleUpdated);
        }

        public async Task<IDataResult<int>> Count()
        {
            var articlesCount = await UnitOfWork.Articles.CountAsync();
            if (articlesCount > -1)
            {
                return new DataResult<int>(ResultStatus.Success, articlesCount);
            }
            else
            {
                return new DataResult<int>(ResultStatus.Error, $"Unexcepted Error.", -1);
            }
        }

        public async Task<IDataResult<int>> CountByNonDeleted()
        {
            var articlesCount = await UnitOfWork.Articles.CountAsync(a => !a.IsDeleted);
            if (articlesCount > -1)
            {
                return new DataResult<int>(ResultStatus.Success, articlesCount);
            }
            else
            {
                return new DataResult<int>(ResultStatus.Error, $"Unexcepted Error.", -1);
            }
        }
    }
}
