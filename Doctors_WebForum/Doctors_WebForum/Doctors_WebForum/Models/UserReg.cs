using System;
using System.Collections.Generic;

namespace Doctors_WebForum.Models
{
    public partial class UserReg
    {
        public int UId { get; set; }
        public string? UName { get; set; }
        public string? UEmail { get; set; }
        public string? UPassword { get; set; }
        public string? UContact { get; set; }
        public string? UAddress { get; set; }
    }
}
