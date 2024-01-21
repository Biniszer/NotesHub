using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesHub.Entities
{
    public class Note
    {
        public Guid Id { get; set; }
        public string State { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Tags{ get; set; }
        public DateTime CreationTime { get; set; }
        public string Comments {  get; set; }
        public string Content { get; set; }
    }
}
