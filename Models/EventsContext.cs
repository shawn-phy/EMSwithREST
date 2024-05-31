using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EMSwithREST.Models;

public partial class EventsContext : DbContext
{
    public EventsContext()
    {
    }

    public EventsContext(DbContextOptions<EventsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Attendee> Attendees { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<Organizer> Organizers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost,1433;Database=Events;User Id=sa;Password=Password_123#;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Attendee>(entity =>
        {
            entity.HasKey(e => e.AttendeeId).HasName("PK__Attendee__4BCAE05CB51D1184");

            entity.Property(e => e.AttendeeId).HasColumnName("attendee_id");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.EventId).HasColumnName("event_id");
            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("last_name");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.RegistrationDate).HasColumnName("registration_date");

            entity.HasOne(d => d.Event).WithMany(p => p.Attendees)
                .HasForeignKey(d => d.EventId)
                .HasConstraintName("FK__Attendees__event__3C69FB99");
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.EventId).HasName("PK__Events__2370F727C9D3D5F7");

            entity.Property(e => e.EventId).HasColumnName("event_id");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.EventDate).HasColumnName("event_date");
            entity.Property(e => e.EventName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("event_name");
            entity.Property(e => e.EventTime).HasColumnName("event_time");
            entity.Property(e => e.Location)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("location");
            entity.Property(e => e.OrganizerId).HasColumnName("organizer_id");

            entity.HasOne(d => d.Organizer).WithMany(p => p.Events)
                .HasForeignKey(d => d.OrganizerId)
                .HasConstraintName("FK__Events__organize__398D8EEE");
        });

        modelBuilder.Entity<Organizer>(entity =>
        {
            entity.HasKey(e => e.OrganizerId).HasName("PK__Organize__0634701447BE2951");

            entity.Property(e => e.OrganizerId).HasColumnName("organizer_id");
            entity.Property(e => e.ContactEmail)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("contact_email");
            entity.Property(e => e.ContactPhone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("contact_phone");
            entity.Property(e => e.OrganizerName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("organizer_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
