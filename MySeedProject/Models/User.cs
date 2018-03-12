namespace Inspinia_MVC5_SeedProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        //public User()
        //{
        //    ConstCompetitions = new HashSet<ConstCompetition>();
        //    User1 = new HashSet<User>();
        //}

        [Key]
        public decimal userNationalID { get; set; }

        [StringLength(20)]
        public string name_A { get; set; }

        [StringLength(20)]
        public string secondName_A { get; set; }

        [StringLength(20)]
        public string thirdName_A { get; set; }

        [StringLength(25)]
        public string lastName_A { get; set; }

        public int? DSDID_FK { get; set; }

        public decimal? hisDirectBossID_FK { get; set; }

        public bool? isActive { get; set; }

        public int? userTypeID_FK { get; set; }

        [Column(TypeName = "image")]
        public byte[] userPicture { get; set; }

        [StringLength(10)]
        public string userMobile { get; set; }

        [StringLength(5)]
        public string UserInterCome { get; set; }

        public int? test { get; set; }

        [StringLength(20)]
        public string name_E { get; set; }

        [StringLength(20)]
        public string secondName_E { get; set; }

        [StringLength(20)]
        public string thirdName_E { get; set; }

        [StringLength(25)]
        public string lastName_E { get; set; }

        [StringLength(50)]
        public string IDNumber { get; set; }

        public DateTime? IDIssueDate { get; set; }

        public DateTime? IDExpiryDate { get; set; }

        public DateTime? DateOfBirth { get; set; }

        [StringLength(20)]
        public string TabayahNo { get; set; }

        [StringLength(20)]
        public string Gosino { get; set; }

        [StringLength(200)]
        public string Email { get; set; }

        public int? code_genderID_FK { get; set; }

        public int? code_nationalityID_FK { get; set; }

        public int? code_religionID_FK { get; set; }

        public int? code_BloodID_FK { get; set; }

        public int? code_MaritalStatusID_FK { get; set; }

        public int? BirthPlace_code_CityID_FK { get; set; }

        public int? IDIssuePlace_code_CityID_FK { get; set; }

        [StringLength(350)]
        public string userTitle { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<ConstCompetition> ConstCompetitions { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<User> User1 { get; set; }

        //public virtual User User2 { get; set; }
    }
}
