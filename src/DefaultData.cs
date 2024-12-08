using System;
using System.Drawing;
using System.Collections.Generic;

namespace HB5Tool
{
	/// <summary>
	/// Default data that can't normally be changed.
	/// Or rather, I can't change it until I figure out how to hack the game.
	/// </summary>
	public static class DefaultData
	{
		/// <summary>
		/// Stadium list.
		/// No, I'm not sure what the gap between Toronto and Baker Bowl is for.
		/// </summary>
		public static string[] StadiumList = new string[]
		{
			"Anaheim",
			"Atlanta",
			"Baltimore",
			"Boston",
			"Chicago (A)",
			"Chicago (N)",
			"Cincinnati",
			"Cleveland",
			"Colorado", // xxx: Colorado 95 in HB5 v5.13 and later
			"Detroit",
			"Florida",
			"Houston",
			"Kansas City",
			"Los Angeles",
			"Milwaukee",
			"Minnesota",
			"Montreal",
			"New York (A)",
			"New York (N)",
			"Oakland",
			"Philadelphia",
			"Pittsburgh",
			"San Diego",
			"San Francisco",
			"Seattle",
			"St. Louis",
			"Texas",
			"Toronto",

			// files don't seem to exist for these four choices:
			"Unknown 0x1C",
			"Unknown 0x1D",
			"Unknown 0x1E",
			"Unknown 0x1F",

			/// xxx: these don't exist in v5.13 and later
			/// (aside from Colorado 95 being moved to the main list)
			"Baker Bowl",
			"Braves Field",
			"Colorado 95",
			"Ebbets Field",
			"Forbes Field",
			"Griffith",
			"League Park",
			"1919 Boston",
			"1927 New York",
			"Polo Grounds",
			"Seals Stadium",
			"Shibe Park",
			"Sportsman's"
		};

