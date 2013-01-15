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
	public class EntityTDG : CommonTDG
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
			+ "(id,name,strength,armor,speed,distortion,type)"
			+ " VALUES (@given_id,@given_name,@given_strength,@given_armor," 
			+ " @given_speed,@given_distortion,@given_type);";

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
		public static void insert(long iID, String iName, int iStrength, int iArmor, 
		                          int iSpeed, float iDistortion, String iEntityType)
		{
			IDbCommand command;
			command = DbRegistry.Instance.Connection.CreateCommand();

			var idParameter         = command.CreateParameter();
			var nameParameter       = command.CreateParameter();
			var strengthParameter   = command.CreateParameter();
			var armorParameter      = command.CreateParameter();
			var speedParameter      = command.CreateParameter();
			var distortionParameter = command.CreateParameter();
			var entityTypeParameter = command.CreateParameter();

			/* Create parameters */
			idParameter.ParameterName = "@given_id"; 
			idParameter.Value = iID;

			nameParameter.ParameterName = "@given_name";
			nameParameter.Value = iName;

			strengthParameter.ParameterName = "@given_strength";
			strengthParameter.Value = iStrength;

			armorParameter.ParameterName = "@given_armor";
			armorParameter.Value = iArmor;

			speedParameter.ParameterName = "@given_speed";
			speedParameter.Value = iSpeed;

			distortionParameter.ParameterName = "@given_distortion";
			distortionParameter.Value = iDistortion;

			entityTypeParameter.ParameterName = "@given_type";
			entityTypeParameter.Value = iEntityType;

			/* Bind parameters to command */
			command.CommandText = INSERT;
			command.Parameters.Add (idParameter);
			command.Parameters.Add (nameParameter);
			command.Parameters.Add (strengthParameter);
			command.Parameters.Add (armorParameter);
			command.Parameters.Add (speedParameter);
			command.Parameters.Add (distortionParameter);
			command.Parameters.Add (entityTypeParameter);
			command.Prepare();

			command.ExecuteNonQuery();
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
		public static int update(long iID, String iName, int iStrength, int iArmor, 
		                         int iSpeed, float iDistortion, String iEntityType)
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

