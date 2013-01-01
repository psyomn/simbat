using System;
using System.Data;

/* User */
using simbat.datasource;

namespace simbat.datasource
{

	/// <summary>
	/// Entity TDG.
	/// 
	/// One thing I never liked TDGs the classic way was that they 
	/// pass a reader back to mappers. I might benchmark something
	/// later and see if passing back just tuples would be wiser.
	/// </summary>
	public class EntityTDG
	{
		#region SQL 
		private static string TABLE_NAME = 
			"entities";

		private static string SELECT_ALL = 
			"SELECT * FROM " + TABLE_NAME + "; ";

		private static string SELECT =
			"SELECT * FROM " + TABLE_NAME + " WHERE id=@given_id;";

		private static string INSERT = 
			"INSERT INTO " + TABLE_NAME
			+ "(name,strength,armor,speed,distortion,entity_type)"
			+ " VALUES (@given_name,@given_strength,@given_armor," 
			+ " @given_speed,@given_distortion,@given_entity_type);";

		private static string DELETE = 
			"DELETE FROM " + TABLE_NAME 
			+ " WHERE id=?";
		#endregion

		/// <summary>
		/// Keep this hidden.
		/// Initializes a new instance of the <see cref="simbat.datasource.EntityTDG"/> class.
		/// </summary>
		protected EntityTDG ()
		{
		}

		/// <summary>
		/// Insert the specified id, name, strength, armor, speed and distortion.
		/// </summary>
		/// <param name='id'>
		/// Identifier.
		/// </param>
		/// <param name='name'>
		/// Name.
		/// </param>
		/// <param name='strength'>
		/// Strength.
		/// </param>
		/// <param name='armor'>
		/// Armor.
		/// </param>
		/// <param name='speed'>
		/// Speed.
		/// </param>
		/// <param name='distortion'>
		/// Distortion.
		/// </param>
		public static void insert(long id, String name, 
		                          int strength, int armor, 
		                          int speed, float distortion)
		{
		}

		/// <summary>
		/// Delete the specified id.
		/// </summary>
		/// <param name='id'>
		/// Identifier.
		/// </param>
		public static int delete(UInt32 id)
		{
			int rowsAffected=0;
			return rowsAffected;
		}

		/// <summary>
		/// Update the specified iID, iName, iStrength, iArmor, iSpeed and iDistortion.
		/// </summary>
		/// <param name='iID'>
		/// I I.
		/// </param>
		/// <param name='iName'>
		/// I name.
		/// </param>
		/// <param name='iStrength'>
		/// I strength.
		/// </param>
		/// <param name='iArmor'>
		/// I armor.
		/// </param>
		/// <param name='iSpeed'>
		/// I speed.
		/// </param>
		/// <param name='iDistortion'>
		/// I distortion.
		/// </param>
		public static int update(long iID, String iName, 
		                         int iStrength, int iArmor, 
		                         int iSpeed, float iDistortion)
		{
			int rowsAffected = 0; 

			return rowsAffected;
		}

		/// <summary>
		/// Find the specified id.
		/// </summary>
		/// <param name='id'>
		/// Identifier.
		/// </param>
		public static IDataReader find(long iID)
		{
			IDbCommand command;
			var parameter = command.CreateParameter();

			parameter.ParameterName = "@given_id";
			parameter.Value = iID;

			command = 
				DbRegistry
				.Instance
				.Connection
				.CreateCommand();

			command.CommandText = SELECT;
			command.Parameters.Add (parameter);
			command.Prepare();

			return command.ExecuteReader();
		}

		/// <summary>
		/// Finds all.
		/// </summary>
		/// <returns>
		/// The all.
		/// </returns>
		public static IDataReader findAll()
		{
			IDbCommand command;

			command = 
				DbRegistry
				.Instance
				.Connection
				.CreateCommand();

			command.CommandText = SELECT_ALL;

			return command.ExecuteReader();
		}
	}

} /* End namespaces */

