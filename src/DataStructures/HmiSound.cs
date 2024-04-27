using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace HB5Tool
{
	/// <summary>
	/// HMI Sound format handler.
	/// </summary>
	public class HmiSound
	{
		/// <summary>
		/// Sound format type. 0 = ADPCM, 1 = PCM?
		/// </summary>
		/// offset 0
		public int FormatType;

		/// <summary>
		/// Length of sound data, minus header.
		/// </summary>
		/// offset 4
		public int DataLength;

		/// <summary>
		/// Unknown value 1.
		/// </summary>
		/// offset 8
		public int Unknown1;

		/// <summary>
		/// Unknown value 2.
		/// </summary>
		/// offset 0xC
		public int Unknown2;

		/// <summary>
		/// Actual sound data.
		/// </summary>
		/// begins at offset 0x20
		public byte[] SoundData;

		/// <summary>
		/// Default constructor.
		/// </summary>
		public HmiSound()
		{
			FormatType = 0;
			DataLength = 0;
			Unknown1 = 0;
			Unknown2 = 0;
			SoundData = null;
		}

		/// <summary>
		/// Constructor using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public HmiSound(BinaryReader br)
		{
			ReadData(br);
		}

		/// <summary>
		/// Read HMI sound data using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public void ReadData(BinaryReader br)
		{
			FormatType = BitConverter.ToInt32(br.ReadBytes(4), 0);
			DataLength = BitConverter.ToInt32(br.ReadBytes(4), 0);
			Unknown1 = BitConverter.ToInt32(br.ReadBytes(4), 0);
			Unknown2 = BitConverter.ToInt32(br.ReadBytes(4), 0);

			// next up is "HMIADPCM" header text, padded with 0x00 bytes

			// skip to sound data
			br.BaseStream.Seek(0x20,SeekOrigin.Begin);
			SoundData = br.ReadBytes(DataLength);
		}
	}
}
