namespace Inspinia_MVC5_SeedProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ConstCompetitionStatu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        //public ConstCompetitionStatu()
        //{
        //    ConstCompetitions = new HashSet<ConstCompetition>();
        //}

        [Key]
        public int CompetitionStatusID { get; set; }

        [StringLength(50)]
        public string CompetitionStatusName { get; set; }

        public bool? CompetitionActive { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<ConstCompetition> ConstCompetitions { get; set; }
    }
}
