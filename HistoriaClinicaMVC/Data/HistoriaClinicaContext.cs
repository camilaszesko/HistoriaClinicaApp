using HistoriaClinicaMVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace HistoriaClinicaMVC.Data
{
    public class HistoriaClinicaContext : IdentityDbContext <IdentityUser<int>, IdentityRole<int>, int>
    {

        public HistoriaClinicaContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MedicoPaciente>().HasKey(mp => new { mp.MedicoId, mp.PacienteId });

            modelBuilder.Entity<MedicoPaciente>()
                .HasOne(mp => mp.Medico)
                .WithMany(m => m.MedicoPacientes)
                .HasForeignKey(mp => mp.MedicoId);



            modelBuilder.Entity<MedicoPaciente>()
                .HasOne(mp => mp.Paciente)
                .WithMany(p => p.MedicosPaciente)
                .HasForeignKey(mp => mp.PacienteId);

            modelBuilder.Entity<IdentityUser<int>>().ToTable("Personas");
            modelBuilder.Entity<IdentityRole<int>>().ToTable("Roles");
            modelBuilder.Entity<IdentityUserRole<int>>().ToTable("PersonasRoles");

            #region Unique
            modelBuilder.Entity<Medico>().HasIndex(m => m.MatriculaNacional).IsUnique();
            modelBuilder.Entity<Empleado>().HasIndex(e => e.Legajo).IsUnique();
            #endregion

        }





      
        

        public DbSet<Empleado> Empleados { get; set; }

        

        public DbSet<Episodio> Episodios { get; set; }

       

        public DbSet<HistoriaClinica> HistoriasClinicas { get; set; }

        public DbSet<Medico> Medicos { get; set; }

        

        public DbSet<Paciente> Pacientes { get; set; }

        public DbSet<Persona> Personas { get; set; }

        public DbSet<Direccion> Direcciones { get; set; }



        public DbSet<HistoriaClinicaMVC.Models.App> App { get; set; }

#pragma warning disable CS0114 // Member hides inherited member; missing override keyword
        public DbSet<Rol> Roles { get; set; }

#pragma warning disable CS0114 // Member hides inherited member; missing override keyword
        public DbSet<HistoriaClinicaMVC.Models.MedicoPaciente> MedicoPaciente { get; set; }
#pragma warning restore CS0114 // Member hides inherited member; missing override keyword
        
    }
}
