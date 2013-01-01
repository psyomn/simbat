using System;

/* User */
using simbat.technical;
using simbat.domain;

namespace simbat
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Hello World!");
			TableManager.run();

			foreach (var e in EntityMapper.findAll())
			{
				Console.WriteLine(e);
			}
		}
	}
}
