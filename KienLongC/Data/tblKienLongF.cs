using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using KienLongC.Models;
using Microsoft.AspNetCore.Mvc;

namespace KienLongC.Data
{
    public class tblKienLongF : DbContext
    {
        public tblKienLongF()
        {
            

        }

        public tblKienLongF(DbContextOptions<tblKienLongF> options)
          : base(options)
        { }
            
             public DbSet<Form> Form { get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Form>(entity =>
            {
                entity.Property(e => e.EmailInput).IsRequired();
            });

           
        }

      
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { 
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS01;Database=tblKienLongF;Trusted_Connection=True;");
        }
    
    }

       
    }

