using System;
using System.IO;

namespace HB5Tool
{
	/// <summary>
	/// Data shared between Batters and Pitchers.
	/// </summary>
	public class PlayerCommonData
	{
		/// <summary>
		/// Maximum player name length.
		/// </summary>
		public static readonly int PLAYER_NAME_LENGTH = 16;

		#region Shared Data Structures
		/// <summary>
		/// Possible streak types.
		/// </summary>
		public enum StreakTypes
		{
			/// <summary>
			/// Even throughout the season.
			/// </summary>
			Even = 0,

			/// <summary>
			/// Hot at the start, cools through end.
			/// </summary>
			HotStart_CoolEnd = 1,

			/// <summary>
			/// Hot at the start and end, cool in the middle.
			/// </summary>
			HotStartEnd_CoolMiddle = 2,

			/// <summary>
			/// Cool at the start and end, hot in the middle.
			/// </summary>
			CoolStartEnd_HotMiddle = 3,

			/// <summary>
			/// Cool at the start, hot at the end.
			/// </summary>
			CoolStart_HotEnd = 4
		};

		/// <summary>
		/// Skin colors
		/// </summary>
		public enum SkinColors
		{
			Light = 0,
			Dark
		}

		/// <summary>
		/// Player Handedness
		/// </summary>
		public enum HandTypes
		{
			Left = 0,
			Right,
			Switch // only valid for batters
		}
		#endregion

		#region Class Members
		/// <summary>
		/// Picture index
		/// </summary>
		/// Most significant byte has some non-standard values:
		/// 0x4000: "no picture, picture option disabled"
		/// 0x8000: "has a picture, but is not used"
		/// "real" pictures start at index 0x0014
		public ushort PictureIndex;

		/// <summary>
		/// Name call
		/// </summary>
		/// offset 4
		public ushort NameCall;

		/// <summary>
		/// Jersey number, 0-99.
		/// </summary>
		public byte JerseyNum;

		/// <summary>
		/// Player name (max 16? characters)
		/// </summary>
		public string Name;

		/// <summary>
		/// Player's age, nominally between 20-55.
		/// </summary>
		public byte Age;

		/// <summary>
		/// Player experience, 0-45.
		/// </summary>
		public byte Experience;

		/// <summary>
		/// Running speed, 1-99.
		/// </summary>
		public byte RunSpeed;

		/// <summary>
		/// Fielding ability at primary position, 0-99.
		/// </summary>
		public byte FieldingAbility;

		/// <summary>
		/// How well a player performs in close and/or late games, 0-99.
		/// </summary>
		public byte CloseLate;

		/// <summary>
		/// Runners in scoring position, 0-99.
		/// </summary>
		public byte ScoringPosition;

		/// <summary>
		/// Combined position and skin color value.
		/// </summary>
		/// 76543210
		/// |__|||||
		///  |  |||+-- Skin Color (0=Light, 1=Dark)
		///  |  ||+--- ???
		///  |  |+---- ???
		///  |  +----- ???
		///  +-------- Position
		public byte Position_SkinColor;

		/// <summary>
		/// Player hand values.
		/// Mask with 0xF0 for throwing.
		/// Mask with 0x0F for batting.
		/// 76543210
		/// |__||__|
		///   |   |
		///   |   +--- Batting (0=Right, 1=Left, 2=Switch)
		///   +------- Throwing (0=Right, 1=Left)
		/// </summary>
		public byte Handedness;

		/// <summary>
		/// Streak value, 0-4.
		/// </summary>
		public StreakTypes Streak;

		/// <summary>
		/// Unknown byte at offset 0x21.
		/// </summary>
		public byte Unknown3;

		/// <summary>
		/// Hacky split-use variable.
		/// Offset 0x1D of player export data differs depending on batter/pitcher.
		/// Batters = Home/Away; Pitchers = vs. LHB
		/// </summary>
		public byte SplitUse;

		/// <summary>
		/// Home/Away performance, 0-99.
		/// </summary>
		public byte HomeAway;

		/// <summary>
		/// Performance vs. left-handed players, 0-99.
		/// For batters, "vs. LHP". For pitchers, "vs. LHB".
		/// </summary>
		public byte VersusLefties;
		#endregion

		#region Constructors
		/// <summary>
		/// Default constructor.
		/// </summary>
		public PlayerCommonData()
		{
			PictureIndex = 0;
			NameCall = 0;
			JerseyNum = 0;
			Name = String.Empty;
			Age = 20;
			Experience = 0;
			RunSpeed = 50;
			FieldingAbility = 50;
			CloseLate = 50;
			ScoringPosition = 50;
			Position_SkinColor = ((byte)(BatterData.FieldingPositions.Catcher) << 4) | (byte)SkinColors.Light;
			Handedness = (byte)HandTypes.Left;
			Streak = StreakTypes.Even;
			Unknown3 = 0;
			SplitUse = 0;
			HomeAway = 50;
			VersusLefties = 50;
		}

		/// <summary>
		/// Constructor using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public PlayerCommonData(BinaryReader br)
		{
			ReadData(br);
		}
		#endregion

		#region Helpers
		public byte GetHand_Throw()
		{
			// should return a value that's 0 or 1
			return (byte)((Handedness & 0xF0) >> 4);
		}

		public byte GetHand_Bat()
		{
			// should return a value between 0-2
			return (byte)(Handedness & 0x0F);
		}

		public byte GetSkinColor()
		{
			return (byte)(Position_SkinColor & 0x01);
		}

		public byte GetPosition()
		{
			// todo: return a FieldingPositions value?
			return (byte)((Position_SkinColor & 0xF0) >> 4);
		}
		#endregion

		/// <summary>
		/// Read data using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public void ReadData(BinaryReader br)
		{
			byte[] tmp = br.ReadBytes(2);
			if (!BitConverter.IsLittleEndian)
			{
				Array.Reverse(tmp);
			}
			PictureIndex = BitConverter.ToUInt16(tmp, 0);

			tmp = br.ReadBytes(2);
			if (!BitConverter.IsLittleEndian)
			{
				Array.Reverse(tmp);
			}
			NameCall = BitConverter.ToUInt16(tmp, 0);

			bool nameFinished = false;
			for (int i = 0; i < PLAYER_NAME_LENGTH; i++)
			{
				char c = (char)br.ReadByte();

				if (c == 0 && !nameFinished)
				{
					nameFinished = true;
				}

				if (c != 0 && !nameFinished)
				{
					Name += c;
				}
			}

			JerseyNum = br.ReadByte();
			Age = br.ReadByte();
			Experience = br.ReadByte();
			RunSpeed = br.ReadByte();
			FieldingAbility = br.ReadByte();
			CloseLate = br.ReadByte();
			ScoringPosition = br.ReadByte();
			SplitUse = br.ReadByte();
			Position_SkinColor = br.ReadByte();
			Handedness = br.ReadByte();
			Streak = (StreakTypes)br.ReadByte();

			// offset 0x21: ???? 0x00 for most players
			Unknown3 = br.ReadByte();

			// it is up to the caller to place SplitUse in the correct location after calling this routine.
		}
	}
}
