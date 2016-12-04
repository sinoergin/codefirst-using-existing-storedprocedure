using System.Linq;
using CodeFirstUsingSP.DbContext;
using static System.Console; // Burada C# 6.0 ile gelen using static deyimini kullandık.

namespace CodeFirstUsingSP
{
    class Program
    {
        static void Main(string[] args)
        {
            var dbContext = new NorthwindDbContext();

            // Yapmamız gereken DbContext'ten kullanmak istediğimiz SP'nin methodunu call etmek yeterli olacaktır.
            var calisanSatis = dbContext.ResultCalisanaGoreSatisBilgisi(1);

            // C# 6.0 ile gelen using static ile string interpolation özellikleri ile yazdırma işlemini gerçekleştirdik.
            WriteLine($"Calisan: {calisanSatis.CalisanAdSoyad} SatisTutar: {calisanSatis.SatisTutari}");

            // Aynı şekilde yine using static kullanmış olduk.
            ReadKey();

            // Diğer method da olduğu gibi aynı şekilde burada method call edip set etmemiz yeterli oluyor.
            var siparisBilgisi = dbContext.ResultGonderimiGerceklesmemisSiparisler();
            foreach (var item in siparisBilgisi.Take(10))
            {
                // Ve benim C# 6.0 ile gelen en beğendiğim özellik: string interpolation :)
                WriteLine(
                    $"SiparisTarihi: {item.SiparisTarihi.ToString("dd-MM-yyyy")} SiparisAdet:{item.SiparisAdedi} SiparisTutari: {item.SiparisTutari}");
            }

            ReadKey();
        }
    }
}
