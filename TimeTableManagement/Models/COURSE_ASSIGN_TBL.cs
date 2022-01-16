namespace TimeTableManagement.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class COURSE_ASSIGN_TBL
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public COURSE_ASSIGN_TBL()
        {
            TIMETABLE_TBL = new HashSet<TIMETABLE_TBL>();
        }

        [Key]
        public int COURSE_ASSIGN_ID { get; set; }

        public int COURSE_FID { get; set; }

        public int DEGREE_FID { get; set; }

        public virtual COURSE_TBL COURSE_TBL { get; set; }

        public virtual DEGREE_TBL DEGREE_TBL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TIMETABLE_TBL> TIMETABLE_TBL { get; set; }
    }
}
