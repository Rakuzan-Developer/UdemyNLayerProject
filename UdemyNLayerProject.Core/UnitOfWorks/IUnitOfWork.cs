﻿using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using System.Threading.Tasks;
using UdemyNLayerProject.Core.Repositories;

namespace UdemyNLayerProject.Core.UnitOfWorks
{
    interface IUnitOfWork
    {
        ICategoryRepository category { get; }
        IProductRepository product { get; }

        Task CommitAsnyc();
        void Commit();
    }
}