﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRentals.DataAccess;

namespace CarRentals.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDatabaseFactory databaseFactory;

        private CarRentalDbContext _dbContext;

        public UnitOfWork(IDatabaseFactory databaseFactory)
        {
            this.databaseFactory = databaseFactory;
        }

        public void Commit()
        {
            DataContext.Commit();
        }

        public CarRentalDbContext DataContext
        {
            get {

                return (_dbContext ?? new CarRentalDbContext());
            }
           
        }
    }
}