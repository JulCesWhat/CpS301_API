using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CpS301_API.Models
{
    public partial class wsoappContext : DbContext
    {
        public virtual DbSet<Ensemble> Ensemble { get; set; }
        public virtual DbSet<Ensembleperson> Ensembleperson { get; set; }
        public virtual DbSet<Eventtype> Eventtype { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<Personunavailable> Personunavailable { get; set; }
        public virtual DbSet<Service> Service { get; set; }
        public virtual DbSet<Serviceevent> Serviceevent { get; set; }
        public virtual DbSet<Song> Song { get; set; }

        //        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //        {
        //            if (!optionsBuilder.IsConfigured)
        //            {
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
        //                optionsBuilder.UseMySql("Server=localhost;Port=3306;User Id=root;password=Password;Database=wsoapp");
        //            }
        //        }

        public wsoappContext(DbContextOptions<wsoappContext> options)
        : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ensemble>(entity =>
            {
                entity.ToTable("ensemble");

                entity.Property(e => e.EnsembleId)
                    .HasColumnName("Ensemble_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Ensembleperson>(entity =>
            {
                entity.HasKey(e => new { e.EnsembleId, e.PersonId });

                entity.ToTable("ensembleperson");

                entity.HasIndex(e => e.PersonId)
                    .HasName("FK_EnsemblePerson_Person");

                entity.Property(e => e.EnsembleId)
                    .HasColumnName("Ensemble_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PersonId)
                    .HasColumnName("Person_ID")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Ensemble)
                    .WithMany(p => p.Ensembleperson)
                    .HasForeignKey(d => d.EnsembleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EnsemblePerson_Ensemble");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Ensembleperson)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EnsemblePerson_Person");
            });

            modelBuilder.Entity<Eventtype>(entity =>
            {
                entity.ToTable("eventtype");

                entity.Property(e => e.EventTypeId)
                    .HasColumnName("EventType_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("person");

                entity.Property(e => e.PersonId)
                    .HasColumnName("Person_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("First_Name")
                    .HasMaxLength(15);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("Last_Name")
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Personunavailable>(entity =>
            {
                entity.HasKey(e => new { e.PersonId, e.ServiceId });

                entity.ToTable("personunavailable");

                entity.HasIndex(e => e.ServiceId)
                    .HasName("FK_PersonUnavailable_Service");

                entity.Property(e => e.PersonId)
                    .HasColumnName("Person_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ServiceId)
                    .HasColumnName("Service_ID")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Personunavailable)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PersonUnavailable_Person");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.Personunavailable)
                    .HasForeignKey(d => d.ServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PersonUnavailable_Service");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.ToTable("service");

                entity.HasIndex(e => e.OrganistId)
                    .HasName("FK_Service_Organist");

                entity.HasIndex(e => e.PianistId)
                    .HasName("FK_Service_Pianist");

                entity.HasIndex(e => e.SongleaderId)
                    .HasName("FK_Service_Songleader");

                entity.Property(e => e.ServiceId)
                    .HasColumnName("Service_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Notes).HasMaxLength(255);

                entity.Property(e => e.OrganistConf)
                    .IsRequired()
                    .HasColumnName("Organist_Conf")
                    .HasColumnType("char(1)");

                entity.Property(e => e.OrganistId)
                    .HasColumnName("Organist_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PianistConf)
                    .IsRequired()
                    .HasColumnName("Pianist_Conf")
                    .HasColumnType("char(1)");

                entity.Property(e => e.PianistId)
                    .HasColumnName("Pianist_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SongleaderConf)
                    .IsRequired()
                    .HasColumnName("Songleader_Conf")
                    .HasColumnType("char(1)");

                entity.Property(e => e.SongleaderId)
                    .HasColumnName("Songleader_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SvcDateTime).HasColumnName("Svc_DateTime");

                entity.Property(e => e.Theme).HasMaxLength(40);

                entity.Property(e => e.Title).HasMaxLength(40);

                entity.HasOne(d => d.Organist)
                    .WithMany(p => p.ServiceOrganist)
                    .HasForeignKey(d => d.OrganistId)
                    .HasConstraintName("FK_Service_Organist");

                entity.HasOne(d => d.Pianist)
                    .WithMany(p => p.ServicePianist)
                    .HasForeignKey(d => d.PianistId)
                    .HasConstraintName("FK_Service_Pianist");

                entity.HasOne(d => d.Songleader)
                    .WithMany(p => p.ServiceSongleader)
                    .HasForeignKey(d => d.SongleaderId)
                    .HasConstraintName("FK_Service_Songleader");
            });

            modelBuilder.Entity<Serviceevent>(entity =>
            {
                entity.HasKey(e => e.EventId);

                entity.ToTable("serviceevent");

                entity.HasIndex(e => e.EnsembleId)
                    .HasName("FK_ServiceEvent_Ensemble");

                entity.HasIndex(e => e.EventTypeId)
                    .HasName("FK_ServiceEvent_EventType");

                entity.HasIndex(e => e.PersonId)
                    .HasName("FK_ServiceEvent_Person");

                entity.HasIndex(e => e.ServiceId)
                    .HasName("FK_ServiceEvent_Service");

                entity.HasIndex(e => e.SongId)
                    .HasName("FK_ServiceEvent_Song");

                entity.Property(e => e.EventId)
                    .HasColumnName("Event_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Confirmed)
                    .IsRequired()
                    .HasColumnType("char(1)");

                entity.Property(e => e.EnsembleId)
                    .HasColumnName("Ensemble_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EventTypeId)
                    .HasColumnName("EventType_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Notes).HasMaxLength(40);

                entity.Property(e => e.PersonId)
                    .HasColumnName("Person_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SeqNum)
                    .HasColumnName("Seq_Num")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ServiceId)
                    .HasColumnName("Service_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SongId)
                    .HasColumnName("Song_ID")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Ensemble)
                    .WithMany(p => p.Serviceevent)
                    .HasForeignKey(d => d.EnsembleId)
                    .HasConstraintName("FK_ServiceEvent_Ensemble");

                entity.HasOne(d => d.EventType)
                    .WithMany(p => p.Serviceevent)
                    .HasForeignKey(d => d.EventTypeId)
                    .HasConstraintName("FK_ServiceEvent_EventType");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Serviceevent)
                    .HasForeignKey(d => d.PersonId)
                    .HasConstraintName("FK_ServiceEvent_Person");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.Serviceevent)
                    .HasForeignKey(d => d.ServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ServiceEvent_Service");

                entity.HasOne(d => d.Song)
                    .WithMany(p => p.Serviceevent)
                    .HasForeignKey(d => d.SongId)
                    .HasConstraintName("FK_ServiceEvent_Song");
            });

            modelBuilder.Entity<Song>(entity =>
            {
                entity.ToTable("song");

                entity.Property(e => e.SongId)
                    .HasColumnName("Song_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Arranger).HasMaxLength(20);

                entity.Property(e => e.HymnbookNum)
                    .HasColumnName("Hymnbook_Num")
                    .HasMaxLength(5);

                entity.Property(e => e.SongType)
                    .IsRequired()
                    .HasColumnName("Song_Type")
                    .HasColumnType("char(1)");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50);
            });
        }
    }
}
