using System.Collections.Generic;
using System.Data.SqlClient;
using CodeFirstUsingSP.StoredProcedureModels;

namespace CodeFirstUsingSP.DbContext
{
    using System.Data.Entity;
    using System.Linq;

    public partial class NorthwindDbContext : DbContext
    {
        public NorthwindDbContext()
            : base("name=NorthwindDbContext")
        {
        }


        // StoredProcedure kullanabilmemiz için DbContext tarafında dönüş tipleri ile birlikte method şeklinde yaratıyoruz ve ister Database.SqlQuery istersek ise CRUD methodları için kullanabileceğimiz Database.ExecuteSqlCommand methodları ile SP'leri çağırıyoruz.

        /// <summary>
        /// ResultGonderimiGerceklesmemisSiparisler methodu GonderimiYapilmamisSiparisBilgileri SP execute edip geriye GenericList döndürecektir.
        /// </summary>
        /// <returns></returns>
        public List<GonderimiGerceklesmemisSiparisler> ResultGonderimiGerceklesmemisSiparisler()
        {
            var list =  this.Database.SqlQuery<GonderimiGerceklesmemisSiparisler>(" GonderimiYapilmamisSiparisBilgileri").ToList();
            
            return list;
        }

        
        /// <summary>
        /// ResultCalisanaGoreSatisBilgisi methodu CalisanaGoreYapmisOlduguToplamSatisAdediveTutari SP execute edip scalar veri döndürecektir.
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public CalisanaGoreSatisBilgisi ResultCalisanaGoreSatisBilgisi(int employeeId)
        {
            if (employeeId == 0)
            {
                return null;
            }

            var sqlParam = new SqlParameter("@employeeId",employeeId);

            List<CalisanaGoreSatisBilgisi> calisanBilgisi =
                this.Database.SqlQuery<CalisanaGoreSatisBilgisi>("CalisanaGoreYapmisOlduguToplamSatisAdediveTutari @employeeId", sqlParam).ToList();

            return calisanBilgisi.First();
        }
    }
}
