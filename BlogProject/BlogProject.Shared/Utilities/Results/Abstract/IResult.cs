using System;
using BlogProject.Shared.Utilities.Results.ComplexTypes;

namespace BlogProject.Shared.Utilities.Results.Abstract
{
    public interface IResult
    {
        public ResultStatus ResultStatus { get; }

        public string Message { get; }

        public Exception Exception { get; }
    }
}
