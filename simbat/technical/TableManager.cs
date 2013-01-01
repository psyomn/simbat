using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

/* User */
using simbat.datasource;
using simbat.technical.dbcommands;

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
			"CREATE TABLE " + TABLE_NAME + " ("
			+ "version_number long,"
			+ "timestamp      long);";

		private static string INSERT = 
			@"INSERT INTO " + TABLE_NAME 
			+ "(version_number,timestamp)"
			+ "VALUES (@given_version_number, @given_timestamp);";

		private static string TABLE_EXISTS = 
			"SELECT name FROM sqlite_master WHERE type='table' AND name='" 
			+ TABLE_NAME + "'; ";

		private static string SELECT_ALL_VERSIONS =
			"SELECT version_number FROM " + TABLE_NAME + ";";

		private static Dictionary<long,DatabaseCommand> mVersions = null;

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
			List<long> processedVersions = null; 

			if (tableManagerExists())
			{
				Console.WriteLine("TableManager configurations exist!");
			}
			else
			{
				createTableManager();
				Console.WriteLine("Created TableManager configuration table");
			}

			if (null == mVersions)
				setupVersionHash();

			processedVersions = GetVersions();
			processedVersions.Sort();

			foreach(var kv in mVersions)
			{
				if (!processedVersions.Contains(kv.Key))
				{
					kv.Value.run ();
					insertVersion(kv.Key);
				}
			}

			/* No longer need */
			mVersions.Clear();
			mVersions = null;

			Console.WriteLine("Completed successfully.");
		}

		#region Services 

		/// <summary>
		/// Setups the version hash.
		/// </summary>
		private static void setupVersionHash()
		{
			mVersions = new Dictionary<long,DatabaseCommand>(); 

			mVersions[1] = new DatabaseCommand0001();
		}

		/// <summary>
		/// Databases the exists.
		/// </summary>
		/// <returns>
		/// The exists.
		/// </returns>
		private static bool tableManagerExists()
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

		#endregion

		#region SQL Stuff
		/// <summary>
		/// Gets the versions.
		/// </summary>
		/// <returns>
		/// The versions.
		/// </returns>
		private static List<long> GetVersions()
		{
			IDataReader reader; 
			IDbCommand command; 
			List<long> versions = new List<long>(); 

			command = DbRegistry
				.Instance
				.Connection
				.CreateCommand();

			command.CommandText = SELECT_ALL_VERSIONS;

			reader = command.ExecuteReader();

			while(reader.Read())
			{
				versions.Add(reader.GetInt32(0));
			}

			return versions;
		}

		/// <summary>
		/// Creates the table manager.
		/// </summary>
		private static void createTableManager()
		{
			IDbCommand command; 

			command = DbRegistry
				.Instance
				.Connection
				.CreateCommand();

			command.CommandText = CREATE;
			command.ExecuteNonQuery();
		}

		/// <summary>
		/// Inserts the version.
		/// </summary>
		/// <param name='iVersion'>
		/// I version.
		/// </param>
		private static void insertVersion(long iVersion)
		{
			Console.WriteLine("TRY TO INSERT");
			IDbCommand command; 
			IDbDataParameter parameter; 

			command = DbRegistry
				.Instance
				.Connection
				.CreateCommand();

			command.CommandText = INSERT;
			command.Prepare();

			parameter =  command.CreateParameter(); 
			parameter.ParameterName = "@given_version_number"; 
			parameter.Value = iVersion;
			command.Parameters.Add (parameter);


			parameter = command.CreateParameter();
			parameter.ParameterName = "@given_timestamp"; 
			parameter.Value = (DateTime.UtcNow - new DateTime(1970,1,1,0,0,0)).TotalSeconds;
			command.Parameters.Add (parameter);

			command.ExecuteNonQuery();

		}
		#endregion
	}

}
