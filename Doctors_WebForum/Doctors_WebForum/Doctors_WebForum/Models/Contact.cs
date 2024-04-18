using System;
using System.Collections.Generic;

namespace Doctors_WebForum.Models
{
    public partial class Contact
    {
        public int CId { get; set; }
        public string? CName { get; set; }
        public string? CEmail { get; set; }
        public string? CSubject { get; set; }
        public string? CMsg { get; set; }
    }
}
