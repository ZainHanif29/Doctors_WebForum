using System;
using System.Collections.Generic;

namespace Doctors_WebForum.Models
{
    public partial class Experience
    {
        public Experience()
        {
            DoctorRegs = new HashSet<DoctorReg>();
        }

        public int EId { get; set; }
        public string? EName { get; set; }

        public virtual ICollection<DoctorReg> DoctorRegs { get; set; }
    }
}
