using System;
using System.Collections.Generic;
using System.IO;

namespace HB5Tool
{
	/// <summary>
	/// Pitcher data, without any extra stuff like stats.
	/// </summary>
	/// target size 0x2C bytes
	public class PitcherData
	{
		#region Pitcher-specific Types
		/// <summary>
		/// Possible pitcher types.
		/// </summary>
		public enum PitcherTypes
		{
			Starter = 0,
			Relief,
			Setup,
			Closer,
			// 0x0A and above cause crashes!
			Invalid = 0xFF // technically, anything after Closer is invalid
		}
		#endregion

		/// <summary>
		/// Data that's common to Pitchers and Batters.
		/// </summary>
		public PlayerCommonData CommonData;

		#region Pitcher-specific Members
		/// <summary>
		/// Pitcher type.
		/// </summary>
		public PitcherTypes PitcherType;

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

		#endregion

		#region Constructors
		/// <summary>
		/// Default constructor.
		/// </summary>
		public PitcherData()
		{
			CommonData = new PlayerCommonData();
			PitcherType = PitcherTypes.Starter;
			Stamina = 50;
			Accuracy = 50;
			Fastball = 50;
			Curveball = 50;
			ChangeUp = 50;
			Slider = 20;
			Sinker = 20;
			Knuckleball = 20;
			Screwball = 20;
		}

		/// <summary>
		/// Constructor using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public PitcherData(BinaryReader br)
		{
			ReadData(br);
		}
		#endregion

		/// <summary>
		/// Read Pitcher data using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public void ReadData(BinaryReader br)
		{
			CommonData = new PlayerCommonData(br);
			// place CommonData.SplitUse in the right place
			CommonData.VersusLefties = CommonData.SplitUse;

			// continue reading pitcher data from the equivalent of offset 0x22 in player export data
			Stamina = br.ReadByte();
			Accuracy = br.ReadByte();
			Fastball = br.ReadByte();
			Curveball = br.ReadByte();
			ChangeUp = br.ReadByte();
			Slider = br.ReadByte();
			Sinker = br.ReadByte();
			Knuckleball = br.ReadByte();
			Screwball = br.ReadByte();

			// player export data offset 0x2B: pitchers only: home/away
			CommonData.HomeAway = br.ReadByte();

			PitcherType = (PitcherTypes)br.ReadByte();

			// extra 3 bytes for player export data needs to be handled elsewhere.
		}
	}
}
