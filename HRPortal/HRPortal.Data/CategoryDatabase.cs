using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using HRPortal.Models;

namespace HRPortal.Data
{
    public class CategoryDataBase
    {
        private static List<Category> _categories; 

        public CategoryDataBase()
        {
            if (_categories == null)
            {
                _categories = GetAllDefaultCategoriess();
            }
        }

        public List<Category> GetAllDefaultCategoriess()
        {
            return new List<Category>
            {
                new Category {categoryName = "Benefit"},
                new Category {categoryName = "Compensation"},
                new Category {categoryName = "Disability"},
                new Category {categoryName = "Handicapped"},
                new Category {categoryName = "Overtime"},
                new Category {categoryName = "Relocation"}
            };
        }

        public List<Category> GetAllCategoriess()
        {
            return _categories;
        }

        public void AddNewCategory(string categoryName)
        {
            Category category = new Category();
            category.categoryName = categoryName;
            _categories.Add(category);
        }

        public List<SelectListItem> CreateCategoryList()
        {
            List<SelectListItem> CategoryList = new List<SelectListItem>();

            foreach (var category in _categories)
            {
                CategoryList.Add(new SelectListItem
                {
                    Text = category.categoryName
                });
            }

            return CategoryList;
        }
    }
}
