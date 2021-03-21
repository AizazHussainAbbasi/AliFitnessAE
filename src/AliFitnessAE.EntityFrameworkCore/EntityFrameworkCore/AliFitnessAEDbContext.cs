using Abp.Zero.EntityFrameworkCore;
using AliFitnessAE.Authorization.Roles;
using AliFitnessAE.Authorization.Users;
using AliFitnessAE.Document;
using AliFitnessAE.LookUp;
using AliFitnessAE.MultiTenancy;
using AliFitnessAE.StatusCore;
using AliFitnessAE.TopicContent;
using AliFitnessAE.UserTrackingCore;
using AliFitnessAE.UserTypeCore;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AliFitnessAE.EntityFrameworkCore
{
    public class AliFitnessAEDbContext : AbpZeroDbContext<Tenant, Role, User, AliFitnessAEDbContext>
    {
        /* Define a DbSet for each entity of the application */ 
        public DbSet<Topic> Topic { get; set; }
        public DbSet<UserType> UserType { get; set; }
        public DbSet<LookUpMaster> LookUpMaster { get; set; }
        public DbSet<LookUpDetail> LookUpDetail { get; set; }
        public DbSet<DocumentType> DocumentType { get; set; }
        public DbSet<BusinessDocument> BusinessDocument { get; set; }
        public DbSet<UserTracking> UserTracking { get; set; }
        public DbSet<PhotoTracking> PhotoTracking { get; set; }
        public DbSet<BusinessDocumentAttachment> BusinessDocumentAttachment { get; set; }
        public DbSet<Status> Status { get; set; }
        
        public AliFitnessAEDbContext(DbContextOptions<AliFitnessAEDbContext> options)
            : base(options)
        {
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    foreach (var foreignKey in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        //    {
        //        foreignKey.DeleteBehavior = DeleteBehavior.NoAction;
        //    }
        //}
    }
}
