using System;
using System.Data;
using Mono.Data.Sqlite;

namespace simbat.datasource
{
	/// <summary>
	/// Db registry. Wrapper for the SQLite3 stuff.
	/// 
	/// Singleton pattern
	/// </summary>
	public class DbRegistry
	{
		#region Member Variables
		private static string     mDbPath = "URI=file:simbat.db";
		private static DbRegistry mInstance = null; 
		private static object     mLock = new object();
		private IDbConnection     mConnection;
		#endregion

		/// <summary>
		/// Initializes a new instance of the <see cref="simbat.DbRegistry"/> class.
		/// Keep this protected since this is a singleton.
		/// </summary>
		protected DbRegistry ()
		{
		}



		#region Mutators
		/// <summary>
		/// Gets the connection.
		/// </summary>
		/// <value>
		/// The connection to the database.
		/// </value>
		public IDbConnection Connection
		{
			get{
				return mConnection;
			}
		}

		/// <summary>
		/// Instance this instance.
		/// 
		/// I'm leaving these generated comments they're hilarious.
		/// </summary>
		public static DbRegistry Instance
		{
			get{
				/* First time init -
				 * Protection from multithreaded calls */
				lock(mLock){
					if(null == mInstance)
					{
						mInstance = new DbRegistry();
						mInstance.mConnection = (IDbConnection) 
							new SqliteConnection (mDbPath);
						
						mInstance.mConnection.Open();
					}
				}

				return mInstance;
			}
		}

		#endregion
	}

} /* End namespaces */

