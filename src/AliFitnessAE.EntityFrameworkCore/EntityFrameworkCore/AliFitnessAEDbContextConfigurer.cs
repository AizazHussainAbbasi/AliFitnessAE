using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace AliFitnessAE.EntityFrameworkCore
{
    public static class AliFitnessAEDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<AliFitnessAEDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<AliFitnessAEDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
