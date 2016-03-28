using System;
using System.Collections.Generic;

namespace MiniKartoteka.Data.DataBaseModels.Models
{
    public class Drug
    {
        public virtual Guid Id { get; protected set; }
        public virtual string Name { get; set; }
        public virtual string Dosage { get; set; }
        public virtual string Size { get; set; }

        public virtual IList<Appointment> Appointments { get; set; }

        public Drug()
        {
            Appointments = new List<Appointment>();
        }
    }
}
