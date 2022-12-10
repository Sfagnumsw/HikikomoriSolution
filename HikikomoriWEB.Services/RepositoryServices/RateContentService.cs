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

namespace HikikomoriWEB.Services.RepositoryServices
{
    public class RateContentService : IContentServices<RateContentViewModel>
    {
        private readonly IBaseContentRepository<RateContent> _repository;
        private readonly IAccountService _accountService;
        public RateContentService(IBaseContentRepository<RateContent> repository, IAccountService accountService)
        {
            _repository = repository;
            _accountService = accountService;
        }

        public async Task<ServiceResponseBase> DeleteContent(int ContentId) //удалить
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

        public async Task<ServiceResponseBase> SaveContent(RateContentViewModel model)//сохранить
        {
            try
            {
                var response = await _accountService.GetCurrentUser();
                IdentityUser currentUser = response.Data;
                RateContent DbModel = new RateContent()
                {
                    Name = model.Name,
                    Autor = model.Autor,
                    Genre = model.Genre,
                    CreationYear = model.CreationYear,
                    CategoryId = model.CategoryId,
                    Rating = model.Rating,
                    Replay = model.Replay,
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

        private async Task<ServiceResponse<IEnumerable<RateContentViewModel>>> GetContent(Categories category) //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        {
            try
            {
                var response = await _accountService.GetCurrentUser();
                IdentityUser currentUser = response.Data;
                var repositoryContentList = await _repository.GetOnCategoryId(category, currentUser.Id);
                if (repositoryContentList.Any() != true) return new ServiceResponse<IEnumerable<RateContentViewModel>>(StatusCode.NotFound);
                var viewModelList = new List<RateContentViewModel>();
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
                return new ServiceResponse<IEnumerable<RateContentViewModel>>(StatusCode.OK, viewModelList);
            }
            catch (Exception ex)
            {
                return new ServiceResponse<IEnumerable<RateContentViewModel>>(ex.Message, StatusCode.ServerError);
            }
        }
    }
}
