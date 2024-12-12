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

		public LeagueTeam()
		{
			CommonData = new TeamCommonData();
		}

		public void ReadData(BinaryReader br)
		{
			CommonData = new TeamCommonData(br);
		}
	}
}
