using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UdemyNLayerProject.Core.Repositories;
using UdemyNLayerProject.Core.UnitOfWorks;
using UdemyNLayerProject.Data.Repositories;

namespace UdemyNLayerProject.Data.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        private ProductRepository _productRepository;
        private CategoryRepository _categoryRepository;


        public ICategoryRepository category => _categoryRepository = _categoryRepository ?? new CategoryRepository(_context);
         

        public IProductRepository product => _productRepository = _productRepository ?? new ProductRepository(_context);

        public UnitOfWork(AppDbContext appDbContext)
        {
            _context = appDbContext;

        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsnyc()
        {
            await _context.SaveChangesAsync();
        }
    }
}
