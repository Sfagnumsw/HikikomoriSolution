using System;
using System.Collections.Generic;
using System.Linq;
using HikikomoriWEB.Services.Interfaces;
using HikikomoriWEB.Domain.Entity;
using HikikomoriWEB.Domain.Enum;
using HikikomoriWEB.Domain.Interfaces;
using HikikomoriWEB.Domain.ResponseEntity;
using HikikomoriWEB.DAL.Interfaces;
using System.Threading.Tasks;

namespace HikikomoriWEB.Services.RepositoryServices
{
    class RememberContentService : IBaseContentServices<RememberContent>
    {
        public Task<IResponseRepository<IEnumerable<RememberContent>>> AllContent()
        {
            throw new NotImplementedException();
        }

        public Task<IResponseRepository<RememberContent>> DeleteContent(int ContentId)
        {
            throw new NotImplementedException();
        }

        public Task<IResponseRepository<IEnumerable<RememberContent>>> GetOnCategoryId(int CategoryId)
        {
            throw new NotImplementedException();
        }

        public Task<IResponseRepository<RememberContent>> GetOnId(int ContentId)
        {
            throw new NotImplementedException();
        }

        public Task<IResponseRepository<RememberContent>> SaveContent(RememberContent obj)
        {
            throw new NotImplementedException();
        }
    }
}
