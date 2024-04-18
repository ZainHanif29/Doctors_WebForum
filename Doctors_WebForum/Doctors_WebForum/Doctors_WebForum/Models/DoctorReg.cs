using System;
using System.Collections.Generic;

namespace Doctors_WebForum.Models
{
    public partial class DoctorReg
    {
        public DoctorReg()
        {
            DoctorAppointments = new HashSet<DoctorAppointment>();
        }

        public int DId { get; set; }
        public string? DName { get; set; }
        public string? DEmail { get; set; }
        public string? DPassword { get; set; }
        public string? DContact { get; set; }
        public string? DAddress { get; set; }
        public int? DPrivacy { get; set; }
        public int? DQualification { get; set; }
        public int? DSpecialization { get; set; }
        public int? DExperience { get; set; }
        public string? DAchivement { get; set; }
        public string? DDesc { get; set; }

        public virtual Experience? DExperienceNavigation { get; set; }
        public virtual Privacy? DPrivacyNavigation { get; set; }
        public virtual Qualification? DQualificationNavigation { get; set; }
        public virtual Specialization? DSpecializationNavigation { get; set; }
        public virtual ICollection<DoctorAppointment> DoctorAppointments { get; set; }
    }
}
