using FluentNHibernate.Mapping;
using MiniKartoteka.Data.DataBaseModels.Models;

namespace MiniKartoteka.Data.DataBaseModels.Mappings
{
    public class PrescriptionMap : ClassMap<Prescription>
    {
        public PrescriptionMap()
        {
            Id(x => x.Id).Column("Id").GeneratedBy.Guid();
            Map(x => x.Dosage);
            References(x => x.Drug);
            References(x => x.Appointment);            
        }
    }
}
