using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Inspinia_MVC5_SeedProject.Models
{
    public class ConstCompetitionViewModel
    {
        [Key]
        public int CompetitionID { get; set; }
        
        public string competitionNo { get; set; }

        public string competitionNote { get; set; }

        public bool? competitionFragmented { get; set; }

        public string CompetitionStatusName { get; set; }

        public DateTime? CompetitionAddedDate { get; set; }

        public string UserName { get; set; }
    }
}