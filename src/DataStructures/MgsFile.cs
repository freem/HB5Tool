using System;
using System.Collections.Generic;
using System.IO;

namespace HB5Tool
{
	/// <summary>
	/// MGS file. Some sort of scripting language?
	/// </summary>
	public class MgsFile
	{
		#region Class Members
		/// <summary>
		/// Number of entries in this MGS file.
		/// </summary>
		public short NumEntries;

		/// <summary>
		/// Table near the beginning of the MGS file.
		/// </summary>
		public List<short> Offsets;
		#endregion

		#region Constructors
		/// <summary>
		/// Default constructor.
		/// </summary>
		public MgsFile()
		{
			NumEntries = 0;
			Offsets = null;
		}

		/// <summary>
		/// Constructor using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public MgsFile(BinaryReader br)
		{
			ReadData(br);
		}
		#endregion

		/// <summary>
		/// Read MGS file data using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public void ReadData(BinaryReader br)
		{
			NumEntries = BitConverter.ToInt16(br.ReadBytes(2), 0);
			Offsets = new List<short>();

			byte[] tmp = br.ReadBytes(NumEntries*2);
			for (int i = 0; i < NumEntries; i++)
			{
				Offsets.Add(BitConverter.ToInt16(tmp,2*i));
			}
		}
	}
}
