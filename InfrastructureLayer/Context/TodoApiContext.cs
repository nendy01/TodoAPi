using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace InfrastructureLayer.Context
{
    public class TodoApiContext : DbContext
    {
        public TodoApiContext(DbContextOptions options): base(options)
        {
        }
        public DbSet<Tareas> Tareas { get; set; } = null!;
    }
   
}