		/// <summary>
		/// The game's "default" palette, modified so each palette index remains intact.
		/// </summary>
		/// Location in each version of the game:
		///---------+------------------------
		/// Version | .exe offset
		///---------+------------------------
		/// v5.11   | 0xEF949
		/// v5.12   | 0xEF955
		///---------+------------------------
		/// v5.13   | 0xEEA0D
		/// v5.14LP | 0xED7AD
		///---------+------------------------
		public static Color[] DefaultPalette = new Color[]
		{
			// row 1
			Color.FromArgb(255,0,0,0),
			Color.FromArgb(85,85,255),
			Color.FromArgb(255,85,85),
			Color.FromArgb(255,255,255),
			Color.FromArgb(255,255,85),
			Color.FromArgb(85,255,85),
			Color.FromArgb(255,85,255),
			Color.FromArgb(85,255,255),
			Color.FromArgb(85,85,85),
			Color.FromArgb(0,0,129),
			Color.FromArgb(129,0,0),
			Color.FromArgb(129,129,129),
			Color.FromArgb(129,44,0),
			Color.FromArgb(0,129,0),
			Color.FromArgb(129,0,129),
			Color.FromArgb(0,129,129),
			//
			Color.FromArgb(1,1,1),
			Color.FromArgb(16,16,16),
			Color.FromArgb(32,32,32),
			Color.FromArgb(48,48,48),
			Color.FromArgb(64,64,64),
			Color.FromArgb(80,80,80),
			Color.FromArgb(97,97,97),
			Color.FromArgb(113,113,113),
			Color.FromArgb(128,128,128),
			Color.FromArgb(145,145,145),
			Color.FromArgb(165,165,165),
			Color.FromArgb(182,182,182),
			Color.FromArgb(198,198,198),
			Color.FromArgb(218,218,218),
			Color.FromArgb(234,234,234),
			Color.FromArgb(252,252,252),
			//
			Color.FromArgb(36,48,0),
			Color.FromArgb(60,64,0),
			Color.FromArgb(76,80,4),
			Color.FromArgb(89,93,4),
			Color.FromArgb(85,97,8),
			Color.FromArgb(97,109,12),
			Color.FromArgb(109,113,16),
			Color.FromArgb(113,125,20),
			Color.FromArgb(125,125,24),
			Color.FromArgb(125,137,28),
			Color.FromArgb(137,141,32),
			Color.FromArgb(137,149,60),
			Color.FromArgb(149,157,52),
			Color.FromArgb(157,170,48),
			Color.FromArgb(165,178,52),
			Color.FromArgb(178,190,60),
			//
			Color.FromArgb(56,28,0),
			Color.FromArgb(76,40,0),
			Color.FromArgb(97,52,0),
			Color.FromArgb(121,64,4),
			Color.FromArgb(137,72,8),
			Color.FromArgb(153,85,16),
			Color.FromArgb(170,93,24),
			Color.FromArgb(186,105,32),
			Color.FromArgb(202,117,40),
			Color.FromArgb(206,125,48),
			Color.FromArgb(210,129,56),
			Color.FromArgb(214,137,64),
			Color.FromArgb(218,145,72),
			Color.FromArgb(222,149,89),
			Color.FromArgb(226,157,105),
			Color.FromArgb(230,170,125),
			//
			Color.FromArgb(89,105,8),
			Color.FromArgb(105,113,12),
			Color.FromArgb(125,125,20),
			Color.FromArgb(141,129,24),
			Color.FromArgb(157,137,36),
			Color.FromArgb(174,141,44),
			Color.FromArgb(190,145,56),
			Color.FromArgb(206,149,68),
			Color.FromArgb(222,153,80),
			Color.FromArgb(238,174,129),
			Color.FromArgb(242,194,153),
			Color.FromArgb(255,218,186),
			Color.FromArgb(234,174,125),
			Color.FromArgb(226,165,113),
			Color.FromArgb(222,157,105),
			Color.FromArgb(218,149,93),
			//
			Color.FromArgb(210,141,85),
			Color.FromArgb(202,133,76),
			Color.FromArgb(194,125,68),
			Color.FromArgb(190,117,60),
			Color.FromArgb(182,113,52),
			Color.FromArgb(178,105,44),
			Color.FromArgb(170,101,40),
			Color.FromArgb(161,93,32),
			Color.FromArgb(157,89,28),
			Color.FromArgb(145,85,28),
			Color.FromArgb(137,76,24),
			Color.FromArgb(125,68,20),
			Color.FromArgb(113,64,20),
			Color.FromArgb(97,52,16),
			Color.FromArgb(80,40,12),
			Color.FromArgb(64,32,8),
			//
			Color.FromArgb(64,36,8),
			Color.FromArgb(97,56,20),
			Color.FromArgb(129,76,40),
			Color.FromArgb(161,101,68),
			Color.FromArgb(182,113,85),
			Color.FromArgb(206,137,105),
			Color.FromArgb(230,161,133),
			Color.FromArgb(255,194,161),
			Color.FromArgb(36,20,4),
			Color.FromArgb(56,32,8),
			Color.FromArgb(76,44,16),
			Color.FromArgb(97,56,28),
			Color.FromArgb(117,68,40),
			Color.FromArgb(137,85,52),
			Color.FromArgb(157,97,68),
			Color.FromArgb(183,114,87),
			//
			Color.FromArgb(72,52,16),
			Color.FromArgb(121,89,32),
			Color.FromArgb(170,129,48),
			Color.FromArgb(218,170,64),
			Color.FromArgb(255,198,85),
			Color.FromArgb(255,206,121),
			Color.FromArgb(255,222,157),
			Color.FromArgb(255,238,206),
			Color.FromArgb(72,72,20),
			Color.FromArgb(121,121,36),
			Color.FromArgb(170,170,56),
			Color.FromArgb(214,218,72),
			Color.FromArgb(255,255,76),
			Color.FromArgb(255,255,129),
			Color.FromArgb(255,255,174),
			Color.FromArgb(255,255,218),
			//
			Color.FromArgb(36,72,20),
			Color.FromArgb(60,121,36),
			Color.FromArgb(89,170,52),
			Color.FromArgb(113,218,68),
			Color.FromArgb(141,255,85),
			Color.FromArgb(174,255,129),
			Color.FromArgb(202,255,174),
			Color.FromArgb(234,255,222),
			Color.FromArgb(20,72,56),
			Color.FromArgb(36,121,93),
			Color.FromArgb(52,170,133),
			Color.FromArgb(68,218,170),
			Color.FromArgb(85,255,198),
			Color.FromArgb(133,255,214),
			Color.FromArgb(182,255,230),
			Color.FromArgb(230,255,246),
			//
			Color.FromArgb(20,52,72),
			Color.FromArgb(36,89,121),
			Color.FromArgb(52,129,170),
			Color.FromArgb(68,170,218),
			Color.FromArgb(85,198,255),
			Color.FromArgb(129,210,255),
			Color.FromArgb(174,226,255),
			Color.FromArgb(218,242,255),
			Color.FromArgb(20,36,72),
			Color.FromArgb(36,60,121),
			Color.FromArgb(52,89,170),
			Color.FromArgb(68,113,218),
			Color.FromArgb(85,141,255),
			Color.FromArgb(129,170,255),
			Color.FromArgb(178,202,255),
			Color.FromArgb(226,234,255),
			//
			Color.FromArgb(52,20,72),
			Color.FromArgb(89,36,121),
			Color.FromArgb(129,52,170),
			Color.FromArgb(165,68,218),
			Color.FromArgb(198,85,255),
			Color.FromArgb(210,125,255),
			Color.FromArgb(222,165,255),
			Color.FromArgb(238,210,255),
			Color.FromArgb(72,16,16),
			Color.FromArgb(121,32,32),
			Color.FromArgb(170,48,48),
			Color.FromArgb(218,64,64),
			Color.FromArgb(255,80,80),
			Color.FromArgb(255,129,129),
			Color.FromArgb(255,178,178),
			Color.FromArgb(255,226,226),
			//
			Color.FromArgb(72,24,0),
			Color.FromArgb(113,44,0),
			Color.FromArgb(170,76,0),
			Color.FromArgb(218,105,0),
			Color.FromArgb(255,129,0),
			Color.FromArgb(255,165,72),
			Color.FromArgb(255,202,149),
			Color.FromArgb(255,242,230),
			Color.FromArgb(125,0,113),
			Color.FromArgb(128,0,117),
			Color.FromArgb(130,0,119),
			Color.FromArgb(132,0,121),
			Color.FromArgb(134,0,123),
			Color.FromArgb(136,0,125),
			Color.FromArgb(138,0,127),
			Color.FromArgb(140,0,128),
			//
			Color.FromArgb(68,16,16),
			Color.FromArgb(97,16,16),
			Color.FromArgb(125,32,32),
			Color.FromArgb(165,40,40),
			Color.FromArgb(210,60,60),
			Color.FromArgb(222,85,85),
			Color.FromArgb(238,113,113),
			Color.FromArgb(255,145,145),
			Color.FromArgb(16,16,68),
			Color.FromArgb(20,20,93),
			Color.FromArgb(28,28,117),
			Color.FromArgb(44,52,153),
			Color.FromArgb(68,80,194),
			Color.FromArgb(93,113,214),
			Color.FromArgb(117,145,234),
			Color.FromArgb(141,178,255),
			//
			Color.FromArgb(36,76,20),
			Color.FromArgb(44,93,28),
			Color.FromArgb(56,109,36),
			Color.FromArgb(72,133,48),
			Color.FromArgb(85,149,60),
			Color.FromArgb(101,170,72),
			Color.FromArgb(133,198,105),
			Color.FromArgb(165,234,133),
			Color.FromArgb(24,24,93),
			Color.FromArgb(36,36,133),
			Color.FromArgb(52,52,174),
			Color.FromArgb(68,68,214),
			Color.FromArgb(80,80,255),
			Color.FromArgb(97,125,255),
			Color.FromArgb(129,165,255),
			Color.FromArgb(194,214,255),
			//
			Color.FromArgb(248,248,248),
			Color.FromArgb(230,222,214),
			Color.FromArgb(202,194,182),
			Color.FromArgb(178,165,153),
			Color.FromArgb(133,121,113),
			Color.FromArgb(89,85,76),
			Color.FromArgb(48,44,40),
			Color.FromArgb(182,255,255),
			Color.FromArgb(89,238,255),
			Color.FromArgb(109,186,255),
			Color.FromArgb(80,144,255),
			Color.FromArgb(72,68,218),
			Color.FromArgb(145,198,68),
			Color.FromArgb(133,170,52),
			Color.FromArgb(72,129,0),
			Color.FromArgb(234,93,64),
			//
			Color.FromArgb(194,76,48),
			Color.FromArgb(157,24,0),
			Color.FromArgb(223,159,107),
			Color.FromArgb(211,142,87),
			Color.FromArgb(195,125,69),
			Color.FromArgb(179,105,45),
			Color.FromArgb(149,85,32),
			Color.FromArgb(121,68,24),
			Color.FromArgb(99,54,17),
			Color.FromArgb(234,190,72),
			Color.FromArgb(219,170,65),
			Color.FromArgb(186,133,36),
			Color.FromArgb(0,0,128),
			Color.FromArgb(255,255,82),
			Color.FromArgb(56,129,105),
			Color.FromArgb(174,174,174)
		};

