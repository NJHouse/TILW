using System;
namespace AutofacDemo
{
	public class MainModel
	{
		private IAddRepository addRepo;

		public MainModel(IAddRepository addParam)
		{
			this.addRepo = addParam;
		}

		public int AddCount()
		{
			return this.addRepo.AddCount();
		}
	}
}

