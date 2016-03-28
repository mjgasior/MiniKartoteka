using System;
using System.Collections.Generic;

namespace MiniKartoteka.Data.DataBaseModels.Models
{
    public class Appointment : Entity
    {
        public virtual DateTime Date { get; set; }
        public virtual string Summary { get; set; }

        public virtual Patient Patient { get; set; }
        public virtual ICollection<Prescription> Prescriptions { get; set; }

        public Appointment()
        {
            Prescriptions = new List<Prescription>();
        }

        public virtual void AddPrescription(Prescription prescription)
        {
            prescription.Appointment = this;
            Prescriptions.Add(prescription);
        }
    }
}