using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRPortal.Data;
using HRPortal.Models;

namespace HRPortal.WebModels
{
    public class PolicyToAddVM// : IValidatableObject
    {
        public Policy PolicyToAdd { get; set; }
        public List<SelectListItem> CategoryList { get; set; }

        public PolicyToAddVM()
        {
            PolicyToAdd = new Policy();
            CategoryList = new List<SelectListItem>();
            CreateCategoryList();
        }

        public void CreateCategoryList()
        {
            CategoryDataBase cd = new CategoryDataBase();
            List<Category> categories = cd.GetAllCategoriess();
       
            foreach (var category in categories)
            {
                CategoryList.Add(new SelectListItem
                {
                    Text = category.categoryName
                });
            }
        }

        //public void CreateCategoryList(List<Category> categories)
        //{
        //    CategoryList = new List<SelectListItem>();
        //    foreach (var category in categories)
        //    {
        //        CategoryList.Add(new SelectListItem
        //        {
        //            Text = category.categoryName
        //        });
        //    }
        //}

        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    List<ValidationResult> errors = new List<ValidationResult>();

        //    if (string.IsNullOrEmpty(PolicyToAdd.Category.categoryName))
        //    {
        //        errors.Add(new ValidationResult("Please choose a Category",
        //            new[] { "Category" }));
        //    }

        //    if (string.IsNullOrEmpty(PolicyToAdd.PolicyTitle))
        //    {
        //        errors.Add(new ValidationResult("Enter a title",
        //            new[] { "PolicyTitle" }));
        //    }

        //    if (string.IsNullOrEmpty(PolicyToAdd.ContentText))
        //    {
        //        errors.Add(new ValidationResult("Enter the policy content",
        //            new[] { "ContentText" }));
        //    }

        //    return errors;

        //}
    }
}