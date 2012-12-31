using System;

/* User */
using simbat.datasource;

namespace simbat.technical.dbcommands
{
	/// <summary>
	/// Database command0001.
	/// 
	/// This creates the very first table structures.
	/// </summary>
	public class DatabaseCommand0001
	{
		private static string CREATE = 
			"CREATE TABLE entities IF NOT EXISTS ("
		    + "id         long,"
			+ "name       varchar(50),"
			+ "strength   int,"
			+ "armor      int,"
			+ "speed      int,"
			+ "distortion float"
			+ "); ";

		protected DatabaseCommand0001 ()
		{

		}

	}

}
