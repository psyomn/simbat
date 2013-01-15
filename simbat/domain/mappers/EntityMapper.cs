using System;
using System.Data;
using System.Collections.Generic;

/* User */
using simbat.datasource;

namespace simbat.domain
{
	/// <summary>
	/// Entity mapper.
	/// </summary>
	public class EntityMapper
	{
		protected EntityMapper ()
		{
		}

		/// <summary>
		/// Finds all.
		/// </summary>
		/// <returns>
		/// The all.
		/// </returns>
		public static List<Entity> findAll()
		{
			Entity ent = null;
			List<Entity> entities = new List<Entity>();
			IDataReader reader = null; 
			String type;

			reader = EntityTDG.findAll();

			while(reader.Read())
			{
				type = reader.GetString(6);

				switch(type){
				case "HUMAN":
				ent = 
					new Human(
					 (UInt32)reader.GetInt32(0), reader.GetString(1),
	                 reader.GetInt32(2), reader.GetInt32(3),
	                 reader.GetInt32(4), reader.GetFloat(5));
					break;
				case "DEMON":
				ent = 
					new Demon(
					 (UInt32)reader.GetInt32(0), reader.GetString(1),
	                 reader.GetInt32(2), reader.GetInt32(3),
	                 reader.GetInt32(4), reader.GetFloat(5));
					break;
				}
				entities.Add(ent);
			}

			return entities;
		}

		/// <summary>
		/// Find the specified id.
		/// </summary>
		/// <param name='id'>
		/// Identifier.
		/// </param>
		public static Entity find(UInt32 id)
		{
			// TODO use enum to find out what type of entity we're loading
			//      since it can also be a demon, human, etc
			return null;
		}

		/// <summary>
		/// Update the specified t.
		/// </summary>
		/// <param name='t'>
		/// T.
		/// </param>
		public static int update(Entity t)
		{
			return 0;
		}

		/// <summary>
		/// Delete the specified t.
		/// </summary>
		/// <param name='t'>
		/// T.
		/// </param>
		public static int delete(Entity t)
		{
			return 0;
		}

		/// <summary>
		/// Insert the specified t.
		/// </summary>
		/// <param name='t'>
		/// T.
		/// </param>
		public static void insert(Entity t)
		{

		}

		public static UInt32 getMaxID()
		{
			return 0; // TODO
		}
	}
}

