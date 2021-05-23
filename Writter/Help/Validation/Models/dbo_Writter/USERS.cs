namespace Writter
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Security.Cryptography;
    using System.Text;

    public partial class USERS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public USERS()
        {
            NOTE = new HashSet<NOTE>();
        }

        [Key]
        [StringLength(25)]
        public string LOGIN { get; set; }

        [Required]
        [StringLength(32)]
        public string PASSWORD { get; set; }

        [StringLength(10)]
        public string TYPE_USER { get; set; }

        [StringLength(32)]
        public string NAME { get; set; }

        [StringLength(6)]
        public string PHOTO { get; set; }

        [StringLength(15)]
        public string STATUS_USER { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NOTE> NOTE { get; set; }

        public static string getHash(string password)
        {
            if (String.IsNullOrEmpty(password))
            {
                return "Error";
            }
            else
            {
                var md5 = MD5.Create();
                var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hash);
            }
        }

    }
}
