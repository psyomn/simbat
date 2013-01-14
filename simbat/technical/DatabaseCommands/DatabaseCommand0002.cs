using System;

using simbat.datasource;

namespace simbat.technical.dbcommands
{
	/// <summary>
	/// Database command0002.
	/// 
	/// This specific command takes care of adding a few test entries into the 
	/// database
	/// </summary>
	public class DatabaseCommand0002 : simbat.technical.dbcommands.DatabaseCommand
	{
		public DatabaseCommand0002 () 
		{

		}

		#region implemented abstract members of simbat.technical.dbcommands.DatabaseCommand
		public override void run ()
		{
			long lastid = 0;

			lastid = EntityTDG.getMaxID("entities") + 1;
			EntityTDG.insert(lastid, "John Asleworth", 1, 1, 1, 0.12f, "HUMAN");
			++lastid;
			EntityTDG.insert(lastid, "Oobloth Gorg", 2,3,2,0.32f,"DEMON");
			++lastid;
		}
		#endregion

	}
}

