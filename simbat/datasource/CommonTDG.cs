using System;
using System.Data;

namespace simbat.datasource
{
	/// <summary>
	/// Common TDG that has common methods that can be inherited
	/// if needed by other tdgs
	/// </summary>
	public class CommonTDG
	{
		private static String SELECT_MAXID = 
			"SELECT MAX(id) FROM ";

		protected CommonTDG ()
		{

		}

		/// <summary>
		/// Gets the max Id from a given table.
		/// </summary>
		/// <returns>
		/// The max ID.
		/// </returns>
		/// <param name='iTableName'>
		/// Table name to get max id from.
		/// </param>
		public static long getMaxID (String iTableName)
		{
			String genericQuery = 
				SELECT_MAXID + iTableName + "; ";
			IDbCommand command; 
			IDataReader reader; 
			long retId = -1; 

			command = DbRegistry.Instance.Connection.CreateCommand ();
			command.CommandText = SELECT_MAXID;
			reader = command.ExecuteReader ();

			while (reader.Read())
			{
				retId = reader.GetInt32(0);
			}

			return retId;
		}
	}
}

