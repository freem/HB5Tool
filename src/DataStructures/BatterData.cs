using System;
using System.Collections.Generic;
using System.IO;

namespace HB5Tool
{
	/// <summary>
	/// Batter data, without any extra stuff like stats.
	/// </summary>
	/// target size 0x28 bytes
	public class BatterData
	{
		#region Batter-specific Types
		/// <summary>
		/// Possible fielding positions, meant for batters.
		/// As these appear in the upper half of a byte, you'll need to mask with 0xF0 and >> 4.
		/// </summary>
		public enum FieldingPositions
		{
			/// <summary>
			/// Pitcher. Wait, what?
			/// Not meant to be selected.
			/// For secondary fielding positions, this is shown as "-".
			/// </summary>
			/// This is not meant to be used, but if you force it, the player will indeed be a pitcher...
			/// with a batter's set of ratings. I have yet to try this in game, so it might break.
			Pitcher = 0,

			Catcher,
			FirstBase,
			SecondBase,
			Shortstop,
			ThirdBase,
			RightField,
			CenterField,
			LeftField,
			DesignatedHitter,
			UtilityInfielder,
			UtilityOutfielder,

			/// <summary>
			/// Pinch Hitter is included in the positions list, but does not appear
			/// to be used in-game?  I'm not sure. Shown as "PH" in game.
			/// </summary>
			PinchHitter,

			/// <summary>
			/// "Offspeed"; Technically not a valid value.
			/// Shown as "OF" in game. Possibly breaks the game in some fashion.
			/// </summary>
			OF,

			/// <summary>
			/// "Changeup"; Technically not a valid value.
			///  Shown as "CU" in game. Possibly breaks the game in some fashion.
			/// </summary>
			CU,

			/// <summary>
			/// "Fastball"; Technically not a valid value.
			///  Shown as "FA" in game. Possibly breaks the game in some fashion.
			/// </summary>
			FA
		}
		#endregion

		/// <summary>
		/// Data that's common to Batters and Pitchers.
		/// </summary>
		public PlayerCommonData CommonData;

		#region Batter-specific Members
		/// <summary>
		/// Secondary fielding position.
		/// </summary>
		public FieldingPositions SecondaryPosition;

		/// <summary>
		/// Fielding ability at secondary position, 0-99.
		/// </summary>
		public byte SecondaryFieldingAbility;

		/// <summary>
		/// Arm strength, 1-99.
		/// </summary>
		public byte Arm;

		/// <summary>
		/// Power hitting value, 0-99.
		/// </summary>
		public byte PowerHit;

		/// <summary>
		/// Contact hitting value, 0-99.
		/// </summary>
		public byte ContactHit;

		/// <summary>
		/// Groundout percentage, 0-99.
		/// </summary>
		public byte GroundoutPct;

		/// <summary>
		/// Pull percentage, 0-99.
		/// </summary>
		public byte PullPct;

		/// <summary>
		/// Offset 0x2A is unused by batters.
		/// This value is not stored in League data.
		/// </summary>
		public byte Batter_Unused2A;

		/// <summary>
		/// Offset 0x2B is unused by batters.
		/// This value is not stored in League data.
		/// </summary>
		public byte Batter_Unused2B;

		/// <summary>
		/// Offset 0x2C is unused by batters.
		/// This value is not stored in League data.
		/// </summary>
		public byte Batter_Unused2C;
		#endregion

		#region Constructors
		/// <summary>
		/// Default constructor.
		/// </summary>
		public BatterData()
		{
			CommonData = new PlayerCommonData();
			SecondaryPosition = FieldingPositions.Pitcher;
			SecondaryFieldingAbility = 50;
			Arm = 50;
			PowerHit = 50;
			ContactHit = 50;
			GroundoutPct = 50;
			PullPct = 50;
			Batter_Unused2A = 0;
			Batter_Unused2B = 0;
			Batter_Unused2C = 0;
		}

		/// <summary>
		/// Constructor using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public BatterData(BinaryReader br)
		{
			ReadData(br);
		}
		#endregion

		/// <summary>
		/// Read Batter data using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public void ReadData(BinaryReader br)
		{
			CommonData = new PlayerCommonData(br);
			// place CommonData.SplitUse in the right place
			CommonData.HomeAway = CommonData.SplitUse;

			// continue reading batter data from the equivalent of offset 0x22 in player export data
			ContactHit = br.ReadByte();
			PowerHit = br.ReadByte();
			Arm = br.ReadByte();
			SecondaryFieldingAbility = br.ReadByte();
			GroundoutPct = br.ReadByte();
			PullPct = br.ReadByte();

			// player export data offset 0x28: batters only: vs. LHP
			CommonData.VersusLefties = br.ReadByte();

			SecondaryPosition = (FieldingPositions)br.ReadByte();

			// The extra 6 bytes for .BTR export data (offsets 0x2A-0x2F) need to be handled elsewhere.
		}
	}
}
