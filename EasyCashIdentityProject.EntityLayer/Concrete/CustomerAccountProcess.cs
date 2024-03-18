using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashIdentityProject.EntityLayer.Concrete
{
	public class CustomerAccountProcess
	{
        public int CustomerAccountProcessID { get; set; }
        public string ProcessType { get; set; } //işlem türü
        public decimal Amount { get; set; } //miktar, ne kadar para gönderildi
        public DateTime ProcessDate { get; set; } //tarih


	}
}
