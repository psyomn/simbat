using System;

namespace simbat.domain
{
	/// <summary>
	/// Entity. Try keeping the data stuff here so that we do the least
	/// work for mapping and TDGs. 
	/// 
	/// In other words, subclasses should really just focus on behavior.
	/// </summary>
	public class Entity
	{
		#region Member Variables
		protected UInt32 mID;
		protected int    mHealth;
		protected int    mStrength;
		protected int    mArmor; 
		protected int    mSpeed;
		protected float  mDistortion; 
		protected static Random mRand = new Random();
		protected String mName;
		public    enum   STATE {ALIVE, ANGERED, DEAD};
		protected STATE  mState;
		#endregion

		/// <summary>
		/// Default initializer
		/// Initializes a new instance of the <see cref="simbat.Entity"/> class.
		/// </summary>
		public Entity ()
		{
			mDistortion = (float) mRand.NextDouble() % 100;
			mHealth     = 10; 
			mStrength   = 1;
			mArmor      = 1; 
			mSpeed      = 1;
			mName       = "Default";
			mState      = STATE.ALIVE;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="simbat.Entity"/> class.
		/// </summary>
		/// <param name='iID'>
		/// I I.
		/// </param>
		/// <param name='iName'>
		/// I name.
		/// </param>
		/// <param name='iStrenght'>
		/// I strenght.
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
		public Entity(UInt32 iID, String iName, int iStrength, int iArmor, 
		              int iSpeed, float iDistortion)
		{
			mID         = iID; 
			mName       = iName;
			mStrength   = iStrength;
			mArmor      = iArmor;
			mSpeed      = iSpeed;
			mDistortion = iDistortion;
		}

		/// <summary>
		/// Attack from this instance.
		/// </summary>
		public int attack()
		{
			return
				mStrength 
				+ (mRand.Next() % 2 == 0 ? 1 : -1)
				* mStrength;
		}

		/// <summary>
		/// Receives the damage.
		/// </summary>
		/// <param name='iDamage'>
		/// I damage.
		/// </param>
		public void receiveDamage(int iDamage)
		{
			/// TODO finish this
		}

		#region Mutators
		public int Strength
		{
			get{
				return mStrength;
			}
			set{
				mStrength = value;
			}
		}

		/// <summary>
		/// Gets or sets the health. This is the total health of the entity.
		/// </summary>
		/// <value>
		/// The health.
		/// </value>
		public int Health
		{
			get{
				return mHealth;
			}
			set{
				mHealth = value;
			}
		}

		/// <summary>
		/// TODO
		/// Gets or sets the armor. The armor is the combination
		/// of the equipment worn + the actual entities resistance.
		/// </summary>
		/// <value>
		/// The armor.
		/// </value>
		public int Armor
		{
			get{
				return mArmor;
			}
			set{
				mArmor = value;
			}
		}

		/// <summary>
		/// Gets or sets the speed. Speed is used for turns.
		/// </summary>
		/// <value>
		/// The speed.
		/// </value>
		public int Speed
		{
			get{
				return mSpeed;
			}
			set{
				mSpeed = value;
			}
		}

		/// <summary>
		/// Gets or sets the name. A name is a common name (both first and 
		/// last name are combined to one field). 
		/// </summary>
		/// <value>
		/// The name.
		/// </value>
		public String Name
		{
			get{
				return mName;
			}
			set{
				mName = value;
			}
		}

		/// <summary>
		/// Gets or sets the state of the current entity. This is for states such
		/// as {Alive, Dead, Angered}.
		/// </summary>
		/// <value>
		/// The state.
		/// </value>
		public STATE State
		{
			get{
				return mState;
			}
			set{
				mState = value;
			}
		}

		public override string ToString ()
		{
			return string.Format 
				("[Entity: Strength={0}, Health={1}, Armor={2}, Speed={3}, Name={4}, Type={5}, State={6}, Distortion={7}]", 
                  Strength, Health, Armor, Speed, Name, this.GetType().Name, mState, mDistortion);
		}

		#endregion 
	}
}

