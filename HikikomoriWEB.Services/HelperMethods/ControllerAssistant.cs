﻿using System.Collections.Generic;
using HikikomoriWEB.Domain.Enum;
using HikikomoriWEB.Domain.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using HikikomoriWEB.Domain.ResponseEntity;

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

        public static bool ErrorCheck<RContent>(this ResponseRepository<IEnumerable<RContent>> content) //проверка StatusCode
        where RContent : AbstractContentViewModel
        {
            if (content.StatusCode != StatusCode.ServerError) return true;
            else return false;
        }

        public static bool ErrorCheck<RContent>(this ResponseRepository<RContent> content)
        where RContent : AbstractContentViewModel
        {
            if (content.StatusCode != StatusCode.ServerError) return true;
            else return false;
        }
    }
}
