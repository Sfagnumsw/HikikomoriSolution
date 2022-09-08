using System;
using System.Collections.Generic;
using System.Linq;
using HikikomoriWEB.DAL.Interfaces;
using System.Threading.Tasks;
using HikikomoriWEB.Services.Interfaces;
using HikikomoriWEB.Domain.Interfaces;
using HikikomoriWEB.Domain.Entity;
using HikikomoriWEB.Domain.ResponseEntity;
using HikikomoriWEB.Domain.Enum;

namespace HikikomoriWEB.Services.RepositoryServices
{
    public class CategoriesService : ICategoriesService
    {
        private readonly ICategoriesRepository _repository;
        public CategoriesService(ICategoriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<IResponseRepository<IEnumerable<Categories>>> AllCategories()
        {
            try
            {
                var response = new ResponseRepository<IEnumerable<Categories>>();
                var CategoryList = await _repository.AllCategories();

                if(CategoryList.Any() != true)
                {
                    response.Description = "Categories.Method [AllCategories] : Список категорий пуст";
                    response.StatusCode = StatusCode.NotFound;
                    return response;
                }

                response.Data = CategoryList;
                response.StatusCode = StatusCode.OK;
                return response;
            }

            catch(Exception ex)
            {
                return new ResponseRepository<IEnumerable<Categories>>()
                {
                    Description = $"Categories.Method [AllCategories] : {ex.Message}",
                    StatusCode = StatusCode.ServerError
                };
            }
        }

        public async Task<IResponseRepository<Categories>> GetOnId(int CategoryId)
        {
            try
            {
                var response = new ResponseRepository<Categories>();
                var CategoryItem = await _repository.GetOnId(CategoryId);

                if(CategoryItem == null)
                {
                    response.Description = "Categories.Method [GetOnId] : Элемент таблицы с таким ID не найден";
                    response.StatusCode = StatusCode.NotFound;
                    return response;
                }

                response.Data = CategoryItem;
                response.StatusCode = StatusCode.OK;
                return response;
            }

            catch(Exception ex)
            {
                return new ResponseRepository<Categories>()
                {
                    Description = $"Categories.Method [GetOnId] : {ex.Message}",
                    StatusCode = StatusCode.ServerError
                };
            }
        }
    }
}
