using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace HB5Tool
{
	/// <summary>
	/// Schedule table entry.
	/// </summary>
	public class ScheduleTableEntry
	{
		#region Class Members
		/// <summary>
		/// Any flags this entry has.
		/// </summary>
		public byte Flags;

		/// <summary>
		/// Number of games during this period.
		/// </summary>
		public byte NumGames;

		/// <summary>
		/// Start date for this period.
		/// </summary>
		public byte StartDate;

		/// <summary>
		/// End date for this period.
		/// </summary>
		public byte EndDate;
		#endregion

		#region Constructors
		/// <summary>
		/// Default constructor.
		/// </summary>
		public ScheduleTableEntry()
		{
			Flags = 0;
			NumGames = 0;
			StartDate = 0;
			EndDate = 0;
		}

		/// <summary>
		/// Constructor using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public ScheduleTableEntry(BinaryReader br)
		{
			ReadData(br);
		}
		#endregion

		/// <summary>
		/// Read data using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public void ReadData(BinaryReader br)
		{
			Flags = br.ReadByte();
			NumGames = br.ReadByte();
			StartDate = br.ReadByte();
			EndDate = br.ReadByte();
		}
	}

	/// <summary>
	/// A single game on the schedule.
	/// </summary>
	public class ScheduleGame
	{
		#region Class Members
		/// <summary>
		/// Date of this game.
		/// </summary>
		public byte Date;

		/// <summary>
		/// Data that represents this game, somehow.
		/// </summary>
		public byte[] Data;
		#endregion

		#region Constructors
		/// <summary>
		/// Default constructor.
		/// </summary>
		public ScheduleGame()
		{
			Date = 0;
			Data = null;
		}

		/// <summary>
		/// Read data using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public ScheduleGame(BinaryReader br)
		{
			ReadData(br);
		}
		#endregion

		/// <summary>
		/// Constructor using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public void ReadData(BinaryReader br)
		{
			Date = br.ReadByte();
			Data = br.ReadBytes(2);
		}

		/// <summary>
		/// Return the first/visiting team ID.
		/// </summary>
		/// <returns>ID of visiting team/team 1</returns>
		public byte GetTeam1()
		{
			return (byte)(((Data[0] & 0xC0) >> 6) | ((Data[1] & 0x07) << 2));
		}

		/// <summary>
		/// Return the second/home team ID.
		/// </summary>
		/// <returns>ID of home team/team 2</returns>
		public byte GetTeam2()
		{
			return (byte)((Data[1] & 0xF8) >> 3);
		}
	}

	/// <summary>
	/// HardBall 5 schedule file (_SC*#.BIN)
	/// </summary>
	public class ScheduleFile
	{
		/// <summary>
		/// Which league type this schedule is for.
		/// Normally determined by filename.
		/// </summary>
		public enum ScheduleLeagueTypes
		{
			MLBPA = 0,  // _SCFILE*
			Legends = 1, // _SCOT*
			Invalid // anything that's not the above
		}

		/// <summary>
		/// Which league length this schedule is for.
		/// Normally determined by filename.
		/// </summary>
		public enum ScheduleLengthTypes
		{
			/// <summary>
			/// Full schedule (144 or 162 games, depending on version and/or patch)
			/// </summary>
			Full = 0,  // _SC*0

			/// <summary>
			/// Half schedule
			/// </summary>
			Half = 1,  // _SC*1

			/// <summary>
			/// Short schedule
			/// </summary>
			Short = 2  // _SC*2
		}

		#region Class Members
		/// <summary>
		/// League type for this schedule.
		/// Note: this is not a part of the file data.
		/// </summary>
		public ScheduleLeagueTypes ScheduleLeague;

		/// <summary>
		/// Length type for this schedule.
		/// Note: this is not a part of the file data.
		/// </summary>
		public ScheduleLengthTypes ScheduleLength;

		/// <summary>
		/// Most of the time this is 0x0000, but in HB5 v5.13 and later, this is 0x1997 (0x97, 0x19).
		/// It doesn't appear to do anything if you edit it.
		/// </summary>
		public short HeaderValue;

		/// <summary>
		/// Number of "active" entries in the table, always assuming the first is pre-season.
		/// The actual number of valid entries in the table is this value +1.
		/// </summary>
		public short NumEntries;

		/// <summary>
		/// Schedule table entries.
		/// </summary>
		public List<ScheduleTableEntry> Entries;

		/// <summary>
		/// freem, you're a nutter for structuring it like this
		/// Key int = week number
		/// </summary>
		public Dictionary<int, List<ScheduleGame>> Games;
		#endregion

		#region Constructors
		/// <summary>
		/// Default constructor.
		/// </summary>
		public ScheduleFile()
		{
			ScheduleLeague = ScheduleLeagueTypes.Invalid;
			ScheduleLength = ScheduleLengthTypes.Full;
			Entries = null;
			Games = null;
		}

		/// <summary>
		/// Constructor using a BinaryReader and specific league and length values.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		/// <param name="_league">League Type</param>
		/// <param name="_length">Season Length</param>
		public ScheduleFile(BinaryReader br, ScheduleLeagueTypes _league, ScheduleLengthTypes _length)
		{
			ScheduleLeague = _league;
			ScheduleLength = _length;
			ReadData(br);
		}
		#endregion

		/// <summary>
		/// Read data using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public void ReadData(BinaryReader br)
		{
			// most often 0x00,0x00, but HB5 v5.13 and later full season schedules use 0x97,0x19
			HeaderValue = BitConverter.ToInt16(br.ReadBytes(2),0);

			NumEntries = BitConverter.ToInt16(br.ReadBytes(2),0);

			Entries = new List<ScheduleTableEntry>();
			for (int i = 0; i < NumEntries+1; i++)
			{
				Entries.Add(new ScheduleTableEntry(br));
			}

			// skip forward
			// xxx: this is an assumption instead of reading other table entries
			br.BaseStream.Seek(0x90, SeekOrigin.Begin);

			Games = new Dictionary<int, List<ScheduleGame>>();
			int counter = 0;
			foreach (ScheduleTableEntry te in Entries)
			{
				// "valid" weeks have te.Flags between 0-5, and more than 0 games
				if (te.Flags < 6 && te.NumGames > 0)
				{
					List<ScheduleGame> gamelist = new List<ScheduleGame>();
					for (int i = 0; i < te.NumGames; i++)
					{
						gamelist.Add(new ScheduleGame(br));
					}
					Games.Add(counter++, gamelist);
				}
			}
		}
	}
}
