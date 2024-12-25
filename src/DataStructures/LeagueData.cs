using System;
using System.Collections.Generic;
using System.IO;

namespace HB5Tool
{
	/// <summary>
	/// League types.
	/// </summary>
	public enum LeagueTypes
	{
		/// <summary>
		/// "Invalid" league type; actually falls back to MLBPA in game.
		/// </summary>
		Invalid = 0,

		/// <summary>
		/// MLBPA league, a.k.a. Major League Baseball with the team names and logos filed off.
		/// </summary>
		MLBPA = 1,

		/// <summary>
		/// Legends league.
		/// </summary>
		Legends = 2,
	}

	/// <summary>
	/// Data types found in a League file.
	/// </summary>
	public enum LeagueDataTypes
	{
		/// <summary>
		/// Invalid or None.
		/// </summary>
		Invalid = 0,

		/// <summary>
		/// League Information
		/// </summary>
		LeagueInfo = 1,

		/// <summary>
		/// Team Definitions
		/// </summary>
		TeamDefs = 2,

		/// <summary>
		/// Player Definitions
		/// </summary>
		PlayerDefs = 3,

		/// <summary>
		/// Used, but unknown season-related purpose.
		/// </summary>
		Unknown4 = 4,

		/// <summary>
		/// Schedule data.
		/// </summary>
		ScheduleData = 5,

		/// <summary>
		/// Used, but unknown season-related purpose.
		/// </summary>
		Unknown6 = 6,

		/// <summary>
		/// Historical player statistics
		/// </summary>
		Stats_Historical = 7,

		/// <summary>
		/// Season player statistics
		/// </summary>
		Stats_Season = 8,

		/// <summary>
		/// Weekly player statistics
		/// </summary>
		Stats_Weekly = 9,

		/// <summary>
		/// Lifetime player statistics
		/// </summary>
		Stats_Lifetime = 10,

		/// <summary>
		/// Used, but unknown data typically found before team defs.
		/// </summary>
		UnknownB = 11,

		/// <summary>
		/// Used, but unknown season-related purpose.
		/// </summary>
		UnknownC = 12
	};

	/// <summary>
	/// A single entry in the League file's data section list.
	/// </summary>
	public class LeagueDataEntry
	{
		#region Class Members
		/// <summary>
		/// Data type.
		/// </summary>
		public byte DataType;

		/// <summary>
		/// Unknown value 1, always 0x30 in known data
		/// </summary>
		public byte Unknown1;

		/// <summary>
		/// Unknown value 2, always 0x00 in known data
		/// </summary>
		public byte Unknown2;

		/// <summary>
		/// Unknown value 3, always 0x00 in known data
		/// </summary>
		public byte Unknown3;

		/// <summary>
		/// Offset where this data begins in the file.
		/// Needs to have LeagueData.LgInfoOffset added to it for the correct address.
		/// </summary>
		public UInt32 Offset;

		/// <summary>
		/// Length of the data.
		/// </summary>
		public UInt32 Length;
		#endregion

		#region Constructors
		/// <summary>
		/// Default Constructor.
		/// </summary>
		public LeagueDataEntry()
		{
			DataType = 0;
			Unknown1 = 0;
			Unknown2 = 0;
			Unknown3 = 0;
			Offset = 0;
			Length = 0;
		}

		/// <summary>
		/// Constructor using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public LeagueDataEntry(BinaryReader br)
		{
			ReadData(br);
		}
		#endregion

		/// <summary>
		/// Read a LeagueDataEntry using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public void ReadData(BinaryReader br)
		{
			DataType = br.ReadByte();
			Unknown1 = br.ReadByte();
			Unknown2 = br.ReadByte();
			Unknown3 = br.ReadByte();
			byte[] tmp = br.ReadBytes(4);
			Offset = BitConverter.ToUInt32(tmp,0);
			tmp = br.ReadBytes(4);
			Length = BitConverter.ToUInt32(tmp, 0);
		}
	}