		#region Team Logo Palette-related
		/// <summary>
		/// Any index with this value is not safe for logo usage.
		/// In other words, these palette entries will vary based on what screen is loaded.
		/// </summary>
		private static readonly Color LOGO_UNSAFE_COLOR = Color.Plum;

		/// <summary>
		/// Logo-safe palette colors. In theory, anyways.
		/// </summary>
		/// Some of these are different from their "actual" values because graphics editors
		/// like to "fix" things that aren't broken (i.e. they will choose the earliest index
		/// if there's more than one matching index for a color)
		/// also the .LBM files give different values and I can't be arsed to redo it
		public static Color[] LogoSafePalette = new Color[]
		{
			// row 1
			//Color.FromArgb(0,0,0,0), // Color.Transparent is 255,255,255; we need 0,0,0
			Color.FromArgb(255,0,0,0), // hack to make my life easier because .net sucks with transparency
			Color.FromArgb(84,84,252),
			Color.FromArgb(252,84,84),
			Color.FromArgb(252,252,252),
			Color.FromArgb(252,252,84),
			Color.FromArgb(84,252,84),
			Color.FromArgb(252,84,252),
			Color.FromArgb(84,252,252),
			Color.FromArgb(84,84,84),
			Color.FromArgb(0,0,128),
			Color.FromArgb(128,0,0),
			Color.FromArgb(128,128,128),
			Color.FromArgb(128,44,0),
			Color.FromArgb(0,128,0),
			Color.FromArgb(128,0,128),
			Color.FromArgb(0,128,128),

			// row 2: black-white gradient
			Color.FromArgb(1,1,1),
			Color.FromArgb(16,16,16),
			Color.FromArgb(32,32,32),
			Color.FromArgb(48,48,48),
			Color.FromArgb(64,64,64),
			Color.FromArgb(80,80,80),
			Color.FromArgb(96,96,96),
			Color.FromArgb(112,112,112),
			Color.FromArgb(129,129,129),
			Color.FromArgb(144,144,144),
			Color.FromArgb(164,164,164),
			Color.FromArgb(180,180,180),
			Color.FromArgb(196,196,196),
			Color.FromArgb(216,216,216),
			Color.FromArgb(232,232,232),
			Color.FromArgb(253,253,253),

			// rows 3 and 4 are unsafe
			LOGO_UNSAFE_COLOR,
			LOGO_UNSAFE_COLOR,
			LOGO_UNSAFE_COLOR,
			LOGO_UNSAFE_COLOR,
			LOGO_UNSAFE_COLOR,
			LOGO_UNSAFE_COLOR,
			LOGO_UNSAFE_COLOR,
			LOGO_UNSAFE_COLOR,
			LOGO_UNSAFE_COLOR,
			LOGO_UNSAFE_COLOR,
			LOGO_UNSAFE_COLOR,
			LOGO_UNSAFE_COLOR,
			LOGO_UNSAFE_COLOR,
			LOGO_UNSAFE_COLOR,
			LOGO_UNSAFE_COLOR,
			LOGO_UNSAFE_COLOR,
			//----------------//
			LOGO_UNSAFE_COLOR,
			LOGO_UNSAFE_COLOR,
			LOGO_UNSAFE_COLOR,
			LOGO_UNSAFE_COLOR,
			LOGO_UNSAFE_COLOR,
			LOGO_UNSAFE_COLOR,
			LOGO_UNSAFE_COLOR,
			LOGO_UNSAFE_COLOR,
			LOGO_UNSAFE_COLOR,
			LOGO_UNSAFE_COLOR,
			LOGO_UNSAFE_COLOR,
			LOGO_UNSAFE_COLOR,
			LOGO_UNSAFE_COLOR,
			LOGO_UNSAFE_COLOR,
			LOGO_UNSAFE_COLOR,
			LOGO_UNSAFE_COLOR,

			// first 11 entries of row 5 are unsafe
			LOGO_UNSAFE_COLOR,
			LOGO_UNSAFE_COLOR,
			LOGO_UNSAFE_COLOR,
			LOGO_UNSAFE_COLOR,
			LOGO_UNSAFE_COLOR,
			LOGO_UNSAFE_COLOR,
			LOGO_UNSAFE_COLOR,
			LOGO_UNSAFE_COLOR,
			LOGO_UNSAFE_COLOR,
			LOGO_UNSAFE_COLOR,
			LOGO_UNSAFE_COLOR,
			//----------------//
			// row 5 skin colors
			Color.FromArgb(252, 188, 112),
			Color.FromArgb(235, 174, 125),
			Color.FromArgb(227, 166, 113),
			Color.FromArgb(223, 158, 105),
			Color.FromArgb(219, 150, 93),

			// row 6 skin colors continued
			Color.FromArgb(211, 142, 85),
			Color.FromArgb(203, 134, 77),
			Color.FromArgb(195, 125, 69),
			Color.FromArgb(190, 117, 60),
			Color.FromArgb(182, 113, 52),
			Color.FromArgb(178, 105, 44),
			Color.FromArgb(170, 101, 40),
			Color.FromArgb(162, 93, 32),
			Color.FromArgb(158, 89, 28),
			Color.FromArgb(146, 85, 28),
			Color.FromArgb(138, 77, 24),
			Color.FromArgb(125, 69, 20),
			Color.FromArgb(113, 65, 20),
			Color.FromArgb(97, 52, 16),
			Color.FromArgb(81, 40, 12),
			Color.FromArgb(65, 32, 8),

			// row 7 possibly skin colors for in-game players
			Color.FromArgb(65, 36, 8),
			Color.FromArgb(97, 56, 20),
			Color.FromArgb(130, 77, 40),
			Color.FromArgb(162, 101, 69),
			Color.FromArgb(182, 113, 85),
			Color.FromArgb(207, 138, 105),
			Color.FromArgb(231, 162, 134),
			Color.FromArgb(255, 195, 162),
			Color.FromArgb(36, 20, 4),
			Color.FromArgb(56, 32, 8),
			Color.FromArgb(77, 44, 16),
			Color.FromArgb(97, 56, 28),
			Color.FromArgb(117, 69, 40),
			Color.FromArgb(138, 85, 52),
			Color.FromArgb(158, 97, 69),
			Color.FromArgb(183, 114, 86),

			// row 8 two yellows
			Color.FromArgb(73, 52, 16),
			Color.FromArgb(121, 89, 32),
			Color.FromArgb(170, 130, 48),
			Color.FromArgb(219, 170, 65),
			Color.FromArgb(255, 199, 85),
			Color.FromArgb(255, 207, 121),
			Color.FromArgb(255, 223, 158),
			Color.FromArgb(255, 239, 207),
			Color.FromArgb(73, 73, 20),
			Color.FromArgb(121, 121, 36),
			Color.FromArgb(170, 170, 56),
			Color.FromArgb(215, 219, 73),
			Color.FromArgb(255, 255, 85),
			Color.FromArgb(255, 255, 130),
			Color.FromArgb(255, 255, 174),
			Color.FromArgb(255, 255, 219),

			// row 9 neon yellow-green and cyan
			Color.FromArgb(36, 73, 20),
			Color.FromArgb(60, 121, 36),
			Color.FromArgb(89, 170, 52),
			Color.FromArgb(113, 219, 69),
			Color.FromArgb(142, 255, 85),
			Color.FromArgb(174, 255, 130),
			Color.FromArgb(203, 255, 174),
			Color.FromArgb(235, 255, 223),
			Color.FromArgb(20, 73, 56),
			Color.FromArgb(36, 121, 93),
			Color.FromArgb(52, 170, 134),
			Color.FromArgb(69, 219, 170),
			Color.FromArgb(85, 255, 199),
			Color.FromArgb(134, 255, 215),
			Color.FromArgb(182, 255, 231),
			Color.FromArgb(231, 255, 247),

			// row 10 two light blues
			Color.FromArgb(20, 52, 73),
			Color.FromArgb(36, 89, 121),
			Color.FromArgb(52, 130, 170),
			Color.FromArgb(69, 170, 219),
			Color.FromArgb(85, 199, 255),
			Color.FromArgb(130, 211, 255),
			Color.FromArgb(174, 227, 255),
			Color.FromArgb(219, 243, 255),
			Color.FromArgb(20, 36, 73),
			Color.FromArgb(36, 60, 121),
			Color.FromArgb(52, 89, 170),
			Color.FromArgb(69, 113, 219),
			Color.FromArgb(85, 142, 255),
			Color.FromArgb(130, 170, 255),
			Color.FromArgb(178, 203, 255),
			Color.FromArgb(227, 235, 255),

			// row 11 purple and red
			Color.FromArgb(52, 20, 73),
			Color.FromArgb(89, 36, 121),
			Color.FromArgb(130, 52, 170),
			Color.FromArgb(166, 69, 219),
			Color.FromArgb(199, 85, 255),
			Color.FromArgb(211, 125, 255),
			Color.FromArgb(223, 166, 255),
			Color.FromArgb(239, 211, 255),
			Color.FromArgb(73, 16, 16),
			Color.FromArgb(121, 32, 32),
			Color.FromArgb(170, 48, 48),
			Color.FromArgb(219, 65, 65),
			Color.FromArgb(255, 85, 85),
			Color.FromArgb(255, 130, 130),
			Color.FromArgb(255, 178, 178),
			Color.FromArgb(255, 227, 227),

			// row 12: orange in the first 8 colors only
			Color.FromArgb(73, 24, 0),
			Color.FromArgb(113, 44, 0),
			Color.FromArgb(170, 77, 0),
			Color.FromArgb(219, 105, 0),
			Color.FromArgb(255, 130, 0),
			Color.FromArgb(255, 166, 73),
			Color.FromArgb(255, 203, 150),
			Color.FromArgb(255, 243, 231),
			// other 8 colors are unsafe
			LOGO_UNSAFE_COLOR,
			LOGO_UNSAFE_COLOR,
			LOGO_UNSAFE_COLOR,
			LOGO_UNSAFE_COLOR,
			LOGO_UNSAFE_COLOR,
			LOGO_UNSAFE_COLOR,
			LOGO_UNSAFE_COLOR,
			LOGO_UNSAFE_COLOR,

			// row 13 all unsafe (cap and trim colors for team 1)
			LOGO_UNSAFE_COLOR,
			LOGO_UNSAFE_COLOR,
			LOGO_UNSAFE_COLOR,
			LOGO_UNSAFE_COLOR,
			LOGO_UNSAFE_COLOR,
			LOGO_UNSAFE_COLOR,
			LOGO_UNSAFE_COLOR,
			LOGO_UNSAFE_COLOR,
			LOGO_UNSAFE_COLOR,
			LOGO_UNSAFE_COLOR,
			LOGO_UNSAFE_COLOR,
			LOGO_UNSAFE_COLOR,
			LOGO_UNSAFE_COLOR,
			LOGO_UNSAFE_COLOR,
			LOGO_UNSAFE_COLOR,
			LOGO_UNSAFE_COLOR,

			// row 14 all unsafe (cap and trim colors for team 2)
			LOGO_UNSAFE_COLOR,
			LOGO_UNSAFE_COLOR,
			LOGO_UNSAFE_COLOR,
			LOGO_UNSAFE_COLOR,
			LOGO_UNSAFE_COLOR,
			LOGO_UNSAFE_COLOR,
			LOGO_UNSAFE_COLOR,
			LOGO_UNSAFE_COLOR,
			LOGO_UNSAFE_COLOR,
			LOGO_UNSAFE_COLOR,
			LOGO_UNSAFE_COLOR,
			LOGO_UNSAFE_COLOR,
			LOGO_UNSAFE_COLOR,
			LOGO_UNSAFE_COLOR,
			LOGO_UNSAFE_COLOR,
			LOGO_UNSAFE_COLOR,

			// row 15 off-white gradient, neon blue gradient, some other colors
			Color.FromArgb(255, 255, 255),
			Color.FromArgb(228, 220, 212),
			Color.FromArgb(200, 192, 180),
			Color.FromArgb(176, 164, 152),
			Color.FromArgb(132, 120, 112),
			Color.FromArgb(88, 84, 76),
			Color.FromArgb(48, 44, 40),
			Color.FromArgb(180, 252, 252),
			Color.FromArgb(88, 236, 252),
			Color.FromArgb(108, 184, 252),
			Color.FromArgb(84, 140, 252),
			Color.FromArgb(72, 68, 216),
			Color.FromArgb(144, 196, 68),
			Color.FromArgb(132, 168, 52),
			Color.FromArgb(72, 128, 0),
			Color.FromArgb(232, 92, 64),

			// row 16 reds, browns, other colors
			Color.FromArgb(192, 76, 48),
			Color.FromArgb(156, 24, 0),
			Color.FromArgb(223, 158, 105),
			Color.FromArgb(212, 143, 86),
			Color.FromArgb(192, 124, 68),
			Color.FromArgb(176, 104, 44),
			Color.FromArgb(148, 84, 32),
			Color.FromArgb(120, 68, 24),
			Color.FromArgb(96, 52, 16),
			Color.FromArgb(232, 188, 72),
			Color.FromArgb(216, 168, 64),
			Color.FromArgb(184, 132, 36),
			Color.FromArgb(0, 0, 129),
			Color.FromArgb(253, 253, 85),
			Color.FromArgb(56, 128, 104),
			Color.FromArgb(172, 172, 172),
		};
		#endregion

