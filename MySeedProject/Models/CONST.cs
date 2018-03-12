namespace Inspinia_MVC5_SeedProject.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CONST : DbContext
    {
        public CONST()
            : base("name=CONST")
        {
        }

        public virtual DbSet<ConstCompetition> ConstCompetitions { get; set; }
        public virtual DbSet<ConstCompetitionStatu> ConstCompetitionStatus { get; set; }
        public virtual DbSet<User> Users { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<ConstCompetition>()
        //        .Property(e => e.userNationalID_FK)
        //        .HasPrecision(10, 0);

        //    modelBuilder.Entity<ConstCompetitionStatu>()
        //        .HasMany(e => e.ConstCompetitions)
        //        .WithOptional(e => e.ConstCompetitionStatu)
        //        .HasForeignKey(e => e.CompetitionStatusID_FK);

        //    modelBuilder.Entity<ConstItemSupplierPrice>()
        //        .Property(e => e.ItemSupplierPriceValue)
        //        .HasPrecision(10, 2);

        //    modelBuilder.Entity<User>()
        //        .Property(e => e.userNationalID)
        //        .HasPrecision(10, 0);

        //    modelBuilder.Entity<User>()
        //        .Property(e => e.hisDirectBossID_FK)
        //        .HasPrecision(10, 0);

        //    modelBuilder.Entity<User>()
        //        .Property(e => e.userMobile)
        //        .IsUnicode(false);

        //    modelBuilder.Entity<User>()
        //        .Property(e => e.UserInterCome)
        //        .IsUnicode(false);

        //    modelBuilder.Entity<User>()
        //        .HasMany(e => e.ConstCompetitions)
        //        .WithOptional(e => e.User)
        //        .HasForeignKey(e => e.userNationalID_FK);

        //    modelBuilder.Entity<User>()
        //        .HasMany(e => e.User1)
        //        .WithOptional(e => e.User2)
        //        .HasForeignKey(e => e.hisDirectBossID_FK);
        //}
    }
}
