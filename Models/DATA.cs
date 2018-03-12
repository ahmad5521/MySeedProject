namespace Inspinia_MVC5_SeedProject.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DATA : DbContext
    {
        public DATA()
            : base("name=DATA")
        {
        }
        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<ConstCompetition>()
            //    .Property(e => e.userNationalID_FK)
            //    .HasPrecision(10, 0);

            //modelBuilder.Entity<ConstCompetition>()
            //    .HasMany(e => e.ConstProjects)
            //    .WithOptional(e => e.ConstCompetition)
            //    .HasForeignKey(e => e.CompetitionID_FK);

            //modelBuilder.Entity<ConstCompetitionStatu>()
            //    .HasMany(e => e.ConstCompetitions)
            //    .WithOptional(e => e.ConstCompetitionStatu)
            //    .HasForeignKey(e => e.CompetitionStatusID_FK);

            //modelBuilder.Entity<ConstProject>()
            //    .HasMany(e => e.ConstProjectSuppliers)
            //    .WithOptional(e => e.ConstProject)
            //    .HasForeignKey(e => e.ProjectID_FK);
        }
    }
}
