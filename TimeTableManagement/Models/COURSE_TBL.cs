namespace TimeTableManagement.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class COURSE_TBL
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public COURSE_TBL()
        {
            COURSE_ASSIGN_TBL = new HashSet<COURSE_ASSIGN_TBL>();
        }

        [Key]
        public int COURSE_ID { get; set; }

        [Required]
        [StringLength(100)]
        public string COURSE_NAME { get; set; }

        [Required]
        [StringLength(50)]
        public string CREDIT_HOURS { get; set; }

        public int DEGREE_FID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<COURSE_ASSIGN_TBL> COURSE_ASSIGN_TBL { get; set; }

        public virtual DEGREE_TBL DEGREE_TBL { get; set; }
    }
}
