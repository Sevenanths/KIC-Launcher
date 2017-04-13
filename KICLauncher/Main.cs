using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Media;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace KICLauncher
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private enum CursorType
        {
            KIC,
            BBC
        }

        private enum ResolutionIniFileActions
        {
            Create,
            Destroy
        }

        // Declare a few variables for easy use
        private static string ApplicationPath = Application.StartupPath;
        private string ResolutionIniFilePath = ApplicationPath + "/resolution.ini";
        private string GameCustomD3D9LibraryPath = ApplicationPath + "/d3d9.dll";
        private string SelfCustomD3D9LibraryPath = ApplicationPath + "/res/d3d9.dll";
        private string BBCCursorFilePath = ApplicationPath + "/res/bbccursor.cur";
        private string KicCursorFilePath = ApplicationPath + "/res/cursor.cur";
        private string KicLauncherConfigFilePath = ApplicationPath + "/KICLauncher.cfg";
        private string GameOfflineExecutablePath = ApplicationPath + "/Offline.exe";
        private string KicGameQuickLoginBatFilePath = ApplicationPath + "/quicklogin.bat";
        private bool EnableHD = false;
        private bool KicMode = false;

        // http://stackoverflow.com/a/4306984
        private static class NativeMethods
        {
            public static Cursor LoadCustomCursor(string path)
            {
                IntPtr hCurs = LoadCursorFromFile(path);
                if (hCurs == IntPtr.Zero) throw new Win32Exception();
                var curs = new Cursor(hCurs);
                // Note: force the cursor to own the handle so it gets released properly
                var fi = typeof(Cursor).GetField("ownHandle", BindingFlags.NonPublic | BindingFlags.Instance);
                fi.SetValue(curs, true);
                return curs;
            }
            [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
            private static extern IntPtr LoadCursorFromFile(string path);
        }

        private void Main_Load(object sender, EventArgs e)
        {
            // Set a custom cursor for that authentic KIC feeling
            SetGameBranding();
            LoadResolutionIniFile();
        }

        private void SetGameBranding()
        {
            // Depending on the contents of the configuration file, we change the branding for the application
            if (!File.Exists(KicLauncherConfigFilePath))
            {
                File.WriteAllText(KicLauncherConfigFilePath, "CBBC");
            }

            string GameBrand = File.ReadAllText(KicLauncherConfigFilePath);
            switch (GameBrand)
            {
                case "KETNET":
                    // We change the lay-out completely for KetnetKick because it has a different overall style
                    pbxLogo.Image = Properties.Resources.BGH_kic;
                    pbxLogo.Size = new System.Drawing.Size(775, 370);
                    this.BackgroundImage = Properties.Resources.kic_bg;
                    // Start button
                    pbxStart.Image = Properties.Resources.startKicButtonFlat;
                    pbxStart.Location = new System.Drawing.Point(235, 405);
                    pbxStart.SizeMode = PictureBoxSizeMode.AutoSize;
                    // HD button
                    pbxHD.Image = Properties.Resources.hdKicButtonFlat;
                    pbxHD.Location = new System.Drawing.Point(235, 463);
                    pbxHD.SizeMode = PictureBoxSizeMode.AutoSize;
                    // Info button
                    pbxInfo.Image = Properties.Resources.infoKicButtonFlat;
                    pbxInfo.Location = new System.Drawing.Point(235, 521);
                    pbxInfo.SizeMode = PictureBoxSizeMode.AutoSize;
                    // Set a KicMode so other events know to change graphics
                    KicMode = true;
                    SetCursor(CursorType.KIC);
                    break;
                case "CBBC":
                    pbxLogo.Image = Properties.Resources.BGH_3;
                    SetCursor(CursorType.BBC);
                    break;
                case "NRKSuper":
                    pbxLogo.Image = Properties.Resources.bgh_nrk2;
                    SetCursor(CursorType.BBC);
                    break;
                case "Gulli":
                    pbxLogo.Image = Properties.Resources.bgh_gulli2;
                    SetCursor(CursorType.BBC);
                    break;
                default:
                break;
            }
        }

        private void SetCursor(CursorType CursorType)
        {
            switch (CursorType)
            {
                case CursorType.BBC:
                    this.Cursor = NativeMethods.LoadCustomCursor(BBCCursorFilePath);
                break;
                case CursorType.KIC:
                    this.Cursor = NativeMethods.LoadCustomCursor(KicCursorFilePath);
                break;
            }
            
        }

        private void LoadResolutionIniFile()
        {
            // If the resolution.ini file exists, we may assume that the HD hack is activated
            EnableHD = File.Exists(ResolutionIniFilePath);
            RenderHDState();
        }

        private void RenderHDState()
        {
            // Set the button image depending on whether HD is activated
            if (EnableHD)
            {
                pbxHD.Image = (KicMode ? Properties.Resources.hdKicButtonFlatPressed : Properties.Resources.hdButtonFlatPressed);
            }
            else
            {
                pbxHD.Image = (KicMode ? Properties.Resources.hdKicButtonFlat : Properties.Resources.hdButtonFlat);
            }
        }

        private void WriteResolutionIniFile(ResolutionIniFileActions Action, decimal Width = 0, decimal Height = 0)
        {
            // 1 = create
            // 0 = destroy
            // Well why didn't I just use a boolean? To be able to extend functionality further if needed.
            switch (Action)
            {
                case ResolutionIniFileActions.Create:
                    // AR doesn't care about Windowed.. it just renders as fullscreen anyway.. Setting it as Windowed makes sure the aspect ratio is not borked
                    string text = "[MAIN]" + Environment.NewLine + "Width=" + Width.ToString() + Environment.NewLine + "Height=" + Height.ToString() + Environment.NewLine + "Windowed=1" + Environment.NewLine + "ForceViewport=0";
                    File.WriteAllText(ResolutionIniFilePath, text);
                    File.Copy(SelfCustomD3D9LibraryPath, GameCustomD3D9LibraryPath, true);
                    break;
                case ResolutionIniFileActions.Destroy:
                    File.Delete(ResolutionIniFilePath);
                    File.Delete(GameCustomD3D9LibraryPath);
                break;
            }
        }

        private void bootGame()
        {
            Process KIC = new Process();
            KIC.StartInfo.FileName = (KicMode ? KicGameQuickLoginBatFilePath : GameOfflineExecutablePath);

            KIC.Start();  
        }

        private void playClick()
        {
            // Recreate the KIC button sound for that classic KIC feeling
            Stream str = Properties.Resources.Click01;
            SoundPlayer snd = new SoundPlayer(str);
            snd.Play();
        }

        private void pbxInfo_MouseDown(object sender, MouseEventArgs e)
        {
            pbxInfo.Image = (KicMode ? Properties.Resources.infoKicButtonFlatPressed : Properties.Resources.infoButtonFlatPressed);
        }

        private void pbxInfo_MouseUp(object sender, MouseEventArgs e)
        {
            playClick();
            pbxInfo.Image = (KicMode ? Properties.Resources.infoKicButtonFlat : Properties.Resources.infoButtonFlat);
            MessageBox.Show("KIC Launcher\ncreated by Sevenanths\n\nWriting this program could not have been possible without the help of Lolzipop171, recaas, Jakop Jørstad, Eskil S. and Robin Hofmann.\n\nSpecial thanks to ndke and RoadrunnerWMC.", "Credits", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void pbxSettings_MouseUp(object sender, MouseEventArgs e)
        {
            if (EnableHD)
            {
                WriteResolutionIniFile(ResolutionIniFileActions.Destroy, 0, 0);
            }
            else
            {
                Rectangle Resolution = Screen.PrimaryScreen.Bounds;
                WriteResolutionIniFile(ResolutionIniFileActions.Create, Resolution.Width, Resolution.Height);
            }
            EnableHD = !EnableHD;
            RenderHDState();
            playClick();
        }

        private void pbxStart_MouseDown(object sender, MouseEventArgs e)
        {
            pbxStart.Image = (KicMode ? Properties.Resources.startKicButtonFlatPressed : Properties.Resources.startButtonFlatPressed);
        }

        private void pbxStart_MouseUp(object sender, MouseEventArgs e)
        {
            pbxStart.Image = (KicMode ? Properties.Resources.startKicButtonFlat : Properties.Resources.startButtonFlat);
            playClick();
            bootGame();

            Application.Exit();
        }
    }
}
