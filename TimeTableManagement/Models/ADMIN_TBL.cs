namespace TimeTableManagement.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ADMIN_TBL
    {
        [Key]
        public int ADMIN_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string ADMIN_NAME { get; set; }

        [Required]
        [StringLength(50)]
        public string ADMIN_EMAIL { get; set; }

        [Required]
        [StringLength(10)]
        public string ADMIN_PASSWORD { get; set; }

        [Required]
        [StringLength(20)]
        public string ADMIN_PHNO { get; set; }

        [Required]
        [StringLength(100)]
        public string ADMIN_ADDRESS { get; set; }

        [StringLength(200)]
        public string ADMIN_IMAGE { get; set; }
    }
}
