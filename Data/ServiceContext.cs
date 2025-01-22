using Microsoft.EntityFrameworkCore;
using InfraManager.Models;

namespace InfraManager.Data
{
    public class ServiceContext : DbContext
    {
        public ServiceContext(DbContextOptions<ServiceContext> options) : base(options) { }

        public DbSet<Service> Services => Set<Service>();
        public DbSet<Consumer> Consumers => Set<Consumer>();
    }
}