		#region Player Picture Palette-related
		/// <summary>
		/// Any index with this value is not safe for player picture usage.
		/// In other words, these palette entries will vary based on what screen is loaded.
		/// </summary>
		private static readonly Color PLAYER_PIC_UNSAFE_COLOR = Color.Plum;

		/// <summary>
		/// completely unconfirmed
		/// </summary>
		public static Color[] PlayerPicSafePalette = new Color[]
		{
			Color.FromArgb(0,0,0),
			Color.FromArgb(84,84,252),
			Color.FromArgb(252,84,84),
			Color.FromArgb(252,252,252),
			Color.FromArgb(252,252,84),
			Color.FromArgb(84,252,84),
			Color.FromArgb(252,84,252),
			Color.FromArgb(84,252,252),
			Color.FromArgb(84,84,84),
			Color.FromArgb(0,0,128),
			Color.FromArgb(128,0,0),
			Color.FromArgb(128,128,128),
			Color.FromArgb(128,44,0),
			Color.FromArgb(0,128,0),
			Color.FromArgb(128,0,128),
			Color.FromArgb(0,128,128),
			Color.FromArgb(1,1,1),
			Color.FromArgb(16,16,16),
			Color.FromArgb(32,32,32),
			Color.FromArgb(48,48,48),
			Color.FromArgb(64,64,64),
			Color.FromArgb(80,80,80),
			Color.FromArgb(96,96,96),
			Color.FromArgb(112,112,112),
			Color.FromArgb(129,129,129),
			Color.FromArgb(144,144,144),
			Color.FromArgb(164,164,164),
			Color.FromArgb(180,180,180),
			Color.FromArgb(196,196,196),
			Color.FromArgb(216,216,216),
			Color.FromArgb(232,232,232),
			Color.FromArgb(253,253,253),
			PLAYER_PIC_UNSAFE_COLOR,
			PLAYER_PIC_UNSAFE_COLOR,
			PLAYER_PIC_UNSAFE_COLOR,
			PLAYER_PIC_UNSAFE_COLOR,
			PLAYER_PIC_UNSAFE_COLOR,
			PLAYER_PIC_UNSAFE_COLOR,
			PLAYER_PIC_UNSAFE_COLOR,
			PLAYER_PIC_UNSAFE_COLOR,
			PLAYER_PIC_UNSAFE_COLOR,
			PLAYER_PIC_UNSAFE_COLOR,
			PLAYER_PIC_UNSAFE_COLOR,
			PLAYER_PIC_UNSAFE_COLOR,
			PLAYER_PIC_UNSAFE_COLOR,
			PLAYER_PIC_UNSAFE_COLOR,
			PLAYER_PIC_UNSAFE_COLOR,
			PLAYER_PIC_UNSAFE_COLOR,
			PLAYER_PIC_UNSAFE_COLOR,
			PLAYER_PIC_UNSAFE_COLOR,
			PLAYER_PIC_UNSAFE_COLOR,
			PLAYER_PIC_UNSAFE_COLOR,
			PLAYER_PIC_UNSAFE_COLOR,
			PLAYER_PIC_UNSAFE_COLOR,
			PLAYER_PIC_UNSAFE_COLOR,
			PLAYER_PIC_UNSAFE_COLOR,
			PLAYER_PIC_UNSAFE_COLOR,
			PLAYER_PIC_UNSAFE_COLOR,
			PLAYER_PIC_UNSAFE_COLOR,
			PLAYER_PIC_UNSAFE_COLOR,
			PLAYER_PIC_UNSAFE_COLOR,
			PLAYER_PIC_UNSAFE_COLOR,
			PLAYER_PIC_UNSAFE_COLOR,
			PLAYER_PIC_UNSAFE_COLOR,
			PLAYER_PIC_UNSAFE_COLOR,
			PLAYER_PIC_UNSAFE_COLOR,
			PLAYER_PIC_UNSAFE_COLOR,
			PLAYER_PIC_UNSAFE_COLOR,
			PLAYER_PIC_UNSAFE_COLOR,
			PLAYER_PIC_UNSAFE_COLOR,
			PLAYER_PIC_UNSAFE_COLOR,
			PLAYER_PIC_UNSAFE_COLOR,
			PLAYER_PIC_UNSAFE_COLOR,
			PLAYER_PIC_UNSAFE_COLOR,
			PLAYER_PIC_UNSAFE_COLOR,
			PLAYER_PIC_UNSAFE_COLOR,
			Color.FromArgb(235,174,125),
			Color.FromArgb(227,166,113),
			Color.FromArgb(223,158,105),
			Color.FromArgb(219,150,93),
			Color.FromArgb(211,142,85),
			Color.FromArgb(203,134,77),
			Color.FromArgb(195,125,69),
			Color.FromArgb(190,117,60),
			Color.FromArgb(182,113,52),
			Color.FromArgb(178,105,44),
			Color.FromArgb(170,101,40),
			Color.FromArgb(162,93,32),
			Color.FromArgb(158,89,28),
			Color.FromArgb(146,85,28),
			Color.FromArgb(138,77,24),
			Color.FromArgb(125,69,20),
			Color.FromArgb(113,65,20),
			Color.FromArgb(97,52,16),
			Color.FromArgb(81,40,12),
			Color.FromArgb(65,32,8),
			Color.FromArgb(65,36,8),
			Color.FromArgb(97,56,20),
			Color.FromArgb(130,77,40),
			Color.FromArgb(162,101,69),
			Color.FromArgb(182,113,85),
			Color.FromArgb(207,138,105),
			Color.FromArgb(231,162,134),
			Color.FromArgb(255,195,162),
			Color.FromArgb(36,20,4),
			Color.FromArgb(56,32,8),
			Color.FromArgb(77,44,16),
			Color.FromArgb(97,56,28),
			Color.FromArgb(117,69,40),
			Color.FromArgb(138,85,52),
			Color.FromArgb(158,97,69),
			Color.FromArgb(183,114,86),
			Color.FromArgb(73,52,16),
			Color.FromArgb(121,89,32),
			Color.FromArgb(170,130,48),
			Color.FromArgb(219,170,65),
			Color.FromArgb(255,199,85),
			Color.FromArgb(255,207,121),
			Color.FromArgb(255,223,158),
			Color.FromArgb(255,239,207),
			Color.FromArgb(73,73,20),
			Color.FromArgb(121,121,36),
			Color.FromArgb(170,170,56),
			Color.FromArgb(215,219,73),
			Color.FromArgb(255,255,85),
			Color.FromArgb(255,255,130),
			Color.FromArgb(255,255,174),
			Color.FromArgb(255,255,219),
			Color.FromArgb(36,73,20),
			Color.FromArgb(60,121,36),
			Color.FromArgb(89,170,52),
			Color.FromArgb(113,219,69),
			Color.FromArgb(142,255,85),
			Color.FromArgb(174,255,130),
			Color.FromArgb(203,255,174),
			Color.FromArgb(235,255,223),
			Color.FromArgb(20,73,56),
			Color.FromArgb(36,121,93),
			Color.FromArgb(52,170,134),
			Color.FromArgb(69,219,170),
			Color.FromArgb(85,255,199),
			Color.FromArgb(134,255,215),
			Color.FromArgb(182,255,231),
			Color.FromArgb(231,255,247),
			Color.FromArgb(20,52,73),
			Color.FromArgb(36,89,121),
			Color.FromArgb(52,130,170),
			Color.FromArgb(69,170,219),
			Color.FromArgb(85,199,255),
			Color.FromArgb(130,211,255),
			Color.FromArgb(174,227,255),
			Color.FromArgb(219,243,255),
			Color.FromArgb(20,36,73),
			Color.FromArgb(36,60,121),
			Color.FromArgb(52,89,170),
			Color.FromArgb(69,113,219),
			Color.FromArgb(85,142,255),
			Color.FromArgb(130,170,255),
			Color.FromArgb(178,203,255),
			Color.FromArgb(227,235,255),
			Color.FromArgb(52,20,73),
			Color.FromArgb(89,36,121),
			Color.FromArgb(130,52,170),
			Color.FromArgb(166,69,219),
			Color.FromArgb(199,85,255),
			Color.FromArgb(211,125,255),
			Color.FromArgb(223,166,255),
			Color.FromArgb(239,211,255),
			Color.FromArgb(73,16,16),
			Color.FromArgb(121,32,32),
			Color.FromArgb(170,48,48),
			Color.FromArgb(219,65,65),
			Color.FromArgb(255,85,85),
			Color.FromArgb(255,130,130),
			Color.FromArgb(255,178,178),
			Color.FromArgb(255,227,227),
			Color.FromArgb(73,24,0),
			Color.FromArgb(113,44,0),
			Color.FromArgb(170,77,0),
			Color.FromArgb(219,105,0),
			Color.FromArgb(255,130,0),
			Color.FromArgb(255,166,73),
			Color.FromArgb(255,203,150),
			Color.FromArgb(255,243,231),
			Color.FromArgb(128,0,128),
			Color.FromArgb(128,0,128),
			Color.FromArgb(128,0,128),
			Color.FromArgb(128,0,128),
			Color.FromArgb(128,0,128),
			Color.FromArgb(128,0,128),
			Color.FromArgb(128,0,128),
			Color.FromArgb(128,0,128),
			Color.FromArgb(68,16,16),
			Color.FromArgb(96,16,16),
			Color.FromArgb(124,32,32),
			Color.FromArgb(164,40,40),
			Color.FromArgb(208,60,60),
			Color.FromArgb(220,84,84),
			Color.FromArgb(236,112,112),
			Color.FromArgb(252,144,144),
			Color.FromArgb(0,44,104),
			Color.FromArgb(12,56,144),
			Color.FromArgb(40,72,188),
			Color.FromArgb(80,96,232),
			Color.FromArgb(100,112,236),
			Color.FromArgb(120,128,240),
			Color.FromArgb(144,148,244),
			Color.FromArgb(168,168,252),
			Color.FromArgb(36,0,64),
			Color.FromArgb(60,0,100),
			Color.FromArgb(84,8,136),
			Color.FromArgb(112,20,172),
			Color.FromArgb(136,40,192),
			Color.FromArgb(160,68,212),
			Color.FromArgb(188,96,232),
			Color.FromArgb(216,132,252),
			Color.FromArgb(112,76,12),
			Color.FromArgb(136,100,16),
			Color.FromArgb(164,128,20),
			Color.FromArgb(188,160,24),
			Color.FromArgb(216,192,32),
			Color.FromArgb(244,228,36),
			Color.FromArgb(248,232,88),
			Color.FromArgb(252,240,148),
			Color.FromArgb(255,255,255),
			Color.FromArgb(228,220,212),
			Color.FromArgb(200,192,180),
			Color.FromArgb(176,164,152),
			Color.FromArgb(132,120,112),
			Color.FromArgb(88,84,76),
			Color.FromArgb(48,44,40),
			Color.FromArgb(180,252,252),
			Color.FromArgb(88,236,252),
			Color.FromArgb(108,184,252),
			Color.FromArgb(84,140,252),
			Color.FromArgb(72,68,216),
			Color.FromArgb(144,196,68),
			Color.FromArgb(132,168,52),
			Color.FromArgb(72,128,0),
			Color.FromArgb(232,92,64),
			Color.FromArgb(192,76,48),
			Color.FromArgb(156,24,0),
			Color.FromArgb(223,158,105),
			Color.FromArgb(212,143,86),
			Color.FromArgb(192,124,68),
			Color.FromArgb(176,104,44),
			Color.FromArgb(148,84,32),
			Color.FromArgb(120,68,24),
			Color.FromArgb(96,52,16),
			Color.FromArgb(232,188,72),
			Color.FromArgb(216,168,64),
			Color.FromArgb(184,132,36),
			Color.FromArgb(0,0,129),
			Color.FromArgb(253,253,85),
			Color.FromArgb(56,128,104),
			Color.FromArgb(172,172,172)
		};
		#endregion

