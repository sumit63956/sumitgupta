using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace SearchServices.Models
{
    public partial class FlightDBContext : DbContext
    {
        public FlightDBContext()
        {
        }

        public FlightDBContext(DbContextOptions<FlightDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AirlineReg> AirlineRegs { get; set; }
        public virtual DbSet<Place> Places { get; set; }
        public virtual DbSet<Schedule> Schedules { get; set; }
        public virtual DbSet<ScheduleDay> ScheduleDays { get; set; }
        public virtual DbSet<UserBooking> UserBookings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=CTSDOTNET381;Initial Catalog=FlightDB;User ID=sa;Password=pass@word1");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AirlineReg>(entity =>
            {
                entity.HasKey(e => e.AirlineId)
                    .HasName("PK__Airline__DC458273F91CFBF6");

                entity.ToTable("AirlineReg");

                entity.Property(e => e.AirlineId).HasColumnName("AirlineID");

                entity.Property(e => e.Available)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ContactAdd).HasMaxLength(100);

                entity.Property(e => e.ContactNumber).HasMaxLength(10);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.UpdateLogo)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Place>(entity =>
            {
                entity.ToTable("place");

                entity.Property(e => e.PlaceId).HasColumnName("placeId");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Schedule>(entity =>
            {
                entity.HasKey(e => e.FlighNo)
                    .HasName("PK__Schedule__BC945970B4F5B7DB");

                entity.ToTable("Schedule");

                entity.Property(e => e.FlighNo)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.AirlineId).HasColumnName("AirlineID");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.FrmPlace)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Instrument)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Meal)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.NoOfBcseats).HasColumnName("NoOfBCSeats");

                entity.Property(e => e.NoOfNbcseats).HasColumnName("NoOfNBCSeats");

                entity.Property(e => e.ScheduleId).HasColumnName("ScheduleID");

                entity.Property(e => e.StrtDate).HasColumnType("datetime");

                entity.Property(e => e.ToPlace)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Trip)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.Airline)
                    .WithMany(p => p.Schedules)
                    .HasForeignKey(d => d.AirlineId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Schedule__Airlin__35BCFE0A");

                entity.HasOne(d => d.ScheduleNavigation)
                    .WithMany(p => p.Schedules)
                    .HasForeignKey(d => d.ScheduleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Schedule__Schedu__36B12243");
            });

            modelBuilder.Entity<ScheduleDay>(entity =>
            {
                entity.HasKey(e => e.ScheduleId)
                    .HasName("PK__Schedule__9C8A5B694E756ACD");

                entity.Property(e => e.ScheduleId).HasColumnName("ScheduleID");

                entity.Property(e => e.Friday)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Monday)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Saturday)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Sunday)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Thursday)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Tuesday)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Wednesday)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<UserBooking>(entity =>
            {
                entity.HasKey(e => e.BookingId)
                    .HasName("PK__UserBook__73951ACD6471ED2F");

                entity.ToTable("UserBooking");

                entity.Property(e => e.BookingId).HasColumnName("BookingID");

                entity.Property(e => e.EmailId).HasMaxLength(50);

                entity.Property(e => e.FlighNo)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Gender)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.IsCancelled)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Meal)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Pnrno).HasColumnName("PNRNo");

                entity.HasOne(d => d.FlighNoNavigation)
                    .WithMany(p => p.UserBookings)
                    .HasForeignKey(d => d.FlighNo)
                    .HasConstraintName("Fk_flighno");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
