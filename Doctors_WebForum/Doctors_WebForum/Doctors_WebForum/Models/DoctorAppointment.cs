using System;
using System.Collections.Generic;

namespace Doctors_WebForum.Models
{
    public partial class DoctorAppointment
    {
        public int ApId { get; set; }
        public string? ApName { get; set; }
        public string? ApEmail { get; set; }
        public string? ApPhone { get; set; }
        public DateTime? ApDate { get; set; }
        public int? ApSpecialization { get; set; }
        public int? DId { get; set; }
        public string? ApMsg { get; set; }

        public virtual Specialization? ApSpecializationNavigation { get; set; }
        public virtual DoctorReg? DIdNavigation { get; set; }
    }
}
