using Microsoft.EntityFrameworkCore;
using StaApplication.Models;

namespace StaApplication.Data
{
    public class StaApplicationContext(DbContextOptions<StaApplicationContext> options) : DbContext(options)
    {
        public DbSet<Karyawan> Karyawan { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Karyawan>().ToTable("karyawan");
            modelBuilder.Entity<Karyawan>().HasKey(x => x.IDKaryawan);
            modelBuilder.Entity<Karyawan>().Property(x => x.IDKaryawan).HasColumnName("idkaryawan");
            modelBuilder.Entity<Karyawan>().Property(x => x.NmKaryawan).HasColumnName("nmkaryawan");
            modelBuilder.Entity<Karyawan>().Property(x => x.TglMasukKerja).HasColumnName("tglmasukkerja");
            modelBuilder.Entity<Karyawan>().Property(x => x.Usia).HasColumnName("usia");
            base.OnModelCreating(modelBuilder);
        }


    }
}
