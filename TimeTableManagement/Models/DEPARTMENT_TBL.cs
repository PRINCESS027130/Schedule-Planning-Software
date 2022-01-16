namespace TimeTableManagement.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DEPARTMENT_TBL
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DEPARTMENT_TBL()
        {
            DEGREE_TBL = new HashSet<DEGREE_TBL>();
            ROOM_TBL = new HashSet<ROOM_TBL>();
            TEACHER_TBL = new HashSet<TEACHER_TBL>();
        }

        [Key]
        public int DEPARTMENT_ID { get; set; }

        [Required]
        [StringLength(200)]
        public string DEPARTMENT_NAME { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DEGREE_TBL> DEGREE_TBL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ROOM_TBL> ROOM_TBL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TEACHER_TBL> TEACHER_TBL { get; set; }
    }
}
