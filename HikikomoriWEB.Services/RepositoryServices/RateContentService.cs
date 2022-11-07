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

        public async Task<ResponseRepository<RateContentViewModel>> DeleteContent(int ContentId)
        {
            try
            {
                var response = new ResponseRepository<RateContentViewModel>();
                await _repository.Delete(ContentId);
                response.Description = "Запись удалена";
                response.StatusCode = StatusCode.OK;
                return response;
            }

            catch (Exception ex)
            {
                return new ResponseRepository<RateContentViewModel>()
                {
                    Description = $"RateContentService.Method [DeleteContent] : {ex.Message}",
                    StatusCode = StatusCode.ServerError
                };
            }

        }

        public async Task<ResponseRepository<RateContentViewModel>> SaveContent(RateContentViewModel obj)
        {
            try
            {
                var response = new ResponseRepository<RateContentViewModel>();

                RateContent DBObj = new RateContent()
                {
                    Name = obj.Name,
                    Autor = obj.Autor,
                    Genre = obj.Genre,
                    CreationYear = obj.CreationYear,
                    CategoryId = obj.CategoryId,
                    Rating = obj.Rating,
                    Replay = obj.Replay
                };

                await _repository.Save(DBObj);
                response.Description = "Запись сохранена";
                response.StatusCode = StatusCode.OK;
                return response;
            }

            catch (Exception ex)
            {
                return new ResponseRepository<RateContentViewModel>()
                {
                    Description = $"Ошибка сохранения | RateContentService.Method [SaveContent] : {ex.Message}",
                    StatusCode = StatusCode.ServerError
                };
            }
        }

        public async Task<ResponseRepository<IEnumerable<RateContentViewModel>>> GetFilms()
        {
            return await GetContent((int)Categories.Films);
        }

        public async Task<ResponseRepository<IEnumerable<RateContentViewModel>>> GetBooks()
        {
            return await GetContent((int)Categories.Books);
        }

        public async Task<ResponseRepository<IEnumerable<RateContentViewModel>>> GetGames()
        {
            return await GetContent((int)Categories.Games);
        }

        public async Task<ResponseRepository<IEnumerable<RateContentViewModel>>> GetSerials()
        {
            return await GetContent((int)Categories.Serials);
        }

        public async Task<ResponseRepository<IEnumerable<RateContentViewModel>>> GetCartoons()
        {
            return await GetContent((int)Categories.Cartoons);
        }

        private async Task<ResponseRepository<IEnumerable<RateContentViewModel>>> GetContent(int CategoryId)
        {
            try
            {
                var response = new ResponseRepository<IEnumerable<RateContentViewModel>>();
                var ViewModelList = new List<RateContentViewModel>();
                var RepositoryContentList = await _repository.GetOnCategoryId(CategoryId);

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
                return new ResponseRepository<IEnumerable<RateContentViewModel>>()
                {
                    Description = $"RateContentService.Method [GetFilms] : {ex.Message}",
                    StatusCode = StatusCode.ServerError
                };
            }
        }
    }
}
