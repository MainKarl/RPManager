using IsekaiDb.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static IsekaiDb.Data.Enumerable;

namespace IsekaiDb.Data
{
    public class IsekaiDbContext : IdentityDbContext
    {
        public DbSet<Passive> Passives { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Weapon> Weapons { get; set; }
        public DbSet<Armor> Armors { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Character> Characters { get; set; }

        public IsekaiDbContext(DbContextOptions<IsekaiDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Character>()
                .Property(c => c.Types)
                .HasConversion(
                    v => string.Join(",", v.Select(e => e.ToString("D")).ToArray()),
                    v => v.Split(new[] { ',' })
                        .Select(e => Enum.Parse(typeof(CharacterType), e))
                        .Cast<CharacterType>()
                        .ToList()
                );

            modelBuilder
                .Entity<Character>()
                .Property(c => c.Status)
                .HasConversion(
                    v => string.Join(",", v.Select(e => e.ToString("D")).ToArray()),
                    v => v.Split(new[] { ',' })
                        .Select(e => Enum.Parse(typeof(CharacterStatus), e))
                        .Cast<CharacterStatus>()
                        .ToList()
                );

            modelBuilder
                .Entity<Armor>()
                .HasMany(x => x.ArmorPassives)
                .WithMany(x => x.ArmorPassives);

            modelBuilder.Seed();

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
