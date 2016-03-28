namespace MiniKartoteka.Data.DataBaseModels.Models
{
    public class Prescription : Entity
    {
        public virtual string Dosage { get; set; }
        public virtual string Size { get; set; }

        public virtual Drug Drug { get; set; }
        public virtual Appointment Appointment { get; set; }
    }
}
