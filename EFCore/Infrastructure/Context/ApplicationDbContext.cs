using EFCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /// Ways to express inheritance as tables
            /// Tpc : Each type will be mapped to a different database object
            /// Tph : All types will be mapped to the same database object
            /// Tpt : Each type will be mapped to a different database object.
            ///       Only the declared properties will be mapped to columns on the corresponding object.
            /// 
            modelBuilder.Entity<Person>().UseTpcMappingStrategy();


            ///
            /// double many2one-relationship with same classes
            /// avoid cycles or multiples paths with OnDelete
            /// 
            modelBuilder.Entity<Club>()
                .HasMany(c => c.GamesAway)
                .WithOne(g => g.ClubAway)
                .HasForeignKey(g => g.ClubAwayId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Club>()
                .HasMany(c => c.GamesHome)
                .WithOne(g => g.ClubHome)
                .HasForeignKey(g => g.ClubHomeId)
                .OnDelete(DeleteBehavior.ClientSetNull);


            ///
            /// express many2many-relationship with custom table name
            /// 
            modelBuilder.Entity<Referee>()
                .HasMany(rf => rf.Games)
                .WithMany(g => g.Referees)
                .UsingEntity(join => join.ToTable("Referees_Games"));

            modelBuilder.Entity<Season>()
                .HasMany(s => s.Clubs)
                .WithMany(c => c.Seasons)
                .UsingEntity(join => join.ToTable("Seasons_Clubs"));

            ///
            /// one2one-relationship 
            /// 
            modelBuilder.Entity<Trainer>()
                .HasOne(t => t.Club)
                .WithOne(c => c.Trainer)
                .HasForeignKey<Club>(c => c.TrainerId);
        }

        // DbSets
        public DbSet<Person> Persons { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Referee> Referees { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<Round> Rounds { get; set; }
        public DbSet<Club> Clubs { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<PlayerStats> PlayersStats { get; set; }


    }
}
