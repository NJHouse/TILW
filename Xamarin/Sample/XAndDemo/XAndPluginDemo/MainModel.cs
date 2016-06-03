using System;

namespace XAndPluginDemo
{
	public class MainModel
	{
		private IDiCount diRepo;

		public MainModel (IDiCount diParam)
		{
			this.diRepo = diParam;
		}

		public IDiCount DIRepo {
			get { return diRepo; }
		}
	}
}

