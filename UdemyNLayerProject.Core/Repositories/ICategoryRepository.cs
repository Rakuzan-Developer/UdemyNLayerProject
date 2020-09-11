﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UdemyNLayerProject.Core.Models;

namespace UdemyNLayerProject.Core.Repositories
{
    interface ICategoryRepository:IRepository<Category>
    {
        Task<Category> GetWithProductsById(int categoryId);
    }
}