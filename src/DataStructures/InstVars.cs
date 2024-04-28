using System;
using System.IO;

namespace HB5Tool
{
	/// <summary>
	/// Representation of INSTVARS.BIN.
	/// </summary>
	public class InstVars
	{
		/// <summary>
		/// Maximum length of CDROM path string.
		/// </summary>
		public static readonly int INSTVARS_CDROM_PATH_MAX = 64;

		#region Class Members
		/// <summary>
		/// Installation type. (0=not installed, 1=minimal, 2=full)
		/// </summary>
		public short InstallType;

		/// <summary>
		/// Unknown value at file offset 2.
		/// </summary>
		public short Unknown2;

		/// <summary>
		/// Unknown value at file offset 4.
		/// </summary>
		public short Unknown4;

		/// <summary>
		/// Unknown value at file offset 6.
		/// </summary>
		public short Unknown6;

		/// <summary>
		/// Path to HB5CDROM.BIN.
		/// </summary>
		public string CdRomPath;
		#endregion

		#region Constructors
		/// <summary>
		/// Default constructor.
		/// </summary>
		public InstVars()
		{
			InstallType = 0;
			Unknown2 = 0;
			Unknown4 = 0;
			Unknown6 = 0;
			CdRomPath = string.Empty;
		}

		/// <summary>
		/// Constructor using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use</param>
		public InstVars(BinaryReader br)
		{
			ReadData(br);
		}
		#endregion

		/// <summary>
		/// Read data using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use</param>
		public void ReadData(BinaryReader br)
		{
			InstallType = BitConverter.ToInt16(br.ReadBytes(2), 0);
			Unknown2 = BitConverter.ToInt16(br.ReadBytes(2), 0);
			Unknown4 = BitConverter.ToInt16(br.ReadBytes(2), 0);
			Unknown6 = BitConverter.ToInt16(br.ReadBytes(2), 0);

			// handle cdrom path
			bool _nameDone = false;
			for (int i = 0; i < INSTVARS_CDROM_PATH_MAX; i++)
			{
				char c = br.ReadChar();

				if (c == 0 && !_nameDone)
				{
					_nameDone = true;
				}

				if (c != 0 && !_nameDone)
				{
					CdRomPath += c;
				}
			}
		}
	}
}
