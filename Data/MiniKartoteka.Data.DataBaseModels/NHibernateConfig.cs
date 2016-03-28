using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using MiniKartoteka.Data.DataBaseModels.Models;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System;

namespace MiniKartoteka.Data.DataBaseModels
{
    public class NHibernateConfig
    {
        public static ISessionFactory CreateSessionFactory()
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
              .BuildSessionFactory();
        }

        private static ISessionFactory CreateSessionFactoryWithDBInit()
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
            new Prescription();
            ISessionFactory sessionFactory = CreateSessionFactory();

            using (ISession session = sessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    var maciek = new Patient { FirstName = "Maciek", LastName = "Harrison" };
                    var joanna = new Patient { FirstName = "Joanna", LastName = "Torrance" };

                    var rutinoscorbin = new Drug { Name = "Rutinoscorbin" };
                    var placebo = new Drug { Name = "Placebo" };
                    var loperamid = new Drug { Name = "Loperamid" };
                    var tussipini = new Drug { Name = "Tussi pini" };

                    session.SaveOrUpdate(rutinoscorbin);
                    session.SaveOrUpdate(placebo);
                    session.SaveOrUpdate(loperamid);
                    session.SaveOrUpdate(tussipini);

                    var presciption1 = new Prescription { Drug = rutinoscorbin, Dosage = "ile lubi", Size = "jedna paczka" };
                    var presciption2 = new Prescription { Drug = placebo, Dosage = "ile lubi", Size = "jedna paczka" };
                    var presciption3 = new Prescription { Drug = loperamid, Dosage = "ile lubi", Size = "jedna paczka" };
                    var presciption4 = new Prescription { Drug = loperamid, Dosage = "ile lubi", Size = "jedna paczka" };
                    var presciption5 = new Prescription { Drug = tussipini, Dosage = "ile lubi", Size = "jedna paczka" };

                    var appointment1 = new Appointment { Date = DateTime.Now, Patient = maciek, Summary = "choroba urojona" };
                    var appointment2 = new Appointment { Date = DateTime.Now - TimeSpan.FromDays(5), Patient = maciek, Summary = "choroba urojona" };
                    var appointment3 = new Appointment { Date = DateTime.Now - TimeSpan.FromDays(7), Patient = joanna, Summary = "choroba motyla noga" };

                    AddPrescriptionsToAppointment(appointment1, presciption1, presciption2);
                    AddPrescriptionsToAppointment(appointment2, presciption3);
                    AddPrescriptionsToAppointment(appointment3, presciption4, presciption5);

                    AddAppointmentsToPatient(maciek, appointment1, appointment2);
                    AddAppointmentsToPatient(joanna, appointment3);

                    // save both stores, this saves everything else via cascading
                    session.SaveOrUpdate(maciek);
                    session.SaveOrUpdate(joanna);

                    transaction.Commit();
                }
            }
        }

        public static void AddPrescriptionsToAppointment(Appointment appointment, params Prescription[] drugs)
        {
            foreach (var product in drugs)
            {
                appointment.AddPrescription(product);
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
