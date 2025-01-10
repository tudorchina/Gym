using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Gym.Models;

namespace Gym.Data
{
    public class GymContext : DbContext
    {
        public GymContext (DbContextOptions<GymContext> options)
            : base(options)
        {
        }

        public DbSet<Gym.Models.Member> Member { get; set; } = default!;
        public DbSet<Gym.Models.Trainer> Trainer { get; set; } = default!;
        public DbSet<Gym.Models.GymClass> GymClasses { get; set; } = default!;
        public DbSet<Gym.Models.Participation> Participations { get; set; } = default!;
    }
}
