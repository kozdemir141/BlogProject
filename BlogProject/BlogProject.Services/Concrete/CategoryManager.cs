using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BlogProject.Data.Abstract;
using BlogProject.Entities.Concrete;
using BlogProject.Entities.Dtos.CategoryDtos;
using BlogProject.Services.Abstract;
using BlogProject.Services.Constants;
using BlogProject.Shared.Utilities.Results.Abstract;
using BlogProject.Shared.Utilities.Results.ComplexTypes;
using BlogProject.Shared.Utilities.Results.Concrete;

namespace BlogProject.Services.Concrete
{
    public class CategoryManager : ManagerBase, ICategoryService
    {
        public CategoryManager(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<IDataResult<CategoryDto>> Get(int categoryId)
        {
            var category = await UnitOfWork.Categories.GetAsync(c => c.Id == categoryId);

            if (category != null)
            {
                return new DataResult<CategoryDto>(ResultStatus.Success, new CategoryDto
                {
                    Category = category
                });
            }
            return new DataResult<CategoryDto>(ResultStatus.Error, Messages.CategoryNotFound, new CategoryDto
            {
                Category = null,
                Messages = Messages.CategoryNotFound,
                ResultStatus = ResultStatus.Error
            });
        }

        public async Task<IDataResult<CategoryUpdateDto>> GetCategoryUpdateDto(int categoryId)
        {
            var result = await UnitOfWork.Categories.AnyAsync(c => c.Id == categoryId);

            if (result)
            {
                var category = await UnitOfWork.Categories.GetAsync(c => c.Id == categoryId);

                var categoryUpdateDto = Mapper.Map<CategoryUpdateDto>(category);

                return new DataResult<CategoryUpdateDto>(ResultStatus.Success, categoryUpdateDto);
            }
            else
            {
                return new DataResult<CategoryUpdateDto>(ResultStatus.Error, Messages.CategoryNotFound, null);
            }
        }

        public async Task<IDataResult<CategoryListDto>> GetAll()
        {
            var categories = await UnitOfWork.Categories.GetAllAsync();

            if (categories.Count > -1)
            {
                return new DataResult<CategoryListDto>(ResultStatus.Success, new CategoryListDto
                {
                    Categories = categories,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<CategoryListDto>(ResultStatus.Error, Messages.NoCategories, new CategoryListDto
            {
                Categories = null,
                Messages = Messages.NoCategories,
                ResultStatus = ResultStatus.Error
            });
        }

        public async Task<IDataResult<CategoryListDto>> GetAllByNonDeleted()
        {
            var categories = await UnitOfWork.Categories.GetAllAsync(c => !c.IsDeleted);

            if (categories.Count > -1)
            {
                return new DataResult<CategoryListDto>(ResultStatus.Success, new CategoryListDto
                {
                    Categories = categories,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<CategoryListDto>(ResultStatus.Error, Messages.NoCategories, new CategoryListDto
            {
                Categories = null,
                ResultStatus = ResultStatus.Error,
                Messages = Messages.NoCategories
            });
        }

        public async Task<IDataResult<CategoryListDto>> GetAllByNonDeletedAndActive()
        {
            var categories = await UnitOfWork.Categories.GetAllAsync(c => !c.IsDeleted && c.IsActive);

            if (categories.Count > -1)
            {
                return new DataResult<CategoryListDto>(ResultStatus.Success, new CategoryListDto
                {
                    Categories = categories
                });
            }
            return new DataResult<CategoryListDto>(ResultStatus.Error, Messages.NoCategories, null);
        }

        public async Task<IDataResult<CategoryListDto>> GetAllByDeleted()
        {
            var categories = await UnitOfWork.Categories.GetAllAsync(c => c.IsDeleted);

            if (categories.Count > -1)
            {
                return new DataResult<CategoryListDto>(ResultStatus.Success, new CategoryListDto
                {
                    Categories = categories
                });
            }
            return new DataResult<CategoryListDto>(ResultStatus.Error, Messages.NoCategories, null);
        }

        public async Task<IDataResult<CategoryDto>> Add(CategoryAddDto categoryAddDto, string createdByName)
        {
            var category = Mapper.Map<Category>(categoryAddDto);

            category.CreatedByName = createdByName;
            category.ModifiedByName = createdByName;

            var addedCategory = await UnitOfWork.Categories.AddAsync(category);
            await UnitOfWork.SaveAsync();

            return new DataResult<CategoryDto>(ResultStatus.Success, Messages.CategoryAdded, new CategoryDto
            {
                Category = addedCategory,
                Messages = Messages.CategoryAdded,
                ResultStatus = ResultStatus.Success
            });
        }

        public async Task<IDataResult<CategoryDto>> Update(CategoryUpdateDto categoryUpdateDto, string modifiedByName)
        {
            var oldCategory = await UnitOfWork.Categories.GetAsync(c => c.Id == categoryUpdateDto.Id);
            var category = Mapper.Map<CategoryUpdateDto, Category>(categoryUpdateDto, oldCategory);
            category.ModifiedByName = modifiedByName;
            var updatedCategory = await UnitOfWork.Categories.UpdateAsync(category);
            await UnitOfWork.SaveAsync();
            return new DataResult<CategoryDto>(ResultStatus.Success, Messages.CategoryUpdated, new CategoryDto
            {
                Category = updatedCategory,
                ResultStatus = ResultStatus.Success,
                Messages = Messages.CategoryUpdated
            });
        }

        public async Task<IDataResult<CategoryDto>> Delete(int categoryId, string modifiedByName)
        {
            var category = await UnitOfWork.Categories.GetAsync(c => c.Id == categoryId);

            if (category != null)
            {
                category.IsDeleted = true;
                category.IsActive = false;
                category.ModifiedByName = modifiedByName;
                category.ModifiedDate = DateTime.Now;
                var deletedCategory = await UnitOfWork.Categories.UpdateAsync(category);
                await UnitOfWork.SaveAsync();

                return new DataResult<CategoryDto>(ResultStatus.Success, new CategoryDto
                {
                    Category = deletedCategory,
                    Messages = Messages.CategoryDeleted,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<CategoryDto>(ResultStatus.Success, new CategoryDto
            {
                Category = null,
                Messages = Messages.NoCategories,
                ResultStatus = ResultStatus.Error
            });
        }

        public async Task<IDataResult<CategoryDto>> UndoDelete(int categoryId, string modifiedByName)
        {
            var category = await UnitOfWork.Categories.GetAsync(c => c.Id == categoryId);

            if (category != null)
            {
                category.IsDeleted = false;
                category.IsActive = true;
                category.ModifiedByName = modifiedByName;
                category.ModifiedDate = DateTime.Now;
                var deletedCategory = await UnitOfWork.Categories.UpdateAsync(category);
                await UnitOfWork.SaveAsync();

                return new DataResult<CategoryDto>(ResultStatus.Success, new CategoryDto
                {
                    Category = deletedCategory,
                    Messages = Messages.CategoryRestored,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<CategoryDto>(ResultStatus.Success, new CategoryDto
            {
                Category = null,
                Messages = Messages.NoCategories,
                ResultStatus = ResultStatus.Error
            });
        }

        public async Task<IResult> HardDelete(int categoryId)
        {
            var category = await UnitOfWork.Categories.GetAsync(c => c.Id == categoryId);

            if (category != null)
            {
                await UnitOfWork.Categories.DeleteAsync(category);
                await UnitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, Messages.CategoryCompletelyDeleted);
            }
            return new Result(ResultStatus.Error, Messages.CategoryNotFound);
        }

        public async Task<IDataResult<int>> Count()
        {
            var categoriesCount = await UnitOfWork.Categories.CountAsync();
            if (categoriesCount > -1)
            {
                return new DataResult<int>(ResultStatus.Success, categoriesCount);
            }
            else
            {
                return new DataResult<int>(ResultStatus.Error, $"Unexcepted Error.", -1);
            }
        }

        public async Task<IDataResult<int>> CountByNonDeleted()
        {
            var categoriesCount = await UnitOfWork.Categories.CountAsync(c => !c.IsDeleted);
            if (categoriesCount > -1)
            {
                return new DataResult<int>(ResultStatus.Success, categoriesCount);
            }
            else
            {
                return new DataResult<int>(ResultStatus.Error, $"Unexcepted Error.", -1);
            }
        }
    }
}
