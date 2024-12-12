using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace HB5Tool
{
	/// <summary>
	/// Team data.
	/// </summary>
	public class TeamCommonData
	{
		#region Constants
		/// <summary>
		/// Maximum team name length, not including null terminator.
		/// </summary>
		public static readonly int TEAM_NAME_LENGTH = 20;

		/// <summary>
		/// Maximum owner name length, not including null terminator.
		/// </summary>
		public static readonly int OWNER_NAME_LENGTH = 15;

		/// <summary>
		/// Maximum summary text length.
		/// </summary>
		public static readonly int SUMMARY_LENGTH = 160; // including null terminator

		/// <summary>
		/// Number of slots for batting order storage.
		/// </summary>
		public static readonly int BATTING_ORDER_LENGTH = 9;

		/// <summary>
		/// Number of slots for fielding position storage.
		/// </summary>
		public static readonly int FIELDING_POSITION_LENGTH = 10;

		/// <summary>
		/// Maximum allowed amount of starting pitchers.
		/// </summary>
		public static readonly int MAX_STARTING_PITCHERS = 6;

		/// <summary>
		/// Maximum amount of roster data.
		/// </summary>
		public static readonly int ROSTER_DATA_LENGTH = 40 * 2;
		#endregion

		#region Class Members
		// Any mention of "offset"s in the Class Members region is related to .HB5 team exports.

		/// <summary>
		/// Team name.
		/// </summary>
		/// offset 0
		public string Name;

		/// <summary>
		/// Team owner's name.
		/// </summary>
		/// offset 0x18; active if first character is not null/0x00
		public string Owner;

		/// <summary>
		/// Cap/hat color.
		/// </summary>
		/// offset 0x28
		public byte CapColor;

		/// <summary>
		/// Trim color.
		/// </summary>
		/// offset 0x29
		public byte TrimColor;

		/// <summary>
		/// Batting order vs. right-handed pitchers. 9 values long.
		/// </summary>
		/// offsets 0x2A-0x32 inclusive
		public byte[] BattingOrder_RHP;

		/// <summary>
		/// Batting order vs. left-handed pitchers. 9 values long.
		/// </summary>
		/// offset 0x33-0x3B inclusive
		public byte[] BattingOrder_LHP;

		/// <summary>
		/// Fielding positions vs. right-handed pitchers. 10 values long.
		/// </summary>
		/// starts at offset 0x3C
		public byte[] FieldingPositions_RHP;

		/// <summary>
		/// Fielding positions vs. left-handed pitchers. 10 values long.
		/// </summary>
		/// starts at offset 0x46
		public byte[] FieldingPositions_LHP;

		/// <summary>
		/// Unknown value. Some teams have 0x00 here, some have 0x01.
		/// </summary>
		/// offset 0x50
		public byte Unknown_50;

		/// <summary>
		/// Home stadium (range unknown)
		/// </summary>
		/// offset 0x51
		public byte Stadium;

		/// <summary>
		/// Star player (range limited to team roster count)
		/// </summary>
		/// offset 0x52
		public byte StarPlayer;

		/// <summary>
		/// Number of starting pitchers.
		/// </summary>
		/// offset 0x53
		public byte NumStartingPitchers;

		/// <summary>
		/// List of starting pitchers. Maximum 6 bytes.
		/// </summary>
		/// starts at offset 0x54
		public byte[] StartingPitcherList;

		// todo: 0x5A-0x6B
		public byte[] Unknown_5A;

		/// <summary>
		/// Summary text.
		/// </summary>
		/// offset 0x6C, 160? characters including null terminator. stop parsing at first 0x00 byte
		public string Summary;

		/// <summary>
		/// Logo data
		/// </summary>
		/// offset 0x10C
		public TeamLogo Logo;

		/// <summary>
		/// Team "identity" for Al Michaels and	TEAMSDIG.BIN.
		/// </summary>
		/// offset 0x70C
		public byte TeamsDigIndex;

		// offset 0x70D unknown
		public byte Unknown_70D;

		// player type starts at 0x070E? 0x50 bytes maximum, each entry is 2 bytes
		// team export files: lower byte is always 0x00; upper byte determines batter (0x01) or pitcher (0x02)?
		// league files: each value is a player index
		public byte[] PlayerIdent;

		// todo: 0x75E-0x77B
		public byte[] Unknown_75E;

		// manager slider values, offset 0x77C
		// everything is stored in nibbles; setting the sliders from 1-7 results in hex 21 43 65 07
		public byte[] SliderValues;
		// offset 0x77C, mask 0x0F: slow hook/quick hook
		// offset 0x77C, mask 0xF0: don't steal/steal lots
		// offset 0x77D, mask 0x0F: hold runners/push runners
		// offset 0x77D, mask 0xF0: sacrifice/hit away
		// offset 0x77E, mask 0x0F: defense/offense
		// offset 0x77E, mask 0xF0: favor speed/favor power
		// offset 0x77F, mask 0x0F: rookies/veterans

		// player data is not handled here
		#endregion

		#region Constructors
		/// <summary>
		/// Default constructor.
		/// </summary>
		public TeamCommonData()
		{
			Name = String.Empty;
			Owner = String.Empty;
			CapColor = 0;
			TrimColor = 0;
			BattingOrder_RHP = null;
			BattingOrder_LHP = null;
			FieldingPositions_RHP = null;
			FieldingPositions_LHP = null;
			Unknown_50 = 0;
			Stadium = 0;
			StarPlayer = 0;
			NumStartingPitchers = 0;
			StartingPitcherList = null;
			Unknown_5A = null;
			Summary = String.Empty;
			Logo = null;
			TeamsDigIndex = 0;
			Unknown_70D = 0;
			PlayerIdent = null;
			Unknown_75E = null;
			SliderValues = null;
		}

		/// <summary>
		/// Constructor using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public TeamCommonData(BinaryReader br)
		{
			ReadData(br);
		}
		#endregion

		#region Manager Slider Helpers
		/// <summary>
		/// How fast to change pitchers.
		/// Low values  = "Slow Hook"
		/// High values = "Quick Hook"
		/// </summary>
		/// <returns></returns>
		public int GetManagerSlider_Hook()
		{
			return SliderValues[0] & 0x0F;
		}

		/// <summary>
		/// How often baserunners should attempt to steal.
		/// Low values  = "Don't Steal"
		/// High values = "Steal Lots
		/// </summary>
		/// <returns></returns>
		public int GetManagerSlider_Steal()
		{
			return (SliderValues[0] & 0xF0) >> 4;
		}

		/// <summary>
		/// 
		/// Low values  = "Hold Runners"
		/// High values = "Push Runners"
		/// </summary>
		/// <returns></returns>
		public int GetManagerSlider_Runners()
		{
			return SliderValues[1] & 0x0F;
		}

		/// <summary>
		/// 
		/// Low values  = "Sacrifice"
		/// High values = "Hit Away"
		/// </summary>
		/// <returns></returns>
		public int GetManagerSlider_Sacrifice()
		{
			return (SliderValues[1] & 0xF0) >> 4;
		}

		/// <summary>
		/// Balance between offense and defense.
		/// Low values  = "Defense"
		/// High values = "Offense"
		/// </summary>
		/// <returns></returns>
		public int GetManagerSlider_OffenseDefense()
		{
			return SliderValues[2] & 0x0F;
		}

		/// <summary>
		/// 
		/// Low values  = "Favor Speed"
		/// High values = "Favor Power"
		/// </summary>
		/// <returns></returns>
		public int GetManagerSlider_SpeedPower()
		{
			return (SliderValues[2] & 0xF0) >> 4;
		}

		/// <summary>
		/// 
		/// Low values  = "Rookies"
		/// High values = "Veterans"
		/// </summary>
		/// <returns></returns>
		public int GetManagerSlider_RookieVeteran()
		{
			return SliderValues[3] & 0x0F;
		}
		#endregion

		/// <summary>
		/// Read data using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public void ReadData(BinaryReader br)
		{
			// team name
			bool strFinished = false;
			for (int i = 0; i < TEAM_NAME_LENGTH; i++)
			{
				char c = (char)br.ReadByte();

				if (c == 0 && !strFinished)
				{
					strFinished = true;
				}

				if (c != 0 && !strFinished)
				{
					Name += c;
				}
			}

			// todo: this is usually 0x00 filled
			br.ReadBytes(4);

			// owner
			strFinished = false;
			for (int i = 0; i < OWNER_NAME_LENGTH; i++)
			{
				char c = (char)br.ReadByte();

				if (c == 0 && !strFinished)
				{
					strFinished = true;
				}

				if (c != 0 && !strFinished)
				{
					Owner += c;
				}
			}
			// owner string null terminator
			br.ReadByte();

			CapColor = br.ReadByte();
			TrimColor = br.ReadByte();
			BattingOrder_RHP = br.ReadBytes(TeamCommonData.BATTING_ORDER_LENGTH);
			BattingOrder_LHP = br.ReadBytes(TeamCommonData.BATTING_ORDER_LENGTH);
			FieldingPositions_RHP = br.ReadBytes(TeamCommonData.FIELDING_POSITION_LENGTH);
			FieldingPositions_LHP = br.ReadBytes(TeamCommonData.FIELDING_POSITION_LENGTH);
			Unknown_50 = br.ReadByte();
			Stadium = br.ReadByte();
			StarPlayer = br.ReadByte();

			// Note: Number of starting pitchers may be less than maximum.
			NumStartingPitchers = br.ReadByte();
			StartingPitcherList = br.ReadBytes(NumStartingPitchers);

			if (NumStartingPitchers < MAX_STARTING_PITCHERS)
			{
				// make up the difference; these values SHOULD be 0x00
				br.ReadBytes(MAX_STARTING_PITCHERS - NumStartingPitchers);
			}

			// todo: bytes that follow the list of starting pitchers
			// offsets 0x5A-0x6B
			Unknown_5A = br.ReadBytes(0x12);

			// summary
			strFinished = false;
			for (int i = 0; i < SUMMARY_LENGTH; i++)
			{
				char c = (char)br.ReadByte();

				if (c == 0 && !strFinished)
				{
					strFinished = true;
				}

				if (c != 0 && !strFinished)
				{
					Summary += c;
				}
			}

			Logo = new TeamLogo(br);
			TeamsDigIndex = br.ReadByte();
			Unknown_70D = br.ReadByte();

			// player type starting at offset 0x70E; 0x50 bytes maximum (40 players), each entry is 2 bytes
			// team export files: lower byte is always 0x00; upper byte determines batter (0x01) or pitcher (0x02)?
			// league files: each value is a player index
			PlayerIdent = br.ReadBytes(ROSTER_DATA_LENGTH);

			// 0x75E to 0x77B unknown
			Unknown_75E = br.ReadBytes(30);

			// sliders at 0x77C
			SliderValues = br.ReadBytes(4);
		}
	}
}
