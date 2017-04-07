namespace Dyplom_csharp_v2.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DataModel : DbContext
    {
        public DataModel()
            : base("name=DataModel")
        {
        }

        public virtual DbSet<element> element { get; set; }
        public virtual DbSet<meshele> meshele { get; set; }
        public virtual DbSet<moment> moment { get; set; }
        public virtual DbSet<nodes> nodes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<element>()
                .HasMany(e => e.meshele)
                .WithRequired(e => e.element)
                .HasForeignKey(e => e.element_idelement)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<moment>()
                .HasMany(e => e.meshele)
                .WithRequired(e => e.moment)
                .HasForeignKey(e => e.moment_idmoment)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<nodes>()
                .HasMany(e => e.meshele)
                .WithRequired(e => e.nodes)
                .HasForeignKey(e => e.Nodes_Node_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<nodes>()
                .HasMany(e => e.meshele1)
                .WithRequired(e => e.nodes1)
                .HasForeignKey(e => e.Nodes_Node_id1)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<nodes>()
                .HasMany(e => e.meshele2)
                .WithRequired(e => e.nodes2)
                .HasForeignKey(e => e.Nodes_Node_id2)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<nodes>()
                .HasMany(e => e.meshele3)
                .WithRequired(e => e.nodes3)
                .HasForeignKey(e => e.Nodes_Node_id3)
                .WillCascadeOnDelete(false);
        }
    }
}
