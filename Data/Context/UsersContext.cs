﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Store.Data.Mapping;
using Store.Domain.Entities.Users;

namespace Store.Data.Context
{
    public class UsersContext: DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseMySql("Server=localhost;Port=3306;Database=store_users;Uid=root;Pwd=VisualStudio.Net3");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(new UserMap().Configure);

            modelBuilder.Entity<Person>(new PersonMap().Configure);

            modelBuilder.Entity<Address>(new AddressMap().Configure);

            modelBuilder.Entity<Phone>(new PhoneMap().Configure);

            modelBuilder.Entity<Client>(new ClientMap().Configure);

            modelBuilder.Entity<Employee>(new EmployeeMap().Configure);
        }
    }
}
