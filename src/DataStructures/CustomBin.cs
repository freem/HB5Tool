using System.IO;

namespace HB5Tool
{
	/// <summary>
	/// Data found in CUSTOM.BIN, CUSTOM_D.BIN, CUSTOM.BIO.
	/// </summary>
	public class CustomBin
	{
		/// <summary>
		/// Maximum string length for custom items, including the null terminator.
		/// </summary>
		public static readonly int CUSTOM_STRING_LENGTH = 24;

		#region Class Members
		/// <summary>
		/// American league logo.
		/// </summary>
		public TeamLogo Logo_AL;

		/// <summary>
		/// National league logo.
		/// </summary>
		public TeamLogo Logo_NL;

		/// <summary>
		/// Legends league logo.
		/// </summary>
		public TeamLogo Logo_Legends;

		/// <summary>
		/// Immortals team logo.
		/// </summary>
		public TeamLogo Logo_Immortals;

		/// <summary>
		/// Name for the All-Star Game held at the middle of the season.
		/// </summary>
		public string StarsGame;

		/// <summary>
		/// Name for the overall Playoffs.
		/// </summary>
		public string Playoffs;

		/// <summary>
		/// Name for the league championship portion of the playoffs.
		/// </summary>
		public string LeagueChampionships;

		/// <summary>
		/// Name for the finals of the playoffs.
		/// </summary>
		public string WorldChampionships;

		/// <summary>
		/// Name for the American/first league.
		/// </summary>
		public string LeagueAmerican;

		/// <summary>
		/// Name for the National/second league.
		/// </summary>
		public string LeagueNational;

		/// <summary>
		/// Determines if injuries can occur.
		/// </summary>
		public bool Injuries;

		/// <summary>
		/// Determines if computer-controlled teams make trades on their own.
		/// </summary>
		public bool ComputerTrades;

		/// <summary>
		/// Determines if computer-controlled teams can reject trades.
		/// </summary>
		public bool ComputerCanRejectTrades;
		#endregion

		#region Constructors
		/// <summary>
		/// Default constructor.
		/// </summary>
		public CustomBin()
		{
			Logo_AL = null;
			Logo_NL = null;
			Logo_Legends = null;
			Logo_Immortals = null;
			StarsGame = string.Empty;
			Playoffs = string.Empty;
			LeagueChampionships = string.Empty;
			WorldChampionships = string.Empty;
			LeagueAmerican = string.Empty;
			LeagueNational = string.Empty;
			Injuries = false;
			ComputerTrades = false;
			ComputerCanRejectTrades = false;
		}

		/// <summary>
		/// Constructor using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public CustomBin(BinaryReader br)
		{
			ReadData(br);
		}
		#endregion

