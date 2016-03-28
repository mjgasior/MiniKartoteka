using FluentNHibernate.Mapping;
using MiniKartoteka.Data.DataBaseModels.Models;

namespace MiniKartoteka.Data.DataBaseModels.Mappings
{
    public class AppointmentMap : ClassMap<Appointment>
    {
        public AppointmentMap()
        {
            Id(x => x.Id).Column("Id").GeneratedBy.Guid();
            Map(x => x.Date);
            Map(x => x.Summary);
            References(x => x.Patient);
            HasMany(x => x.Prescriptions)
                .Inverse()
                .Cascade.All();
        }
    }
}
