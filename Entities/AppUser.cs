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
        public ICollection<Fantasy> Fantasies { get; set; }
        public ICollection<Feeling> Feelings { get; set; }
        public ICollection<GenericText> GenericTexts { get; set; }
        public ICollection<Health> Healths { get; set; }
        public ICollection<Prescription> Prescriptions { get; set; }
        public ICollection<PlayList> PlayLists { get; set; }
        public ICollection<Activities> Activities { get; set; }
        public ICollection<Contact> Contacts { get; set; }
        public ICollection<SafetyPlanCard> SafetyPlanCards { get; set; }
        public ICollection<TellMyself> TellMyselfs { get; set; }
    }
}
