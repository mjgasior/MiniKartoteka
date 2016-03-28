using System;
using System.Collections.Generic;

namespace MiniKartoteka.Data.DataBaseModels.Models
{
    public class Appointment
    {
        public virtual Guid Id { get; protected set; }
        public virtual DateTime Date { get; set; }
        public virtual string Summary { get; set; }

        public virtual Patient Patient { get; set; }
        public virtual ICollection<Drug> Drugs { get; set; }

        public Appointment()
        {
            Drugs = new List<Drug>();
        }

        public virtual void AddDrug(Drug drug)
        {
            drug.Appointments.Add(this);
            Drugs.Add(drug);
        }
    }
}