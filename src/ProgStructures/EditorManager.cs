using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HB5Tool
{
	/// <summary>
	/// Possible sources of various data used by editors.
	/// </summary>
	public enum EditorDataSources
	{
		/// <summary>
		/// Unset and/or invalid
		/// </summary>
		Invalid = -1,

		/// <summary>
		/// Player export file (.BTR/.PIT)
		/// </summary>
		PlayerExport = 0,

		/// <summary>
		/// Team export file (.HB5)
		/// </summary>
		TeamExport = 1,

		/// <summary>
		/// League file (.LGD)
		/// </summary>
		League = 2
	};

	// for players:
	// - data source
	//   if .BTR/.PIT: filename
	//   if .HB5: team player index
	//   if .LGD: global player index

	// for teams:
	// - data source
	//   if .HB5: filename
	//   if .LGD: team index

	/// <summary>
	/// Manager for various dialogs.
	/// </summary>
	public class EditorManager
	{
		

	}
}
