using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HB5Tool
{
	public partial class DriverListViewer : Form
	{
		public DriverList Drivers;

		public DriverListViewer(string _filePath)
		{
			InitializeComponent();

			using (FileStream fs = new FileStream(_filePath, FileMode.Open))
			{
				using (BinaryReader br = new BinaryReader(fs))
				{
					Drivers = new DriverList(br);
				}
			}

			StringBuilder sb = new StringBuilder();

			sb.AppendLine(string.Format("Driver List Start Offset: 0x{0:X}", Drivers.DataStartOffset));
			sb.AppendLine(string.Format("Driver List Total Length: 0x{0:X}", Drivers.DataTotalLength));
			sb.AppendLine();

			foreach (DriverListEntry entry in Drivers.Entries)
			{
				sb.AppendLine(string.Format("ID 0x{0:X8} = {1}", entry.Identifier, entry.DisplayName));
			}

			tbDriverList.Text = sb.ToString();
		}
	}
}
