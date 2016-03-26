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
            var cfg = new Configuration();
            cfg.DataBaseIntegration(x => {
                x.ConnectionString = "Server=localhost;Database=NHibernateDemo;Integrated Security=SSPI;";
                x.Driver<NpgsqlDriver>();
                x.Dialect<PostgreSQLDialect>();
                });
            cfg.AddAssembly(Assembly.GetAssembly(typeof(Wwywalto)));
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
