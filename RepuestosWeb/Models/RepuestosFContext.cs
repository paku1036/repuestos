using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace RepuestosWeb.Models
{
    public  class RepuestosFContext : DbContext
    {
        public RepuestosFContext()
        {
        }

        public RepuestosFContext(DbContextOptions<RepuestosFContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Año> Años { get; set; }
        public virtual DbSet<Categorium> Categoria { get; set; }
        public virtual DbSet<Ciudad> Ciudads { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Comercio> Comercios { get; set; }
        public virtual DbSet<Consultum> Consulta { get; set; }
        public virtual DbSet<Cotiza> Cotizas { get; set; }
        public virtual DbSet<Fotografium> Fotografia { get; set; }
        public virtual DbSet<LoginLog> LoginLogs { get; set; }
        public virtual DbSet<Marca> Marcas { get; set; }
        public virtual DbSet<Modelo> Modelos { get; set; }
        public virtual DbSet<Motor> Motors { get; set; }
        public virtual DbSet<Pai> Pais { get; set; }
        public virtual DbSet<PaisFabricacion> PaisFabricacions { get; set; }
        public virtual DbSet<Region> Regions { get; set; }
        public virtual DbSet<Repuesto> Repuestos { get; set; }
        public virtual DbSet<RepuestoCategorium> RepuestoCategoria { get; set; }
        public virtual DbSet<RepuestoComercio> RepuestoComercios { get; set; }
        public virtual DbSet<SubModelo> SubModelos { get; set; }
        public virtual DbSet<Tipo> Tipos { get; set; }
        public virtual DbSet<TipoLogin> TipoLogins { get; set; }
        public virtual DbSet<UnidadMedidum> UnidadMedida { get; set; }
        public virtual DbSet<VerRepuesto> VerRepuestos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=177.222.33.6,20200;Initial Catalog=RepuestosF;Persist Security Info=True;User ID=repuestos;Password=rep123*");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Año>(entity =>
            {
                entity.ToTable("Año");

                entity.Property(e => e.AñoId).ValueGeneratedNever();
            });

            modelBuilder.Entity<Categorium>(entity =>
            {
                entity.HasKey(e => e.CategoriaId)
                    .HasName("PK__Categori__F353C1E5F1E5CABA");

                entity.Property(e => e.CategoriaId).ValueGeneratedNever();

                entity.Property(e => e.CategoriaNombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.CategoriaPadrei)
                    .WithMany(p => p.InverseCategoriaPadrei)
                    .HasForeignKey(d => d.CategoriaPadreiId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Categoria__Categ__5BE2A6F2");
            });

            modelBuilder.Entity<Ciudad>(entity =>
            {
                entity.ToTable("Ciudad");

                entity.Property(e => e.CiudadId).ValueGeneratedNever();

                entity.Property(e => e.CiudadNombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.Region)
                    .WithMany(p => p.Ciudads)
                    .HasForeignKey(d => d.RegionId)
                    .HasConstraintName("FK__Ciudad__RegionId__52593CB8");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("Cliente");

                entity.Property(e => e.ClienteId).ValueGeneratedNever();

                entity.Property(e => e.ClienteCuenta)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ClienteNombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.Ciudad)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.CiudadId)
                    .HasConstraintName("FK_Cliente_Ciudad");

                entity.HasOne(d => d.LoginLog)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.LoginLogId)
                    .HasConstraintName("FK__Cliente__LoginLo__3D5E1FD2");

                entity.HasOne(d => d.TipoLogin)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.TipoLoginId)
                    .HasConstraintName("FK__Cliente__TipoLog__3E52440B");
            });

            modelBuilder.Entity<Comercio>(entity =>
            {
                entity.ToTable("Comercio");

                entity.Property(e => e.ComercioId).ValueGeneratedNever();

                entity.Property(e => e.ComercioNombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.Ciudad)
                    .WithMany(p => p.Comercios)
                    .HasForeignKey(d => d.CiudadId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Comercio_Ciudad");
            });

            modelBuilder.Entity<Consultum>(entity =>
            {
                entity.HasKey(e => e.ConsultaId)
                    .HasName("PK__Consulta__7D0B7DCCD1A4B825");

                entity.Property(e => e.ConsultaId).ValueGeneratedNever();

                entity.Property(e => e.BusquedaTexto)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ConsultaCantidadCoincidencias)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.Consulta)
                    .HasForeignKey(d => d.ClienteId)
                    .HasConstraintName("FK__Consulta__Client__412EB0B6");
            });

            modelBuilder.Entity<Cotiza>(entity =>
            {
                entity.HasKey(e => new { e.ClienteId, e.RepuestoId, e.CotizaId })
                    .HasName("PK__Cotiza__F31300FEBF284238");

                entity.ToTable("Cotiza");

                entity.Property(e => e.CotizaFechaHora).HasColumnType("datetime");

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.Cotizas)
                    .HasForeignKey(d => d.ClienteId)
                    .HasConstraintName("FK__Cotiza__ClienteI__47DBAE45");

                entity.HasOne(d => d.Repuesto)
                    .WithMany(p => p.Cotizas)
                    .HasForeignKey(d => d.RepuestoId)
                    .HasConstraintName("FK__Cotiza__Repuesto__48CFD27E");
            });

            modelBuilder.Entity<Fotografium>(entity =>
            {
                entity.HasKey(e => e.FotografiaId)
                    .HasName("PK__Fotograf__D2BA5284480DE11B");

                entity.Property(e => e.FotografiaId).ValueGeneratedNever();

                entity.Property(e => e.FotografiaNombre)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.Repuesto)
                    .WithMany(p => p.Fotografia)
                    .HasForeignKey(d => d.RepuestoId)
                    .HasConstraintName("FK_Fotografia_Repuesto");
            });

            modelBuilder.Entity<LoginLog>(entity =>
            {
                entity.ToTable("LoginLog");

                entity.Property(e => e.LoginLogId).ValueGeneratedNever();

                entity.Property(e => e.LoginLogFechaHoraa).HasColumnType("datetime");
            });

            modelBuilder.Entity<Marca>(entity =>
            {
                entity.ToTable("Marca");

                entity.Property(e => e.MarcaId).ValueGeneratedNever();

                entity.Property(e => e.MarcaNombre)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.Año)
                    .WithMany(p => p.Marcas)
                    .HasForeignKey(d => d.AñoId)
                    .HasConstraintName("FK_Marca_Año");
            });

            modelBuilder.Entity<Modelo>(entity =>
            {
                entity.ToTable("Modelo");

                entity.Property(e => e.ModeloId).ValueGeneratedNever();

                entity.Property(e => e.ModeloNombre)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.Marca)
                    .WithMany(p => p.Modelos)
                    .HasForeignKey(d => d.MarcaId)
                    .HasConstraintName("FK__Modelo__MarcaId__25869641");
            });

            modelBuilder.Entity<Motor>(entity =>
            {
                entity.ToTable("Motor");

                entity.Property(e => e.MotorId).ValueGeneratedNever();

                entity.Property(e => e.MotorDescripcion)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.SubModelo)
                    .WithMany(p => p.Motors)
                    .HasForeignKey(d => d.SubModeloId)
                    .HasConstraintName("FK__Motor__SubModelo__2B3F6F97");
            });

            modelBuilder.Entity<Pai>(entity =>
            {
                entity.HasKey(e => e.PaisId)
                    .HasName("PK__Pais__B501E18584B104CA");

                entity.Property(e => e.PaisId).ValueGeneratedNever();

                entity.Property(e => e.PaisNombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<PaisFabricacion>(entity =>
            {
                entity.ToTable("PaisFabricacion");

                entity.Property(e => e.PaisFabricacionId).ValueGeneratedNever();

                entity.Property(e => e.PaisFabricacionNombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Region>(entity =>
            {
                entity.ToTable("Region");

                entity.Property(e => e.RegionId).ValueGeneratedNever();

                entity.Property(e => e.RegionNombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.Pais)
                    .WithMany(p => p.Regions)
                    .HasForeignKey(d => d.PaisId)
                    .HasConstraintName("FK__Region__PaisId__4F7CD00D");
            });

            modelBuilder.Entity<Repuesto>(entity =>
            {
                entity.ToTable("Repuesto");

                entity.Property(e => e.RepuestoId).ValueGeneratedNever();

                entity.Property(e => e.RepuestoDescripcionCorta)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.RepuestoDescripcionLarga)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.RepuestoNombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.RepuestoNroParte)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.RepuestoVinvehiculo)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("RepuestoVINVehiculo")
                    .IsFixedLength(true);

                entity.HasOne(d => d.Motor)
                    .WithMany(p => p.Repuestos)
                    .HasForeignKey(d => d.MotorId)
                    .HasConstraintName("FK__Repuesto__MotorI__38996AB5");

                entity.HasOne(d => d.PaisFabricacion)
                    .WithMany(p => p.Repuestos)
                    .HasForeignKey(d => d.PaisFabricacionId)
                    .HasConstraintName("FK__Repuesto__PaisFa__3A81B327");

                entity.HasOne(d => d.Tipo)
                    .WithMany(p => p.Repuestos)
                    .HasForeignKey(d => d.TipoId)
                    .HasConstraintName("FK__Repuesto__TipoId__37A5467C");

                entity.HasOne(d => d.UnidadMedida)
                    .WithMany(p => p.Repuestos)
                    .HasForeignKey(d => d.UnidadMedidaId)
                    .HasConstraintName("FK__Repuesto__Unidad__398D8EEE");
            });

            modelBuilder.Entity<RepuestoCategorium>(entity =>
            {
                entity.HasKey(e => e.RepuestoCategoriaId)
                    .HasName("PK__Repuesto__39434CD6761E73C0");

                entity.Property(e => e.RepuestoCategoriaId).ValueGeneratedNever();

                entity.HasOne(d => d.Categoria)
                    .WithMany(p => p.RepuestoCategoria)
                    .HasForeignKey(d => d.CategoriaId)
                    .HasConstraintName("FK__RepuestoC__Categ__5FB337D6");

                entity.HasOne(d => d.Repuesto)
                    .WithMany(p => p.RepuestoCategoria)
                    .HasForeignKey(d => d.RepuestoId)
                    .HasConstraintName("FK__RepuestoC__Repue__5EBF139D");
            });

            modelBuilder.Entity<RepuestoComercio>(entity =>
            {
                entity.HasKey(e => new { e.ComercioId, e.RepuestoId, e.RepuestoComercioId })
                    .HasName("PK__Repuesto__84506AEBEC0C1BB7");

                entity.ToTable("RepuestoComercio");

                entity.HasOne(d => d.Comercio)
                    .WithMany(p => p.RepuestoComercios)
                    .HasForeignKey(d => d.ComercioId)
                    .HasConstraintName("FK__RepuestoC__Comer__59063A47");

                entity.HasOne(d => d.Repuesto)
                    .WithMany(p => p.RepuestoComercios)
                    .HasForeignKey(d => d.RepuestoId)
                    .HasConstraintName("FK__RepuestoC__Repue__5812160E");
            });

            modelBuilder.Entity<SubModelo>(entity =>
            {
                entity.ToTable("SubModelo");

                entity.Property(e => e.SubModeloId).ValueGeneratedNever();

                entity.Property(e => e.SubModeloNombre)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.Modelo)
                    .WithMany(p => p.SubModelos)
                    .HasForeignKey(d => d.ModeloId)
                    .HasConstraintName("FK__SubModelo__Model__286302EC");
            });

            modelBuilder.Entity<Tipo>(entity =>
            {
                entity.ToTable("Tipo");

                entity.Property(e => e.TipoId).ValueGeneratedNever();

                entity.Property(e => e.TipoNombre)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<TipoLogin>(entity =>
            {
                entity.ToTable("TipoLogin");

                entity.Property(e => e.TipoLoginId).ValueGeneratedNever();

                entity.Property(e => e.TipoLoginNombre)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<UnidadMedidum>(entity =>
            {
                entity.HasKey(e => e.UnidadMedidaId)
                    .HasName("PK__UnidadMe__33972861F6417F06");

                entity.Property(e => e.UnidadMedidaId).ValueGeneratedNever();

                entity.Property(e => e.UnidadMedidaNombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<VerRepuesto>(entity =>
            {
                entity.HasKey(e => new { e.ClienteId, e.RepuestoId, e.VerRepuestoId })
                    .HasName("PK__VerRepue__37330ED8C162B9AA");

                entity.ToTable("VerRepuesto");

                entity.Property(e => e.VerRepuestoFechaHora).HasColumnType("datetime");

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.VerRepuestos)
                    .HasForeignKey(d => d.ClienteId)
                    .HasConstraintName("FK__VerRepues__Clien__440B1D61");

                entity.HasOne(d => d.Repuesto)
                    .WithMany(p => p.VerRepuestos)
                    .HasForeignKey(d => d.RepuestoId)
                    .HasConstraintName("FK__VerRepues__Repue__44FF419A");
            });

            //OnModelCreatingPartial(modelBuilder);
        }

        //public void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
