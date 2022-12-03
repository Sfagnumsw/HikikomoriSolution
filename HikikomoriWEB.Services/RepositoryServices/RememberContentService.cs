using System;
using System.Collections.Generic;
using System.Linq;
using HikikomoriWEB.Domain.Entity;
using HikikomoriWEB.Domain.Enum;
using HikikomoriWEB.Domain.ResponseEntity;
using HikikomoriWEB.DAL.Interfaces;
using HikikomoriWEB.Services.Interfaces;
using System.Threading.Tasks;
using HikikomoriWEB.Domain.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace HikikomoriWEB.Services.RepositoryServices
{
    public class RememberContentService : IBaseContentServices<RememberContentViewModel>
    {
        private readonly IBaseContentRepository<RememberContent> _repository;
        private readonly IAccountService _accountService;
        public RememberContentService(IBaseContentRepository<RememberContent> repository, IAccountService accountService)
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
            catch(Exception ex)
            {
                return new ServiceResponseEmpty()
                {
                    Description = $"RememberContentService.Method [DeleteContent] : {ex.Message}",
                    StatusCode = StatusCode.ServerError
                };
            }
        }

        public async Task<ServiceResponseEmpty> SaveContent(RememberContentViewModel obj)
        {
            try
            {
                var response = new ServiceResponseEmpty();
                IdentityUser currentUser = await _accountService.GetCurrentUser();
                RememberContent DBObj = new RememberContent()
                {
                    Name = obj.Name,
                    Autor = obj.Autor,
                    CategoryId = obj.CategoryId,
                    Genre = obj.Genre,
                    CreationYear = obj.CreationYear,
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
                    Description = $"Ошибка сохранения | RememberContentService.Method [SaveContent] : {ex.Message}",
                    StatusCode = StatusCode.ServerError
                };
            }
        }

        public async Task<ServiceResponse<IEnumerable<RememberContentViewModel>>> GetFilms()
        {
            return await GetContent(Categories.Films);
        }

        public async Task<ServiceResponse<IEnumerable<RememberContentViewModel>>> GetBooks()
        {
            return await GetContent(Categories.Books);
        }

        public async Task<ServiceResponse<IEnumerable<RememberContentViewModel>>> GetGames()
        {
            return await GetContent(Categories.Games);
        }

        public async Task<ServiceResponse<IEnumerable<RememberContentViewModel>>> GetSerials()
        {
            return await GetContent(Categories.Serials);
        }

        public async Task<ServiceResponse<IEnumerable<RememberContentViewModel>>> GetCartoons()
        {
            return await GetContent(Categories.Cartoons);
        }

        private async Task<ServiceResponse<IEnumerable<RememberContentViewModel>>> GetContent(Categories category)
        {
            try
            {
                var response = new ServiceResponse<IEnumerable<RememberContentViewModel>>();
                var ViewModelList = new List<RememberContentViewModel>();
                IdentityUser currentUser = await _accountService.GetCurrentUser();
                var RepositoryContentList = await _repository.GetOnCategoryId(category, currentUser.Id);

                if (RepositoryContentList.Any() != true)
                {
                    response.Description = "Элементы таблицы этой категории не найдены";
                    response.StatusCode = StatusCode.NotFound;
                    return response;
                }

                foreach (var i in RepositoryContentList)
                {
                    ViewModelList.Add(new RememberContentViewModel
                    {
                        Id = i.Id,
                        Name = i.Name,
                        Autor = i.Autor,
                        CategoryId = i.CategoryId,
                        Genre = i.Genre,
                        CreationYear = i.CreationYear
                    });
                }

                response.Data = ViewModelList;
                response.StatusCode = StatusCode.OK;
                return response;
            }
            catch (Exception ex)
            {
                return new ServiceResponse<IEnumerable<RememberContentViewModel>>()
                {
                    Description = $"RememberContentService.Method [GetOnCategoryId] : {ex.Message}",
                    StatusCode = StatusCode.ServerError
                };
            }
        }
    }
}
