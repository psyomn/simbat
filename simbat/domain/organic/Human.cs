using System;

namespace simbat.domain
{
	/// <summary>
	/// Human.
	/// </summary>
	public class Human : Entity
	{
		public Human (UInt32 iID, String iName, int iStrength, int iArmor, 
		              int iSpeed, float iDistortion, STATE iState) : 
					  base (iID,iName,iStrength,iArmor,iSpeed,iDistortion,iState)
		{

		}
	}
}

