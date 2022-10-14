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
using Microsoft.Extensions.Logging;

namespace HikikomoriWEB.Services.RepositoryServices
{
    public class RateContentService : IBaseContentServices<RateContent>
    {
        private readonly IBaseContentRepository<RateContent> _repository;
        private readonly ILogger<RateContent> _logger;
        public RateContentService(IBaseContentRepository<RateContent> repository, ILogger<RateContent> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<IResponseRepository<IEnumerable<RateContent>>> GetAll()
        {
            try
            {
                var response = new ResponseRepository<IEnumerable<RateContent>>();
                var ContentList = await _repository.GetAll();

                if (ContentList.Any() != true)
                {
                    response.Description = "RateContentService.Method [AllContent] : Список оцененного контента пуст";
                    response.StatusCode = StatusCode.NotFound;
                    return response;
                }

                response.Data = ContentList;
                response.StatusCode = StatusCode.OK;
                return response;
            }

            catch (Exception ex)
            {
                return new ResponseRepository<IEnumerable<RateContent>>()
                {
                    Description = $"RateContentService.Method [AllContent] : {ex.Message}",
                    StatusCode = StatusCode.ServerError
                };
            }
        }


        public async Task<IResponseRepository<RateContent>> DeleteContent(int ContentId)
        {
            try
            {
                var response = new ResponseRepository<RateContent>();
                await _repository.Delete(ContentId);
                response.StatusCode = StatusCode.OK;
                return response;
            }

            catch (Exception ex)
            {
                return new ResponseRepository<RateContent>()
                {
                    Description = $"RateContentService.Method [DeleteContent] : {ex.Message}",
                    StatusCode = StatusCode.ServerError
                };
            }

        }

        public async Task<IResponseRepository<IEnumerable<RateContent>>> GetFilms()
        {
            try
            {
                var response = new ResponseRepository<IEnumerable<RateContent>>();
                var FilmList = await _repository.GetOnCategoryId((int)Categories.Films);

                if (FilmList.Any() != true)
                {
                    response.Description = "RateContentService.Method [GetOnCategoryId] : Элементы таблицы этой категории не найдены";
                    response.StatusCode = StatusCode.NotFound;
                    return response;
                }

                response.Data = FilmList;
                response.StatusCode = StatusCode.OK;
                return response;
            }

            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                return new ResponseRepository<IEnumerable<RateContent>>()
                {
                    Description = $"RateContentService.Method [GetFilms] : {ex.Message}",
                    StatusCode = StatusCode.ServerError
                };
            }
        }

        public async Task<IResponseRepository<IEnumerable<RateContent>>> GetBooks()
        {
            try
            {
                var response = new ResponseRepository<IEnumerable<RateContent>>();
                var BookList = await _repository.GetOnCategoryId((int)Categories.Books);

                if (BookList.Any() != true)
                {
                    response.Description = "RateContentService.Method [GetOnCategoryId] : Элементы таблицы этой категории не найдены";
                    response.StatusCode = StatusCode.NotFound;
                    return response;
                }

                response.Data = BookList;
                response.StatusCode = StatusCode.OK;
                return response;
            }

            catch (Exception ex)
            {
                return new ResponseRepository<IEnumerable<RateContent>>()
                {
                    Description = $"RateContentService.Method [GetFilms] : {ex.Message}",
                    StatusCode = StatusCode.ServerError
                };
            }
        }

        public async Task<IResponseRepository<IEnumerable<RateContent>>> GetGames()
        {
            try
            {
                var response = new ResponseRepository<IEnumerable<RateContent>>();
                var GameList = await _repository.GetOnCategoryId((int)Categories.Games);

                if (GameList.Any() != true)
                {
                    response.Description = "RateContentService.Method [GetOnCategoryId] : Элементы таблицы этой категории не найдены";
                    response.StatusCode = StatusCode.NotFound;
                    return response;
                }

                response.Data = GameList;
                response.StatusCode = StatusCode.OK;
                return response;
            }

            catch (Exception ex)
            {
                return new ResponseRepository<IEnumerable<RateContent>>()
                {
                    Description = $"RateContentService.Method [GetFilms] : {ex.Message}",
                    StatusCode = StatusCode.ServerError
                };
            }
        }

        public async Task<IResponseRepository<IEnumerable<RateContent>>> GetSerials()
        {
            try
            {
                var response = new ResponseRepository<IEnumerable<RateContent>>();
                var SerialsList = await _repository.GetOnCategoryId((int)Categories.Serials);

                if (SerialsList.Any() != true)
                {
                    response.Description = "RateContentService.Method [GetOnCategoryId] : Элементы таблицы этой категории не найдены";
                    response.StatusCode = StatusCode.NotFound;
                    return response;
                }

                response.Data = SerialsList;
                response.StatusCode = StatusCode.OK;
                return response;
            }

            catch (Exception ex)
            {
                return new ResponseRepository<IEnumerable<RateContent>>()
                {
                    Description = $"RateContentService.Method [GetFilms] : {ex.Message}",
                    StatusCode = StatusCode.ServerError
                };
            }
        }

        public async Task<IResponseRepository<IEnumerable<RateContent>>> GetCartoons()
        {
            try
            {
                var response = new ResponseRepository<IEnumerable<RateContent>>();
                var CartoonsList = await _repository.GetOnCategoryId((int)Categories.Cartoons);

                if (CartoonsList.Any() != true)
                {
                    response.Description = "RateContentService.Method [GetOnCategoryId] : Элементы таблицы этой категории не найдены";
                    response.StatusCode = StatusCode.NotFound;
                    return response;
                }

                response.Data = CartoonsList;
                response.StatusCode = StatusCode.OK;
                return response;
            }

            catch (Exception ex)
            {
                return new ResponseRepository<IEnumerable<RateContent>>()
                {
                    Description = $"RateContentService.Method [GetFilms] : {ex.Message}",
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

                if (ContentItem == null)
                {
                    response.Description = "RateContentService.Method [GetOnId] : Элемент таблицы с таким ID не найден";
                    response.StatusCode = StatusCode.NotFound;
                    return response;
                }

                response.Data = ContentItem;
                response.StatusCode = StatusCode.OK;
                return response;
            }

            catch (Exception ex)
            {
                return new ResponseRepository<RateContent>()
                {
                    Description = $"RateContentService.Method [GetOnId] : {ex.Message}",
                    StatusCode = StatusCode.ServerError
                };
            }
        }

        public async Task<IResponseRepository<RateContent>> SaveContent(RateContent obj)
        {
            try
            {
                var response = new ResponseRepository<RateContent>();
                await _repository.Save(obj);
                response.Description = "Запись сохранена";
                response.StatusCode = StatusCode.OK;
                return response;
            }

            catch (Exception ex)
            {
                return new ResponseRepository<RateContent>()
                {
                    Description = $"RateContentService.Method [SaveContent] : {ex.Message}",
                    StatusCode = StatusCode.ServerError
                };
            }
        }
    }
}
