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
                var ListContent = await _repository.GetAll();

                if(ListContent.Any() != true)
                {
                    response.Description = "RememberContentService.Method [AllContent] : Список отложенного контента пуст";
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
                    Description = $"RememberContentService.Method [AllContent] : {ex.Message}",
                    StatusCode = StatusCode.ServerError
                };
            }
        }

        public async Task<IResponseRepository<RememberContent>> DeleteContent(int ContentId)
        {
            try
            {
                var response = new ResponseRepository<RememberContent>();

                if(_repository.GetOnId(ContentId) == null)
                {
                    response.Description = $"RememberContentService.Method[DeleteContent] : Элемент таблицы с таким ID не найден";
                    response.StatusCode = StatusCode.NotFound;
                    return response;
                }
                await _repository.Delete(ContentId);
                response.StatusCode = StatusCode.OK;
                return response;
            }

            catch(Exception ex)
            {
                return new ResponseRepository<RememberContent>()
                {
                    Description = $"RememberContentService.Method [DeleteContent] : {ex.Message}",
                    StatusCode = StatusCode.ServerError
                };
            }
        }

        public async Task<IResponseRepository<IEnumerable<RememberContent>>> GetFilms()
        {
            try
            {
                var response = new ResponseRepository<IEnumerable<RememberContent>>();
                var FilmList = await _repository.GetOnCategoryId((int)Categories.Films);

                if(FilmList.Any() != true)
                {
                    response.Description = "RememberContentService.Method [GetOnCategoryId] : Элементы таблицы этой категории не найдены";
                    response.StatusCode = StatusCode.NotFound;
                    return response;
                }

                response.Data = FilmList;
                response.StatusCode = StatusCode.OK;
                return response;
            }

            catch(Exception ex)
            {
                return new ResponseRepository<IEnumerable<RememberContent>>()
                {
                    Description = $"RememberContentService.Method [GetOnCategoryId] : {ex.Message}",
                    StatusCode = StatusCode.ServerError
                };
            }
        }

        public async Task<IResponseRepository<IEnumerable<RememberContent>>> GetBooks()
        {
            try
            {
                var response = new ResponseRepository<IEnumerable<RememberContent>>();
                var BookList = await _repository.GetOnCategoryId((int)Categories.Books);

                if (BookList.Any() != true)
                {
                    response.Description = "RememberContentService.Method [GetOnCategoryId] : Элементы таблицы этой категории не найдены";
                    response.StatusCode = StatusCode.NotFound;
                    return response;
                }

                response.Data = BookList;
                response.StatusCode = StatusCode.OK;
                return response;
            }

            catch (Exception ex)
            {
                return new ResponseRepository<IEnumerable<RememberContent>>()
                {
                    Description = $"RememberContentService.Method [GetOnCategoryId] : {ex.Message}",
                    StatusCode = StatusCode.ServerError
                };
            }
        }

        public async Task<IResponseRepository<IEnumerable<RememberContent>>> GetGames()
        {
            try
            {
                var response = new ResponseRepository<IEnumerable<RememberContent>>();
                var GameList = await _repository.GetOnCategoryId((int)Categories.Games);

                if (GameList.Any() != true)
                {
                    response.Description = "RememberContentService.Method [GetOnCategoryId] : Элементы таблицы этой категории не найдены";
                    response.StatusCode = StatusCode.NotFound;
                    return response;
                }

                response.Data = GameList;
                response.StatusCode = StatusCode.OK;
                return response;
            }

            catch (Exception ex)
            {
                return new ResponseRepository<IEnumerable<RememberContent>>()
                {
                    Description = $"RememberContentService.Method [GetOnCategoryId] : {ex.Message}",
                    StatusCode = StatusCode.ServerError
                };
            }
        }

        public async Task<IResponseRepository<IEnumerable<RememberContent>>> GetSerials()
        {
            try
            {
                var response = new ResponseRepository<IEnumerable<RememberContent>>();
                var SerialList = await _repository.GetOnCategoryId((int)Categories.Serials);

                if (SerialList.Any() != true)
                {
                    response.Description = "RememberContentService.Method [GetOnCategoryId] : Элементы таблицы этой категории не найдены";
                    response.StatusCode = StatusCode.NotFound;
                    return response;
                }

                response.Data = SerialList;
                response.StatusCode = StatusCode.OK;
                return response;
            }

            catch (Exception ex)
            {
                return new ResponseRepository<IEnumerable<RememberContent>>()
                {
                    Description = $"RememberContentService.Method [GetOnCategoryId] : {ex.Message}",
                    StatusCode = StatusCode.ServerError
                };
            }
        }

        public async Task<IResponseRepository<IEnumerable<RememberContent>>> GetCartoons()
        {
            try
            {
                var response = new ResponseRepository<IEnumerable<RememberContent>>();
                var CartoonList = await _repository.GetOnCategoryId((int)Categories.Cartoons);

                if (CartoonList.Any() != true)
                {
                    response.Description = "RememberContentService.Method [GetOnCategoryId] : Элементы таблицы этой категории не найдены";
                    response.StatusCode = StatusCode.NotFound;
                    return response;
                }

                response.Data = CartoonList;
                response.StatusCode = StatusCode.OK;
                return response;
            }

            catch (Exception ex)
            {
                return new ResponseRepository<IEnumerable<RememberContent>>()
                {
                    Description = $"RememberContentService.Method [GetOnCategoryId] : {ex.Message}",
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
                    response.Description = "RememberContentService.Method [GetOnId] : Элемент таблицы с таким ID не найден";
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
                    Description = $"RememberContentService.Method [GetOnId] : {ex.Message}",
                    StatusCode = StatusCode.ServerError
                };
            }
        }

        public async Task<IResponseRepository<RememberContent>> SaveContent(RememberContent obj)
        {
            try
            {
                var response = new ResponseRepository<RememberContent>();
                await _repository.Save(obj);
                response.Description = "Запись сохранена";
                response.StatusCode = StatusCode.OK;
                return response;
            }

            catch(Exception ex)
            {
                return new ResponseRepository<RememberContent>()
                {
                    Description = $"RememberContentService.Method [SaveContent] : {ex.Message}",
                    StatusCode = StatusCode.ServerError
                };
            }
        }
    }
}
