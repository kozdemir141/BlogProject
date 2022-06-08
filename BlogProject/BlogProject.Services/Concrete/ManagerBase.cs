using System;
using AutoMapper;
using BlogProject.Data.Abstract;

namespace BlogProject.Services.Concrete
{
    public class ManagerBase
    {
        public ManagerBase(IUnitOfWork unitOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }

        protected IUnitOfWork UnitOfWork { get; }

        protected IMapper Mapper { get; }
    }
}

