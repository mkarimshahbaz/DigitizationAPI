using DigitizationAPI.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitizationAPI.DbContexts
{
    public class IndividualsDbContext : DbContext
    {
        public IndividualsDbContext(DbContextOptions<IndividualsDbContext> options) : base(options)
        {
        }

        public DbSet<Individual> Individuals { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
