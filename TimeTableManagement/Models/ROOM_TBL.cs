namespace TimeTableManagement.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ROOM_TBL
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ROOM_TBL()
        {
            TIMETABLE_TBL = new HashSet<TIMETABLE_TBL>();
        }

        [Key]
        public int ROOM_ID { get; set; }

        [Required]
        [StringLength(1000)]
        public string ROOM_NO { get; set; }

        public int DEPARTMENT_FID { get; set; }

        public virtual DEPARTMENT_TBL DEPARTMENT_TBL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TIMETABLE_TBL> TIMETABLE_TBL { get; set; }
    }
}
