using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace HB5Tool
{
	/// <summary>
	/// Player Stats type.
	/// This is a program-specific value, not used by the game.
	/// </summary>
	public enum PlayerStatsType
	{
		/// <summary>
		/// Historical (anything before the first played season)
		/// </summary>
		Historical = 0,

		/// <summary>
		/// Weekly stats.
		/// </summary>
		Week,

		/// <summary>
		/// Season statistics.
		/// </summary>
		Season,

		/// <summary>
		/// Lifetime statistics (culmination of all played seasons)
		/// </summary>
		Lifetime,

		/// <summary>
		/// Current game statistics.
		/// </summary>
		Game
	};

	/// <summary>
	/// Player statistics. 0x166 bytes in total.
	/// </summary>
	public class PlayerStats
	{
		/// <summary>
		/// Length of the Player Stats data structure.
		/// </summary>
		public static readonly int PLAYER_STATS_LENGTH = 0x166;

		/// <summary>
		/// Stats "type" associated with these values.
		/// </summary>
		public PlayerStatsType StatsType;

		// "playr" refers to .BTR/.PIT offsets
		// "stats" refers to the proper index
		// playr/stats bt/pi
		// --------------------------------------------
		// 0x030/0x000 [B/P] G   - Games Played
		// 0x032/0x002 [B/P] AB  - At Bats
		// 0x034/0x004 [B/P] H   - Hits
		// 0x036/0x006 ??
		// 0x038/0x008 [x/P] GS  - Games Started
		// 0x03A/0x00A ??
		// 0x03C/0x00C ??
		// 0x03E/0x00E ??
		// 0x040/0x010 ??
		// 0x042/0x012 ??
		// 0x044/0x014 ??
		// 0x046/0x016 ??
		// 0x048/0x018 ??
		// 0x04A/0x01A ??
		// 0x04C/0x01C ??
		// 0x04E/0x01E ??
		// 0x050/0x020 [x/P] CG  - Complete Games
		// 0x052/0x022 [x/P] IP  - Innings Pitched, decimal. 0x01 = 0.1; 0x02 = 0.2; 0x03 = 1.0; 0x04 = 1.1, etc.
		// 0x054/0x024 ??
		// 0x056/0x026 ??
		// 0x058/0x028 ??
		// 0x05A/0x02A ??
		// 0x05C/0x02C ??
		// 0x05E/0x02E ??
		// 0x060/0x030 ??
		// 0x062/0x032 ??
		// 0x064/0x034 ??
		// 0x066/0x036 ??
		// 0x068/0x038 ??
		// 0x06A/0x03A [x/P] W   - Wins
		// 0x074/0x... [B/P] R   - Runs
		// 0x076/0x... [B/x] 1B  - 
		// 0x080/0x... [x/P] L   - Losses
		// 0x08C/0x... [B/x] 2B  - 
		// 0x096/0x... [x/P] Sv  - Saves
		// 0x0AC/0x... [x/P] BB  - Base on Balls
		// 0x0C4/0x... [x/P] SO  - Strikeouts
		// 0x0D4/0x... [B/x] BB  - Base on Balls
		// 0x0EC/0x... [B/x] SO  - Strikeouts
		// 0x10A/0x... [B/P] A   - Assists
		// 0x10C/0x... [B/x] E   - Errors
		// 0x114/0x... [B/x] DP  - Double Plays
		// 0x166/0x... [x/P] Sho - Shutouts
		// 0x170/0x... [x/P] ER  - Earned Runs
		// 0x190/0x... [x/P] WP  - Wild Pitches

		// temporary implementation
		public byte[] StatsData;

		#region Constructors
		/// <summary>
		/// Default constructor.
		/// </summary>
		public PlayerStats()
		{
			StatsData = null;
			StatsType = PlayerStatsType.Historical;
		}

		/// <summary>
		/// Constructor using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public PlayerStats(BinaryReader br, PlayerStatsType _type = PlayerStatsType.Historical)
		{
			StatsType = _type;
			ReadData(br);
		}
		#endregion

		/// <summary>
		/// Read stats data using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public void ReadData(BinaryReader br)
		{
			// temporary implementation
			StatsData = br.ReadBytes(PLAYER_STATS_LENGTH);
		}
	}
}
