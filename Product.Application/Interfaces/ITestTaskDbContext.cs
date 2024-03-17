using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Domain;

namespace TestTask.Application.Interfaces
{
    public interface ITestTaskDbContext
    {
        DbSet<Product> Products { get; set; }
        DbSet<ProductVersion> ProductVersions { get; set; }
        DbSet<EventLog> EventLogs { get; set; }

        //отвечает за сохранение данных в базе
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        
    }
}
