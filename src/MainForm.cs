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
				string errorMsg;
				if (!OpenFile(ofd.FileName, out errorMsg))
				{
					MessageBox.Show(errorMsg, "HB5Tool", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		/// <summary>
		/// The large routine that handles file opening.
		/// </summary>
		/// <param name="_filePath">Path to file to open.</param>
		private bool OpenFile(string _filePath, out string errorMsg)
		{
			bool openSuccessful = false;
			errorMsg = string.Empty;

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
						openSuccessful = true;
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
						openSuccessful = true;
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
							openSuccessful = true;
						}
						else
						{
							errorMsg = "This does not appear to be a HardBall 5 league file.";
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
						openSuccessful = true;
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
						openSuccessful = true;
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
						openSuccessful = true;
					}
					break;

				case ".hlr":
					{
						// .hlr file = highlight reel; not much study on this yet
						errorMsg = "Highlight Reels are not supported at this time.";
					}
					break;

				case ".sav":
					{
						// .sav file = game save; not much study on this yet
						errorMsg = "Saved Games are not supported at this time.";
					}
					break;

				case ".lgr":
					{
						// .lgr file = league saved game? saved in a directory matching the league filename
						errorMsg = "LGR files are not supported at this time.";
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
							openSuccessful = true;
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
								openSuccessful = true;
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
								openSuccessful = true;
							}

							// DEFAULTS.BIN, DEF_D.BIN
							if (fnNoExt.Equals("defaults") || fnNoExt.StartsWith("def_"))
							{
								DefaultsBinEditor dbEd = new DefaultsBinEditor(_filePath);
								dbEd.MdiParent = this;
								dbEd.CloseFormCallback += MdiChild_CloseFormCallback;
								dbEd.Show();
								UpdateWindowMenu();
								binFileHandled = true;
								openSuccessful = true;
							}

							// INSTVARS.BIN
							if (fnNoExt.Equals("instvars"))
							{
								InstvarsEditor ivEd = new InstvarsEditor(_filePath);
								ivEd.MdiParent = this;
								ivEd.CloseFormCallback += MdiChild_CloseFormCallback;
								ivEd.Show();
								UpdateWindowMenu();
								binFileHandled = true;
								openSuccessful = true;
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
								errorMsg = "gluelist handling is broken right now";
								binFileHandled = true;
							}

							// audio data{
							// DIGS.BIN, TEAMSDIG.BIN
							if (fnNoExt.Equals("digs") || fnNoExt.Equals("teamsdig"))
							{
								DigsEditor digEm = new DigsEditor(_filePath);
								digEm.MdiParent = this;
								digEm.CloseFormCallback += MdiChild_CloseFormCallback;
								digEm.Show();
								UpdateWindowMenu();
								binFileHandled = true;
								openSuccessful = true;
							}

							// WORDS.BIN
							if (fnNoExt.Equals("words"))
							{
								WordsBinEditor wordEd = new WordsBinEditor(_filePath);
								wordEd.MdiParent = this;
								wordEd.CloseFormCallback += MdiChild_CloseFormCallback;
								wordEd.Show();
								UpdateWindowMenu();
								binFileHandled = true;
								openSuccessful = true;
							}
							// }

							// ANNOUNCE.BIN
							if (fnNoExt.Equals("announce"))
							{
								AnnounceBinEditor abEd = new AnnounceBinEditor(_filePath);
								abEd.MdiParent = this;
								abEd.CloseFormCallback += MdiChild_CloseFormCallback;
								abEd.Show();
								UpdateWindowMenu();
								binFileHandled = true;
								openSuccessful = true;
							}

							// INFO*.BIN // where * is a number; stadium information
							if (fnNoExt.StartsWith("info"))
							{
								StadiumInfoEditor stadEd = new StadiumInfoEditor(_filePath);
								stadEd.MdiParent = this;
								stadEd.CloseFormCallback += MdiChild_CloseFormCallback;
								stadEd.Show();
								UpdateWindowMenu();
								binFileHandled = true;
								openSuccessful = true;
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
									schEd.CloseFormCallback += MdiChild_CloseFormCallback;
									schEd.Show();
									UpdateWindowMenu();
									binFileHandled = true;
									openSuccessful = true;
								}
								else
								{
									errorMsg = "Invalid schedule type??";
									binFileHandled = true;
								}
							}

							// PICS.BIN
							if (fnNoExt.Equals("pics"))
							{
								PicsEditor pEd = new PicsEditor(_filePath);
								pEd.MdiParent = this;
								pEd.CloseFormCallback += MdiChild_CloseFormCallback;
								pEd.Show();
								UpdateWindowMenu();
								binFileHandled = true;
								openSuccessful = true;
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
								openSuccessful = true;
							}

							// these files make up a full league:
							// {
							// LGINFO*.BIN
							if (fnNoExt.StartsWith("lginfo"))
							{
								errorMsg = "LGINFO not yet handled";
								binFileHandled = true; // don't double msg
							}

							// BAT*.BIN; this covers BAT1.BIN, BAT2.BIN, BATH1.BIN, BATH2.BIN
							if (fnNoExt.StartsWith("bat"))
							{
								// important to note difference between BAT and BATH
								if (fnNoExt.StartsWith("bath"))
								{
									// historical batter stats, as found in a league.
									errorMsg = "BATH not yet handled";
									binFileHandled = true; // don't double msg
								}
								else
								{
									// regular batter info, as found in a league.
									errorMsg = "BAT not yet handled";
									binFileHandled = true; // don't double msg
								}
							}

							// PIT*.BIN; this covers PIT1.BIN, PIT2.BIN, PITH1.BIN, PITH2.BIN
							if (fnNoExt.StartsWith("pit"))
							{
								// important to note difference between PIT and PITH
								if (fnNoExt.StartsWith("pith"))
								{
									// historical pitcher stats, as found in a league.
									errorMsg = "PITH not yet handled";
									binFileHandled = true; // don't double msg
								}
								else
								{
									// regular pitcher info, as found in a league.
									errorMsg = "PIT not yet handled";
									binFileHandled = true; // don't double msg
								}
							}

							// TEAMS*.BIN // where * is "1" or "2"
							if (fnNoExt.StartsWith("teams") && !fnNoExt.Contains("teamsdig"))
							{
								errorMsg = "TEAMS not yet handled";
								binFileHandled = true; // don't double msg
							}
							// }

							if (!binFileHandled)
							{
								errorMsg = "Unsupported .bin file; there are too many files with .bin as the extension, and they all have different formats.";
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
						aEd = new ArchiveEditor(_filePath, fnNoExt.Contains("_psx"));

						aEd.MdiParent = this;
						aEd.CloseFormCallback += MdiChild_CloseFormCallback;
						aEd.Show();
						UpdateWindowMenu();
						openSuccessful = true;
					}
					break;

				default:
					errorMsg = string.Format("Whatever format this is ({0}), it's currently unsupported.", Path.GetExtension(_filePath).ToLower());
					break;
			}

			return openSuccessful;
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
					List<string> ErrorMessages = new List<string>();
					string errorMsg = string.Empty;
					foreach (string _file in files)
					{
						if (!OpenFile(_file, out errorMsg))
						{
							ErrorMessages.Add(string.Format("{0}: {1}", Path.GetFileName(_file), errorMsg));
						}
					}
					if (ErrorMessages.Count > 0)
					{
						StringBuilder sb = new StringBuilder();
						sb.AppendLine(string.Format("Errors occured when opening {0} file(s):", ErrorMessages.Count));
						foreach (string err in ErrorMessages)
						{
							sb.AppendLine(err);
						}
						MessageBox.Show(sb.ToString(),"HB5Tool",MessageBoxButtons.OK,MessageBoxIcon.Error);
					}
					return;
				}
				else
				{
					string errorMsg;
					if (!OpenFile(files[0], out errorMsg))
					{
						MessageBox.Show(errorMsg, "HB5Tool", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
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

		private void manualToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Manual has not yet been written, mainly because the program is not that useful for people who aren't freem.");
		}
	}
}
