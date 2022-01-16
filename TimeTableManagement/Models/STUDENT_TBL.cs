namespace TimeTableManagement.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class STUDENT_TBL
    {
        [Key]
        public int STUDENT_ID { get; set; }

        [Required]
        [StringLength(100)]
        public string STUDENT_NAME { get; set; }

        [Required]
        [StringLength(100)]
        public string STUDENT_EMAIL { get; set; }

        [Required]
        [StringLength(10)]
        public string STUDENT_PASSWORD { get; set; }

        public int CLASS_FID { get; set; }

        public virtual CLASS_TBL CLASS_TBL { get; set; }
    }
}
