﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HikikomoriWEB.DAL.Interfaces
{
    public interface IBaseContentRepository<T>
    {
        Task<IEnumerable<T>> GetAll(); // получить все
        Task<T> GetOnId(int Id); // получить по ID
        Task Save(T obj); // сохранить
        Task Delete(int Id); // удалить
        Task<IEnumerable<T>> GetOnCategoryId(int CategoryId); // контент из определенной категории

    }
}
