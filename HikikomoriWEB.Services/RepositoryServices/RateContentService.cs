using System;
using System.Collections.Generic;
using System.Linq;
using HikikomoriWEB.Services.Interfaces;
using System.Threading.Tasks;
using HikikomoriWEB.Domain.Entity;
using HikikomoriWEB.Domain.ResponseEntity;
using HikikomoriWEB.DAL.Interfaces;
using HikikomoriWEB.Domain.Enum;
using HikikomoriWEB.Domain.Interfaces;

namespace HikikomoriWEB.Services.RepositoryServices
{
    public class RateContentService : IBaseContentServices<RateContent>
    {
        private readonly IBaseContentRepository<RateContent> _repository;
        public RateContentService(IBaseContentRepository<RateContent> repository)
        {
            _repository = repository;
        }

        public async Task<IResponseRepository<IEnumerable<RateContent>>> AllContent()
        {
            try
            {
                var response = new ResponseRepository<IEnumerable<RateContent>>();
                var ContentList = await _repository.AllContent();

                if(ContentList.Any() != true)
                {
                    response.Description = "RateContent.Method [AllContent] : Список оцененного контента пуст";
                    response.StatusCode = StatusCode.NotFound;
                    return response;
                }

                response.Data = ContentList;
                response.StatusCode = StatusCode.OK;
                return response;
            }

            catch(Exception ex)
            {
                return new ResponseRepository<IEnumerable<RateContent>>()
                {
                    Description = $"RateContent.Method [AllContent] : {ex.Message}",
                    StatusCode = StatusCode.ServerError
                };
            }
        }


        public async Task<IResponseRepository<RateContent>> DeleteContent(int ContentId)
        {
            try
            {
                var response = new ResponseRepository<RateContent>();
                await _repository.DeleteContent(ContentId);
                response.StatusCode = StatusCode.OK;
                return response;
            }

            catch(Exception ex)
            {
                return new ResponseRepository<RateContent>()
                {
                    Description = $"RateContent.Method [DeleteContent] : {ex.Message}",
                    StatusCode = StatusCode.ServerError
                };
            }
            
        }

        public async Task<IResponseRepository<IEnumerable<RateContent>>> GetOnCategoryId(int CategoryId)
        {
            try
            {
                var response = new ResponseRepository<IEnumerable<RateContent>>();
                var ContentList = await _repository.GetOnCategoryId(CategoryId);

                if(ContentList.Any() != true)
                {
                    response.Description = "RateContent.Method [GetOnCategoryId] : Элементы таблицы этой категории не найдены";
                    response.StatusCode = StatusCode.NotFound;
                }

                response.Data = ContentList;
                response.StatusCode = StatusCode.OK;
                return response;
            }

            catch(Exception ex)
            {
                return new ResponseRepository<IEnumerable<RateContent>>()
                {
                    Description = $"RateContent.Method [GetOnCategoryId] : {ex.Message}",
                    StatusCode = StatusCode.ServerError
                };
            }
        }

        public async Task<IResponseRepository<RateContent>> GetOnId(int ContentId)
        {
            try
            {
                var response = new ResponseRepository<RateContent>();
                var ContentItem = await _repository.GetOnId(ContentId);

                if(ContentItem == null)
                {
                    response.Description = "RateContent.Method [GetOnId] : Элемент таблицы с таким ID не найден";
                    response.StatusCode = StatusCode.NotFound;
                    return response;
                }

                response.Data = ContentItem;
                response.StatusCode = StatusCode.OK;
                return response;
            }

            catch(Exception ex)
            {
                return new ResponseRepository<RateContent>()
                {
                    Description = $"RateContent.Method [GetOnId] : {ex.Message}",
                    StatusCode = StatusCode.ServerError
                };
            }
        }

        public async Task<IResponseRepository<RateContent>> SaveContent(RateContent obj)
        {
            try
            {
                var response = new ResponseRepository<RateContent>();
                await _repository.SaveContent(obj);
                response.StatusCode = StatusCode.OK;
                return response;
            }

            catch(Exception ex)
            {
                return new ResponseRepository<RateContent>()
                {
                    Description = $"RateContent.Method [SaveContent] : {ex.Message}",
                    StatusCode = StatusCode.ServerError
                };
            }
        }
    }
}
