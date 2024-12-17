using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

	/// <summary>
	/// Editor calling parameters.
	/// Used as keys into the various "current editor" Dictionaries.
	/// </summary>
	public struct EditorParams
	{
		/// <summary>
		/// Editor data source.
		/// </summary>
		public EditorDataSources Source;

		/// <summary>
		/// Filename if applicable, or String.Empty otherwise.
		/// </summary>
		public string Filename;

		/// <summary>
		/// Player/Team index if applicable, or -1 otherwise.
		/// </summary>
		public int index;

		/// <summary>
		/// Editor form associated with these params.
		/// </summary>
		public Form EditorForm;

		public EditorParams(EditorDataSources _src, string _file, int _idx, Form _form)
		{
			Source = _src;
			Filename = _file;
			index = _idx;
			EditorForm = _form;
		}
	}

	/// <summary>
	/// Batter representation for an editor.
	/// </summary>
	public struct EditorBatter
	{
		public BatterData Data;
		// todo: does not handle anything but historical stats at the moment
		public PlayerStats Stats;
	}

	/// <summary>
	/// Pitcher representation for an editor.
	/// </summary>
	public struct EditorPitcher
	{
		public PitcherData Data;
		// todo: does not handle anything but historical stats at the moment
		public PlayerStats Stats;
	}

	/// <summary>
	/// Team representation for an editor.
	/// </summary>
	public struct EditorTeam
	{
		public TeamCommonData Data;
		public List<EditorBatter> Batters;
		public List<EditorPitcher> Pitchers;
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
	public static class EditorManager
	{
		public static Dictionary<EditorParams, EditorBatter> Batters = new Dictionary<EditorParams, EditorBatter>();

		public static Dictionary<EditorParams, EditorPitcher> Pitchers = new Dictionary<EditorParams, EditorPitcher>();
	}
}
