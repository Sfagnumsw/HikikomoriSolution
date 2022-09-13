﻿using System.Collections.Generic;
using HikikomoriWEB.Domain.Enum;
using HikikomoriWEB.Domain.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Reflection;
using System.ComponentModel.DataAnnotations;

namespace HikikomoriWEB.Services.HelperMethods
{
    public static class Helpers
    {
        public static SelectList SelectListCategories()
        {
            List<CategoryViewModel> categoryList = new List<CategoryViewModel>();
            var arr = typeof(Categories).GetFields();
            foreach(var i in arr)
            {
                if (i.Name.Equals("value__")) continue;
                categoryList.Add(new CategoryViewModel() { Name = ((DisplayAttribute)i.GetCustomAttributes(typeof(DisplayAttribute), true)[0]).Name, Value = int.Parse(i.GetRawConstantValue().ToString()) });              
            }
            return new SelectList(categoryList, "Value", "Name");
        }
    }
}
