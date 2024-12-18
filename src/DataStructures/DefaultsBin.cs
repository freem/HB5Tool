using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace HB5Tool
{
	/// <summary>
	/// Data found in DEFAULTS.BIN, DEF_D.BIN, DEFAULTS.BIO
	/// </summary>
	public class DefaultsBin
	{
		#region Constants
		/// <summary>
		/// Maximum length of path to current league file.
		/// </summary>
		public static readonly int DEFAULTS_LEAGUE_PATH_MAX = 64;

		/// <summary>
		/// Maximum value for Team Skill values.
		/// </summary>
		public static readonly int TEAM_SKILL_MAX = 10;

		/// <summary>
		/// Maximum value for Game Speed value.
		/// </summary>
		public static readonly int GAME_SPEED_MAX = 16;

		/// <summary>
		/// Maximum volume value.
		/// </summary>
		public static readonly int VOLUME_MAX = 127;

		/// <summary>
		/// Maximum length of names for the Home Run Derby scoreboard.
		/// </summary>
		public static readonly int HOME_RUN_DERBY_NAME_LENGTH = 16;

		/// <summary>
		/// Maximum possible score for Home Run Derby in 3 pitch mode.
		/// </summary>
		public static readonly int HOME_RUN_DERBY_MAX_SCORE_3_PITCHES = 3000;

		/// <summary>
		/// Maximum possible score for Home Run Derby in 5 pitch mode.
		/// </summary>
		public static readonly int HOME_RUN_DERBY_MAX_SCORE_5_PITCHES = 5000;

		/// <summary>
		/// Maximum possible score for Home Run Derby in 10 pitch mode.
		/// </summary>
		public static readonly int HOME_RUN_DERBY_MAX_SCORE_10_PITCHES = 10000;

		/// <summary>
		/// Maximum possible score for Home Run Derby in 20 pitch mode.
		/// </summary>
		public static readonly int HOME_RUN_DERBY_MAX_SCORE_20_PITCHES = 20000;
		#endregion

		#region Bitfield Masks

		#region Level of Play
		/// <summary>
		/// Level of Play mask for Designated Hitter.
		/// </summary>
		public readonly short LevelOfPlay_DesignatedHitter = 1;

		/// <summary>
		/// Level of Play mask for Fielding Errors.
		/// </summary>
		public readonly short LevelOfPlay_FieldingErrors = 2;

		/// <summary>
		/// Level of Play mask for Injuries.
		/// </summary>
		public readonly short LevelOfPlay_Injuries = 4;

		/// <summary>
		/// Level of Play mask for Pitch to Center.
		/// </summary>
		public readonly short LevelOfPlay_PitchToCenter = 8;

		/// <summary>
		/// Level of Play mask for Pitching Crosshair.
		/// </summary>
		public readonly short LevelOfPlay_PitchingCrosshair = 0x10;

		/// <summary>
		/// Level of Play mask for Pitching Fatigue.
		/// </summary>
		public readonly short LevelOfPlay_PitchingFatigue = 0x20;

		/// <summary>
		/// Level of Play mask for Fielding Marker.
		/// </summary>
		public readonly short LevelOfPlay_FieldingMarker = 0x40;

		/// <summary>
		/// Level of Play mask for Base Stealing.
		/// </summary>
		public readonly short LevelOfPlay_BaseStealing = 0x80;

		/// <summary>
		/// Level of Play mask for Player Ratings.
		/// </summary>
		public readonly short LevelOfPlay_PlayerRatings = 0x100;
		#endregion

		#region Manager Options
		/// <summary>
		/// Manager Options mask for Pitching. (Disabled in One Pitch Mode.)
		/// </summary>
		public readonly short ManagerOptions_Pitching = 1;

		/// <summary>
		/// Manager Options mask for Batting. (Disabled in One Pitch Mode.)
		/// </summary>
		public readonly short ManagerOptions_Batting = 2;

		/// <summary>
		/// Manager Options mask for Fielding.
		/// </summary>
		public readonly short ManagerOptions_Fielding = 4;

		/// <summary>
		/// Manager Options mask for Throwing.
		/// </summary>
		public readonly short ManagerOptions_Throwing = 8;

		/// <summary>
		/// Manager Options mask for Base Running.
		/// </summary>
		public readonly short ManagerOptions_BaseRunning = 0x10;

		/// <summary>
		/// Manager Options mask for Substitutions.
		/// </summary>
		public readonly short ManagerOptions_Substitutions = 0x20;

		/// <summary>
		/// Manager Options mask for setting/changing Fielder Positions.
		/// </summary>
		public readonly short ManagerOptions_FielderPositions = 0x40;
		#endregion

		#region Batting Practice Pitches
		/// <summary>
		/// Batting Practice Pitch mask for Offspeed.
		/// </summary>
		public readonly short BattingPracticePitch_Offspeed = 1;

		/// <summary>
		/// Batting Practice Pitch mask for Curveball.
		/// </summary>
		public readonly short BattingPracticePitch_Curveball = 2;

		/// <summary>
		/// Batting Practice Pitch mask for Fastball.
		/// </summary>
		public readonly short BattingPracticePitch_Fastball = 4;

		/// <summary>
		/// Batting Practice Pitch mask for Screwball.
		/// </summary>
		public readonly short BattingPracticePitch_Screwball = 8;

		/// <summary>
		/// Batting Practice Pitch mask for Sinker.
		/// </summary>
		public readonly short BattingPracticePitch_Sinker = 0x10;

		/// <summary>
		/// Batting Practice Pitch mask for Fastball! (the exclamation point matters)
		/// </summary>
		public readonly short BattingPracticePitch_FastballExc = 0x20;

		/// <summary>
		/// Batting Practice Pitch mask for Slider.
		/// </summary>
		public readonly short BattingPracticePitch_Slider = 0x40;

		/// <summary>
		/// Batting Practice Pitch mask for Knuckleball.
		/// </summary>
		public readonly short BattingPracticePitch_Knuckleball = 0x80;
		#endregion

		#region Sound Toggle Options
		/// <summary>
		/// Sound Toggle mask for Sound Effects.
		/// </summary>
		public readonly short SoundToggle_Effects = 1;

		/// <summary>
		/// Sound Toggle mask for Crowd sounds.
		/// </summary>
		public readonly short SoundToggle_Crowd = 2;

		/// <summary>
		/// Sound Toggle mask for Surround Sound mode.
		/// </summary>
		public readonly short SoundToggle_SurroundSound = 4;

		/// <summary>
		/// Welcome back to the game. I'm (the Sound Toggle mask for) Al Michaels.
		/// </summary>
		public readonly short SoundToggle_AlMichaels = 8;

		/// <summary>
		/// Sound Toggle mask for PA Echo effect.
		/// </summary>
		public readonly short SoundToggle_PaEcho = 0x10;

		/// <summary>
		/// Sound Toggle mask for Background Music.
		/// </summary>
		public readonly short SoundToggle_BGM = 0x20;
		#endregion

		#endregion

		/// <summary>
		/// Path to currently active league file.
		/// </summary>
		/// offset 0, 64 characters max
		public string CurLeagueFile;

		/// <summary>
		/// Team 1 Input Set (3=Keyboard 1, 4=Keyboard 2)
		/// </summary>
		/// offset 0x40
		public byte ControlSet1;

		/// <summary>
		/// Team 2 Input Set (3=Keyboard 1, 4=Keyboard 2)
		/// </summary>
		/// offset 0x41
		public byte ControlSet2;

		/// <summary>
		/// Team 1 control (0=CPU, 1=Human)
		/// </summary>
		/// offset 0x42
		public byte ControlTeam1;

		/// <summary>
		/// Team 2 control (0=CPU, 1=Human)
		/// </summary>
		/// offset 0x43
		public byte ControlTeam2;

		// todo: what's at 0x44-0x47??

		/// <summary>
		/// Exhibition Team 1 (Away)
		/// </summary>
		/// offset 0x48
		public byte ExhibitionTeam1;

		/// <summary>
		/// Exhibition Team 2 (Home)
		/// </summary>
		/// offset 0x49
		public byte ExhibitionTeam2;

		/// <summary>
		/// View options. (0 = none; 1 = Large Batter; 2 = Catcher + Umpire; 3 = both)
		/// </summary>
		/// offset 0x4A
		public short ViewOptions;

		// Level of Play values:
		// 0x4C/4E  0x4D/4F
		// FEDCBA98 76543210
		// |||||||| xxxxxxx|
		// ||||||||        +-- Player Ratings (0=off, 1=on)
		// |||||||+----------- Designated Hitter (0=off, 1=on)
		// ||||||+------------ Fielding Errors (0=off, 1=on)
		// |||||+------------- Injuries (0=off, 1=on)
		// ||||+-------------- Pitch to Center (0=off, 1=on)
		// |||+--------------- Pitching Crosshair (0=off, 1=on)
		// ||+---------------- Pitcher Fatigue (0=off, 1=on)
		// |+----------------- Fielding Marker (0=off, 1=on)
		// +------------------ Base Stealing (0=off, 1=on)

		/// <summary>
		/// "Level of Play" settings for Team 1.
		/// </summary>
		/// offset 0x4C
		public short PlayLevelSettings_Team1;

		/// <summary>
		/// "Level of Play" settings for Team 2.
		/// </summary>
		/// offset 0x4E
		public short PlayLevelSettings_Team2;

		// Manager Options values:
		// 0x50/52  0x51/53
		// FEDCBA98 76543210
		// x||||||| xxxxxxxx
		//  ||||||+----------- Pitching (disabled in one pitch mode)
		//  |||||+------------ Batting (disabled in one pitch mode)
		//  ||||+------------- Fielding
		//  |||+-------------- Throwing
		//  ||+--------------- Base Running
		//  |+---------------- Substitutions
		//  +----------------- Fielder Positions

		/// <summary>
		/// Manager Options for Team 1.
		/// </summary>
		/// offset 0x50
		public short ManagerSettings_Team1;

		/// <summary>
		/// Manager Options for Team 2.
		/// </summary>
		/// offset 0x52
		public short ManagerSettings_Team2;

		/// <summary>
		/// Team 1 Skill level.
		/// Lower values = easier for team; Higher values = harder for team.
		/// </summary>
		/// offset 0x54
		public short Skill_Team1;

		/// <summary>
		/// Team 2 Skill level.
		/// Lower values = easier for team; Higher values = harder for team.
		/// </summary>
		/// offset 0x56
		public short Skill_Team2;

		/// <summary>
		/// Game speed.
		/// </summary>
		/// offset 0x58
		public short GameSpeed;

		/// <summary>
		/// Batting Practice pitch types.
		/// </summary>
		/// offset 0x5A
		/// 0x5A     0x5B
		/// FEDCBA98 76543210
		/// |||||||| xxxxxxxx
		/// |||||||+----------- Offspeed
		/// ||||||+------------ Curveball
		/// |||||+------------- Fastball
		/// ||||+-------------- Screwball
		/// |||+--------------- Sinker
		/// ||+---------------- Fastball!
		/// |+----------------- Slider
		/// +------------------ Knuckleball
		public short BattingPractice_Pitches;

		/// <summary>
		/// Batting Practice pitch zone. (0=Center, 1=High/Low, 2=Inside/Outside, 3=Random)
		/// </summary>
		/// offset 0x5C
		public short BattingPractice_PitchZone;

		/// <summary>
		/// Display Mode (0=Pitcher view, 1=Batter view, 2=switch between Pitcher and Batter views)
		/// </summary>
		/// offset 0x5E
		public short DisplayMode;

		// todo: 0x60-0x63

		/// <summary>
		/// In-game sound options.
		/// </summary>
		/// offset 0x64
		/// First/least significant byte holds all useful values.
		/// All disabled = 0xC0; All enabled = 0xFF
		/// 
		/// 76543210
		/// 11||||||
		///   |||||+--- sound effects
		///   ||||+---- crowd
		///   |||+----- surround sound
		///   ||+------ Al Michaels
		///   |+------- PA Echo
		///   +-------- background music
		///
		/// Example values for first byte:
		/// 0xC1 = sound effects
		/// 0xC3 = sound effects and crowd
		/// 0xC7 = sound effects, crowd, surround sound
		/// 0xCF = sound effects, crowd, surround sound, al michaels
		/// 0xDF = sound effects, crowd, surround sound, al michaels, pa echo
		/// 0xEF = sound effects, crowd, surround sound, al michaels, background music
		public short SoundToggles;

		/// <summary>
		/// Home Run Derby Pitch Count. (0=3, 1=5, 2=10, 3=20)
		/// </summary>
		/// offset 0x66
		public short HomeRunDerbyPitchCount;

		/// <summary>
		/// If the most significant bit is set, One Pitch Mode is enabled.
		/// </summary>
		/// offset 0x68
		public short OnePitchMode;

		/// <summary>
		/// In-game Music Volume. (Different from the main music volume for some reason.)
		/// </summary>
		/// offset 0x6A
		public short GameMusicVolume;

		// todo: 0x6C-0x71

		/// <summary>
		/// Perform initial setup on game boot if zero.
		/// </summary>
		/// offset 0x72
		public short InitialSetup;

		/// <summary>
		/// Sound card type, as defined in DRVRLIST.BIN.
		/// </summary>
		/// offset 0x74
		public int SoundCard_Type;
		
		// todo: offset 0x78 possibly also a sound card-related int

		/// <summary>
		/// Sound card port.
		/// </summary>
		/// offset 0x7C
		public int SoundCard_Port;

		/// <summary>
		/// Sound card IRQ channel.
		/// </summary>
		/// offset 0x80
		public int SoundCard_IRQ;

		/// <summary>
		/// Sound card "high" DMA channel.
		/// </summary>
		/// offset 0x84
		public int SoundCard_DMA;

		// todo: 0x88-0x9B

		/// <summary>
		/// Main Sound volume.
		/// </summary>
		/// offset 0x9C
		public short SoundVolume;

		/// <summary>
		/// Main Music volume.
		/// </summary>
		/// offset 0x9E
		public short MusicVolume;

		// controller/joystick inputs are possibly somewhere in here

		#region Home Run Derby Scoreboard
		/// <summary>
		/// High score name for Home Run Derby - 3 Pitches.
		/// </summary>
		/// offset 0xB2
		public string HomeRunDerbyName_3;

		/// <summary>
		/// High score value for Home Run Derby - 3 Pitches.
		/// </summary>
		/// offset 0xC2
		public short HomeRunDerbyScore_3;

		/// <summary>
		/// High score name for Home Run Derby - 5 Pitches.
		/// </summary>
		/// offset 0xC4
		public string HomeRunDerbyName_5;

		/// <summary>
		/// High score value for Home Run Derby - 5 Pitches.
		/// </summary>
		/// offset 0xD4
		public short HomeRunDerbyScore_5;

		/// <summary>
		/// High score name for Home Run Derby - 10 Pitches.
		/// </summary>
		/// offset 0xD6
		public string HomeRunDerbyName_10;

		/// <summary>
		/// High score value for Home Run Derby - 10 Pitches.
		/// </summary>
		/// offset 0xE6
		public short HomeRunDerbyScore_10;

		/// <summary>
		/// High score name for Home Run Derby - 20 Pitches.
		/// </summary>
		/// offset 0xE8
		public string HomeRunDerbyName_20;

		/// <summary>
		/// High score value for Home Run Derby - 20 Pitches.
		/// </summary>
		/// offset 0xF8
		public short HomeRunDerbyScore_20;
		#endregion

		// todo: 0xFA-0xFB

		/// <summary>
		/// Team for Practice/Home Run Derby.
		/// </summary>
		/// offset 0xFC
		public byte PracticeTeam;

		#region Constructors
		/// <summary>
		/// Default constructor.
		/// </summary>
		public DefaultsBin()
		{
			CurLeagueFile = string.Empty;
			ControlSet1 = 0;
			ControlSet2 = 0;
			ControlTeam1 = 0;
			ControlTeam2 = 0;
			ExhibitionTeam1 = 0;
			ExhibitionTeam2 = 0;
			ViewOptions = 0;
			PlayLevelSettings_Team1 = 0;
			PlayLevelSettings_Team2 = 0;
			ManagerSettings_Team1 = 0;
			ManagerSettings_Team2 = 0;
			Skill_Team1 = 0;
			Skill_Team2 = 0;
			GameSpeed = 0;
			BattingPractice_Pitches = 0;
			BattingPractice_PitchZone = 0;
			DisplayMode = 0;
			SoundToggles = 0;
			HomeRunDerbyPitchCount = 0;
			OnePitchMode = 0;
			GameMusicVolume = 64;
			InitialSetup = 0;
			SoundCard_Type = 0;
			SoundCard_Port = 0x220;
			SoundCard_IRQ = 7;
			SoundCard_DMA = 5;
			SoundVolume = 64;
			MusicVolume = 64;
			HomeRunDerbyName_3 = string.Empty;
			HomeRunDerbyScore_3 = 0;
			HomeRunDerbyName_5 = string.Empty;
			HomeRunDerbyScore_5 = 0;
			HomeRunDerbyName_10 = string.Empty;
			HomeRunDerbyScore_10 = 0;
			HomeRunDerbyName_20 = string.Empty;
			HomeRunDerbyScore_20 = 0;
			PracticeTeam = 0;
		}

		/// <summary>
		/// Constructor using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public DefaultsBin(BinaryReader br)
		{
			ReadData(br);
		}
		#endregion

		/// <summary>
		/// Read DEFAULTS.BIN data using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public void ReadData(BinaryReader br)
		{
			// loaded league string
			bool _nameDone = false;
			for (int i = 0; i < DEFAULTS_LEAGUE_PATH_MAX; i++)
			{
				char c = br.ReadChar();

				if (c == 0 && !_nameDone)
				{
					_nameDone = true;
				}

				if (c != 0 && !_nameDone)
				{
					CurLeagueFile += c;
				}
			}

			ControlSet1 = br.ReadByte();
			ControlSet2 = br.ReadByte();
			ControlTeam1 = br.ReadByte();
			ControlTeam2 = br.ReadByte();

			// todo: offsets 0x44-0x47

			br.BaseStream.Seek(0x48, SeekOrigin.Begin);
			ExhibitionTeam1 = br.ReadByte();
			ExhibitionTeam2 = br.ReadByte();
			ViewOptions = BitConverter.ToInt16(br.ReadBytes(2), 0);
			PlayLevelSettings_Team1 = BitConverter.ToInt16(br.ReadBytes(2), 0);
			PlayLevelSettings_Team2 = BitConverter.ToInt16(br.ReadBytes(2), 0);
			ManagerSettings_Team1 = BitConverter.ToInt16(br.ReadBytes(2), 0);
			ManagerSettings_Team2 = BitConverter.ToInt16(br.ReadBytes(2), 0);
			Skill_Team1 = BitConverter.ToInt16(br.ReadBytes(2), 0);
			Skill_Team2 = BitConverter.ToInt16(br.ReadBytes(2), 0);
			GameSpeed = BitConverter.ToInt16(br.ReadBytes(2), 0);
			BattingPractice_Pitches = BitConverter.ToInt16(br.ReadBytes(2), 0);
			BattingPractice_PitchZone = BitConverter.ToInt16(br.ReadBytes(2), 0);
			DisplayMode = BitConverter.ToInt16(br.ReadBytes(2), 0);

			// todo: 0x60-0x63

			br.BaseStream.Seek(0x64, SeekOrigin.Begin);
			SoundToggles = BitConverter.ToInt16(br.ReadBytes(2), 0);
			HomeRunDerbyPitchCount = BitConverter.ToInt16(br.ReadBytes(2), 0);
			OnePitchMode = BitConverter.ToInt16(br.ReadBytes(2), 0);
			GameMusicVolume = BitConverter.ToInt16(br.ReadBytes(2), 0);

			// todo: 0x6C-0x71

			br.BaseStream.Seek(0x72, SeekOrigin.Begin);
			InitialSetup = BitConverter.ToInt16(br.ReadBytes(2), 0);
			SoundCard_Type = BitConverter.ToInt32(br.ReadBytes(4), 0);

			// todo: 0x78 is possibly another sound card related int

			br.BaseStream.Seek(0x7C, SeekOrigin.Begin);
			SoundCard_Port = BitConverter.ToInt32(br.ReadBytes(4), 0);
			SoundCard_IRQ = BitConverter.ToInt32(br.ReadBytes(4), 0);
			SoundCard_DMA = BitConverter.ToInt32(br.ReadBytes(4), 0);

			// todo: 0x88-0x9B

			// skip to next area
			br.BaseStream.Seek(0x9C,SeekOrigin.Begin);
			SoundVolume = BitConverter.ToInt16(br.ReadBytes(2), 0);
			MusicVolume = BitConverter.ToInt16(br.ReadBytes(2), 0);

			// todo: 0xA0-0xB1

			// skip to home run area
			br.BaseStream.Seek(0xB2,SeekOrigin.Begin);
			// name 3
			_nameDone = false;
			for (int i = 0; i < HOME_RUN_DERBY_NAME_LENGTH; i++)
			{
				char c = br.ReadChar();

				if (c == 0 && !_nameDone)
				{
					_nameDone = true;
				}

				if (c != 0 && !_nameDone)
				{
					HomeRunDerbyName_3 += c;
				}
			}
			// score 3
			HomeRunDerbyScore_3 = BitConverter.ToInt16(br.ReadBytes(2), 0);

			// name 5
			_nameDone = false;
			for (int i = 0; i < HOME_RUN_DERBY_NAME_LENGTH; i++)
			{
				char c = br.ReadChar();

				if (c == 0 && !_nameDone)
				{
					_nameDone = true;
				}

				if (c != 0 && !_nameDone)
				{
					HomeRunDerbyName_5 += c;
				}
			}
			// score 5
			HomeRunDerbyScore_5 = BitConverter.ToInt16(br.ReadBytes(2), 0);

			// name 10
			_nameDone = false;
			for (int i = 0; i < HOME_RUN_DERBY_NAME_LENGTH; i++)
			{
				char c = br.ReadChar();

				if (c == 0 && !_nameDone)
				{
					_nameDone = true;
				}

				if (c != 0 && !_nameDone)
				{
					HomeRunDerbyName_10 += c;
				}
			}
			// score 10
			HomeRunDerbyScore_10 = BitConverter.ToInt16(br.ReadBytes(2), 0);

			// name 20
			_nameDone = false;
			for (int i = 0; i < HOME_RUN_DERBY_NAME_LENGTH; i++)
			{
				char c = br.ReadChar();

				if (c == 0 && !_nameDone)
				{
					_nameDone = true;
				}

				if (c != 0 && !_nameDone)
				{
					HomeRunDerbyName_20 += c;
				}
			}
			// score 20
			HomeRunDerbyScore_20 = BitConverter.ToInt16(br.ReadBytes(2), 0);

			// PracticeTeam at 0xFC
			br.BaseStream.Seek(0xFC, SeekOrigin.Begin);
			PracticeTeam = br.ReadByte();
		}
	}
}
