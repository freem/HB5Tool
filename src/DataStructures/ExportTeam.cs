using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace HB5Tool
{
	// todo: rewrite the bulk of this as a new class that doesn't assume we're loading .HB5 exports

	/// <summary>
	/// Exported Hardball 5 team (*.hb5)
	/// </summary>
	public class ExportTeam
	{
		// player data is 0x194 bytes?

		#region Class Members
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

		// 0x2A-0x32 inclusive: batting order vs. RHP (9x)
		public byte[] BattingOrder_RHP;

		// 0x33-0x3B inclusive: batting order vs. LHP (9x)
		public byte[] BattingOrder_LHP;

		// 0x3C start of fielding positions vs. RHP (10x)
		public byte[] FieldingPositions_RHP;

		// 0x46 start of fielding positions vs. LHP (10x)
		public byte[] FieldingPositions_LHP;

		// offset 0x50: ???
		// some teams have 0x00 here, some have 0x01.
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

		// 0x53: number of starting pitchers? maximum 6
		public byte NumStartingPitchers;

		// 0x54 start of starting pitchers list? maximum 6 bytes
		public byte[] StartingPitcherList;

		// todo: 0x5A-0x6B

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

		// offset 0x70C: team "identity" for al michaels/teamsdig
		// byte?

		// player type starts at 0x070E? 0x50 bytes maximum, each entry is 2 bytes
		// team export files: lower byte is always 0x00; upper byte determines batter (0x01) or pitcher (0x02)?
		// league files: each value is a player index

		// next offset is 0x75E

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

		// player data starts at offset 0x780
		//public List<ExportPlayer> PlayerData;

		#endregion

		#region Constructors
		/// <summary>
		/// Default constructor.
		/// </summary>
		public ExportTeam()
		{
			Name = string.Empty;
			Owner = string.Empty;
			CapColor = 0;
			TrimColor = 0;
			Unknown_50 = 0;
			Stadium = 0;
			StarPlayer = 0;
			Summary = string.Empty;
			StartingPitcherList = null;
			SliderValues = new byte[4];
		}

		/// <summary>
		/// Constructor using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public ExportTeam(BinaryReader br)
		{
			ReadData(br);
		}
		#endregion

		#region Manager Slider Helpers
		public int GetManagerSlider_Hook()
		{
			return SliderValues[0] & 0x0F;
		}

		public int GetManagerSlider_Steal()
		{
			return (SliderValues[0] & 0xF0) >> 4;
		}

		public int GetManagerSlider_Runners()
		{
			return SliderValues[1] & 0x0F;
		}

		public int GetManagerSlider_Sacrifice()
		{
			return (SliderValues[1] & 0xF0) >> 4;
		}

		public int GetManagerSlider_OffenseDefense()
		{
			return SliderValues[2] & 0x0F;
		}

		public int GetManagerSlider_SpeedPower()
		{
			return (SliderValues[2] & 0xF0) >> 4;
		}

		public int GetManagerSlider_RookieVeteran()
		{
			return SliderValues[3] & 0x0F;
		}
		#endregion

		/// <summary>
		/// Read export team data using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public void ReadData(BinaryReader br)
		{
			// this is only needed when loading a team from League data
			long TeamBasePos = br.BaseStream.Position;

			while (br.PeekChar() != 0)
			{
				Name += br.ReadChar();
			}

			br.BaseStream.Seek(TeamBasePos+0x18, SeekOrigin.Begin);

			while (br.PeekChar() != 0)
			{
				Owner += br.ReadChar();
			}

			// next known values are at offset 0x28 (cap and trim colors)
			br.BaseStream.Seek(TeamBasePos+0x28, SeekOrigin.Begin);
			CapColor = br.ReadByte();
			TrimColor = br.ReadByte();

			// batting order vs. RHP at 0x2A
			BattingOrder_RHP = br.ReadBytes(TeamCommonData.BATTING_ORDER_LENGTH);

			// batting order vs. LHP at 0x33
			BattingOrder_LHP = br.ReadBytes(TeamCommonData.BATTING_ORDER_LENGTH);

			// fielding positions vs. RHP at 0x3C
			FieldingPositions_RHP = br.ReadBytes(TeamCommonData.FIELDING_POSITION_LENGTH);
			// fielding positions vs. LHP at 0x46
			FieldingPositions_LHP = br.ReadBytes(TeamCommonData.FIELDING_POSITION_LENGTH);

			// whatever's at 0x50
			Unknown_50 = br.ReadByte();

			Stadium = br.ReadByte();
			StarPlayer = br.ReadByte();

			NumStartingPitchers = br.ReadByte();
			StartingPitcherList = br.ReadBytes(NumStartingPitchers);
			// todo: bytes that follow the list of starting pitchers
			// offsets 0x5A-0x6B

			// summary at offset 0x6C
			br.BaseStream.Seek(TeamBasePos+0x6C, SeekOrigin.Begin);
			while (br.PeekChar() != 0)
			{
				Summary += br.ReadChar();
			}
			// todo: account for any space left over from an early summary ending

			// logo at 0x10C
			br.BaseStream.Seek(TeamBasePos+0x10C, SeekOrigin.Begin);
			Logo = new TeamLogo(br);

			// data resumes at 0x70C
			// 0x70C is team name for Al Michaels's announcing

			// slider values at offset 0x77C
			br.BaseStream.Seek(TeamBasePos+0x77C, SeekOrigin.Begin);
			SliderValues = br.ReadBytes(4);

			// Team Export data continues; League Team data ends

			// player data starts at offset 0x780
			// each player is 0x194 bytes
			/*
			PlayerData = new List<ExportPlayer>();
			while (br.BaseStream.Position < br.BaseStream.Length)
			{
				PlayerData.Add(new ExportPlayer(br, false, true, true));
			}
			*/
		}

	}
}
