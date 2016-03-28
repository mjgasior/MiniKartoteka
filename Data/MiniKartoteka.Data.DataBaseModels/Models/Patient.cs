using System;
using System.Collections.Generic;

namespace MiniKartoteka.Data.DataBaseModels.Models
{
    public class Patient : Entity
    {
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }

        public Patient()
        {
            Appointments = new List<Appointment>();
        }

        public virtual void AddAppointment(Appointment appointment)
        {
            appointment.Patient = this;
            Appointments.Add(appointment);
        }
    }
}
