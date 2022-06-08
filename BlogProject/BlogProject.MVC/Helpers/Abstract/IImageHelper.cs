using System;
using System.Threading.Tasks;
using BlogProject.Entities.ComplexTypes;
using BlogProject.Entities.Dtos;
using BlogProject.Shared.Utilities.Results.Abstract;
using Microsoft.AspNetCore.Http;

namespace BlogProject.MVC.Helpers.Abstract
{
    public interface IImageHelper
    {
        Task<IDataResult<ImageUploadedDto>> Upload(string name, IFormFile pictureFile, PictureType pictureType, string folderName = null);

        IDataResult<ImageDeletedDto> Delete(string pictureName);
    }
}
