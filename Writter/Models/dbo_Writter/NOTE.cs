namespace Writter
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NOTE")]
    public partial class NOTE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NOTE()
        {
            STYLE = new HashSet<STYLE>();
        }

        [Key]
        public int ID_NOTE { get; set; }

        [StringLength(1000)]
        public string CONTENT { get; set; }

        [StringLength(14)]
        public string TYPE_NOTE { get; set; }

        [StringLength(50)]
        public string NAME_OF_NOTE { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DATE_CREATE { get; set; }

        [StringLength(25)]
        public string LOGIN_USER { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<STYLE> STYLE { get; set; }

        public virtual USERS USERS { get; set; }
    }
}
