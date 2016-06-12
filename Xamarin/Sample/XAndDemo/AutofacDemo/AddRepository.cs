using System;
namespace AutofacDemo
{
	public class AddRepository : IAddRepository
	{
		int count = 0;

		public int AddCount()
		{
			return ++count;
		}
	}
}

