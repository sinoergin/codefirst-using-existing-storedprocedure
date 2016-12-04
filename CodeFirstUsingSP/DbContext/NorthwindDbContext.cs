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

        public List<GonderimiGerceklesmemisSiparisler> ResultGonderimiGerceklesmemisSiparisler()
        {
            var list =  this.Database.SqlQuery<GonderimiGerceklesmemisSiparisler>(" GonderimiYapilmamisSiparisBilgileri").ToList();

            return list;
        }

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
