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

namespace HikikomoriWEB.Services.RepositoryServices
{
    public class RememberContentService : IBaseContentServices<RememberContentViewModel>
    {
        private readonly IBaseContentRepository<RememberContent> _repository;
        public RememberContentService(IBaseContentRepository<RememberContent> repository)
        {
            _repository = repository;
        } 

        public async Task<ResponseRepository<RememberContentViewModel>> DeleteContent(int ContentId)
        {
            try
            {
                var response = new ResponseRepository<RememberContentViewModel>();
                await _repository.Delete(ContentId);
                response.Description = "Запись удалена";
                response.StatusCode = StatusCode.OK;
                return response;
            }
            catch(Exception ex)
            {
                return new ResponseRepository<RememberContentViewModel>()
                {
                    Description = $"RememberContentService.Method [DeleteContent] : {ex.Message}",
                    StatusCode = StatusCode.ServerError
                };
            }
        }

        public async Task<ResponseRepository<RememberContentViewModel>> SaveContent(RememberContentViewModel obj)
        {
            try
            {
                var response = new ResponseRepository<RememberContentViewModel>();

                RememberContent DBObj = new RememberContent()
                {
                    Name = obj.Name,
                    Autor = obj.Autor,
                    CategoryId = obj.CategoryId,
                    Genre = obj.Genre,
                    CreationYear = obj.CreationYear
                };

                await _repository.Save(DBObj);
                response.Description = "Запись сохранена";
                response.StatusCode = StatusCode.OK;
                return response;
            }

            catch (Exception ex)
            {
                return new ResponseRepository<RememberContentViewModel>()
                {
                    Description = $"Ошибка сохранения | RememberContentService.Method [SaveContent] : {ex.Message}",
                    StatusCode = StatusCode.ServerError
                };
            }
        }

        public async Task<ResponseRepository<IEnumerable<RememberContentViewModel>>> GetFilms()
        {
            return await GetContent((int)Categories.Films);
        }

        public async Task<ResponseRepository<IEnumerable<RememberContentViewModel>>> GetBooks()
        {
            return await GetContent((int)Categories.Books);
        }

        public async Task<ResponseRepository<IEnumerable<RememberContentViewModel>>> GetGames()
        {
            return await GetContent((int)Categories.Games);
        }

        public async Task<ResponseRepository<IEnumerable<RememberContentViewModel>>> GetSerials()
        {
            return await GetContent((int)Categories.Serials);
        }

        public async Task<ResponseRepository<IEnumerable<RememberContentViewModel>>> GetCartoons()
        {
            return await GetContent((int)Categories.Cartoons);
        }

        private async Task<ResponseRepository<IEnumerable<RememberContentViewModel>>> GetContent(int CategoryId)
        {
            try
            {
                var response = new ResponseRepository<IEnumerable<RememberContentViewModel>>();
                var ViewModelList = new List<RememberContentViewModel>();
                var RepositoryContentList = await _repository.GetOnCategoryId(CategoryId);

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
                return new ResponseRepository<IEnumerable<RememberContentViewModel>>()
                {
                    Description = $"RememberContentService.Method [GetOnCategoryId] : {ex.Message}",
                    StatusCode = StatusCode.ServerError
                };
            }
        }
    }
}
