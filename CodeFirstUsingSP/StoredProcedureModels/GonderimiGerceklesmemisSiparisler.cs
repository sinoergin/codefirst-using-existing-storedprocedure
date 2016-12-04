using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstUsingSP.StoredProcedureModels
{
    public class GonderimiGerceklesmemisSiparisler
    {
        public string FirmaAdi { get; set; }
        public int? SiparisAdedi { get; set; }
        public DateTime SiparisTarihi { get; set; }
        public decimal? SiparisTutari { get; set; }
        public int? SiparisVerilenUrunAdedi { get; set; }      
    }
}
