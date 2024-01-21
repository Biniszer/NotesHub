using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesHub.Entities
{
    public class Comment
    {
        public Guid Id {  get; set; }
        public string Message { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Author { get; set; }
    }
}
