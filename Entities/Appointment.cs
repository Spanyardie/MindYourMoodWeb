using MindYourMoodWeb.Interfaces;
using System;
using System.Collections.Generic;

namespace MindYourMoodWeb.Entities
{
    public class Appointment : Entity
    {
        public enum AppointmentType
        {
            Counsellor,
            ConsultantPsychiatrist,
            MedicationReview,
            CrisisTeam,
            GroupTherapy,
            CognitiveBehaviouralTherapy,
            Consultation,
            CommunityPsychiatricNurse,
            HospitalMentalHealth,
            HospitalConsultation,
            HospitalScan,
            HospitalOutpatient,
            HospitalOperation,
            GeneralPractitioner,
            PracticeNurse,
            BloodTest,
            FluJab,
            WorkTeamMeeting,
            WorkHr,
            WorkAppraisal,
            WorkGeneralMeeting,
            WorkProjectPlanning,
            WorkTraining,
            JobInterview
        }

        public DateTime Date { get; set; }
        public AppointmentType Type { get; set; }
        public string Location { get; set; }
        public string WithWhom { get; set; }
        public DateTime AppointmentTime { get; set; }
        public string Notes { get; set; }
        public ICollection<AppointmentQuestion> Questions { get; set; }
        public AppUser User { get; set; }
    }
}
