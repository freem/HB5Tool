using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace HB5Tool
{
	/// <summary>
	/// Team data as you'd find in a league/.LGD file.
	/// </summary>
	public class LeagueTeam
	{
		/// <summary>
		/// Data that's common between League and Export Teams.
		/// </summary>
		public TeamCommonData CommonData;

		// player roster is stored as indices into the league's batter/pitcher roster

		// the players themselves are found elsewhere in the league file.

		#region Constructors
		/// <summary>
		/// Default constructor.
		/// </summary>
		public LeagueTeam()
		{
			CommonData = new TeamCommonData();
		}

		/// <summary>
		/// Constructor using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public LeagueTeam(BinaryReader br)
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
			CommonData = new TeamCommonData(br);
		}
	}
}
