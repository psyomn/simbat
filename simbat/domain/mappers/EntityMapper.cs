using System;
using System.Collections.Generic;

namespace simbat
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
			return null;
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
	}
}

