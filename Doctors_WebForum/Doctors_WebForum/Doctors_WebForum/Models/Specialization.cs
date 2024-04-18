using System;
using System.Collections.Generic;

namespace Doctors_WebForum.Models
{
    public partial class Specialization
    {
        public Specialization()
        {
            DoctorAppointments = new HashSet<DoctorAppointment>();
            DoctorRegs = new HashSet<DoctorReg>();
        }

        public int SId { get; set; }
        public string? SName { get; set; }

        public virtual ICollection<DoctorAppointment> DoctorAppointments { get; set; }
        public virtual ICollection<DoctorReg> DoctorRegs { get; set; }
    }
}