		/// <summary>
		/// Cap and Trim colors for teams in MLBPA leagues.
		/// </summary>
		/// Note: You can use the Legends cap and trim colors by using indices 0x0C and above
		/// 
		/// Location in each version of the game:
		///---------+------------------------
		/// Version | .exe offset
		///---------+------------------------
		/// v5.11   | 0xF1FD5
		/// v5.12   | 0xF1FE1
		///---------+------------------------
		/// v5.13   | 0xF10AD
		/// v5.14LP | 0xEFE4D
		///---------+------------------------
		public static Dictionary<int, Color[]> CapTrimColors_MLBPA = new Dictionary<int, Color[]>()
		{
			// 0x00 = Navy Blue
			{
				0,
				new Color[8]
				{
					Color.FromArgb(0,0,44),
					Color.FromArgb(0,0,52),
					Color.FromArgb(4,4,60),
					Color.FromArgb(4,4,68),
					Color.FromArgb(12,12,80),
					Color.FromArgb(20,20,89),
					Color.FromArgb(28,28,97),
					Color.FromArgb(36,36,109)
				}
			},

			// 0x01 = Dark Red
			{
				1,
				new Color[8]
				{
					Color.FromArgb(68,16,16),
					Color.FromArgb(97,16,16),
					Color.FromArgb(125,32,32),
					Color.FromArgb(165,40,40),
					Color.FromArgb(210,60,60),
					Color.FromArgb(222,85,85),
					Color.FromArgb(238,113,113),
					Color.FromArgb(255,145,145)
				}
			},

			// 0x02 = Dark Green
			{
				2,
				new Color[8]
				{
					Color.FromArgb(8,48,16),
					Color.FromArgb(16,72,24),
					Color.FromArgb(28,101,40),
					Color.FromArgb(44,125,52),
					Color.FromArgb(60,153,68),
					Color.FromArgb(85,178,85),
					Color.FromArgb(105,206,105),
					Color.FromArgb(137,234,133)
				}
			},

			// 0x03 = Purple
			{
				3,
				new Color[8]
				{
					Color.FromArgb(36,0,64),
					Color.FromArgb(60,0,101),
					Color.FromArgb(85,8,137),
					Color.FromArgb(113,20,174),
					Color.FromArgb(137,40,194),
					Color.FromArgb(161,68,214),
					Color.FromArgb(190,97,234),
					Color.FromArgb(218,133,255)
				}
			},

			// 0x04 = Orange
			{
				4,
				new Color[8]
				{
					Color.FromArgb(109,48,0),
					Color.FromArgb(157,76,4),
					Color.FromArgb(206,105,8),
					Color.FromArgb(255,141,24),
					Color.FromArgb(255,157,52),
					Color.FromArgb(255,178,80),
					Color.FromArgb(255,194,109),
					Color.FromArgb(255,210,141)
				}
			},

			// 0x05 = Yellow
			{
				5,
				new Color[8]
				{
					Color.FromArgb(113,76,12),
					Color.FromArgb(137,101,16),
					Color.FromArgb(165,129,20),
					Color.FromArgb(190,161,24),
					Color.FromArgb(218,194,32),
					Color.FromArgb(246,230,36),
					Color.FromArgb(250,234,89),
					Color.FromArgb(255,242,149)
				}
			},

			// 0x06 = Green
			{
				6,
				new Color[8]
				{
					Color.FromArgb(48,80,16),
					Color.FromArgb(60,105,20),
					Color.FromArgb(76,129,24),
					Color.FromArgb(97,153,24),
					Color.FromArgb(113,178,28),
					Color.FromArgb(137,202,60),
					Color.FromArgb(170,226,101),
					Color.FromArgb(206,255,153)
				}
			},

			// 0x07 = Black
			{
				7,
				new Color[8]
				{
					Color.FromArgb(0,0,0),
					Color.FromArgb(20,20,16),
					Color.FromArgb(44,44,40),
					Color.FromArgb(64,64,60),
					Color.FromArgb(89,89,80),
					Color.FromArgb(113,113,105),
					Color.FromArgb(137,137,125),
					Color.FromArgb(161,161,149)
				}
			},

			// 0x08 = Brown
			{
				8,
				new Color[8]
				{
					Color.FromArgb(52,36,20),
					Color.FromArgb(76,52,28),
					Color.FromArgb(101,72,44),
					Color.FromArgb(129,93,56),
					Color.FromArgb(149,109,72),
					Color.FromArgb(170,129,93),
					Color.FromArgb(190,149,113),
					Color.FromArgb(210,174,137)
				}
			},

			// 0x09 = Blue
			{
				9,
				new Color[8]
				{
					Color.FromArgb(0,44,105),
					Color.FromArgb(12,56,145),
					Color.FromArgb(40,72,190),
					Color.FromArgb(80,97,234),
					Color.FromArgb(101,113,238),
					Color.FromArgb(121,129,242),
					Color.FromArgb(145,149,246),
					Color.FromArgb(170,170,255)
				}
			},

			// 0x0A = Red
			{
				10,
				new Color[8]
				{
					Color.FromArgb(113,0,0),
					Color.FromArgb(153,4,4),
					Color.FromArgb(194,16,16),
					Color.FromArgb(234,36,36),
					Color.FromArgb(238,60,60),
					Color.FromArgb(242,89,89),
					Color.FromArgb(246,117,117),
					Color.FromArgb(255,149,149)
				}
			},

			// 0x0B = Teal
			{
				11,
				new Color[8]
				{
					Color.FromArgb(0,64,64),
					Color.FromArgb(12,85,85),
					Color.FromArgb(28,105,105),
					Color.FromArgb(40,125,125),
					Color.FromArgb(56,145,145),
					Color.FromArgb(64,153,153),
					Color.FromArgb(72,165,165),
					Color.FromArgb(80,178,178)
				}
			}
		};

		/// <summary>
		/// Cap and Trim colors for teams in Legends leagues.
		/// </summary>
		public static Dictionary<int, Color[]> CapTrimColors_Legends = new Dictionary<int, Color[]>()
		{
			// Note: everything beyond this point is used for Legends league teams.
			// you can still use them in MLBPA league types by starting from 0x0C.

			// 0x00 (0x0C for MLBPA teams) = Purplish-blue
			// this is the only significantly different palette in the Legends league type
			{
				0,
				new Color[8]
				{
					Color.FromArgb(16,16,68),
					Color.FromArgb(32,24,97),
					Color.FromArgb(52,32,125),
					Color.FromArgb(76,44,153),
					Color.FromArgb(80,64,178),
					Color.FromArgb(97,101,202),
					Color.FromArgb(129,149,226),
					Color.FromArgb(165,202,255)
				}
			},

			// todo: there are another 11 sets of colors after these.
		};
	}
}
