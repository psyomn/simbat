using System;

namespace simbat.domain
{
	/// <summary>
	/// Demon.
	/// </summary>
	public class Demon : Entity
	{
		public Demon (UInt32 iID, String iName, int iStrength, int iArmor, 
		              int iSpeed, float iDistortion) : 
					  base (iID,iName,iStrength,iArmor,iSpeed,iDistortion)
		{
		}
	}
}

