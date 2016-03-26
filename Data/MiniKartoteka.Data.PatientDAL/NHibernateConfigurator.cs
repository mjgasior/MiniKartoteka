using MiniKartoteka.Data.DataBaseModels;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using System.Reflection;

namespace MiniKartoteka.Data.PatientDAL
{
    public static class NHibernateConfigurator
    {
        public static void Configurate()
        {
            /*
            <hibernate-configuration xmlns="urn:nhibernate-configuration-2.2">
            <session-factory>
            <property name="connection.provider">NHibernate.Connection.DriverConnectionProvider</property>
            <property name="dialect">NHibernate.Dialect.PostgreSQLDialect</property>
            <property name="connection.driver_class">NHibernate.Driver.NpgsqlDriver</property>
            <property name="connection.connection_string_name">NHibernate.connectionString</property>
            <property name="current_session_context_class">web</property>
            <mapping assembly="NHibernateTest">
            </mapping></session-factory>
            </hibernate-configuration>
            */
            var cfg = new Configuration();
            cfg.DataBaseIntegration(x => {
                x.ConnectionString = "server=localhost;Port=5432;Database=hiberdemo;User Id=postgres;Password=123456;";
                x.Driver<NpgsqlDriver>();
                x.Dialect<PostgreSQLDialect>();
                });
            //cfg.AddAssembly(Assembly.GetAssembly(typeof(Wwywalto)));
            cfg.AddAssembly(Assembly.GetCallingAssembly());
            ISessionFactory sessionFactory = cfg.BuildSessionFactory();

            using (ISession session = sessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    // perfrom database logic

                    transaction.Commit();
                }
            }
        }
    }
}
