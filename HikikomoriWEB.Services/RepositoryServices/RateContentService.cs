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
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace HikikomoriWEB.Services.RepositoryServices
{
    public class RateContentService : IBaseContentServices<RateContentViewModel>
    {
        private readonly IBaseContentRepository<RateContent> _repository;
        private readonly IAccountService _accountService;
        public RateContentService(IBaseContentRepository<RateContent> repository, IAccountService accountService)
        {
            _repository = repository;
            _accountService = accountService;
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
                IdentityUser currentUser = await _accountService.GetCurrentUser();
                RateContent DBObj = new RateContent()
                {
                    Name = obj.Name,
                    Autor = obj.Autor,
                    Genre = obj.Genre,
                    CreationYear = obj.CreationYear,
                    CategoryId = obj.CategoryId,
                    Rating = obj.Rating,
                    Replay = obj.Replay,
                    UserId = currentUser.Id
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
                var viewModelList = new List<RateContentViewModel>();
                IdentityUser currentUser = await _accountService.GetCurrentUser();
                var repositoryContentList = await _repository.GetOnCategoryId(category, currentUser.Id);

                if (repositoryContentList.Any() != true)
                {
                    response.Description = "Элементы таблицы этой категории не найдены";
                    response.StatusCode = StatusCode.NotFound;
                    return response;
                }

                foreach (var i in repositoryContentList)
                {
                    viewModelList.Add(new RateContentViewModel
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

                response.Data = viewModelList;
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
