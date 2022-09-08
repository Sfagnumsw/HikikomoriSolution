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
    public class RememberContentService : IBaseContentServices<RememberContent>
    {
        private readonly IBaseContentRepository<RememberContent> _repository;
        public RememberContentService(IBaseContentRepository<RememberContent> repository)
        {
            _repository = repository;
        }

        public async Task<IResponseRepository<IEnumerable<RememberContent>>> AllContent()
        {
            try
            {
                var response = new ResponseRepository<IEnumerable<RememberContent>>();
                var ListContent = await _repository.AllContent();

                if(ListContent.Any() != true)
                {
                    response.Description = "RememberContent.Method [AllContent] : Список отложенного контента пуст";
                    response.StatusCode = StatusCode.NotFound;
                    return response;
                }

                response.Data = ListContent;
                response.StatusCode = StatusCode.OK;
                return response;
            }

            catch(Exception ex)
            {
                return new ResponseRepository<IEnumerable<RememberContent>>()
                {
                    Description = $"RememberContent.Method [AllContent] : {ex.Message}",
                    StatusCode = StatusCode.ServerError
                };
            }
        }

        public async Task<IResponseRepository<RememberContent>> DeleteContent(int ContentId)
        {
            try
            {
                var response = new ResponseRepository<RememberContent>();
                await _repository.DeleteContent(ContentId);
                response.StatusCode = StatusCode.OK;
                return response;
            }

            catch(Exception ex)
            {
                return new ResponseRepository<RememberContent>()
                {
                    Description = $"RememberContent.Method [DeleteContent] : {ex.Message}",
                    StatusCode = StatusCode.ServerError
                };
            }
        }

        public async Task<IResponseRepository<IEnumerable<RememberContent>>> GetOnCategoryId(int CategoryId)
        {

            try
            {
                var response = new ResponseRepository<IEnumerable<RememberContent>>();
                var ListContent = await _repository.GetOnCategoryId(CategoryId);

                if(ListContent.Any() != true)
                {
                    response.Description = "RememberContent.Method [GetOnCategoryId] : Элементы таблицы этой категории не найдены";
                    response.StatusCode = StatusCode.NotFound;
                    return response;
                }

                response.Data = ListContent;
                response.StatusCode = StatusCode.OK;
                return response;
            }

            catch(Exception ex)
            {
                return new ResponseRepository<IEnumerable<RememberContent>>()
                {
                    Description = $"RememberContent.Method [GetOnCategoryId] : {ex.Message}",
                    StatusCode = StatusCode.ServerError
                };
            }
        }

        public async Task<IResponseRepository<RememberContent>> GetOnId(int ContentId)
        {
            try
            {
                var response = new ResponseRepository<RememberContent>();
                var ContentItem = await _repository.GetOnId(ContentId);

                if(ContentItem == null)
                {
                    response.Description = "RememberContent.Method [GetOnId] : Элемент таблицы с таким ID не найден";
                    response.StatusCode = StatusCode.NotFound;
                    return response;
                }

                response.Data = ContentItem;
                response.StatusCode = StatusCode.OK;
                return response;
            }

            catch(Exception ex)
            {
                return new ResponseRepository<RememberContent>()
                {
                    Description = $"RememberContent.Method [GetOnId] : {ex.Message}",
                    StatusCode = StatusCode.ServerError
                };
            }
        }

        public async Task<IResponseRepository<RememberContent>> SaveContent(RememberContent obj)
        {
            try
            {
                var response = new ResponseRepository<RememberContent>();
                await _repository.SaveContent(obj);
                response.StatusCode = StatusCode.OK;
                return response;
            }

            catch(Exception ex)
            {
                return new ResponseRepository<RememberContent>()
                {
                    Description = $"RememberContent.Method [SaveContent] : {ex.Message}",
                    StatusCode = StatusCode.ServerError
                };
            }
        }
    }
}
