using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using EntityLayer.Models.Entities;

namespace DataLayer.DataBase;

public partial class Libreria2DbContext : DbContext
{
    public Libreria2DbContext()
    {
    }

    public Libreria2DbContext(DbContextOptions<Libreria2DbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Autor> Autors { get; set; }

    public virtual DbSet<Categoria> Categorias { get; set; }

    public virtual DbSet<Estudiante> Estudiantes { get; set; }

    public virtual DbSet<Inventario> Inventarios { get; set; }

    public virtual DbSet<Libro> Libros { get; set; }

    public virtual DbSet<PrestamosCabecera> PrestamosCabeceras { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=LancelotPC; Database=Libreria2DB; Trusted_Connection=True; MultipleActiveResultSets=true; TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Autor>(entity =>
        {
            entity.HasKey(e => e.IdAutor).HasName("PK__AUTOR__DA37C1373FB1C38A");

            entity.ToTable("AUTOR");

            entity.Property(e => e.IdAutor)
                .ValueGeneratedNever()
                .HasColumnName("ID_AUTOR");
            entity.Property(e => e.Estado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("ESTADO");
            entity.Property(e => e.NombreAutor)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NOMBRE_AUTOR");
        });

        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.IdCategoria).HasName("PK__CATEGORI__4BD51FA53C4589D7");

            entity.ToTable("CATEGORIAS");

            entity.Property(e => e.IdCategoria)
                .ValueGeneratedNever()
                .HasColumnName("ID_CATEGORIA");
            entity.Property(e => e.DescripcionCategoria)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DESCRIPCION_CATEGORIA");
            entity.Property(e => e.Estado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("ESTADO");
        });

        modelBuilder.Entity<Estudiante>(entity =>
        {
            entity.HasKey(e => e.IdEstudiante).HasName("PK__ESTUDIAN__5598088085B5D1B8");

            entity.ToTable("ESTUDIANTE");

            entity.HasIndex(e => e.Cedula, "UQ__ESTUDIAN__06BB84481CC4F55A").IsUnique();

            entity.HasIndex(e => e.Correo, "UQ__ESTUDIAN__264F33C8CB544071").IsUnique();

            entity.Property(e => e.IdEstudiante)
                .ValueGeneratedNever()
                .HasColumnName("ID_ESTUDIANTE");
            entity.Property(e => e.Cedula)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CEDULA");
            entity.Property(e => e.Contrasenia)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CONTRASENIA");
            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CORREO");
            entity.Property(e => e.Estado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("ESTADO");
            entity.Property(e => e.Nombres)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NOMBRES");
        });

        modelBuilder.Entity<Inventario>(entity =>
        {
            entity.HasKey(e => e.IdLibros).HasName("PK__INVENTAR__0ECE31B2E92B1C90");

            entity.ToTable("INVENTARIO");

            entity.Property(e => e.IdLibros)
                .ValueGeneratedNever()
                .HasColumnName("ID_LIBROS");
            entity.Property(e => e.Estado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("ESTADO");
            entity.Property(e => e.TotalStock).HasColumnName("TOTAL_STOCK");

            entity.HasOne(d => d.IdLibrosNavigation).WithOne(p => p.Inventario)
                .HasForeignKey<Inventario>(d => d.IdLibros)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__INVENTARI__ID_LI__5812160E");
        });

        modelBuilder.Entity<Libro>(entity =>
        {
            entity.HasKey(e => e.IdLibro).HasName("PK__LIBROS__93FF0A0616CDFC16");

            entity.ToTable("LIBROS");

            entity.Property(e => e.IdLibro)
                .ValueGeneratedNever()
                .HasColumnName("ID_LIBRO");
            entity.Property(e => e.AnioPublicacion)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("ANIO_PUBLICACION");
            entity.Property(e => e.Estado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("ESTADO");
            entity.Property(e => e.IdAutor).HasColumnName("ID_AUTOR");
            entity.Property(e => e.IdCategoria).HasColumnName("ID_CATEGORIA");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");

            entity.HasOne(d => d.IdAutorNavigation).WithMany(p => p.Libros)
                .HasForeignKey(d => d.IdAutor)
                .HasConstraintName("FK__LIBROS__ID_AUTOR__4E88ABD4");

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.Libros)
                .HasForeignKey(d => d.IdCategoria)
                .HasConstraintName("FK__LIBROS__ID_CATEG__4D94879B");
        });

        modelBuilder.Entity<PrestamosCabecera>(entity =>
        {
            entity.HasKey(e => e.IdPrestamo).HasName("PK__PRESTAMO__3D5A1E6CD78E05FB");

            entity.ToTable("PRESTAMOS_CABECERA");

            entity.Property(e => e.IdPrestamo)
                .ValueGeneratedNever()
                .HasColumnName("ID_PRESTAMO");
            entity.Property(e => e.Estado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("ESTADO");
            entity.Property(e => e.FechaEstimadaDevolucion)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_ESTIMADA_DEVOLUCION");
            entity.Property(e => e.FechaPrestamo)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_PRESTAMO");
            entity.Property(e => e.FechaRealDevolucion)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_REAL_DEVOLUCION");
            entity.Property(e => e.IdEstudiante).HasColumnName("ID_ESTUDIANTE");
            entity.Property(e => e.IdLibro).HasColumnName("ID_LIBRO");

            entity.HasOne(d => d.IdEstudianteNavigation).WithMany(p => p.PrestamosCabeceras)
                .HasForeignKey(d => d.IdEstudiante)
                .HasConstraintName("FK__PRESTAMOS__ID_ES__1332DBDC");

            entity.HasOne(d => d.IdLibroNavigation).WithMany(p => p.PrestamosCabeceras)
                .HasForeignKey(d => d.IdLibro)
                .HasConstraintName("FK__PRESTAMOS__ID_LI__14270015");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__USUARIO__91136B90420F9871");

            entity.ToTable("USUARIO");

            entity.HasIndex(e => e.Cedula, "UQ__USUARIO__06BB8448583BF3F9").IsUnique();

            entity.HasIndex(e => e.Correo, "UQ__USUARIO__264F33C831202A22").IsUnique();

            entity.Property(e => e.IdUsuario)
                .ValueGeneratedNever()
                .HasColumnName("ID_USUARIO");
            entity.Property(e => e.Cedula)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CEDULA");
            entity.Property(e => e.Contrasenia)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CONTRASENIA");
            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CORREO");
            entity.Property(e => e.Estado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("ESTADO");
            entity.Property(e => e.Nombres)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NOMBRES");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
