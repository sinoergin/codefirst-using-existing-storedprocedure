using System.Linq;
using CodeFirstUsingSP.DbContext;
using static System.Console;

namespace CodeFirstUsingSP
{
    class Program
    {
        static void Main(string[] args)
        {
            var dbContext = new NorthwindDbContext();

            var calisanSatis = dbContext.ResultCalisanaGoreSatisBilgisi(1);
            WriteLine($"Calisan: {calisanSatis.CalisanAdSoyad} SatisTutar: {calisanSatis.SatisTutari}");

            ReadKey();

            var siparisBilgisi = dbContext.ResultGonderimiGerceklesmemisSiparisler();
            foreach (var item in siparisBilgisi.Take(10))
            {
                WriteLine(
                    $"SiparisTarihi: {item.SiparisTarihi.ToString("dd-MM-yyyy")} SiparisAdet:{item.SiparisAdedi} SiparisTutari: {item.SiparisTutari}");
            }

            ReadKey();
        }
    }
}
