using System.Collections.Generic;
using HikikomoriWEB.Domain.Enum;
using HikikomoriWEB.Domain.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using HikikomoriWEB.Domain.Interfaces;
using HikikomoriWEB.Domain.Entity;
using System.ComponentModel.DataAnnotations;

namespace HikikomoriWEB.Services.HelperMethods
{
    public static class ControllerAssistant
    {
        public static SelectList SelectListCategories() //формирование selectlist для категорий
        {
            List<CategoryViewModel> categoryList = new List<CategoryViewModel>();
            var arr = typeof(Categories).GetFields();
            foreach (var i in arr)
            {
                if (i.Name.Equals("value__")) continue;
                categoryList.Add(new CategoryViewModel() { Name = ((DisplayAttribute)i.GetCustomAttributes(typeof(DisplayAttribute), true)[0]).Name, Value = int.Parse(i.GetRawConstantValue().ToString()) });
            }
            return new SelectList(categoryList, "Value", "Name");
        }

        public static bool ErrorCheck<Rate, Remember>(IResponseRepository<Rate> rated, IResponseRepository<Remember> remembered) //проверка StatusCode
        where Rate : AbstractContent
        where Remember : AbstractContent
        {
            if (rated.StatusCode == StatusCode.ServerError || remembered.StatusCode == StatusCode.ServerError)
            {
                return false;
            }
            return true;
        }

        public static bool ErrorCheck<Rate, Remember>(IResponseRepository<IEnumerable<Rate>> rated, IResponseRepository<IEnumerable<Remember>> remembered)
        where Rate : AbstractContent
        where Remember : AbstractContent
        {
            if (rated.StatusCode == StatusCode.ServerError || remembered.StatusCode == StatusCode.ServerError)
            {
                return false;
            }
            return true;
        }

        public static bool ErrorCheck<RContent>(IResponseRepository<RContent> content)
        where RContent : AbstractContent
        {
            if (content.StatusCode == StatusCode.ServerError)
            {
                return false;
            }
            return true;
        }
    }
}
