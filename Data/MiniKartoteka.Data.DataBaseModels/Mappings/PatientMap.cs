using FluentNHibernate.Mapping;
using MiniKartoteka.Data.DataBaseModels.Models;

namespace MiniKartoteka.Data.DataBaseModels.Mappings
{
    public class PatientMap : ClassMap<Patient>
    {
        public PatientMap()
        {
            Id(x => x.Id).Column("Id").GeneratedBy.Guid();
            Map(x => x.FirstName);
            Map(x => x.LastName);
            HasMany(x => x.Appointments)
                .Inverse()
                .Cascade.All();
        }
    }
}
