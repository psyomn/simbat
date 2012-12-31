using System;
using System.Collections.Generic;
using System.Data;

/* User */
using simbat.datasource;

namespace simbat.technical
{

	/// <summary>
	/// Table manager. This performs updates to the schema.
	/// 
	/// You need to run this at the beginning of the application
	/// (Main.cs would be a good idea) 
	/// 
	/// Here is the idea:
	///  - Go to db, check out the table which stores version information of
	///    current table
	///  - Get a list of versions
	///  - Find the set difference between the executed schema revisions, and
	///    changes to be made
	///  - if set-difference.size > 0
	///    | perform schema alterations
	///    else if set-difference < 0 
	///    | error condition
	///    else
	///    | up to date
	///    end
	/// </summary>
	public class TableManager
	{
		#region Member Variables
		private static string TABLE_NAME = "schema_histories";

		private static string CREATE = 
			"CREATE TABLE IF NOT EXISTS" + TABLE_NAME + " ("
			+ "version_number long"
			+ "timestamp      long);";

		private static string INSERT = 
			"INSERT INTO " + TABLE_NAME 
			+ "(version_number,timestamp)"
			+ "VALUES (@given_version_number, @given_timestamp)";

		private static string TABLE_EXISTS = 
			"SELECT name FROM sqlite_master WHERE type='table' AND name='" 
			+ TABLE_NAME + "'; ";

		#endregion

		/// <summary>
		/// Keep this hidden.
		/// Initializes a new instance of the <see cref="simbat.technical.TableManager"/> class.
		/// </summary>
		protected TableManager ()
		{
		}

		/// <summary>
		/// Run this instance.
		/// </summary>
		public static void run()
		{
			if (databaseExists())
			{
				Console.WriteLine("[TABLEMANAGER] Database Exists!");
			}
			Console.WriteLine("[TABLEMANAGER] Completed successfully.");
		}

		/// <summary>
		/// Databases the exists.
		/// </summary>
		/// <returns>
		/// The exists.
		/// </returns>
		private static bool databaseExists()
		{
			IDataReader reader; 
			IDbCommand command; 
			bool found = false; 

			command = DbRegistry
				.Instance
				.Connection
				.CreateCommand();

			command.CommandText = TABLE_EXISTS;
			reader = command.ExecuteReader();

			while(reader.Read()){
				found = true; 
			}

			return found; 
		}

		#region SQL Stuff
		/// <summary>
		/// Gets the versions.
		/// </summary>
		/// <returns>
		/// The versions.
		/// </returns>
		private static List<long> GetVersions()
		{
			// TODO

			return null;
		}
		#endregion
	}

}
