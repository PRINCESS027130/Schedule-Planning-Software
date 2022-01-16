namespace TimeTableManagement.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TIMETABLE_TBL
    {
        [Key]
        public int TIMETABLE_ID { get; set; }

        public int TEACHER_FID { get; set; }

        public int CLASS_FID { get; set; }

        public int SLOT_FID { get; set; }

        public int ROOM_FID { get; set; }

        public int COURSE_ASSIGN_FID { get; set; }

        public virtual CLASS_TBL CLASS_TBL { get; set; }

        public virtual COURSE_ASSIGN_TBL COURSE_ASSIGN_TBL { get; set; }

        public virtual ROOM_TBL ROOM_TBL { get; set; }

        public virtual SLOT_TBL SLOT_TBL { get; set; }

        public virtual TEACHER_TBL TEACHER_TBL { get; set; }
    }
}
