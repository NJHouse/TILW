using System;

namespace XAndPluginDemo
{
	public class DiCount : IDiCount
	{
		int count = 0;

		public int AddPerClick()
		{
			return ++count;
		}
	}
}

