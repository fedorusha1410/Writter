namespace Writter
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("STYLE")]
    public partial class STYLE
    {
        [Key]
        public int ID_STYLE_NOTE { get; set; }

        [StringLength(10)]
        public string STATUS { get; set; }

        public int FONTSIZE { get; set; }

        [Required]
        [StringLength(32)]
        public string FONTFAMILY { get; set; }

        [Required]
        [StringLength(20)]
        public string FOREGROUND { get; set; }

        public int? ID_NOTE { get; set; }

        public virtual NOTE NOTE { get; set; }
    }
}
