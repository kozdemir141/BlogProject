using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using AutoMapper;
using BlogProject.Entities.ComplexTypes;
using BlogProject.Entities.Concrete;
using BlogProject.Entities.Dtos.ArticleDtos;
using BlogProject.MVC.Areas.Admin.Models.ArticleModels;
using BlogProject.MVC.Helpers.Abstract;
using BlogProject.Services.Abstract;
using BlogProject.Shared.Utilities.Results.ComplexTypes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace BlogProject.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class ArticleController : BaseController
    {
        private readonly IArticleService _articleService;
        private readonly ICategoryService _categoryService;
        private readonly IToastNotification _toastNotification;

        public ArticleController(IArticleService articleService, ICategoryService categoryService, IImageHelper imageHelper, UserManager<User> userManager, IToastNotification toastNotification) : base(userManager, imageHelper)
        {
            _articleService = articleService;
            _categoryService = categoryService;
            _toastNotification = toastNotification;
        }

        [Authorize(Roles = "SuperAdmin,Article.Read")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _articleService.GetAllByNonDeletedAndActive();

            if (result.ResultStatus == ResultStatus.Success) return View(result.Data);

            return NotFound();
        }

        [Authorize(Roles = "SuperAdmin,Article.Create")]
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var result = await _categoryService.GetAllByNonDeletedAndActive();

            if (result.ResultStatus == ResultStatus.Success)
            {
                return View(new ArticleAddViewModel
                {
                    CategoryListDto = result.Data
                });
            }
            return NotFound();
        }

        [Authorize(Roles = "SuperAdmin,Article.Create")]
        [HttpPost]
        public async Task<IActionResult> Add(ArticleAddViewModel articleAddViewModel)
        {
            if (ModelState.IsValid)
            {
                var imageResult = await ImageHelper.Upload(LoggedInUser.UserName, articleAddViewModel.ArticleAddDto.ThumbnailFile, PictureType.Post);

                articleAddViewModel.ArticleAddDto.Thumbnail = imageResult.Data.FullName;

                var result = await _articleService.Add(articleAddViewModel.ArticleAddDto, LoggedInUser.UserName, LoggedInUser.Id);

                if (result.ResultStatus == ResultStatus.Success)
                {
                    _toastNotification.AddSuccessToastMessage(result.Message, new ToastrOptions
                    {
                        Title = "Succesfull Transactions!"
                    });
                    return RedirectToAction("Index", "Article");
                }
                else
                {
                    ModelState.AddModelError("", result.Message);
                }
            }
            var categories = await _categoryService.GetAllByNonDeletedAndActive();
            articleAddViewModel.CategoryListDto = categories.Data;
            return View(articleAddViewModel);
        }

        [Authorize(Roles = "SuperAdmin,Article.Update")]
        [HttpGet]
        public async Task<IActionResult> Update(int articleId)
        {
            var articleResult = await _articleService.GetArticleUpdateDto(articleId);
            var categoryResult = await _categoryService.GetAllByNonDeletedAndActive();

            if (categoryResult.ResultStatus == ResultStatus.Success && articleResult.ResultStatus == ResultStatus.Success)
            {
                return View(new ArticleUpdateViewModel
                {
                    ArticleUpdateDto = articleResult.Data,
                    CategoryListDto = categoryResult.Data
                });
            }
            else
            {
                return NotFound();
            }
        }

        [Authorize(Roles = "SuperAdmin,Article.Update")]
        [HttpPost]
        public async Task<IActionResult> Update(ArticleUpdateViewModel articleUpdateViewModel)
        {
            if (ModelState.IsValid)
            {
                bool isNewThumbnailUploaded = false;
                var oldThumbnail = articleUpdateViewModel.ArticleUpdateDto.Thumbnail;

                if (articleUpdateViewModel.ArticleUpdateDto.ThumbnailFile != null)
                {
                    var uploadedImageResult = await ImageHelper.Upload(articleUpdateViewModel.ArticleUpdateDto.SeoAuthor, articleUpdateViewModel.ArticleUpdateDto.ThumbnailFile, PictureType.Post);

                    articleUpdateViewModel.ArticleUpdateDto.Thumbnail = uploadedImageResult.ResultStatus == ResultStatus.Success
                        ? uploadedImageResult.Data.FullName
                        : "postImages/defaultThumbnail.jpg";

                    if (oldThumbnail != "postImages/defaultThumbnail.jpg")
                    {
                        isNewThumbnailUploaded = true;
                    }
                }
                var result = await _articleService.Update(articleUpdateViewModel.ArticleUpdateDto, LoggedInUser.UserName);

                if (result.ResultStatus == ResultStatus.Success)
                {
                    if (isNewThumbnailUploaded)
                    {
                        ImageHelper.Delete(oldThumbnail);
                    }
                    _toastNotification.AddSuccessToastMessage(result.Message, new ToastrOptions
                    {
                        Title = "Succesfull Transactions!"
                    });
                    return RedirectToAction("Index", "Article");
                }
                else
                {
                    ModelState.AddModelError("", result.Message);
                }
            }
            var categories = await _categoryService.GetAllByNonDeletedAndActive();
            articleUpdateViewModel.CategoryListDto = categories.Data;
            return View(articleUpdateViewModel);
        }

        [Authorize(Roles = "SuperAdmin,Article.Delete")]
        [HttpPost]
        public async Task<JsonResult> Delete(int articleId)
        {
            var result = await _articleService.Delete(articleId, LoggedInUser.UserName);
            var articleResult = JsonSerializer.Serialize(result);
            return Json(articleResult);
        }

        [Authorize(Roles = "SuperAdmin,Article.Read")]
        [HttpGet]
        public async Task<JsonResult> GetAllArticles()
        {
            var articles = await _articleService.GetAllByNonDeletedAndActive();
            var articleResult = JsonSerializer.Serialize(articles, new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve
            });
            return Json(articleResult);
        }

        //Garbage Collector Action s After This Part----------------------------------------------------------------------

        [Authorize(Roles = "SuperAdmin,Article.Read")]
        [HttpGet]
        public async Task<IActionResult> DeletedArticles()
        {
            var result = await _articleService.GetAllByDeleted();

            if (result.ResultStatus == ResultStatus.Success) return View(result.Data);

            return NotFound();
        }

        [Authorize(Roles = "SuperAdmin,Article.Read")]
        [HttpGet]
        public async Task<JsonResult> GetAllDeletedArticles()
        {
            var articles = await _articleService.GetAllByDeleted();
            var articleResult = JsonSerializer.Serialize(articles, new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve
            });
            return Json(articleResult);
        }

        [Authorize(Roles = "SuperAdmin,Article.Update")]
        [HttpPost]
        public async Task<JsonResult> UndoDelete(int articleId)
        {
            var result = await _articleService.UndoDelete(articleId, LoggedInUser.UserName);
            var articleResult = JsonSerializer.Serialize(result);
            return Json(articleResult);
        }

        [Authorize(Roles = "SuperAdmin,Article.Delete")]
        [HttpPost]
        public async Task<JsonResult> HardDelete(int articleId)
        {
            var result = await _articleService.HardDelete(articleId);
            var articleResult = JsonSerializer.Serialize(result);
            if (LoggedInUser.Picture != "postImages/defaultThumbnail.jpg")
                ImageHelper.Delete(LoggedInUser.Picture);
            return Json(articleResult);
        }
    }
}
