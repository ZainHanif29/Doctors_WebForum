using System;
using System.Collections.Generic;

namespace Doctors_WebForum.Models
{
    public partial class Qualification
    {
        public Qualification()
        {
            DoctorRegs = new HashSet<DoctorReg>();
        }

        public int QId { get; set; }
        public string? QName { get; set; }

        public virtual ICollection<DoctorReg> DoctorRegs { get; set; }
    }
}
