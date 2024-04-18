using System;
using System.Collections.Generic;

namespace Doctors_WebForum.Models
{
    public partial class AdminReg
    {
        public int AId { get; set; }
        public string? AName { get; set; }
        public string? AEmail { get; set; }
        public string? APassword { get; set; }
    }
}
