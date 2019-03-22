using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace The_Guild_Back.DAL
{
    public partial class project2theGuildContext : DbContext
    {
        public project2theGuildContext()
        {
        }

        public project2theGuildContext(DbContextOptions<project2theGuildContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AdventurerParty> AdventurerParty { get; set; }
        public virtual DbSet<Progress> Progress { get; set; }
        public virtual DbSet<RankRequirements> RankRequirements { get; set; }
        public virtual DbSet<Ranks> Ranks { get; set; }
        public virtual DbSet<Request> Request { get; set; }
        public virtual DbSet<RequestingGroup> RequestingGroup { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:matthew1995sql.database.windows.net,1433;Initial Catalog=project2theGuild;Persist Security Info=False;User ID=matthew;Password=Llm0507?four;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.3-servicing-35854");

            modelBuilder.Entity<AdventurerParty>(entity =>
            {
                entity.HasIndex(e => e.Nam)
                    .HasName("UQ__Adventur__DF906FE5CBD4AC4F")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AdventurerId).HasColumnName("adventurerID");

                entity.Property(e => e.Nam)
                    .IsRequired()
                    .HasColumnName("nam")
                    .HasMaxLength(50);

                entity.Property(e => e.RequestId).HasColumnName("requestID");

                entity.HasOne(d => d.Adventurer)
                    .WithMany(p => p.AdventurerParty)
                    .HasForeignKey(d => d.AdventurerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_adventurerparty_adventurer");

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.AdventurerParty)
                    .HasForeignKey(d => d.RequestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_adventurerparty_request");
            });

            modelBuilder.Entity<Progress>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nam)
                    .IsRequired()
                    .HasColumnName("nam")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<RankRequirements>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CurrentRankId).HasColumnName("currentRankID");

                entity.Property(e => e.MinTotalStats).HasColumnName("minTotalStats");

                entity.Property(e => e.NextRankId).HasColumnName("nextRankID");

                entity.Property(e => e.NumberRequests).HasColumnName("numberRequests");

                entity.HasOne(d => d.CurrentRank)
                    .WithMany(p => p.RankRequirementsCurrentRank)
                    .HasForeignKey(d => d.CurrentRankId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_requirements_current_rank");

                entity.HasOne(d => d.NextRank)
                    .WithMany(p => p.RankRequirementsNextRank)
                    .HasForeignKey(d => d.NextRankId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_requirements_next_rank");
            });

            modelBuilder.Entity<Ranks>(entity =>
            {
                entity.HasIndex(e => e.Nam)
                    .HasName("UQ__Ranks__DF906FE5D40052F4")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Fee)
                    .HasColumnName("fee")
                    .HasColumnType("money");

                entity.Property(e => e.Nam)
                    .IsRequired()
                    .HasColumnName("nam")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Request>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cost)
                    .HasColumnName("cost")
                    .HasColumnType("money");

                entity.Property(e => e.Descript)
                    .IsRequired()
                    .HasColumnName("descript")
                    .HasMaxLength(50);

                entity.Property(e => e.ProgressId).HasColumnName("progressID");

                entity.Property(e => e.RankId).HasColumnName("rankID");

                entity.Property(e => e.Requirements)
                    .IsRequired()
                    .HasColumnName("requirements")
                    .HasMaxLength(50);

                entity.Property(e => e.Reward)
                    .HasColumnName("reward")
                    .HasColumnType("money");

                entity.HasOne(d => d.Progress)
                    .WithMany(p => p.Request)
                    .HasForeignKey(d => d.ProgressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_request_progress");

                entity.HasOne(d => d.Rank)
                    .WithMany(p => p.Request)
                    .HasForeignKey(d => d.RankId)
                    .HasConstraintName("FK_request_rank");
            });

            modelBuilder.Entity<RequestingGroup>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CustomerId).HasColumnName("customerID");

                entity.Property(e => e.RequestId).HasColumnName("requestID");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.RequestingGroup)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_requestinggroup_customer");

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.RequestingGroup)
                    .HasForeignKey(d => d.RequestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_requestinggroup_request");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Charisma).HasColumnName("charisma");

                entity.Property(e => e.Constitution).HasColumnName("constitution");

                entity.Property(e => e.Dex).HasColumnName("dex");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("firstName")
                    .HasMaxLength(50);

                entity.Property(e => e.Intelligence).HasColumnName("intelligence");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("lastName")
                    .HasMaxLength(50);

                entity.Property(e => e.RankId).HasColumnName("rankID");

                entity.Property(e => e.Salary)
                    .HasColumnName("salary")
                    .HasColumnType("money");

                entity.Property(e => e.Strength).HasColumnName("strength");

                entity.Property(e => e.Wisdom).HasColumnName("wisdom");

                entity.HasOne(d => d.Rank)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RankId)
                    .HasConstraintName("FK_user_rank");
            });
        }
    }
}
