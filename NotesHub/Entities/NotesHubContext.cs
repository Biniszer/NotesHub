using Microsoft.EntityFrameworkCore;
using NotesHub.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace NotesHub.Entities
{
    public class NotesHubContext : DbContext
    {
        public DbSet<Note> Notes { get; set; }
        public DbSet<PublicNote> PublicNotes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<NoteState> NoteStates { get; set; }
        public DbSet<Comment> Comments { get; set; }
        private const string ConnectionstringKey = "postgres";
        private const string JsonFile = "appsettings.json";
        public static AppSettingsJson ReadConfiguration()
        {
            string json = File.ReadAllText(JsonFile);
            return JsonSerializer.Deserialize<AppSettingsJson>(json);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration= ReadConfiguration();
            var connectionString = configuration.ConnectionString[ConnectionstringKey];
            optionsBuilder.UseNpgsql(connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(eb =>
            {
                eb.HasMany(n => n.Notes).WithOne(u => u.Author).HasForeignKey(n => n.AuthorId);
                eb.Property(u=>u.Id).IsRequired();
                eb.Property(u => u.Name).HasColumnType("text").IsRequired();
                eb.Property(u=>u.Surname).HasColumnType("text").IsRequired();
                eb.Property(u=>u.Password).HasColumnType("text").IsRequired();
                eb.Property(u => u.Nick).HasColumnType("text").IsRequired();
                eb.Property(u => u.Email).HasColumnType("text").IsRequired();
            });
            modelBuilder.Entity<Tag>();
            modelBuilder.Entity<Comment>(eb=>
            {
                eb.Property(c=>c.Id).IsRequired();
                eb.Property(c=>c.Message).HasDefaultValue("Tu wpisz komentarz...").IsRequired();
                eb.Property(c=>c.Message).HasColumnType("text");
                eb.Property(c=>c.Message).HasMaxLength(300);
                eb.Property(c=>c.CreatedDate).HasDefaultValue(DateTime.Now).IsRequired();
                eb.Property(c=>c.UpdatedDate).ValueGeneratedOnUpdate();
                eb.Property(c=>c.Author).IsRequired();
            });
            modelBuilder.Entity<PublicNote>(eb =>
            {
                eb.HasMany(c => c.Comments).WithOne().HasForeignKey(c => c.NoteId);
            });
            modelBuilder.Entity<Note>(eb =>
            {
                eb.Property(note=>note.Id).IsRequired();
                eb.Property(note=>note.Name).IsRequired();
                eb.Property(note => note.Name).HasDefaultValue("Nowa notatka - tytuł");
                eb.Property(note=>note.Content).HasColumnType("text");
                eb.Property(note=>note.Content).HasDefaultValue("Tutaj napisz zawartość notatki");
                eb.Property(note => note.CreationTime).HasPrecision(3);
                eb.Property(note=>note.Content).HasMaxLength(3000);               
                eb.HasMany(n => n.Tags).WithMany(t => t.Notes);
                eb.HasOne(n=>n.State).WithMany().HasForeignKey(n=>n.StateId);
            });
            //modelBuilder.Entity<NoteState>().Property(ns=>ns.State).IsRequired();
        }
    }
}
