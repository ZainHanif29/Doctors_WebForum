using System;
using System.Collections.Generic;

namespace Doctors_WebForum.Models
{
    public partial class Privacy
    {
        public Privacy()
        {
            DoctorRegs = new HashSet<DoctorReg>();
        }

        public int PId { get; set; }
        public string? PName { get; set; }

        public virtual ICollection<DoctorReg> DoctorRegs { get; set; }
    }
}
