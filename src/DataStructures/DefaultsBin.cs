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
		/// <summary>
		/// Maximum length of path to current league file.
		/// </summary>
		public static readonly int DEFAULTS_LEAGUE_PATH_MAX = 64;

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

		/// <summary>
		/// Path to currently active league file.
		/// </summary>
		/// offset 0, 64 characters max
		public string CurLeagueFile;

		// controller/joystick inputs are possibly somewhere in here

		/// <summary>
		/// exhibition team 1?
		/// </summary>
		/// offset 0x48
		public byte ExhibitionTeam1;

		/// <summary>
		/// exhibition team 2?
		/// </summary>
		/// offset 0x49
		public byte ExhibitionTeam2;

		// offset 0x4A (short?): large batter (1) and ump/catcher view (2), or 3 for both

		// offset 0x4C (short): team 1 "level of play" settings
		public short PlayLevelSettings_Team1;

		// offset 0x4E (short): team 2 "level of play" settings
		public short PlayLevelSettings_Team2;

		// offset 0x50 (short): team 1 manager settings
		public short ManagerSettings_Team1;

		// offset 0x52 (short): team 2 manager settings
		public short ManagerSettings_Team2;

		// offset 0x54 (short?): team 1 skill?
		public short Skill_Team1;

		// offset 0x56 (short?): team 2 skill?
		public short Skill_Team2;

		// offset 0x58 (short?): game speed?

		// offset 0x5A (byte? short?): batting practice pitch types
		// todo: map out values

		// offset 0x5C (byte? short?): batting practice pitch zone (0=center, 1=, 2=, 3=random)

		// offset 0x5E (short?): display mode? 0=pitcher, 1=batter, 2=pitcher/batter

		// offset 0x64: in-game sound options; all disabled = 0xC0, all enabled = 0xFF
		// 0xC1 = sound effects
		// 0xC3 = sound effects and crowd
		// 0xC7 = sound effects, crowd, surround sound
		// 0xCF = sound effects, crowd, surround sound, al michaels
		// 0xDF = sound effects, crowd, surround sound, al michaels, pa echo
		// 0xEF = sound effects, crowd, surround sound, al michaels, background music
		// 76543210
		// 11||||||
		//   |||||+--- sound effects
		//   ||||+---- crowd
		//   |||+----- surround sound
		//   ||+------ Al Michaels
		//   |+------- PA Echo
		//   +-------- background music

		/// <summary>
		/// Home Run Derby Pitch Count. (0=3, 1=5, 2=10, 3=20)
		/// </summary>
		/// offset 0x66
		public short HomeRunDerbyPitchCount;

		// offset 0x68 (short): if most significant bit is set, One Pitch Mode is enabled

		// offset 0x6A (short?): in-game music volume

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

		/// <summary>
		/// Team for Practice/Home Run Derby
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
			ExhibitionTeam1 = 0;
			ExhibitionTeam2 = 0;
			PlayLevelSettings_Team1 = 0;
			PlayLevelSettings_Team2 = 0;
			ManagerSettings_Team1 = 0;
			ManagerSettings_Team2 = 0;
			Skill_Team1 = 0;
			Skill_Team2 = 0;
			HomeRunDerbyPitchCount = 0;
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

		public DefaultsBin(BinaryReader br)
		{
			ReadData(br);
		}
		#endregion

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

			// todo: everything from 0x40-0x9B

			br.BaseStream.Seek(0x48, SeekOrigin.Begin);
			ExhibitionTeam1 = br.ReadByte();
			ExhibitionTeam2 = br.ReadByte();

			br.BaseStream.Seek(0x4C, SeekOrigin.Begin);
			PlayLevelSettings_Team1 = BitConverter.ToInt16(br.ReadBytes(2), 0);
			PlayLevelSettings_Team2 = BitConverter.ToInt16(br.ReadBytes(2), 0);
			ManagerSettings_Team1 = BitConverter.ToInt16(br.ReadBytes(2), 0);
			ManagerSettings_Team2 = BitConverter.ToInt16(br.ReadBytes(2), 0);
			Skill_Team1 = BitConverter.ToInt16(br.ReadBytes(2), 0);
			Skill_Team2 = BitConverter.ToInt16(br.ReadBytes(2), 0);

			br.BaseStream.Seek(0x66, SeekOrigin.Begin);
			HomeRunDerbyPitchCount = BitConverter.ToInt16(br.ReadBytes(2), 0);

			// skip to next area
			br.BaseStream.Seek(0x9C,SeekOrigin.Begin);
			SoundVolume = BitConverter.ToInt16(br.ReadBytes(2), 0);
			MusicVolume = BitConverter.ToInt16(br.ReadBytes(2), 0);

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

			// todo PracticeTeam at 0xFC
			br.BaseStream.Seek(0xFC, SeekOrigin.Begin);
			PracticeTeam = br.ReadByte();
		}
	}
}
