namespace Inspinia_MVC5_SeedProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ConstCompetition")]
    public partial class ConstCompetition
    {
        [Key]
        public int CompetitionID { get; set; }

        [StringLength(50)]
        public string competitionNo { get; set; }

        public string competitionNote { get; set; }

        public bool? competitionFragmented { get; set; }

        public int? CompetitionStatusID_FK { get; set; }

        public DateTime? CompetitionAddedDate { get; set; }

        public decimal? userNationalID_FK { get; set; }

        //public virtual ConstCompetitionStatu ConstCompetitionStatu { get; set; }

        //public virtual User User { get; set; }
    }
}
