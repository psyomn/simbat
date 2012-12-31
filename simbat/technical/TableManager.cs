using System;
using System.Collections.Generic;

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
			Console.WriteLine("[TABLEMANAGER] Completed successfully.");
		}

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
	}

}
