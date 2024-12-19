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
		public int Index;

		public EditorParams(EditorDataSources _src, string _file, int _idx)
		{
			Source = _src;
			Filename = _file;
			Index = _idx;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public override int GetHashCode()
		{
			return (Source, Filename, Index).GetHashCode();
		}

		/// <summary>
		/// Equality check for EditorParams.
		/// </summary>
		/// <param name="obj">Something that can be cast to EditorParams!</param>
		/// <returns>True if the source, filename, and index match.</returns>
		public override bool Equals(object obj)
		{
			return obj is EditorParams other && (other.Source, other.Filename, other.Index).Equals((Source, Filename, Index));
		}
	}

	/// <summary>
	/// Manager for various editor dialogs.
	/// </summary>
	public static class EditorManager
	{
		/// <summary>
		/// Active Batter editors.
		/// </summary>
		public static Dictionary<EditorParams, Form> Batters = new Dictionary<EditorParams, Form>();

		/// <summary>
		/// Active Pitcher editors.
		/// </summary>
		public static Dictionary<EditorParams, Form> Pitchers = new Dictionary<EditorParams, Form>();

		/// <summary>
		/// Active Team editors.
		/// </summary>
		public static Dictionary<EditorParams, Form> Teams = new Dictionary<EditorParams, Form>();
	}
}
