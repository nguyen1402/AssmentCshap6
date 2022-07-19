using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssmentCshap6.Data.EF
{
    public class AssContextFactory : IDesignTimeDbContextFactory<AsmentCshap6Context>
    {
        public AsmentCshap6Context CreateDbContext(string[] args)
        {
            IConfigurationRoot configurationRoot = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                                                                            .AddJsonFile("appsetting.json")
                                                                            .Build();

            var config = configurationRoot.GetConnectionString("AssConnect");

            var optionsBulde = new DbContextOptionsBuilder<AsmentCshap6Context>();
            optionsBulde.UseSqlServer(config);
            return new AsmentCshap6Context(optionsBulde.Options);
        }
    }
}
