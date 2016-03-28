using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using MiniKartoteka.Data.DataBaseModels.Models;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System;
using System.IO;

namespace MiniKartoteka.Data.DataBaseModels
{
    public class NHibernateConfig
    {
        private static ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
              .Database(
                PostgreSQLConfiguration.PostgreSQL82
                        .ConnectionString(c =>
                            c.Host("127.0.0.1")
                            .Port(5432)
                            .Database("AAV")
                            .Username("postgres")
                            .Password("123456"))
              )
              .Mappings(m => m.FluentMappings.AddFromAssemblyOf<NHibernateConfig>())
              .ExposeConfiguration(BuildSchema)
              .BuildSessionFactory();
        }

        private static void BuildSchema(Configuration config)
        {
            // delete the existing db on each run
            //if (File.Exists(DbFile))
            //{
            //    File.Delete(DbFile);
            //}

            // this NHibernate tool takes a configuration (with mapping info in)
            // and exports a database schema from it
            new SchemaExport(config).Create(false, true);
        }

        public static void Initialize()
        {
            ISessionFactory sessionFactory = CreateSessionFactory();

            using (ISession session = sessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    var maciek = new Patient { FirstName = "Maciek", LastName = "Harrison" };
                    var joanna = new Patient { FirstName = "Joanna", LastName = "Torrance" };

                    var rutinoscorbin = new Drug { Name = "Rutinoscorbin", Dosage = "1 tbletka" };
                    var tussipini = new Drug { Name = "Tussi pini", Dosage = "1 lyzka" };
                    var oxycort = new Drug { Name = "Oxycort", Dosage = "1 prysniecie" };
                    var morfina = new Drug { Name = "Morfina", Dosage = "1 szczyk" };
                    var placebo = new Drug { Name = "Placebo", Dosage = "ile wlezie" };
                    var loperamid = new Drug { Name = "Loperamid", Dosage = "wedle poczeby" };

                    var maciek1 = new Appointment { Date = DateTime.Now };
                    var maciek2 = new Appointment { Date = DateTime.Now - TimeSpan.FromDays(5) };
                    var joanna1 = new Appointment { Date = DateTime.Now - TimeSpan.FromDays(6) };
                    var joanna2 = new Appointment { Date = DateTime.Now - TimeSpan.FromDays(7) };
                    var maciek3 = new Appointment { Date = DateTime.Now - TimeSpan.FromDays(8) };

                    // add products to the stores, there's some crossover in the products in each
                    // store, because the store-product relationship is many-to-many
                    AddDrugsToAppointment(maciek1, rutinoscorbin, tussipini);
                    AddDrugsToAppointment(maciek2, rutinoscorbin, tussipini, morfina);
                    AddDrugsToAppointment(maciek3, rutinoscorbin, tussipini, morfina, placebo);

                    AddDrugsToAppointment(joanna1, loperamid, oxycort);
                    AddDrugsToAppointment(joanna2, rutinoscorbin, morfina);

                    // add employees to the stores, this relationship is a one-to-many, so one
                    // employee can only work at one store at a time
                    AddAppointmentsToPatient(maciek, maciek1, maciek2, maciek3);
                    AddAppointmentsToPatient(joanna, joanna1, joanna2);

                    // save both stores, this saves everything else via cascading
                    session.SaveOrUpdate(maciek);
                    session.SaveOrUpdate(joanna);

                    transaction.Commit();
                }
            }
        }

        public static void AddDrugsToAppointment(Appointment appointment, params Drug[] drugs)
        {
            foreach (var product in drugs)
            {
                appointment.AddDrug(product);
            }
        }

        public static void AddAppointmentsToPatient(Patient patient, params Appointment[] appointments)
        {
            foreach (var employee in appointments)
            {
                patient.AddAppointment(employee);
            }
        }
    }
}
