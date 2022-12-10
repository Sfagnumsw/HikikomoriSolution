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
    public class RememberContentService : IContentServices<RememberContentViewModel>
    {
        private readonly IBaseContentRepository<RememberContent> _repository;
        private readonly IAccountService _accountService;
        public RememberContentService(IBaseContentRepository<RememberContent> repository, IAccountService accountService)
        {
            _repository = repository;
            _accountService = accountService;
        } 

        public async Task<ServiceResponseBase> DeleteContent(int ContentId)
        {
            try
            {
                await _repository.Delete(ContentId);
                return new ServiceResponseBase("Запись удалена", StatusCode.OK);
            }
            catch (Exception ex)
            {
                return new ServiceResponseBase(ex.Message, StatusCode.ServerError);
            }
        }

        public async Task<ServiceResponseBase> SaveContent(RememberContentViewModel model)
        {
            try
            {
                var response = await _accountService.GetCurrentUser();
                IdentityUser currentUser = response.Data;
                RememberContent DbModel = new RememberContent()
                {
                    Name = model.Name,
                    Autor = model.Autor,
                    CategoryId = model.CategoryId,
                    Genre = model.Genre,
                    CreationYear = model.CreationYear,
                    UserId = currentUser.Id
                };
                await _repository.Save(DbModel);
                return new ServiceResponseBase("Запись сохранена", StatusCode.OK);
            }
            catch (Exception ex)
            {
                return new ServiceResponseBase(ex.Message, StatusCode.ServerError);
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
                var response = await _accountService.GetCurrentUser();
                IdentityUser currentUser = response.Data;
                var repositoryContentList = await _repository.GetOnCategoryId(category, currentUser.Id);
                if (repositoryContentList.Any() != true) return new ServiceResponse<IEnumerable<RememberContentViewModel>>(StatusCode.NotFound);
                var ViewModelList = new List<RememberContentViewModel>();
                foreach (var i in repositoryContentList)
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
                return new ServiceResponse<IEnumerable<RememberContentViewModel>>(StatusCode.OK, ViewModelList);
            }
            catch (Exception ex)
            {
                return new ServiceResponse<IEnumerable<RememberContentViewModel>>(ex.Message, StatusCode.ServerError);
            }
        }
    }
}
