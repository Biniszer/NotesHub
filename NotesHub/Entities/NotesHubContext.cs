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
        public DbSet<User> Users { get; set; }
        public DbSet<Tag> Tags { get; set; }
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
    }
}
