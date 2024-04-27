using System;
using System.Text;

namespace HB5Tool
{
	public static class SharedStrings
	{
		/// <summary>
		/// File filter for exported batters.
		/// </summary>
		public static readonly string BatterExportFilter = "Exported Batter (*.btr)|*.btr";

		/// <summary>
		/// File filter for exported pitchers.
		/// </summary>
		public static readonly string PitcherExportFilter = "Exported Pitcher (*.pit)|*.pit";

		/// <summary>
		/// File filter for all exported player files.
		/// </summary>
		public static readonly string PlayerExportFilter = "Exported Player (*.btr,*.pit)|*.btr;*.pit";

		/// <summary>
		/// File filter for exported teams.
		/// </summary>
		public static readonly string TeamExportFilter = "Exported Team (*.hb5)|*.hb5";

		/// <summary>
		/// File filter for league data.
		/// </summary>
		public static readonly string LeagueFilter = "League Data (*.lgd)|*.lgd";

		/// <summary>
		/// File filter for binary data.
		/// </summary>
		public static readonly string BinaryFilter = "Binary Data (*.bin)|*.bin";

		/// <summary>
		/// File filter for GlueMB, which includes HB5 for PS1 and HB4.
		/// </summary>
		public static readonly string GlueFilter = "Glue Files (*.glu)|*.glu";

		/// <summary>
		/// File filter for MGS files.
		/// </summary>
		public static readonly string MgsFilter = "MGS Files (*.mgs)|*.mgs";

		/// <summary>
		/// File filter for MSH files.
		/// </summary>
		public static readonly string MshFilter = "MSH Files (*.msh)|*.msh";

		/// <summary>
		/// File filter for Font files.
		/// </summary>
		public static readonly string FontFilter = "Font Files (*.fnt)|*.fnt";

		/// <summary>
		/// File filter for PNG files.
		/// </summary>
		public static readonly string PngFilter = "PNG Files (*.png)|*.png";

		/// <summary>
		/// File filter for exported team logos.
		/// </summary>
		public static readonly string LogoFilter = "Hardball 5 Team Logo Files (*.hb5logo)|*.hb5logo";

		/// <summary>
		/// Standard "all files" *.* mask
		/// </summary>
		public static readonly string AllFilter = "All Files (*.*)|*.*";

		/// <summary>
		/// All of the above Hardball 5-specific formats.
		/// </summary>
		public static readonly string HB5FilesFilter = "All HardBall 5 Formats (*.btr,*.pit,*.hb5,*.lgd,*.mgs,*.msh,*.fnt,*.bin)|*.btr;*.pit;*.hb5;*.lgd;*.mgs;*.msh;*.fnt;*.bin";

		/// <summary>
		/// Standard file filter.
		/// </summary>
		public static readonly string GeneralFilter = string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|{10}",
			HB5FilesFilter,
			BatterExportFilter,
			PitcherExportFilter,
			TeamExportFilter,
			LeagueFilter,
			BinaryFilter,
			GlueFilter,
			MgsFilter,
			MshFilter,
			FontFilter,
			AllFilter
		);
	}
}
