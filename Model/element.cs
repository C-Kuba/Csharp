namespace Dyplom_csharp_v2.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("mydb.element")]
    public partial class element
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public element()
        {
            meshele = new HashSet<meshele>();
        }

        [Key]
        public int idelement { get; set; }

        public int? count_of_nodes { get; set; }

        public int? count_of_moments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<meshele> meshele { get; set; }
    }
}
