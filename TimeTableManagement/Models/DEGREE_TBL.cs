namespace TimeTableManagement.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DEGREE_TBL
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DEGREE_TBL()
        {
            CLASS_TBL = new HashSet<CLASS_TBL>();
            COURSE_ASSIGN_TBL = new HashSet<COURSE_ASSIGN_TBL>();
            COURSE_TBL = new HashSet<COURSE_TBL>();
        }

        [Key]
        public int DEGREE_ID { get; set; }

        [Required]
        [StringLength(200)]
        public string DEGREE_NAME { get; set; }

        public int DEPARTMENT_FID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLASS_TBL> CLASS_TBL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<COURSE_ASSIGN_TBL> COURSE_ASSIGN_TBL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<COURSE_TBL> COURSE_TBL { get; set; }

        public virtual DEPARTMENT_TBL DEPARTMENT_TBL { get; set; }
    }
}
