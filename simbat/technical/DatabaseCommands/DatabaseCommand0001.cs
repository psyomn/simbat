using System;
using System.Data;

/* User */
using simbat.datasource;

namespace simbat.technical.dbcommands
{
	/// <summary>
	/// Database command0001.
	/// 
	/// This creates the very first table structures.
	/// </summary>
	public class DatabaseCommand0001 : simbat.technical.dbcommands.DatabaseCommand
	{
		#region SQL 
		private static string CREATE = 
			"CREATE TABLE entities ("
		    + "id         long auto_increment,"
			+ "name       varchar(50),"
			+ "strength   int,"
			+ "armor      int,"
			+ "speed      int,"
			+ "distortion float," 
			+ "type       int," 
			+ "state      int"
			+ "); ";

		/// <summary>
		/// The identifier. Should match the class name.
		/// </summary>
		private static long mID = 1; 
		#endregion

		/// <summary>
		/// Initializes a new instance of the <see cref="simbat.technical.dbcommands.DatabaseCommand0001"/> class.
		/// </summary>
		public DatabaseCommand0001 ()
		{

		}		

		#region implemented abstract members of simbat.technical.dbcommands.DatabaseCommand
		public override void run ()
		{
			IDbCommand command;
			command = DbRegistry.Instance.Connection.CreateCommand();
			command.CommandText = CREATE;
			command.ExecuteNonQuery();
		}
		#endregion
	}

}
