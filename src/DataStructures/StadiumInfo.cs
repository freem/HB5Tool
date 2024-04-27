using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace HB5Tool
{
	public enum StadiumTypes
	{
		Outdoor = 0,
		Dome_Permanent = 1,
		Dome_Retractable = 2
	}

	public enum TurfTypes
	{
		Natural = 0,
		Artificial = 1
	}

	/// <summary>
	/// Stadium information (INFO%02d.BIN)
	/// </summary>
	public class StadiumInfo
	{
		// offset 0
		public byte Unknown1;

		// offset 1
		public StadiumTypes StadiumType;

		// offset 2
		public TurfTypes TurfType;

		// offset 3
		public byte Unknown2;

		// offset 4
		public short MaxAttendance;

		/// <summary>
		/// Stadium name.
		/// </summary>
		/// offset 0x12; max length unknown
		public string Name;

		/// <summary>
		/// 0x78 max length
		/// </summary>
		/// offset 0x3A
		public string Description;
	}
}