	/// <summary>
	/// A Hardball 5 league. (*.LGD file)
	/// </summary>
	public class LeagueData
	{
		#region Constants
		/// <summary>
		/// Hardball 5 League data header.
		/// This header makes HB5 leagues distinct from HardBall 4 leagues, which use the same file extension.
		/// HardBall 6 also uses .LGD, but the format doesn't start with the same magic number.
		/// </summary>
		/// Presumably this is in BCD, giving us October 1995 as a date.
		public static readonly byte[] HB5_LEAGUE_HEADER = { 0x95, 0x19, 0x10, 0x00 };

		/// <summary>
		/// Number of available bytes for the league divisions.
		/// </summary>
		public static readonly int NUM_DIVISION_BYTES = 6;

		/// <summary>
		/// Maximum team count.
		/// Hardball 5 was made before the MLB expansion teams were added.
		/// </summary>
		public static readonly int MAX_TEAM_NUM = 28;

		/// <summary>
		/// Number of bytes a Batter uses in the player definition database.
		/// </summary>
		public static readonly int PLAYER_DB_LENGTH_BATTER = 0x28;

		/// <summary>
		/// Number of bytes a Pitcher uses in the player definition database.
		/// </summary>
		public static readonly int PLAYER_DB_LENGTH_PITCHER = 0x2C;
		#endregion

		#region Class Members
		/// <summary>
		/// Offset to League Information (corresponds to LGINFO*.BIN files)
		/// Technically used as the starting offset for the table following it.
		/// </summary>
		/// Is there a chance the first entry *isn't* league data?
		public UInt32 LgInfoOffset;

		/// <summary>
		/// List of data sections in this league file.
		/// </summary>
		public List<LeagueDataEntry> DataSections;

		// todo: some of this stuff should be in separate structures, based on how the league file is laid out.

		/// <summary>
		/// League type.
		/// </summary>
		/// offset 0xC8
		public LeagueTypes LeagueType;

		/// <summary>
		/// Controls how many teams are in each division.
		/// 6 values.
		/// </summary>
		/// offset 0xCA
		public byte[] DivisionTeams;

		/// <summary>
		/// Team ID list, 28 values maximum.
		/// However, not all may be used...
		/// </summary>
		/// offset 0xD0
		public byte[] TeamIDs;

		/// <summary>
		/// The number of teams actually defined.
		/// </summary>
		public int NumDefinedTeams;

		// offset 0xEC: ???
		// 0x07 for MLBPA, 0x01 for Legends
		// this could be the schedule type; check again with a started league
		public byte UnknownEC;

		// todo: last two values of league info

		#region Player Databases
		/// <summary>
		/// Total number of players in the league's player database.
		/// </summary>
		public short NumPlayers;

		/// <summary>
		/// Number of batters in the league's player database.
		/// </summary>
		public short NumBatters;

		// player data starts around offset 0xF0, but check the header to be sure
		// batters first, then pitchers
		// the first set of data corresponds to offsets 0x02-0x29 of the export batter (inclusive).

		/// <summary>
		/// Database of Batters in this league.
		/// </summary>
		public Dictionary<int, BatterData> BatterDatabase;

		/// <summary>
		/// Database of Pitchers in this league.
		/// </summary>
		public Dictionary<int, PitcherData> PitcherDatabase;
		#endregion

		/// <summary>
		/// Teams in this league.
		/// </summary>
		/// Each team's data is 0x780 bytes
		public List<TeamCommonData> Teams;

		// four sets of player statistics follow:
		// Historical, Season, Weekly, Lifetime
		// Actual size is (number of players * 0x166); all four stat sections have the same size.
		public List<PlayerStats> Stats_Historical;
		public List<PlayerStats> Stats_Season;
		public List<PlayerStats> Stats_Weekly;
		public List<PlayerStats> Stats_Lifetime;

		// then some stuff that only gets filled for currently active leagues

		public List<byte> ScheduleData;

		// values for currently unknown sections
		public List<byte> Unknown4Values;
		public List<byte> Unknown6Values;
		public List<byte> UnknownBValues;
		public List<byte> UnknownCValues;
		#endregion

