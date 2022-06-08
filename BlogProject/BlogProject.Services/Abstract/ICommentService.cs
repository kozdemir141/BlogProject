using System;
using System.Threading.Tasks;
using BlogProject.Entities.Dtos.CommentDtos;
using BlogProject.Shared.Utilities.Results.Abstract;

namespace BlogProject.Services.Abstract
{
    public interface ICommentService
    {
        Task<IDataResult<CommentDto>> Get(int commentId);

        Task<IDataResult<CommentUpdateDto>> GetCommentUpdateDto(int commentId);

        Task<IDataResult<CommentListDto>> GetAll();

        Task<IDataResult<CommentListDto>> GetAllByDeleted();

        Task<IDataResult<CommentListDto>> GetAllByNonDeleted();

        Task<IDataResult<CommentListDto>> GetAllByNonDeletedAndActive();

        Task<IDataResult<CommentDto>> Add(CommentAddDto commentAddDto);

        Task<IDataResult<CommentDto>> Update(CommentUpdateDto commentUpdateDto, string modifiedByName);

        Task<IDataResult<CommentDto>> Delete(int commentId, string modifiedByName);

        Task<IDataResult<CommentDto>> UndoDelete(int commentId, string modifiedByName);

        Task<IDataResult<CommentDto>> Approve(int commentId, string modifiedByName);

        Task<IResult> HardDelete(int commentId);

        Task<IDataResult<int>> Count();

        Task<IDataResult<int>> CountByNonDeleted();
    }
}
