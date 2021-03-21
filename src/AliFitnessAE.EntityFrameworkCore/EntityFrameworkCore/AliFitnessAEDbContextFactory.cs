using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using AliFitnessAE.Configuration;
using AliFitnessAE.Web;

namespace AliFitnessAE.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class AliFitnessAEDbContextFactory : IDesignTimeDbContextFactory<AliFitnessAEDbContext>
    {
        public AliFitnessAEDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<AliFitnessAEDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            AliFitnessAEDbContextConfigurer.Configure(builder, configuration.GetConnectionString(AliFitnessAEConsts.ConnectionStringName));

            return new AliFitnessAEDbContext(builder.Options);
        }
    }
}
