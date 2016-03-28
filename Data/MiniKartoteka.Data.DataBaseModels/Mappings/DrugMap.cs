using FluentNHibernate.Mapping;
using MiniKartoteka.Data.DataBaseModels.Models;

namespace MiniKartoteka.Data.DataBaseModels.Mappings
{
    public class DrugMap : ClassMap<Drug>
    {
        public DrugMap()
        {
            Id(x => x.Id).Column("Id").GeneratedBy.Guid();
            Map(x => x.Name);
            Map(x => x.Dosage);
            HasManyToMany(x => x.Appointments)
              .Cascade.All()
              .Inverse()
              .Table("PrescribedDrug");
        }
    }
}
