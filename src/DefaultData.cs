﻿using System;
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
		/// Team Cap/Trim color database. (Primary shade version)
		/// Values after 0x0C seem to repeat from 0x01... haven't bothered testing much.
		/// </summary>
		/// All color samples taken from the 5th shade out of 8.
		public static Color[] CapTrimColors =
		{
			Color.FromArgb(12,12,81),    // 0x00 = Navy Blue
			Color.FromArgb(211,60,60),   // 0x01 = Dark Red
			Color.FromArgb(60,154,69),   // 0x02 = Dark Green
			Color.FromArgb(138,40,195),  // 0x03 = Purple
			Color.FromArgb(255,128,52),  // 0x04 = Orange
			Color.FromArgb(219,195,32),  // 0x05 = Yellow
			Color.FromArgb(113,178,28),  // 0x06 = Green
			Color.FromArgb(89,89,81),    // 0x07 = Black
			Color.FromArgb(150,109,73),  // 0x08 = Brown
			Color.FromArgb(101,113,239), // 0x09 = Blue
			Color.FromArgb(239,60,60),   // 0x0A = Red
			Color.FromArgb(56,146,146),  // 0x0B = Teal
			Color.FromArgb(81,65,178),   // 0x0C = Purplish-blue, not normally selectable
		};

		// todo: full color database using Dictionary<int, Color[]>
	}
}