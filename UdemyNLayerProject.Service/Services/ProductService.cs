using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UdemyNLayerProject.Core.Models;
using UdemyNLayerProject.Core.Services;
using UdemyNLayerProject.Core.UnitOfWorks;

namespace UdemyNLayerProject.Service.Services
{
    class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork )
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Product> Add(Product entity)
        {
            await _unitOfWork.product.Add(entity);           
            await _unitOfWork.CommitAsnyc();

            return entity;
        }

        public async Task<IEnumerable<Product>> AddRange(IEnumerable<Product> entities)
        {
            await _unitOfWork.product.AddRange(entities);
            await _unitOfWork.CommitAsnyc();

            return entities;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _unitOfWork.product.GetAll();
        }

        public async Task<Product> GetById(int id)
        {
            return await _unitOfWork.product.GetById(id);
        }

        public async Task<Product> GetWithCategoryById(int productId)
        {
            return await _unitOfWork.product.GetWithCategoryById(productId);
        }

        public void Remove(Product entity)
        {
            _unitOfWork.product.Remove(entity);
            _unitOfWork.Commit();
        }

        public void RemoveRange(IEnumerable<Product> entities)
        {
            _unitOfWork.product.RemoveRange(entities);
            _unitOfWork.Commit();
        }

        public async Task<Product> SingleOrDefault(Expression<Func<Product, bool>> predicate)
        {
            return await _unitOfWork.product.SingleOrDefault(predicate);
        }

        public Product Update(Product entity)
        {
            var updatedProduct = _unitOfWork.product.Update(entity);
            _unitOfWork.Commit();

            return updatedProduct;
        }

        public async Task<IEnumerable<Product>> Where(Expression<Func<Product, bool>> predicate)
        {
            return await _unitOfWork.product.Where(predicate);
        }
    }
}
