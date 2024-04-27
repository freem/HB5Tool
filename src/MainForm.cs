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
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
			UpdateWindowMenu();
		}

		public void UpdateWindowMenu()
		{
			windowToolStripMenuItem.Visible = MdiChildren.Length > 0;
		}

		private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			AboutBox a = new AboutBox();
			a.ShowDialog();
		}

		private void openToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Title = "Open File";
			ofd.Filter = SharedStrings.GeneralFilter;
			ofd.Multiselect = false;
			if (ofd.ShowDialog() == DialogResult.OK)
			{
				OpenFile(ofd.FileName);
			}
		}

		/// <summary>
		/// The large routine that handles file opening.
		/// </summary>
		/// <param name="_filePath">Path to file to open.</param>
		private void OpenFile(string _filePath)
		{
			switch (Path.GetExtension(_filePath).ToLower())
			{
				case ".btr":
				case ".pit":
					{
						// exported batter or pitcher
						PlayerEditor pEd = new PlayerEditor(PlayerEditor.PlayerDataSources.PlayerExport, _filePath);
						pEd.MdiParent = this;
						pEd.CloseFormCallback += MdiChild_CloseFormCallback;
						pEd.Show();
						UpdateWindowMenu();
					}
					break;

				case ".hb5":
					{
						// exported team
						TeamEditor tEd = new TeamEditor(TeamEditor.TeamDataSources.TeamExport, _filePath);
						tEd.MdiParent = this;
						tEd.CloseFormCallback += MdiChild_CloseFormCallback;
						tEd.Show();
						UpdateWindowMenu();
					}
					break;

				case ".lgd":
					{
						// league

						// make sure this is a hardball 5 league
						bool hb5League = false;
						using (FileStream tempFS = new FileStream(_filePath, FileMode.Open))
						{
							using (BinaryReader tempBR = new BinaryReader(tempFS))
							{
								byte[] _hdr = tempBR.ReadBytes(4);
								if (_hdr[0] == LeagueData.HB5_LEAGUE_HEADER[0] && _hdr[1] == LeagueData.HB5_LEAGUE_HEADER[1]
									&& _hdr[2] == LeagueData.HB5_LEAGUE_HEADER[2] && _hdr[3] == LeagueData.HB5_LEAGUE_HEADER[3])
								{
									hb5League = true;
								}
							}
						}

						if (hb5League)
						{
							LeagueEditor lEd = new LeagueEditor(_filePath);
							lEd.MdiParent = this;
							lEd.CloseFormCallback += MdiChild_CloseFormCallback;
							lEd.Show();
							UpdateWindowMenu();
						}
						else
						{
							MessageBox.Show("This does not appear to be a HardBall 5 league file.","HB5Tool",MessageBoxButtons.OK,MessageBoxIcon.Error);
						}
					}
					break;

				case ".msh":
					{
						// .msh file
						MshEditor mEd = new MshEditor(_filePath);
						mEd.MdiParent = this;
						mEd.CloseFormCallback += MdiChild_CloseFormCallback;
						mEd.Show();
						UpdateWindowMenu();
					}
					break;

				case ".mgs":
					{
						// .mgs file
						MgsEditor mEd = new MgsEditor(_filePath);
						mEd.MdiParent = this;
						mEd.CloseFormCallback += MdiChild_CloseFormCallback;
						mEd.Show();
						UpdateWindowMenu();
					}
					break;

				// note: PFN is slightly different, so don't use it here
				case ".fnt":
					{
						// .fnt file
						FontEditor fEd = new FontEditor(_filePath);
						fEd.MdiParent = this;
						fEd.CloseFormCallback += MdiChild_CloseFormCallback;
						fEd.Show();
						UpdateWindowMenu();
					}
					break;

				case ".hlr":
					{
						// .hlr file = highlight reel; not much study on this yet
						MessageBox.Show("Highlight Reels are not supported at this time.","HB5Tool",MessageBoxButtons.OK,MessageBoxIcon.Error);
					}
					break;

				case ".sav":
					{
						// .sav file = game save; not much study on this yet
						MessageBox.Show("Saved Games are not supported at this time.", "HB5Tool", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
					break;

				case ".lgr":
					{
						// .lgr file = league saved game? saved in a directory matching the league filename
						MessageBox.Show("LGR files are not supported at this time.", "HB5Tool", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
					break;

				// todo: handle .bio files? (renamed .bin files)

				case ".bin":
					// non-obvious, need to see if first two bytes are ASCII "MB"
					{
						bool isArchive = false;
						using (FileStream tempFS = new FileStream(_filePath, FileMode.Open))
						{
							using (BinaryReader tempBR = new BinaryReader(tempFS))
							{
								byte[] _hdr = tempBR.ReadBytes(2);
								if (_hdr[0] == GlueMB.GLUE_HEADER[0] && _hdr[1] == GlueMB.GLUE_HEADER[1])
								{
									isArchive = true;
								}
							}
						}

						if (isArchive)
						{
							ArchiveEditor aEd = new ArchiveEditor(_filePath);
							aEd.MdiParent = this;
							aEd.CloseFormCallback += MdiChild_CloseFormCallback;
							aEd.Show();
							UpdateWindowMenu();
						}
						else
						{
							// Congrats, you have one of many possible files! You'll need to check the filename.
							// This is a terrible way of doing things, since it restricts what you can open.

							// Note: .bio is NOT handled here, nor should be... which makes it a pain

							string fnNoExt = Path.GetFileNameWithoutExtension(_filePath).ToLower();
							bool binFileHandled = false;

							// some names are straightforward, while others are not.

							// LOGOFILE.BIN
							if (fnNoExt.Equals("logofile"))
							{
								LogoFileEditor logoEd = new LogoFileEditor(_filePath);
								logoEd.MdiParent = this;
								logoEd.CloseFormCallback += MdiChild_CloseFormCallback;
								logoEd.Show();
								UpdateWindowMenu();
								binFileHandled = true;
							}

							// CUSTOM.BIN, CUSTOM_D.BIN
							if (fnNoExt.StartsWith("custom"))
							{
								// custom.bin editor
								CustomBinEditor cbEd = new CustomBinEditor(_filePath);
								cbEd.MdiParent = this;
								cbEd.CloseFormCallback += MdiChild_CloseFormCallback;
								cbEd.Show();
								UpdateWindowMenu();
								binFileHandled = true;
							}

							// DEFAULTS.BIN, DEF_D.BIN
							if (fnNoExt.Equals("defaults") || fnNoExt.StartsWith("def_"))
							{
								DefaultsBinEditor dbEd = new DefaultsBinEditor(_filePath);
								dbEd.MdiParent = this;
								dbEd.Show();
								UpdateWindowMenu();
								binFileHandled = true;
							}

							// INSTVARS.BIN
							if (fnNoExt.Equals("instvars"))
							{
								// installation variables
							}

							// GLUELIST.BIN
							if (fnNoExt.Equals("gluelist"))
							{
								/*
								GlueListEditor glEd = new GlueListEditor(_filePath);
								glEd.MdiParent = this;
								glEd.Show();
								UpdateWindowMenu();
								binFileHandled = true;
								*/
								MessageBox.Show("gluelist handling is broken right now","HB5Tool",MessageBoxButtons.OK,MessageBoxIcon.Error);
								binFileHandled = true;
							}

							// audio data{
							// DIGS.BIN, TEAMSDIG.BIN
							if (fnNoExt.Equals("digs") || fnNoExt.Equals("teamsdig"))
							{
								DigsEditor digEm = new DigsEditor(_filePath);
								digEm.MdiParent = this;
								digEm.Show();
								UpdateWindowMenu();
								binFileHandled = true;
							}

							// WORDS.BIN
							if (fnNoExt.Equals("words"))
							{
								// this one is a pain
							}
							// }

							// ANNOUNCE.BIN
							if (fnNoExt.Equals("announce"))
							{
								AnnounceBinEditor abEd = new AnnounceBinEditor(_filePath);
								abEd.MdiParent = this;
								//abEd.CloseFormCallback += MdiChild_CloseFormCallback;
								abEd.Show();
								UpdateWindowMenu();
								binFileHandled = true;
							}

							// INFO*.BIN // where * is a number; stadium information
							if (fnNoExt.StartsWith("info"))
							{
							}

							// GRASS0.BIN
							// DIRT.BIN

							// _SC*.BIN, where * is a combination of ("FILE" or "OT") and a number 0-2
							if (fnNoExt.StartsWith("_sc"))
							{
								// schedule files.
								// original HB5, 162 game patch, and HB5 Enhanced all differ in  _SCFILE0.BIN

								// determine league type and length from filename
								ScheduleFile.ScheduleLeagueTypes schType = ScheduleFile.ScheduleLeagueTypes.Invalid;
								if (fnNoExt.Contains("file"))
								{
									schType = ScheduleFile.ScheduleLeagueTypes.MLBPA;
								}
								else if (fnNoExt.Contains("ot")) // "old-timers"?
								{
									schType = ScheduleFile.ScheduleLeagueTypes.Legends;
								}

								if (schType != ScheduleFile.ScheduleLeagueTypes.Invalid)
								{
									// grab the number
									ScheduleFile.ScheduleLengthTypes schLength = (ScheduleFile.ScheduleLengthTypes)Convert.ToInt32(fnNoExt.Substring(fnNoExt.Length - 1));

									ScheduleEditor schEd = new ScheduleEditor(_filePath, schType, schLength);
									schEd.MdiParent = this;
									schEd.Show();
									UpdateWindowMenu();
									binFileHandled = true;
								}
							}

							// PICS.BIN
							if (fnNoExt.Equals("pics"))
							{
								PicsEditor pEd = new PicsEditor(_filePath);
								pEd.MdiParent = this;
								//pEd.CloseFormCallback += MdiChild_CloseFormCallback;
								pEd.Show();
								UpdateWindowMenu();
								binFileHandled = true;
							}

							// SONG*.BIN // essentially "is this a .wav file or not?"
							if (fnNoExt.StartsWith("song"))
							{
								byte[] hdr;
								using (FileStream tempFS = new FileStream(_filePath, FileMode.Open))
								{
									using (BinaryReader tempBR = new BinaryReader(tempFS))
									{
										hdr = tempBR.ReadBytes(4);
									}
								}

								// "RIFF" = wav file
								if (hdr[0] == 0x52 && hdr[1] == 0x49 && hdr[2] == 0x46 && hdr[3] == 0x46)
								{
									MessageBox.Show(string.Format("{0} is a .wav file.", _filePath), "HB5Tool", MessageBoxButtons.OK, MessageBoxIcon.Information);
								}
								// anything else is presumed to be HMI ADPCM
								else
								{
									// todo: is this actually ADPCM or regular PCM? (file offset 0)
									MessageBox.Show(string.Format("{0} is a HMI ADPCM file.", _filePath), "HB5Tool", MessageBoxButtons.OK, MessageBoxIcon.Information);
								}
								binFileHandled = true;
							}

							// these files make up a full league:
							// {
							// LGINFO*.BIN
							if (fnNoExt.StartsWith("lginfo"))
							{
							}

							// BAT*.BIN; this covers BAT1.BIN, BAT2.BIN, BATH1.BIN, BATH2.BIN
							if (fnNoExt.StartsWith("bat"))
							{
								// important to note difference between BAT and BATH
								if (fnNoExt.StartsWith("bath"))
								{
									// historical batter stats, as found in a league.
								}
								else
								{
									// regular batter info, as found in a league.
								}
							}

							// PIT*.BIN; this covers PIT1.BIN, PIT2.BIN, PITH1.BIN, PITH2.BIN
							if (fnNoExt.StartsWith("pit"))
							{
								// important to note difference between PIT and PITH
								if (fnNoExt.StartsWith("pith"))
								{
									// historical pitcher stats, as found in a league.
								}
								else
								{
									// regular pitcher info, as found in a league.
								}
							}

							// TEAMS*.BIN // where * is "1" or "2"
							if (fnNoExt.StartsWith("teams"))
							{
							}
							// }

							if (!binFileHandled)
							{
								MessageBox.Show("This .bin file is currently unsupported; there are too many files with .bin as the extension, and they all have different formats.", "HB5Tool");
							}
						}
					}
					break;

				case ".glu":
					{
						// Glue file. This extension only appears in the PS1 version of HardBall 5.
						// It also appears in previous HardBall games (e.g. HardBall 4 demo version).

						string fnNoExt = Path.GetFileNameWithoutExtension(_filePath).ToLower();
						ArchiveEditor aEd;
						// the assumption is that all .glu files with "_PSX" in the filename are the PS1 version.
						if (fnNoExt.Contains("_psx"))
						{
							// PS1 .glu file
							aEd = new ArchiveEditor(_filePath, true);
						}
						else
						{
							// standard .glu file
							aEd = new ArchiveEditor(_filePath);
						}

						aEd.MdiParent = this;
						aEd.CloseFormCallback += MdiChild_CloseFormCallback;
						aEd.Show();
						UpdateWindowMenu();
					}
					break;

				default:
					MessageBox.Show(string.Format("Whatever format this is ({0}), it's currently unsupported.", Path.GetExtension(_filePath).ToLower()), "HB5Tool");
					break;
			}
		}

		private void MdiChild_CloseFormCallback(object sender, EventArgs e)
		{
			if (MdiChildren.Length == 1)
			{
				// bullshit hack
				windowToolStripMenuItem.Visible = false;
			}
			else
			{
				UpdateWindowMenu();
			}
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void filenameDecodeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			QuickDecode qd = new QuickDecode();
			qd.MdiParent = this;
			qd.Show();
		}

		private void programOptionsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ProgOptionsDialog pod = new ProgOptionsDialog();
			if (pod.ShowDialog() == DialogResult.OK)
			{
				Properties.Settings.Default.HB5InstallDir = pod.Hb5InstallPath;
				Properties.Settings.Default.LeagueOverridePath = pod.LeagueOverridePath;
				Properties.Settings.Default.Save();
			}
		}

		private void MainForm_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				e.Effect = DragDropEffects.Copy;
			}
			else
			{
				e.Effect = DragDropEffects.None;
			}
		}

		private void MainForm_DragDrop(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
				if (files.Length > 1)
				{
					MessageBox.Show("I'll add opening multiple files later.","HB5Tool");
					return;
				}
				OpenFile(files[0]);
			}
		}

		private void imageTestToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Title = "Convert PNG to Team Logo";
			ofd.Filter = SharedStrings.PngFilter;
			ofd.Multiselect = false;
			if (ofd.ShowDialog() == DialogResult.OK)
			{
				TeamLogo tempLogo = new TeamLogo();
				tempLogo.PixelData = new byte[TeamLogo.LOGO_WIDTH*TeamLogo.LOGO_HEIGHT];
				tempLogo.ImportImage(ofd.FileName);
				using (FileStream fs = new FileStream(string.Format("{0}.hb5logo", Path.GetFileNameWithoutExtension(ofd.FileName)),FileMode.Create))
				{
					using (BinaryWriter bw = new BinaryWriter(fs))
					{
						tempLogo.WriteData(bw);
					}
				}
			}
		}
	}
}