		#region Constructors
		/// <summary>
		/// Default constructor.
		/// </summary>
		public LeagueData()
		{
			LgInfoOffset = 0;
			DataSections = null;
			LeagueType = LeagueTypes.MLBPA;
			NumDefinedTeams = 0;
			NumPlayers = 0;
			NumBatters = 0;
			DivisionTeams = new byte[NUM_DIVISION_BYTES];
			TeamIDs = new byte[MAX_TEAM_NUM];
			BatterDatabase = null;
			PitcherDatabase = null;
		}

		/// <summary>
		/// Constructor using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public LeagueData(BinaryReader br)
		{
			DivisionTeams = new byte[NUM_DIVISION_BYTES];
			TeamIDs = new byte[MAX_TEAM_NUM];
			ReadData(br);
		}
		#endregion

		/// <summary>
		/// Read League data using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public void ReadData(BinaryReader br)
		{
			// determine if this is a Hardball 5 league
			byte[] tmp = br.ReadBytes(4);
			if (tmp[0] == HB5_LEAGUE_HEADER[0] && tmp[1] == HB5_LEAGUE_HEADER[1]
				&& tmp[2] == HB5_LEAGUE_HEADER[2] && tmp[3] == HB5_LEAGUE_HEADER[3])
			{
				tmp = br.ReadBytes(4);
				LgInfoOffset = BitConverter.ToUInt32(tmp,0);

				DataSections = new List<LeagueDataEntry>();
				// read until reaching LgInfoOffset
				while (br.BaseStream.Position < LgInfoOffset)
				{
					LeagueDataEntry lde = new LeagueDataEntry(br);
					if (lde.DataType != 0)
					{
						DataSections.Add(lde);
					}
				}

				// actual league info (pointed to by LgInfoOffset)

				br.BaseStream.Seek(LgInfoOffset, SeekOrigin.Begin);
				LeagueType = (LeagueTypes)br.ReadByte();
				// todo: don't ignore next byte; needs to be 0x00 for valid league
				br.ReadByte();

				DivisionTeams = br.ReadBytes(NUM_DIVISION_BYTES);
				TeamIDs = br.ReadBytes(MAX_TEAM_NUM);

				for (int i = 0; i < TeamIDs.Length; i++)
				{
					if (TeamIDs[i] != 0)
					{
						++NumDefinedTeams;
					}
				}

				// player defs
				br.BaseStream.Seek(LgInfoOffset + DataSections[GetIndexOfType(LeagueDataTypes.PlayerDefs)].Offset, SeekOrigin.Begin);
				NumPlayers = BitConverter.ToInt16(br.ReadBytes(2),0);
				NumBatters = BitConverter.ToInt16(br.ReadBytes(2),0);

				// batters
				BatterDatabase = new Dictionary<int,BatterData>();
				for (int i = 1; i <= NumBatters; i++)
				{
					BatterData btr = new BatterData(br);
					BatterDatabase.Add(i, btr);
				}

				// pitchers
				PitcherDatabase = new Dictionary<int, PitcherData>();
				for (int i = 1; i <= NumPlayers-NumBatters; i++)
				{
					PitcherData pit = new PitcherData(br);
					PitcherDatabase.Add(i, pit);
				}

				// team data
				br.BaseStream.Seek(LgInfoOffset + DataSections[GetIndexOfType(LeagueDataTypes.TeamDefs)].Offset, SeekOrigin.Begin);
				Teams = new List<TeamCommonData>();
				for (int i = 0; i < NumDefinedTeams; i++)
				{
					Teams.Add(new TeamCommonData(br));
				}

				// all stats entries should be the same length. total length of a single section should be 0x166*num players

				// player historical stats
				br.BaseStream.Seek(LgInfoOffset + DataSections[GetIndexOfType(LeagueDataTypes.Stats_Historical)].Offset, SeekOrigin.Begin);
				Stats_Historical = new List<PlayerStats>();
				for (int i = 0; i < NumPlayers; i++)
				{
					Stats_Historical.Add(new PlayerStats(br));
				}

				// player season stats
				br.BaseStream.Seek(LgInfoOffset + DataSections[GetIndexOfType(LeagueDataTypes.Stats_Season)].Offset, SeekOrigin.Begin);
				Stats_Season = new List<PlayerStats>();
				for (int i = 0; i < NumPlayers; i++)
				{
					Stats_Season.Add(new PlayerStats(br, PlayerStatsType.Season));
				}

				// player weekly stats
				br.BaseStream.Seek(LgInfoOffset + DataSections[GetIndexOfType(LeagueDataTypes.Stats_Weekly)].Offset, SeekOrigin.Begin);
				Stats_Weekly = new List<PlayerStats>();
				for (int i = 0; i < NumPlayers; i++)
				{
					Stats_Weekly.Add(new PlayerStats(br, PlayerStatsType.Week));
				}

				// player lifetime stats
				br.BaseStream.Seek(LgInfoOffset + DataSections[GetIndexOfType(LeagueDataTypes.Stats_Lifetime)].Offset, SeekOrigin.Begin);
				Stats_Lifetime = new List<PlayerStats>();
				for (int i = 0; i < NumPlayers; i++)
				{
					Stats_Lifetime.Add(new PlayerStats(br, PlayerStatsType.Lifetime));
				}

				// schedule data
				ScheduleData = new List<byte>();
				br.BaseStream.Seek(LgInfoOffset + DataSections[GetIndexOfType(LeagueDataTypes.ScheduleData)].Offset, SeekOrigin.Begin);
				ScheduleData.AddRange(br.ReadBytes((int)DataSections[GetIndexOfType(LeagueDataTypes.ScheduleData)].Length));

				// other data
				Unknown4Values = new List<byte>();
				br.BaseStream.Seek(LgInfoOffset + DataSections[GetIndexOfType(LeagueDataTypes.Unknown4)].Offset, SeekOrigin.Begin);
				Unknown4Values.AddRange(br.ReadBytes((int)DataSections[GetIndexOfType(LeagueDataTypes.Unknown4)].Length));

				Unknown6Values = new List<byte>();
				br.BaseStream.Seek(LgInfoOffset + DataSections[GetIndexOfType(LeagueDataTypes.Unknown6)].Offset, SeekOrigin.Begin);
				Unknown6Values.AddRange(br.ReadBytes((int)DataSections[GetIndexOfType(LeagueDataTypes.Unknown6)].Length));

				UnknownBValues = new List<byte>();
				br.BaseStream.Seek(LgInfoOffset + DataSections[GetIndexOfType(LeagueDataTypes.UnknownB)].Offset, SeekOrigin.Begin);
				UnknownBValues.AddRange(br.ReadBytes((int)DataSections[GetIndexOfType(LeagueDataTypes.UnknownB)].Length));

				UnknownCValues = new List<byte>();
				br.BaseStream.Seek(LgInfoOffset + DataSections[GetIndexOfType(LeagueDataTypes.UnknownC)].Offset, SeekOrigin.Begin);
				UnknownCValues.AddRange(br.ReadBytes((int)DataSections[GetIndexOfType(LeagueDataTypes.UnknownC)].Length));
			}
		}

		public int GetIndexOfType(LeagueDataTypes _dt)
		{
			if (DataSections == null)
			{
				return -1;
			}

			for (int i = 0; i < DataSections.Count; i++)
			{
				if ((LeagueDataTypes)DataSections[i].DataType == _dt)
				{
					return i;
				}
			}

			return -1;
		}

		/// <summary>
		/// Returns a player type based on the ID passed in.
		/// </summary>
		/// <param name="_input">Player ID to check type of.</param>
		/// <returns>A PlayerTypes enum value based on the ID.</returns>
		public PlayerTypes GetPlayerTypeFromID(int _input)
		{
			if (_input > NumPlayers || _input < 0)
			{
				return PlayerTypes.Invalid;
			}

			if (_input > NumBatters)
			{
				return PlayerTypes.Pitcher;
			}
			else
			{
				return PlayerTypes.Batter;
			}
		}
	}
}
