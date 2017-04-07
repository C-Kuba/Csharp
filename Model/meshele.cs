namespace Dyplom_csharp_v2.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("mydb.meshele")]
    public partial class meshele
    {
        [Key]
        public int idMeshEle { get; set; }

        public int Nodes_Node_id { get; set; }

        public int Nodes_Node_id1 { get; set; }

        public int Nodes_Node_id2 { get; set; }

        public int Nodes_Node_id3 { get; set; }

        public int moment_idmoment { get; set; }

        public int element_idelement { get; set; }

        public virtual element element { get; set; }

        public virtual moment moment { get; set; }

        public virtual nodes nodes { get; set; }

        public virtual nodes nodes1 { get; set; }

        public virtual nodes nodes2 { get; set; }

        public virtual nodes nodes3 { get; set; }
    }
}
