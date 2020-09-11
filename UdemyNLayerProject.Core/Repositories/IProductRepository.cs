using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UdemyNLayerProject.Core.Models;

namespace UdemyNLayerProject.Core.Repositories
{
    interface IProductRepository:IRepository<Product>
    {
        Task<Product> GetWithCategoryById(int productId);
    }
}
