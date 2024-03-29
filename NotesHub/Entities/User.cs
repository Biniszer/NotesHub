﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesHub.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public string Nick {  get; set; }
        public string Email { get; set; }
        public List<Note> Notes{ get; set; } = new List<Note>();
    }
}
