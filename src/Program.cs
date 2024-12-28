using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HB5Tool
{
	static class Program
	{
		/// <summary>
		/// Default PICS.BIN instance, if enabled.
		/// </summary>
		public static PicsBin GlobalPicsBin;

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
		}
	}
}
