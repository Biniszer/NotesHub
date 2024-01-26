using NotesHub.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesHub.Entities
{
    public class NoteState
    {
        public Guid Id { get; set; }
        public State Value { get; set; }
    }
}
