using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashIdentityProject.EntityLayer.Concrete
{
	public class CustomerAccount
	{
        public int CustomerAccountID { get; set; }
        public string CustomerAccountNumber { get; set; } //hesapnumarası
        public string CustomerAccountCurrency { get; set; } //döviz türü
        public decimal CustomerAccountBalance { get; set; } //bakiye
        public string BankBranch { get; set; } //şube
        public int AppUserID { get; set; }
        public AppUser AppUser { get; set; }


    }
}
