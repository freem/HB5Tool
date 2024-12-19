using System;
using System.Collections.Generic;
using System.IO;

namespace HB5Tool
{
	/// <summary>
	/// Exported Hardball 5 team (*.hb5)
	/// </summary>
	public class ExportTeam
	{
		#region Class Members
		/// <summary>
		/// Data common to all team types.
		/// </summary>
		public TeamCommonData CommonData;

		// player data starts at offset 0x780
		// each player's data is 0x194 bytes
		//public List<ExportPlayer> PlayerData;
		#endregion

		#region Constructors
		/// <summary>
		/// Default constructor.
		/// </summary>
		public ExportTeam()
		{
			CommonData = new TeamCommonData();
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

		/// <summary>
		/// Read export team data using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public void ReadData(BinaryReader br)
		{
			CommonData = new TeamCommonData(br);

			// todo: player data
			/*
			for (int i = 0; i < CommonData.PlayerIdent.Length; i++)
			{
				ushort val = CommonData.PlayerIdent[i];
				if (val == 1)
				{
					Console.WriteLine(string.Format("Entry 0x{0:X2} = 0x{1:X4} (Batter)", i, CommonData.PlayerIdent[i]));
				}
				else if (val == 2)
				{
					Console.WriteLine(string.Format("Entry 0x{0:X2} = 0x{1:X4} (Pitcher)", i, CommonData.PlayerIdent[i]));
				}
				else
				{
					Console.WriteLine(string.Format("Entry 0x{0:X2} = 0x{1:X4}", i, CommonData.PlayerIdent[i]));
				}
			}
			*/
			
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
