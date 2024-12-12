using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace HB5Tool
{
	// This class, in its current existence, is deprecated.
	// todo: rewrite this to work with the new split data formats

	/// <summary>
	/// Possible exported player types.
	/// </summary>
	public enum PlayerTypes
	{
		Invalid = 0,
		//HB4_Batter = 0x20,
		//HB4_Pitcher = 0x21,
		Batter = 0x40,
		Pitcher = 0x41
	}

	/// <summary>
	/// Represents a Hardball 5 baseball player from a .PIT or .BTR file.
	/// </summary>
	public class ExportPlayer
	{
		#region Class Members
		/// <summary>
		/// Batter or Pitcher.
		/// </summary>
		public PlayerTypes PlayerType;

		//public BatterData Batter;

		//public PitcherData Pitcher;

		// [Batter only] unused values at 0x2A-0x2C
		// [Batter and Pitcher] unused values at 0x2D-0x2F

		//public PlayerStats Stats;

		#region Shared between Batters and Pitchers
		/// <summary>
		/// Picture index
		/// </summary>
		/// Most significant byte has some non-standard values:
		/// 0x4000: "no picture, picture option disabled"
		/// 0x8000: "has a picture, but is not used"
		/// "real" pictures start at index 0x0014
		public short PictureIndex;

		/// <summary>
		/// Name call
		/// </summary>
		/// offset 4
		public short NameCall;

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
		/// </summary>
		public byte Handedness;

		/// <summary>
		/// Streak value, 0-4.
		/// </summary>
		public PlayerCommonData.StreakTypes Streak;

		/// <summary>
		/// Unknown byte at offset 0x21.
		/// </summary>
		public byte Unknown3;
		#endregion

		#region Batter/Pitcher values that are "shared", but in different locations
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

		#region Batter-only values
		/// <summary>
		/// Secondary fielding position.
		/// </summary>
		public BatterData.FieldingPositions SecondaryPosition;

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
		/// </summary>
		public byte Batter_Unused2A;

		/// <summary>
		/// Offset 0x2B is unused by batters.
		/// </summary>
		public byte Batter_Unused2B;

		/// <summary>
		/// Offset 0x2C is unused by batters.
		/// </summary>
		public byte Batter_Unused2C;
		#endregion

		#region Pitcher-only values
		/// <summary>
		/// Pitcher type.
		/// </summary>
		public PitcherData.PitcherTypes PitcherType;

		/// <summary>
		/// Pitcher stamina, 1-99.
		/// </summary>
		public byte Stamina;

		/// <summary>
		/// Pitch accuracy, 1-99.
		/// </summary>
		public byte Accuracy;

		#region Pitch Type values
		/// Note: Pitch values under 50 are not displayed in the in-game pitch list.

		/// <summary>
		/// Fastball value, 0-99 (>= 90 is "Fastball!")
		/// </summary>
		public byte Fastball;

		/// <summary>
		/// Curveball value, 0-99
		/// </summary>
		public byte Curveball;

		/// <summary>
		/// Change-up value, 0-99
		/// </summary>
		public byte ChangeUp;

		/// <summary>
		/// Slider value, 0-99
		/// </summary>
		public byte Slider;

		/// <summary>
		/// Sinker value, 0-99
		/// </summary>
		public byte Sinker;

		/// <summary>
		/// Knuckleball value, 0-99
		/// </summary>
		public byte Knuckleball;

		/// <summary>
		/// FROM THE UNDERGROUND, 0-99
		/// </summary>
		public byte Screwball;
		#endregion // pitch type

		#endregion // pitcher-only

		/// <summary>
		/// Unused value at offset 0x2D.
		/// </summary>
		public byte Unused2D;

		/// <summary>
		/// Unused value at offset 0x2E.
		/// </summary>
		public byte Unused2E;

		/// <summary>
		/// Unused value at offset 0x2F.
		/// </summary>
		public byte Unused2F;

		#region Statistics
		// temp statdump 0x166 bytes
		public byte[] StatDump;

		// offset 0x030: Batter/Pitcher "H G" (Games played)
		// offset 0x032: Batter/Pitcher "H AB" (At bats)
		// offset 0x034: Batter/Pitcher "H H" (Hits)
		// offset 0x038: ------|Pitcher "H GS" (Games Started)
		// offset 0x050: ------|Pitcher "H CG" (Complete Games)

		// offset 0x052: ------|Pitcher "H IP" (Innings Pitched)
		// (2 bytes, decimal) 0x01 = 0.1; 0x02 = 0.2; 0x03 = 1.0; 0x04 = 1.1, etc.

		// offset 0x06A: ------|Pitcher "H W" (Wins)
		// offset 0x074: Batter/Pitcher "H R"
		// offset 0x076: Batter|------- "H 1B" (Singles)
		// offset 0x080: ------|Pitcher "H L" (Losses)
		// offset 0x08C: Batter|------- "H 2B" (Doubles)
		// offset 0x096: ------|Pitcher "H Sv" (Saves)
		// offset 0x0A2: Batter|------- "H 3B" (Triples)
		// offset 0x0AC: ------|Pitcher "H BB"
		// offset 0x0B8: Batter|------- "H RBI" (Runs Batted In)
		// offset 0x0C4: ------|Pitcher "H SO"
		// offset 0x0D4: Batter|------- "H BB"
		// offset 0x0DA: ------|Pitcher "H OAB"
		// offset 0x0EC: Batter|------- "H SO"
		// offset 0x0F0: ------|Pitcher "H OH"
		// offset 0x102: Batter|------- "H SB" (Stolen Bases)
		// offset 0x104: Batter|------- "H CS" ((been) Caught Stealing (once, when I was 5))
		// offset 0x108: Batter|------- "H PO" (Put Outs)
		// offset 0x10A: Batter|------- "H A"
		// offset 0x10C: Batter|------- "H E"
		// offset 0x114: Batter|------- "H DP"
		// offset 0x166: ------|Pitcher "H Sho"
		// offset 0x170: ------|Pitcher "H ER" (Earned Runs)
		// offset 0x190: ------|Pitcher "H WP"
		#endregion

		#endregion

		#region Constructors
		/// <summary>
		/// Default constructor.
		/// </summary>
		public ExportPlayer()
		{
			// values here are arbitrary

			PlayerType = PlayerTypes.Invalid;
			PictureIndex = 0;
			NameCall = 0;
			JerseyNum = 0;
			Name = String.Empty;
			Age = 20;
			Experience = 0;
			RunSpeed = 50;
			FieldingAbility = 50;
			CloseLate = 50;
			Handedness = 0;
			Streak = 0;
			Unknown3 = 0;
			Unused2D = 0;
			Unused2E = 0;
			Unused2F = 0;

			#region Batter-only
			Arm = 50;
			PowerHit = 50;
			ContactHit = 50;
			GroundoutPct = 0;
			PullPct = 0;
			SecondaryFieldingAbility = 50;
			Batter_Unused2A = 0;
			Batter_Unused2B = 0;
			Batter_Unused2C = 0;
			#endregion

			#region Pitcher-only
			PitcherType = PitcherData.PitcherTypes.Invalid;
			Stamina = 1;
			Accuracy = 1;
			Fastball = 50;
			Curveball = 50;
			ChangeUp = 50;
			Slider = 20;
			Sinker = 20;
			Knuckleball = 20;
			Screwball = 20;
			#endregion

			StatDump = null;
		}

		/// <summary>
		/// Constructor using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public ExportPlayer(BinaryReader br)
		{
			ReadData(br);
		}

		public ExportPlayer(BinaryReader br, bool _header, bool _ignored, bool _stats)
		{
			ReadData(br, _header, _ignored, _stats);
		}
		#endregion

		#region Helpers
		public byte GetHand_Throw()
		{
			// should return a value that's 0 or 1
			return (byte)((Handedness & 0xF0)>>4);
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
			return (byte)((Position_SkinColor & 0xF0)>>4);
		}
		#endregion

		/// <summary>
		/// Read data from a player export file (.BTR/.PIT) using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public void ReadPlayerExportFile(BinaryReader br)
		{
			// offset 0 = type
			PlayerType = (PlayerTypes)br.ReadByte();

			// offset 1 must be 0x00, otherwise this won't work in-game
			// todo: actually check this value instead of ignoring it
			br.ReadByte();

			/*
			if (PlayerType == PlayerTypes.Batter)
			{
				Batter = new BatterData(br);
				Pitcher = null;
				// skip offsets 0x2A-0x2F
			}
			else if (PlayerType == PlayerTypes.Pitcher)
			{
				Pitcher = new PitcherData(br);
				Batter = null;
				// skip offsets 0x2D-0x2F
			}
			else
			{
				// neither a batter nor pitcher, so invalid
			}
			*/
		}

		/// <summary>
		/// Read exported player data with a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		/// <param name="parseHeader">Parse player export header. (Default: true)</param>
		/// <param name="readIgnored">Read bytes that are ignored by leauge data. (Default: true)</param>
		/// <param name="parseStats">Parse player statistics. (Default: true)</param>
		public void ReadData(BinaryReader br, bool parseHeader = true, bool readIgnored = true, bool parseStats = true)
		{
			if (parseHeader)
			{
				// offset 0 = type
				PlayerType = (PlayerTypes)br.ReadByte();

				// offset 1 must be 0x00, otherwise this won't work in-game
				// todo: actually check this value instead of ignoring it
				br.ReadByte();
			}

			// offset 2: picture/name ID
			// player data starts here in league files
			byte[] tmp = br.ReadBytes(2);
			if (!BitConverter.IsLittleEndian)
			{
				Array.Reverse(tmp);
			}
			PictureIndex = BitConverter.ToInt16(tmp, 0);

			// offsets 4: name call
			tmp = br.ReadBytes(2);
			if (!BitConverter.IsLittleEndian)
			{
				Array.Reverse(tmp);
			}
			NameCall = BitConverter.ToInt16(tmp, 0);

			// offset 6: start of player name (16 chars max)
			bool nameFinished = false;
			for (int i = 0; i < PlayerCommonData.PLAYER_NAME_LENGTH; i++)
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

			// offset 0x16: jersey number
			JerseyNum = br.ReadByte();

			// offset 0x17: age
			Age = br.ReadByte();

			// offset 0x18: experience
			Experience = br.ReadByte();

			// offset 0x19: speed
			RunSpeed = br.ReadByte();

			// offset 0x1A: primary fielding ability
			FieldingAbility = br.ReadByte();

			// offset 0x1B: close/late
			CloseLate = br.ReadByte();

			// offset 0x1C: runners in scoring position
			ScoringPosition = br.ReadByte();

			// offset 0x1D differs depending on batter/pitcher
			if (PlayerType == PlayerTypes.Batter)
			{
				// batters: home/away
				HomeAway = br.ReadByte();
			}
			else if (PlayerType == PlayerTypes.Pitcher)
			{
				// pitchers: vs. LHB
				VersusLefties = br.ReadByte();
			}

			// offset 0x1E: skin color (batter/pitcher; 0=L, 1=D) and position (batter only...)
			// 76543210
			// |__|||||
			//  |  |||+-- Skin Color (0=Light, 1=Dark)
			//  |  ||+--- ???
			//  |  |+---- ???
			//  |  +----- ???
			//  +-------- Position
			Position_SkinColor = br.ReadByte();

			// offset 0x1F: handedness
			// 76543210
			// |__||__|
			//   |   |
			//   |   +--- Bats (0=R, 1=L, 2=S)
			//   +------- Throws (0=R, 1=L)
			Handedness = br.ReadByte();

			// offset 0x20: streak
			Streak = (PlayerCommonData.StreakTypes)br.ReadByte();

			// offset 0x21: ???? 0x00 for most players
			Unknown3 = br.ReadByte();

			if (PlayerType == PlayerTypes.Batter)
			{
				// offset 0x22: batters only: contact
				ContactHit = br.ReadByte();

				// offset 0x23: batters only: power
				PowerHit = br.ReadByte();

				// offset 0x24: batters only: arm
				Arm = br.ReadByte();

				// offset 0x25: batters only: secondary fielding ability
				SecondaryFieldingAbility = br.ReadByte();

				// offset 0x26: batters only: ground %
				GroundoutPct = br.ReadByte();

				// offset 0x27: batters only: pull %
				PullPct = br.ReadByte();

				// offset 0x28: batters only?: vs. LHP
				VersusLefties = br.ReadByte();

				// offset 0x29: batters only: secondary fielding position
				SecondaryPosition = (BatterData.FieldingPositions)br.ReadByte();

				// 0x2A-0x2C ignored by batter; presumed to be 0x00
				// not stored in league player DB
				if (readIgnored)
				{
					Batter_Unused2A = br.ReadByte();
					Batter_Unused2B = br.ReadByte();
					Batter_Unused2C = br.ReadByte();
				}
			}
			else if (PlayerType == PlayerTypes.Pitcher)
			{
				// offset 0x22: pitchers only: stamina
				Stamina = br.ReadByte();

				// offset 0x23: pitchers only: accuracy
				Accuracy = br.ReadByte();

				// offset 0x24: pitchers only: fastball
				Fastball = br.ReadByte();

				// offset 0x25: pitchers only: curveball
				Curveball = br.ReadByte();

				// offset 0x26: pitchers only: changeup
				ChangeUp = br.ReadByte();

				// offset 0x27: pitchers only: slider
				Slider = br.ReadByte();

				// offset 0x28: pitchers only: sinker
				Sinker = br.ReadByte();

				// offset 0x29: pitchers only: knuckleball
				Knuckleball = br.ReadByte();

				// offset 0x2A: pitchers only: screwball
				Screwball = br.ReadByte();

				// offset 0x2B: pitchers only: home/away
				HomeAway = br.ReadByte();

				// offset 0x2C: pitchers only: pitcher type
				PitcherType = (PitcherData.PitcherTypes)br.ReadByte();

				// HACK: induce a read that's only required for league player databases
				if (!parseHeader && !parseStats)
				{
					Unused2D = br.ReadByte();
				}
			}

			// 0x2D-0x2F presumably unused, often set to 0x00
			// not stored in league player DB
			if (readIgnored)
			{
				Unused2D = br.ReadByte();
				Unused2E = br.ReadByte();
				Unused2F = br.ReadByte();
			}

			// player and team exports continue with statistics here
			// league files put stats elsewhere

			if (parseStats)
			{
				StatDump = new byte[PlayerStats.PLAYER_STATS_LENGTH];
				ReadStats(br);
			}
		}

		public void WriteData(BinaryWriter bw)
		{
			// what gets written depends on player type; some things are the same, though

			if (PlayerType == PlayerTypes.Batter)
			{
			}
			else if (PlayerType == PlayerTypes.Pitcher)
			{
			}
		}

		// Read/Write routines for Leagues, BAT*.BIN/BATH*.BIN, PIT*.BIN/PITH*.BIN

		public void ReadStats(BinaryReader br)
		{
			// temporary stat dump
			StatDump = br.ReadBytes(PlayerStats.PLAYER_STATS_LENGTH);
		}
	}
}
