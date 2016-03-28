using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
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
            var sessionFactory = CreateSessionFactory();
        }


        //public static void Configurate()
        //{
        //    var cfg = new Configuration();
        //    cfg.DataBaseIntegration(x => {
        //        x.ConnectionString = "Server=127.0.0.1;Port=5432;Database=AAV;User Id=postgres;Password = 123456;";
        //        x.Driver<NpgsqlDriver>();
        //        x.Dialect<PostgreSQLDialect>();
        //    });
        //    cfg.AddAssembly(Assembly.GetAssembly(typeof(Customer)));

        //    ISessionFactory sessionFactory = cfg.BuildSessionFactory();

        //    using (ISession session = sessionFactory.OpenSession())
        //    {
        //        using (ITransaction transaction = session.BeginTransaction())
        //        {
        //            // perfrom database logic

        //            transaction.Commit();
        //        }
        //    }
        //}
    }
}