		/// <summary>
		/// Read CUSTOM.BIN data using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public void ReadData(BinaryReader br)
		{
			// logos
			Logo_AL = new TeamLogo(br);
			Logo_NL = new TeamLogo(br);
			Logo_Legends = new TeamLogo(br);
			Logo_Immortals = new TeamLogo(br);

			// strings
			bool _nameDone = false;
			for (int i = 0; i < CUSTOM_STRING_LENGTH; i++)
			{
				char c = br.ReadChar();

				if (c == 0 && !_nameDone)
				{
					_nameDone = true;
				}

				if (c != 0 && !_nameDone)
				{
					StarsGame += c;
				}
			}
			_nameDone = false;
			for (int i = 0; i < CUSTOM_STRING_LENGTH; i++)
			{
				char c = br.ReadChar();

				if (c == 0 && !_nameDone)
				{
					_nameDone = true;
				}

				if (c != 0 && !_nameDone)
				{
					Playoffs += c;
				}
			}
			_nameDone = false;
			for (int i = 0; i < CUSTOM_STRING_LENGTH; i++)
			{
				char c = br.ReadChar();

				if (c == 0 && !_nameDone)
				{
					_nameDone = true;
				}

				if (c != 0 && !_nameDone)
				{
					LeagueChampionships += c;
				}
			}
			_nameDone = false;
			for (int i = 0; i < CUSTOM_STRING_LENGTH; i++)
			{
				char c = br.ReadChar();

				if (c == 0 && !_nameDone)
				{
					_nameDone = true;
				}

				if (c != 0 && !_nameDone)
				{
					WorldChampionships += c;
				}
			}
			_nameDone = false;
			for (int i = 0; i < CUSTOM_STRING_LENGTH; i++)
			{
				char c = br.ReadChar();

				if (c == 0 && !_nameDone)
				{
					_nameDone = true;
				}

				if (c != 0 && !_nameDone)
				{
					LeagueAmerican += c;
				}
			}
			_nameDone = false;
			for (int i = 0; i < CUSTOM_STRING_LENGTH; i++)
			{
				char c = br.ReadChar();

				if (c == 0 && !_nameDone)
				{
					_nameDone = true;
				}

				if (c != 0 && !_nameDone)
				{
					LeagueNational += c;
				}
			}

			// boolean values
			byte options = br.ReadByte();
			Injuries = (options & 0x01) != 0;
			ComputerTrades = (options & 0x02) != 0;
			ComputerCanRejectTrades = (options & 0x04) != 0;
			// todo: ignores second byte
		}

		/// <summary>
		/// Write CUSTOM.BIN data using a BinaryWriter.
		/// </summary>
		/// <param name="bw">BinaryWriter instance to use.</param>
		public void WriteData(BinaryWriter bw)
		{
			// logos
			Logo_AL.WriteData(bw);
			Logo_NL.WriteData(bw);
			Logo_Legends.WriteData(bw);
			Logo_Immortals.WriteData(bw);

			// strings (don't forget the null terminator)
			for (int i = 0; i < StarsGame.Length; i++)
			{
				bw.Write((byte)StarsGame[i]);
			}
			for (int i = StarsGame.Length; i < CUSTOM_STRING_LENGTH; i++)
			{
				bw.Write((byte)0);
			}

			for (int i = 0; i < Playoffs.Length; i++)
			{
				bw.Write((byte)Playoffs[i]);
			}
			for (int i = Playoffs.Length; i < CUSTOM_STRING_LENGTH; i++)
			{
				bw.Write((byte)0);
			}

			for (int i = 0; i < LeagueChampionships.Length; i++)
			{
				bw.Write((byte)LeagueChampionships[i]);
			}
			for (int i = LeagueChampionships.Length; i < CUSTOM_STRING_LENGTH; i++)
			{
				bw.Write((byte)0);
			}

			for (int i = 0; i < WorldChampionships.Length; i++)
			{
				bw.Write((byte)WorldChampionships[i]);
			}
			for (int i = WorldChampionships.Length; i < CUSTOM_STRING_LENGTH; i++)
			{
				bw.Write((byte)0);
			}

			for (int i = 0; i < LeagueAmerican.Length; i++)
			{
				bw.Write((byte)LeagueAmerican[i]);
			}
			for (int i = LeagueAmerican.Length; i < CUSTOM_STRING_LENGTH; i++)
			{
				bw.Write((byte)0);
			}

			for (int i = 0; i < LeagueNational.Length; i++)
			{
				bw.Write((byte)LeagueNational[i]);
			}
			for (int i = LeagueNational.Length; i < CUSTOM_STRING_LENGTH; i++)
			{
				bw.Write((byte)0);
			}

			// boolean values (LSB contains values; MSB is 0xFF)
			byte options = 0xF8;
			if (Injuries)
			{
				options |= 1;
			}
			if (ComputerTrades)
			{
				options |= 2;
			}
			if (ComputerCanRejectTrades)
			{
				options |= 4;
			}
			bw.Write(options);
			bw.Write((byte)0xFF);
		}
	}
}
