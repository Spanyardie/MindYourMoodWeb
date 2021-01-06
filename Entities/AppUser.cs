using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace MindYourMoodWeb.Entities
{
    public class AppUser : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime LastActive { get; set; } = DateTime.Now;
        public ICollection<AppUserRole> UserRoles { get; set; }
        public ICollection<Affirmation> Affirmations { get; set; }
        public ICollection<ChuffChartItem> ChuffChartItems { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
        public ICollection<Attitude> Attitudes { get; set; }
    }
}
