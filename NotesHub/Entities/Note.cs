using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesHub.Entities
{
    public class PublicNote : Note
    {
        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
    public class Note
    {
        public Guid Id { get; set; }
        public NoteState State { get; set; }
        public Guid StateId { get; set; }
        public string Name { get; set; }
        public DateTime CreationTime { get; set; }
        public string? Content { get; set; }
        public User Author { get; set; }
        public Guid AuthorId { get; set; }
        public List<Tag> Tags { get; set; }
    }
}
