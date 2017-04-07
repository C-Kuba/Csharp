namespace Dyplom_csharp_v2.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("mydb.moment")]
    public partial class moment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public moment()
        {
            meshele = new HashSet<meshele>();
        }

        [Key]
        public int idmoment { get; set; }

        public double? Mxx_Top { get; set; }

        public double? Mxx_Bottom { get; set; }

        public double? Myy_Top { get; set; }

        public double? Myy_Bottom { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<meshele> meshele { get; set; }
    }
}
