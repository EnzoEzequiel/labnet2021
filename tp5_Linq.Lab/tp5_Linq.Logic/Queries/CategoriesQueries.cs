﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tp5_Linq.Entities;

namespace tp5_Linq.Logic
{
    public class CategoriesQueries : BaseLogic
    {
        public List<Categories> DistinctCategories()
        {
            var categoriesD = from categories in context.Categories
                              join products in context.Products on
                                categories.CategoryID equals products.CategoryID
                              select categories;
            return categoriesD.ToList();
        }
    }
}
