namespace TimeTableManagement.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CLASS_TBL
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CLASS_TBL()
        {
            STUDENT_TBL = new HashSet<STUDENT_TBL>();
            TIMETABLE_TBL = new HashSet<TIMETABLE_TBL>();
        }

        [Key]
        public int CLASS_ID { get; set; }

        [Required]
        [StringLength(10)]
        public string SESSION { get; set; }

        [Required]
        [StringLength(10)]
        public string SECTION { get; set; }

        [Required]
        [StringLength(20)]
        public string SHIFT { get; set; }

        public int DEGREE_FID { get; set; }

        public virtual DEGREE_TBL DEGREE_TBL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<STUDENT_TBL> STUDENT_TBL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TIMETABLE_TBL> TIMETABLE_TBL { get; set; }
    }
}
