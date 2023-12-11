using Octokit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Hot_Snap
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
            LoadSettings();
            LoadCardList();
            LoadDeckList();
        }

        private void LoadDeckList()
        {
            if (Properties.Settings.Default.snapLocation == "")
            {
                //MessageBox.Show("Snap folder needs to be set in Settings", "Missing Snap Folder", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string deckFolder = Properties.Settings.Default.snapLocation + @"\SNAP_Data\StreamingAssets\aa\StandaloneWindows64\MockCdn";
            //String[] files = Directory.GetFiles(deckFolder);
            String[] files = Directory.GetFiles(deckFolder, "cardbacks_assets_*", SearchOption.TopDirectoryOnly);
            DataTable table = new DataTable();
            table.Columns.Add("Deck Name");
            table.Columns.Add("File Name");

            for (int i = 0; i < files.Length; i++)
            {
                FileInfo file = new FileInfo(files[i]);
                DataRow dr = table.NewRow();
                string[] name = file.Name.Split('_');
                //dr[0] = name[0] + "_" + name[1]; //file.Name.Split('_').First();
                dr[0] = file.Name.Replace("cardbacks_assets_", "").Split('_').First();
                dr[1] = file.Name;
                table.Rows.Add(dr);
            }
            dgv_decks.DataSource = table;
            dgv_decks.Columns[1].Visible = false;
            dgv_decks.Columns[0].Width = 120;
        }

        private async void LoadCardList()
        {
            if (Properties.Settings.Default.snapLocation == "")
            {
                MessageBox.Show("Snap folder and GitHub Token needs to be set in Settings", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //Connect to GitHub
            var client = new GitHubClient(new ProductHeaderValue("HotSnap"));

            var tokenAuth = new Credentials(Properties.Settings.Default.token);
            client.Credentials = tokenAuth;

            //Populate the list only if it exists on the repository
            try
            {
                //Define GitHub [Account] > [Repo] > [Folder]
                var previewContents = await client
                .Repository
                .Content
                .GetAllContents("hotshotz79", "HotSnap-Custom-Assets", @"Variants");

                //Download the Base64 image
                WebClient webClient = new WebClient();
                webClient.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/70.0.3538.77 Safari/537.36");
                webClient.Headers.Add(HttpRequestHeader.Authorization, "token "+ Properties.Settings.Default.token);
                webClient.Headers.Add(HttpRequestHeader.Accept, "application/octet-stream");

                string snapFolder = Properties.Settings.Default.snapLocation + @"\SNAP_Data\StreamingAssets\aa\StandaloneWindows64\MockCdn";
                bool skip = false;
                String[] files = Directory.GetFiles(snapFolder, "cards_assets_*", SearchOption.TopDirectoryOnly);
                DataTable table = new DataTable();
                table.Columns.Add("Card Name");
                table.Columns.Add("File Name");

                for (int x = 0; x < previewContents.Count; x++)
                {
                    if (previewContents[x].Type == "dir")
                    {
                        for (int i = 0; i < files.Length; i++)
                        {
                            skip = false;
                            FileInfo file = new FileInfo(files[i]);
                            //Skip if variant name
                            if (file.Name.Contains("spell0"))
                                continue;
                            //Console.WriteLine(file.Name + " | " + previewContents[x].Name);
                            if (file.Name.Contains(previewContents[x].Name))
                            {
                                for (int j = 1; j < 21; j++)
                                {
                                    if (j < 10)
                                    {
                                        if (file.Name.Contains("_0" + j + "_"))
                                        {
                                            skip = true;
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        if (file.Name.Contains("_" + j + "_"))
                                        {
                                            skip = true;
                                            break;
                                        }
                                    }
                                }
                                if (!skip)
                                {
                                    DataRow dr = table.NewRow();
                                    dr[0] = file.Name.Replace("cards_assets_", "").Split('_').First();
                                    dr[1] = file.Name;
                                    table.Rows.Add(dr);
                                }
                            }
                        }
                    }
                }

                /*
                string snapFolder = Properties.Settings.Default.snapLocation + @"\SNAP_Data\StreamingAssets\aa\StandaloneWindows64\MockCdn";
                bool skip = false;
                String[] files = Directory.GetFiles(snapFolder, "cards_assets_*", SearchOption.TopDirectoryOnly);
                DataTable table = new DataTable();
                table.Columns.Add("Card Name");
                table.Columns.Add("File Name");

                for (int i = 0; i < files.Length; i++)
                {
                    skip = false;
                    FileInfo file = new FileInfo(files[i]);
                    //Skip if variant
                    if (file.Name.Contains("testcard") || file.Name.Contains("zzz"))
                        continue;
                    for (int j = 1; j < 21; j++)
                    {
                        if (j < 10)
                        {
                            if (file.Name.Contains("_0" + j + "_"))
                            {
                                skip = true;
                                break;
                            }
                        }
                        else
                        {
                            if (file.Name.Contains("_" + j + "_"))
                            {
                                skip = true;
                                break;
                            }
                        }
                    }
                    if (!skip)
                    {
                        DataRow dr = table.NewRow();
                        dr[0] = file.Name.Replace("cards_assets_", "").Split('_').First();
                        dr[1] = file.Name;
                        table.Rows.Add(dr);
                    }
                }
                */
                dgv_cards.DataSource = table;
                dgv_cards.Columns[1].Visible = false;
                dgv_cards.Columns[0].Width = 120;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadSettings()
        {
            txtSnapLocation.Text = Properties.Settings.Default.snapLocation;
            txtToken.Text = Properties.Settings.Default.token;
            txtUsername.Text = Properties.Settings.Default.username;
            if (Properties.Settings.Default.dispNsfw == "yes")
                chk_showNsfw.Checked = true;
            else
                chk_showNsfw.Checked = false;
            if (Properties.Settings.Default.capturePop == "yes")
                chk_skipCaptureMsg.Checked = true;
            else
                chk_skipCaptureMsg.Checked = false;
        }

        private void btnSettingsSave_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.snapLocation = txtSnapLocation.Text;
            Properties.Settings.Default.token = txtToken.Text;
            Properties.Settings.Default.username = txtUsername.Text;
            if (chk_showNsfw.Checked)
                Properties.Settings.Default.dispNsfw = "yes";
            else
                Properties.Settings.Default.dispNsfw = "no";
            if (chk_skipCaptureMsg.Checked)
                Properties.Settings.Default.capturePop = "yes";
            else
                Properties.Settings.Default.capturePop = "no";
            Properties.Settings.Default.Save();
            if (!String.IsNullOrEmpty(txtSnapLocation.Text) && !String.IsNullOrEmpty(txtToken.Text))
            { 
                LoadCardList();
                LoadDeckList(); 
            }

            var mm = new MainMenu();
            Point mouse_pt = new Point(MousePosition.X, MousePosition.Y-200);
            Message frmMessage = new Message(Properties.Resources.HulkThing_FistBump);
            frmMessage.StartPosition = FormStartPosition.Manual;
            frmMessage.Location = mouse_pt;
            frmMessage.ShowDialog();
        }

        private void btnSettingsBrowse_Click(object sender, EventArgs e)
        {
            DialogResult result = dialog_snapLoc.ShowDialog();

            if (result == DialogResult.OK)
            {
                txtSnapLocation.Text = dialog_snapLoc.SelectedPath;
            }
        }

        private void dgv_cards_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            flow_variants.Controls.Clear();
            lblNoVariants.Visible = false;
            lblInstalled.Visible = false;
            lblDblClick.Visible = false;
            RetrievePreview();
        }

        private async void RetrievePreview()
        {

            //Connect to GitHub
            var client = new GitHubClient(new ProductHeaderValue("HotSnap"));

            var tokenAuth = new Credentials(Properties.Settings.Default.token);
            client.Credentials = tokenAuth;

            try
            {
                //Define GitHub [Account] > [Repo] > [Folder]
                var previewContents = await client
                .Repository
                .Content
                .GetAllContents("hotshotz79", "HotSnap-Custom-Assets", @"Variants/" + dgv_cards.CurrentRow.Cells[0].Value.ToString());

                //Download the Base64 image
                WebClient webClient = new WebClient();
                webClient.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/70.0.3538.77 Safari/537.36");
                webClient.Headers.Add(HttpRequestHeader.Authorization, "token "+ Properties.Settings.Default.token);
                webClient.Headers.Add(HttpRequestHeader.Accept, "application/octet-stream");

                try
                {
                    for (int i = 0; i < previewContents.Count; i++)
                    {
                        if (previewContents[i].Name.Contains(".image"))
                        {
                            if (!chk_showNsfw.Checked && previewContents[i].Name.Contains("_nsfw"))
                                continue;

                            webClient.DownloadFile(previewContents[i].DownloadUrl, "temp.png");

                            //Convert Base64 to actual image
                            var str = File.ReadAllText("temp.png");
                            var img = Image.FromStream(new MemoryStream(Convert.FromBase64String(str)));

                            //Populate Flow Layout
                            PictureBox pbCard = new PictureBox();
                            pbCard.Image = img;
                            pbCard.Name = previewContents[i].DownloadUrl; //used for downloading .bundle file
                            pbCard.Tag = dgv_cards.CurrentRow.Cells[1].Value.ToString(); //used for copy-pasting
                            pbCard.Size = new Size(260, 310);
                            pbCard.SizeMode = PictureBoxSizeMode.StretchImage;
                            pbCard.BorderStyle = BorderStyle.FixedSingle;
                            pbCard.DoubleClick += new EventHandler(iconClicked);
                            flow_variants.Controls.Add(pbCard);

                        }
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
                finally
                {
                    File.Delete("temp.png");
                    lblDblClick.Text = previewContents.Count /2 + " Variants found, double click to install";
                    lblDblClick.Visible = true;
                }
            }
            catch (Exception e)
            {
                lblNoVariants.Visible = true;
            }
        }

        private void iconClicked(object sender, EventArgs e)
        {
            //Hash verification
            PictureBox pb = (PictureBox)sender;
            string[] nameSplit = pb.Name.Split('_');
            string[] baseNameSplit = pb.Tag.ToString().Split('_');

            if (baseNameSplit[3].ToString().Replace(".bundle", "") != nameSplit[4].ToString().Replace(".image","")) //.replace (".image", "") -- change to [4] when hash added -- [5] will be nsfw
            {
                DialogResult dialogResult = MessageBox.Show("The hash tag did not match, possibly due to variant created with older asset.\n\n" +
                    "Installing this variant might not work in game (changes can be reverted using Restore button)","Hash mismatch", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    //do nothing, let the process flow
                }
                else if (dialogResult == DialogResult.No)
                {
                    return;
                }
            }

            //Download Bundle File
            WebClient webClient = new WebClient();
            webClient.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/70.0.3538.77 Safari/537.36");
            webClient.Headers.Add(HttpRequestHeader.Authorization, "token "+ Properties.Settings.Default.token);
            webClient.Headers.Add(HttpRequestHeader.Accept, "application/octet-stream");
            webClient.DownloadFile(pb.Name.Replace(".image",".variant").ToString(), "temp.bundle");

            //Convert Base64 to actual bundle
            var str = File.ReadAllText("temp.bundle");
            File.WriteAllBytes("b64.bundle", Convert.FromBase64String(str));

            string copyPath = "b64.bundle";
            string pastePath = Properties.Settings.Default.snapLocation + @"\SNAP_Data\StreamingAssets\aa\StandaloneWindows64\MockCdn\" + pb.Tag.ToString();

            //Backup first
            Directory.CreateDirectory("Backup");
            string backupPath = @"Backup\" + pb.Tag.ToString();
            if (!File.Exists(backupPath)) 
                File.Copy(pastePath, backupPath, false);

            //Copy > Overwrite > Delete temp files
            File.Copy(copyPath, pastePath, true);
            File.Delete("b64.bundle");
            File.Delete("temp.bundle");

            lblInstalled.Text = "Variant: " + nameSplit[2].ToString() + " | By user: " + nameSplit[3].Replace(".png","")  + " | Status: Installed";
            lblInstalled.Visible = true;
            lblDblClick.Visible = false;
        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            if (!chk_skipCaptureMsg.Checked)
            MessageBox.Show("Make sure the game is running fullscreen behind this application. \n\nClick OK to capture card",
                "Ready to Capture",MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            
            Rectangle bounds = Screen.GetBounds(Point.Empty);
            using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    int milliseconds = 1000;
                    this.WindowState = FormWindowState.Minimized;
                    Thread.Sleep(milliseconds);
                    g.CopyFromScreen(0, 0, 0, 0, bounds.Size);
                    this.Show();
                    this.WindowState = FormWindowState.Normal;
                }
                //bitmap.Save("capture.png", ImageFormat.Png);

                Bitmap croppedBmp = new Bitmap(10,10);
                croppedBmp = bitmap.Clone(new Rectangle(700, 100, 520, 620), PixelFormat.Format32bppArgb);

                croppedBmp.Save("capture.png", ImageFormat.Png);
                pic_upload.Image = croppedBmp;
                pic_upload.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void btnBrowseBundle_Click(object sender, EventArgs e)
        {
            lblCardSelected.Text = "";
            diag_fileUpload.InitialDirectory = Properties.Settings.Default.snapLocation + @"\SNAP_Data\StreamingAssets\aa\StandaloneWindows64\MockCdn";

            DialogResult result = diag_fileUpload.ShowDialog();
            
            if (result == DialogResult.OK)
            {
                //Check if base card is selected
                string[] cardSelectedName = diag_fileUpload.SafeFileName.Split('_');
                if (cardSelectedName.Count() > 4)
                {
                    MessageBox.Show("Selected bundle is not a 'Base' card.\n\nCurrent version of this tool does not support customization of variant assets (file name tagged with 01-20).", "Base Asset Only", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                txtBundleLoc.Text = diag_fileUpload.FileName;
                lblCardSelected.Text = cardSelectedName[2].ToString();
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtBundleLoc.Text))
            {
                MessageBox.Show("No .bundle selected to upload");
                return;
            }

            if (pic_upload.Image == null)
            {
                MessageBox.Show("No Screenshot attached");
                return;
            }

            if (String.IsNullOrEmpty(txtVariantName.Text))
            {
                MessageBox.Show("Variant Name Missing");
                return;
            }
            UploadToGit();
        }
        
        private async void UploadToGit()
        {
            var client = new GitHubClient(new ProductHeaderValue("HotSnap"));
            var tokenAuth = new Credentials(Properties.Settings.Default.token);
            client.Credentials = tokenAuth;

            try
            {
                string[] getHash = txtBundleLoc.Text.Split('_');
                string hashVerify = "";
                for (int x = 0; x < getHash.Length; x++)
                {
                    if (getHash[x].ToString().Contains(".bundle"))
                        hashVerify = getHash[x].ToString().Replace(".bundle","");
                }
                var (owner, repoName, filePath, branch) = ("hotshotz79", "HotSnap-Custom-Assets",
                    @"Variants/" + lblCardSelected.Text + "/" +
                    DateTime.Now.ToString("yyMMdd_HHmmss") + "_" + txtVariantName.Text + "_" + Properties.Settings.Default.username + "_" + hashVerify,
                    "main");

                if (chkUploadNsfw.Checked)
                    filePath = filePath + "_nsfw";

                //Upload Image
                byte[] imageArray = File.ReadAllBytes("capture.png");
                string base64Image = Convert.ToBase64String(imageArray);
                filePath = filePath + ".image";
                await client.Repository.Content.CreateFile(
                     owner, repoName, filePath,
                     new CreateFileRequest($"Upload Variant Image: " + lblCardSelected.Text, base64Image, branch));

                byte[] bundleArray = File.ReadAllBytes(txtBundleLoc.Text);
                string base64Bundle = Convert.ToBase64String(bundleArray);
                filePath = filePath.Replace(".image",".variant");
                await client.Repository.Content.CreateFile(
                     owner, repoName, filePath,
                     new CreateFileRequest($"Upload Variant Bundle: " + lblCardSelected.Text, base64Bundle, branch));
                File.Delete("capture.png");
                
                MessageBox.Show("Upload successful");
                ResetUpload();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Upload Error");
            }
        }

        private void btnPatch_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(Properties.Settings.Default.snapLocation))
            {
                MessageBox.Show("Snap Folder not set");
                return;
            }

            string catalogDir = Properties.Settings.Default.snapLocation + @"\SNAP_Data\StreamingAssets\aa\StandaloneWindows64\MockCdn\";
            DirectoryInfo taskDirectory = new DirectoryInfo(catalogDir);
            FileInfo[] taskFiles = taskDirectory.GetFiles("catalog*.json");
            
            try
            {
                //1. Run the .bat command to Patch JSON
                string filename = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\patcher\\PatchCRC.bat";
                string parameters = "\"" + taskFiles[0].FullName.ToString() + "\"";
                //Process.Start(filename, parameters);
                var process = Process.Start(filename, parameters);
                process.WaitForExit();
                //Loop to see if .patched file exists, check every 5 seconds(?)
                //3. Rename and move patched file
                string patchedfile = taskFiles[0].Name.ToString() + ".patched";
                while (true)
                {
                    if (File.Exists(catalogDir + patchedfile))
                    {
                        break;
                    }
                    // code here
                    Thread.Sleep(5000);
                }

                string appDataPath = @"%APPDATA%\..\LocalLow\Second Dinner\Snap\com.unity.addressables\";
                if (File.Exists(Environment.ExpandEnvironmentVariables(appDataPath) + taskFiles[0].Name.ToString()))
                    File.Delete(Environment.ExpandEnvironmentVariables(appDataPath) + taskFiles[0].Name.ToString());
                File.Copy(catalogDir + patchedfile, Environment.ExpandEnvironmentVariables(appDataPath) + taskFiles[0].Name.ToString());
                File.Delete(catalogDir + patchedfile);

                MessageBox.Show("JSON Patched");
            }
            catch (Exception ex)
            {
                MessageBox.Show(this,
                    "Write exception", "There was a problem while writing the file:\n" + ex.ToString());
            }
        }

        private void btnGuide_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tabPage6);
        }

        private void dgv_cards_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //flow_variants.Dispose();
            //lblNoVariants.Visible =false;   
        }

        private void btnPull_Click(object sender, EventArgs e)
        {
            flow_variants.Controls.Clear();
            lblNoVariants.Visible = false;
            lblInstalled.Visible = false;
            lblDblClick.Visible = false;
            RetrievePreview();
        }

        private void lnk_uabe_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/hotshotz79/UABE-SnapVersion/releases");
        }

        private void lnk_studio_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/Perfare/AssetStudio/releases");
        }

        private void lnk_github_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/settings/profile");
        }

        private void lnk_netRuntime_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://aka.ms/dotnet-core-applaunch?missing_runtime=true&arch=x64&rid=win10-x64&apphost_version=6.0.11");
        }

        private void btnBrowseScreenshot_Click(object sender, EventArgs e)
        {
            //TODO
            var mm = new MainMenu();
            Point mouse_pt = new Point(MousePosition.X, MousePosition.Y-200);
            Message frmMessage = new Message(Properties.Resources.Uploaded_Thanos);
            frmMessage.StartPosition = FormStartPosition.Manual;
            frmMessage.Location = mouse_pt; 
            frmMessage.ShowDialog();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetUpload();
        }

        private void ResetUpload()
        {
            pic_upload.Image = null;
            txtBundleLoc.Text = string.Empty;
            lblCardSelected.Text = "";
            txtVariantName.Text = string.Empty;
            chkUploadNsfw.Checked = false;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
