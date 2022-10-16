using Microsoft.EntityFrameworkCore;

namespace MVCCRUD.Models
{
    public partial class MVCCRUDContextEstudiante : DbContext
    {
        public MVCCRUDContextEstudiante()
        {
        }

        public MVCCRUDContextEstudiante(DbContextOptions<MVCCRUDContextEstudiante> options)
            : base(options)
        {
        }

        
        public virtual DbSet<Estudiante> Estudiantes { get; set; } = null!;


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                //                optionsBuilder.UseSqlServer("server=localhost; database=MVCCRUD; integrated security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Estudiante>(entity =>
            {
                entity.Property(e => e.Carnet)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                   .HasMaxLength(50)
                   .IsUnicode(false);


                entity.Property(e => e.Apellido)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PrimerParcial)
                 .HasMaxLength(50)
                 .IsUnicode(false);

                entity.Property(e => e.SegundoParcial)
                 .HasMaxLength(50)
                 .IsUnicode(false);

                entity.Property(e => e.Sistematico)
                 .HasMaxLength(50)
                 .IsUnicode(false);

                entity.Property(e => e.NotaFinal)
                 .HasMaxLength(50)
                 .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
