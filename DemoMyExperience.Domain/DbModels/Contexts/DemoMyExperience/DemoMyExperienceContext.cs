using DemoMyExperience.Domain.DbModels.Contexts.DemoMyExperience.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DemoMyExperience.Domain.DbModels.Contexts.DemoMyExperience
{
    public class DemoMyExperienceContext : DbContext
    {

        public DemoMyExperienceContext(DbContextOptions<DemoMyExperienceContext> options): base(options)
        {
            Database.EnsureCreated();
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //{
        //
        //}

        public DbSet<UserRepository> Users { get; set; }
    }

}
