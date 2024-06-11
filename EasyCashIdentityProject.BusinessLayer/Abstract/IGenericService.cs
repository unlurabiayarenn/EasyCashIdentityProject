using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashIdentityProject.BusinessLayer.Abstract
{
	public interface IGenericService<T> where T : class
	{
		//Başların T ifadesi koyuldu çünkü buradaki ifadeler dataacccesdeki yapıdan ayrılsın
		void TInsert(T t);
		void TDelete(T t);
		void TUpdate(T t);
		T TGetByID(int id);
		List<T> TGetList();
	}
}
