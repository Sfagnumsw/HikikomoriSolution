using System;
using System.Collections.Generic;
using System.Linq;
using HikikomoriWEB.Services.Interfaces;
using System.Threading.Tasks;
using HikikomoriWEB.Domain.Entity;
using HikikomoriWEB.Domain.ResponseEntity;
using HikikomoriWEB.DAL.Interfaces;
using HikikomoriWEB.Domain.Enum;
using HikikomoriWEB.Domain.ViewModels;

namespace HikikomoriWEB.Services.RepositoryServices
{
    public class RateContentService : IBaseContentServices<RateContentViewModel>
    {
        private readonly IBaseContentRepository<RateContent> _repository;
        public RateContentService(IBaseContentRepository<RateContent> repository)
        {
            _repository = repository;
        }

        public async Task<ServiceResponseEmpty> DeleteContent(int ContentId)
        {
            try
            {
                var response = new ServiceResponseEmpty();
                await _repository.Delete(ContentId);
                response.Description = "Запись удалена";
                response.StatusCode = StatusCode.OK;
                return response;
            }
            catch (Exception ex)
            {
                return new ServiceResponseEmpty()
                {
                    Description = $"RateContentService.Method [DeleteContent] : {ex.Message}",
                    StatusCode = StatusCode.ServerError
                };
            }

        }

        public async Task<ServiceResponseEmpty> SaveContent(RateContentViewModel obj)
        {
            try
            {
                var response = new ServiceResponseEmpty();

                RateContent DBObj = new RateContent()
                {
                    Name = obj.Name,
                    Autor = obj.Autor,
                    Genre = obj.Genre,
                    CreationYear = obj.CreationYear,
                    CategoryId = obj.CategoryId,
                    Rating = obj.Rating,
                    Replay = obj.Replay,
                                                         //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                };

                await _repository.Save(DBObj);
                response.Description = "Запись сохранена";
                response.StatusCode = StatusCode.OK;
                return response;
            }
            catch (Exception ex)
            {
                return new ServiceResponseEmpty()
                {
                    Description = $"Ошибка сохранения | RateContentService.Method [SaveContent] : {ex.Message}",
                    StatusCode = StatusCode.ServerError
                };
            }
        }

        public async Task<ServiceResponse<IEnumerable<RateContentViewModel>>> GetFilms()
        {
            return await GetContent(Categories.Films);
        }

        public async Task<ServiceResponse<IEnumerable<RateContentViewModel>>> GetBooks()
        {
            return await GetContent(Categories.Books);
        }

        public async Task<ServiceResponse<IEnumerable<RateContentViewModel>>> GetGames()
        {
            return await GetContent(Categories.Games);
        }

        public async Task<ServiceResponse<IEnumerable<RateContentViewModel>>> GetSerials()
        {
            return await GetContent(Categories.Serials);
        }

        public async Task<ServiceResponse<IEnumerable<RateContentViewModel>>> GetCartoons()
        {
            return await GetContent(Categories.Cartoons);
        }

        private async Task<ServiceResponse<IEnumerable<RateContentViewModel>>> GetContent(Categories category)
        {
            try
            {
                var response = new ServiceResponse<IEnumerable<RateContentViewModel>>();
                var ViewModelList = new List<RateContentViewModel>();
                var RepositoryContentList = await _repository.GetOnCategoryId(category);

                if (RepositoryContentList.Any() != true)
                {
                    response.Description = "Элементы таблицы этой категории не найдены";
                    response.StatusCode = StatusCode.NotFound;
                    return response;
                }

                foreach (var i in RepositoryContentList)
                {
                    ViewModelList.Add(new RateContentViewModel
                    {
                        Id = i.Id,
                        Name = i.Name,
                        Autor = i.Autor,
                        CategoryId = i.CategoryId,
                        Genre = i.Genre,
                        CreationYear = i.CreationYear,
                        Rating = i.Rating,
                        Replay = i.Replay
                    });
                }

                response.Data = ViewModelList;
                response.StatusCode = StatusCode.OK;
                return response;
            }
            catch (Exception ex)
            {
                return new ServiceResponse<IEnumerable<RateContentViewModel>>()
                {
                    Description = $"RateContentService.Method [GetFilms] : {ex.Message}",
                    StatusCode = StatusCode.ServerError
                };
            }
        }
    }
}
