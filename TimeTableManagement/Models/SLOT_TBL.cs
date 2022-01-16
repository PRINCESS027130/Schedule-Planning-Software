namespace TimeTableManagement.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SLOT_TBL
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SLOT_TBL()
        {
            TIMETABLE_TBL = new HashSet<TIMETABLE_TBL>();
        }

        [Key]
        public int SLOT_ID { get; set; }

        public DateTime SLOT_START_TIME { get; set; }

        public DateTime SLOT_END_TIME { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TIMETABLE_TBL> TIMETABLE_TBL { get; set; }
    }
}
