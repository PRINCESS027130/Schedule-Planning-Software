namespace TimeTableManagement.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TEACHER_TBL
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TEACHER_TBL()
        {
            TIMETABLE_TBL = new HashSet<TIMETABLE_TBL>();
        }

        [Key]
        public int TEACHER_ID { get; set; }

        [Required]
        [StringLength(100)]
        public string TEACHER_NAME { get; set; }

        [Required]
        [StringLength(100)]
        public string TEACHER_EMAIL { get; set; }

        [Required]
        [StringLength(10)]
        public string TEACHER_PASSWORD { get; set; }

        [Required]
        [StringLength(50)]
        public string TEACHER_PHNO { get; set; }

        [Required]
        [StringLength(200)]
        public string TEACHER_ADDRESS { get; set; }

        public int DEPARTMENT_FID { get; set; }

        public virtual DEPARTMENT_TBL DEPARTMENT_TBL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TIMETABLE_TBL> TIMETABLE_TBL { get; set; }
    }
}
