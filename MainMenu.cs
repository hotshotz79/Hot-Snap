using Hot_Snap.Properties;
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
        public DataTable dtVariants;
        public DataTable dtDecks;
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
                MessageBox.Show("Snap folder needs to be set in Settings", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (dtDecks == null)
            {
                dtDecks = new DataTable();
                dtDecks.Columns.Add("Deck Name");
                dtDecks.Columns.Add("File Name");
                dtDecks.Columns.Add("Local");
            }
            else
                dtDecks.Clear();

            LoadDeckLocal();
            LoadDeckGitHub();

            dtDecks.DefaultView.Sort = "Deck Name asc";
            dgv_decks.DataSource = dtDecks;
            dgv_decks.Columns[1].Visible = false;
            dgv_decks.Columns[2].Visible = false;
            dgv_decks.Columns[0].Width = 140;
        }

        private async void LoadDeckGitHub()
        {
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
                .GetAllContents("hotshotz79", "HotSnap-Custom-Assets", @"Cardbacks");

                //Download the Base64 image
                WebClient webClient = new WebClient();
                webClient.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/70.0.3538.77 Safari/537.36");
                webClient.Headers.Add(HttpRequestHeader.Authorization, "token "+ Properties.Settings.Default.token);
                webClient.Headers.Add(HttpRequestHeader.Accept, "application/octet-stream");

                string deckFolder = Properties.Settings.Default.snapLocation + @"\SNAP_Data\StreamingAssets\aa\StandaloneWindows64\MockCdn";

                String[] files = Directory.GetFiles(deckFolder, "cardbacks_assets_*", SearchOption.TopDirectoryOnly);

                //cardbacks_assets_snapcube_01_4c6cdee88dea349632974c04c25cfa5f

                for (int x = 0; x < previewContents.Count; x++)
                {
                    if (previewContents[x].Type == "dir")
                    {
                        for (int i = 0; i < files.Length; i++)
                        {
                            FileInfo file = new FileInfo(files[i]);

                            string[] name = file.Name.Split('_');

                            if (name[2] + "_" + name[3] == previewContents[x].Name)
                            {
                                DataRow dr = dtDecks.NewRow();
                                dr[0] = file.Name.Replace("cardbacks_assets_", "").Split('_').First() + "_" + name[3].ToString();
                                dr[1] = file.Name;
                                dr[2] = "false";
                                dtDecks.Rows.Add(dr);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void LoadDeckLocal()
        {
            string currentPath = Directory.GetCurrentDirectory();

            var deckName = new DirectoryInfo(currentPath + @"\Custom\Decks").GetDirectories().Select(d => d.Name);

            string snapFolder = Properties.Settings.Default.snapLocation + @"\SNAP_Data\StreamingAssets\aa\StandaloneWindows64\MockCdn";
            //bool skip = false;
            String[] files = Directory.GetFiles(snapFolder, "cardbacks_assets_*", SearchOption.TopDirectoryOnly);

            foreach (var custName in deckName)
            {
                for (int i = 0; i < files.Length; i++)
                {
                    FileInfo file = new FileInfo(files[i]);
                    string[] name = file.Name.Split('_');   //Snap Folder name splits
                    string[] custSplit = custName.Split('_');

                    //Base card only has name
                    if (custSplit.Length == 1)
                    {
                        //base card split will only have 4 length
                        if (name.Length == 4)
                        {
                            if (name[2] == custSplit[0])
                            {
                                //Console.WriteLine("Match Found " + name[2]);
                                DataRow dr = dtDecks.NewRow();
                                dr[0] = file.Name.Replace("cardbacks_assets_", "").Split('_').First();
                                dr[1] = file.Name;
                                dr[2] = "true";
                                dtDecks.Rows.Add(dr);
                                break;
                            }
                        }
                    }
                    //Variants have digits, resulting in split
                    else
                    {
                        if (name.Length == 5)
                        {
                            if (name[2] == custSplit[0] &&
                            name[3] == custSplit[1])
                            {
                                DataRow dr = dtDecks.NewRow();
                                dr[0] = file.Name.Replace("cardbacks_assets_", "").Split('_').First() + "_" + custSplit[1];
                                dr[1] = file.Name;
                                dr[2] = "true";
                                dtDecks.Rows.Add(dr);
                                break;
                            }
                        }
                    }
                }

            }
        }

        private void LoadCardList()
        {
            if (Properties.Settings.Default.snapLocation == "")
            {
                MessageBox.Show("Snap folder (and GitHub Token for online pulls) needs to be set in Settings", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (dtVariants == null)
            {
                dtVariants = new DataTable();
                dtVariants.Columns.Add("Card Name");
                dtVariants.Columns.Add("File Name");
                dtVariants.Columns.Add("Local");
            }
            else
                dtVariants.Clear();

            LoadVariantLocal();
            LoadVariantGitHub();

            dtVariants.DefaultView.Sort = "Card Name asc";
            dgv_cards.DataSource = dtVariants;
            dgv_cards.Columns[1].Visible = false;
            dgv_cards.Columns[2].Visible = false;
            dgv_cards.Columns[0].Width = 140;
        }

        private async void LoadVariantGitHub()
        {
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
                            FileInfo file = new FileInfo(files[i]);
                            //Skip certain cards (such as Nico Robins spells)
                            if (file.Name.Contains("spell0"))
                                continue;

                            string[] name = file.Name.Split('_');

                            if (name[2] == previewContents[x].Name)
                            {
                                //if variant, name split length = 5
                                //otherwise base split = 4
                                if (name.Length == 4)
                                {
                                    DataRow dr = dtVariants.NewRow();
                                    dr[0] = file.Name.Replace("cards_assets_", "").Split('_').First();
                                    dr[1] = file.Name;
                                    dr[2] = "false";
                                    dtVariants.Rows.Add(dr);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadVariantLocal()
        {
            string currentPath = Directory.GetCurrentDirectory();
            if (!Directory.Exists(Path.Combine(currentPath, "Custom")))
            {
                Directory.CreateDirectory(Path.Combine(currentPath, "Custom"));
                Directory.CreateDirectory(Path.Combine(currentPath + @"\Custom", "Variants"));
                Directory.CreateDirectory(Path.Combine(currentPath + @"\Custom", "Decks"));
            }
            //var variantsFolder = new List<string>(Directory.GetDirectories(currentPath + @"\Custom\Variants"));
            var variantsName = new DirectoryInfo(currentPath + @"\Custom\Variants").GetDirectories().Select(d => d.Name);

            string snapFolder = Properties.Settings.Default.snapLocation + @"\SNAP_Data\StreamingAssets\aa\StandaloneWindows64\MockCdn";
            //bool skip = false;
            String[] files = Directory.GetFiles(snapFolder, "cards_assets_*", SearchOption.TopDirectoryOnly);
            DataTable table = new DataTable();
            table.Columns.Add("Card Name");
            table.Columns.Add("File Name");

            foreach (var custName in variantsName)
            {
                for (int i = 0; i < files.Length; i++)
                {
                    FileInfo file = new FileInfo(files[i]);
                    string[] name = file.Name.Split('_');   //Snap Folder name splits
                    string[] custSplit = custName.Split('_');

                    //Base card only has name
                    if (custSplit.Length == 1)
                    {
                        //base card split will only have 4 length
                        if (name.Length == 4)
                        {
                            if (name[2] == custSplit[0])
                            {
                                //Console.WriteLine("Match Found " + name[2]);
                                DataRow dr = dtVariants.NewRow();
                                dr[0] = file.Name.Replace("cards_assets_", "").Split('_').First();
                                dr[1] = file.Name;
                                dr[2] = "true";
                                dtVariants.Rows.Add(dr);
                                break;
                            }
                        }
                    }
                    //Variants have digits, resulting in split
                    else
                    {
                        if (name.Length == 5)
                        {
                            if (name[2] == custSplit[0] &&
                            name[3] == custSplit[1])
                            {
                                DataRow dr = dtVariants.NewRow();
                                dr[0] = file.Name.Replace("cards_assets_", "").Split('_').First() + "_" + custSplit[1];
                                dr[1] = file.Name;
                                dr[2] = "true";
                                dtVariants.Rows.Add(dr);
                                break;
                            }
                        }
                    }
                }

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

            //Emote Pop Up
            var mm = new MainMenu();
            Point mouse_pt = new Point(MousePosition.X, MousePosition.Y-200);
            Message frmMessage = new Message(Properties.Resources.HulkThing_FistBump, 2000);
            frmMessage.StartPosition = FormStartPosition.Manual;
            frmMessage.Location = mouse_pt;
            frmMessage.ShowDialog();
        }

        private void btnSettingsBrowse_Click(object sender, EventArgs e)
        {
            DialogResult result = dlg_snapLoc.ShowDialog();

            if (result == DialogResult.OK)
            {
                txtSnapLocation.Text = dlg_snapLoc.SelectedPath;
            }
        }

        private void dgv_cards_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            flow_variants.Controls.Clear();
            lblNoVariants.Visible = false;
            lblInstalled.Visible = false;
            lblDblClick.Visible = false;
            RetrievePreview(@"Variants/", dgv_cards);
        }

        private async void RetrievePreview(string folder, DataGridView dgv)
        {
            //Check if local file
            if (dgv.CurrentRow.Cells[2].Value.ToString() == "true")
            {
                int varCount = 0;
                string currentPath = Directory.GetCurrentDirectory();
                List<string> localFolder;
                
                if (folder.Contains("Variant"))
                    localFolder = new List<string>(Directory.GetDirectories(currentPath + @"\Custom\Variants"));
                else
                    localFolder = new List<string>(Directory.GetDirectories(currentPath + @"\Custom\Decks"));
                //var variantsName = new DirectoryInfo(currentPath + @"\Custom\Variants").GetDirectories().Select(d => d.Name);

                foreach (var sub in localFolder)
                {
                    if (sub.ToString().Contains(dgv.CurrentRow.Cells[0].Value.ToString()))
                    {
                        String[] varImages = Directory.GetFiles(sub, "*.png", SearchOption.TopDirectoryOnly);
                        varCount = varImages.Length;
                        foreach (String thumbnail in varImages)
                        {
                            var img = Image.FromFile(thumbnail);

                            PictureBox pbCard = new PictureBox();
                            pbCard.Image = img;
                            pbCard.Name = Path.GetFileName(thumbnail).Replace(".png", ".bundle");// used for local file name
                            pbCard.Tag = dgv_cards.CurrentRow.Cells[1].Value.ToString(); //used for MockCdn file name
                            pbCard.AccessibleDescription = Path.GetDirectoryName(thumbnail);    //used for folder path
                            pbCard.AccessibleName  = "local";   //determine if local or github
                            pbCard.Size = new Size(260, 310);
                            pbCard.SizeMode = PictureBoxSizeMode.StretchImage;
                            pbCard.BorderStyle = BorderStyle.FixedSingle;
                            pbCard.DoubleClick += new EventHandler(iconClicked);
                            if (folder.Contains("Variant"))
                                flow_variants.Controls.Add(pbCard);
                            else
                                flow_deck.Controls.Add(pbCard);
                        }
                    }
                }

                if (folder.Contains("Variant"))
                {
                    lblDblClick.Text = varCount + " Variants found, double click to install"; //previewContents.Count /2 + " Variants found, double click to install";
                    lblDblClick.Visible = true;
                }
                else
                {
                    lblDblClickDeck.Text = varCount + " Decks found, double click to install"; //previewContents.Count /2 + " Variants found, double click to install";
                    lblDblClickDeck.Visible = true;
                }
                    //Skip Github
                return;
            }

            //Connect to GitHub
            var client = new GitHubClient(new ProductHeaderValue("HotSnap"));

            var tokenAuth = new Credentials(Properties.Settings.Default.token);
            client.Credentials = tokenAuth;

            //GitHub pull begins here
            try
            {
                //Define GitHub [Account] > [Repo] > [Folder]
                var previewContents = await client
                .Repository
                .Content
                .GetAllContents("hotshotz79", "HotSnap-Custom-Assets", folder + dgv.CurrentRow.Cells[0].Value.ToString());

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
                            //if (!chk_showNsfw.Checked && previewContents[i].Name.Contains("_nsfw"))
                            //continue;
                            Image img = Resources.nsfw;
                            if (chk_showNsfw.Checked)
                            {
                                //Convert Base64 to actual image
                                webClient.DownloadFile(previewContents[i].DownloadUrl, "temp.png");
                                var str = File.ReadAllText("temp.png");

                                img = Image.FromStream(new MemoryStream(Convert.FromBase64String(str)));
                            }
                            else
                            {
                                if (previewContents[i].Name.Contains("_nsfw"))
                                    img = Resources.nsfw;
                                else
                                {
                                    //Convert Base64 to actual image
                                    webClient.DownloadFile(previewContents[i].DownloadUrl, "temp.png");
                                    var str = File.ReadAllText("temp.png");

                                    img = Image.FromStream(new MemoryStream(Convert.FromBase64String(str)));
                                }
                            }

                            //Populate Flow Layout
                            PictureBox pbCard = new PictureBox();
                            pbCard.Image = img;
                            pbCard.Name = previewContents[i].DownloadUrl; //used for downloading .bundle file
                            pbCard.Tag = dgv_cards.CurrentRow.Cells[1].Value.ToString(); //used for copy-pasting
                            pbCard.AccessibleName = "online";
                            pbCard.Size = new Size(260, 310);
                            pbCard.SizeMode = PictureBoxSizeMode.StretchImage;
                            pbCard.BorderStyle = BorderStyle.FixedSingle;
                            pbCard.DoubleClick += new EventHandler(iconClicked);
                            if (folder.Contains("Variant"))
                                flow_variants.Controls.Add(pbCard);
                            else
                                flow_deck.Controls.Add(pbCard);
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
            string[] nameSplit = pb.Name.Split('_');    //File name
            string[] baseNameSplit = pb.Tag.ToString().Split('_'); //MockCdn name
            bool hashMisMatch = false;
            string hashCheck = nameSplit[4].ToString();
            int index = hashCheck.IndexOf(".");

            if (index >= 0)
                hashCheck = hashCheck.Substring(0, index);

            if (baseNameSplit.Length == 4)
            {
                if (baseNameSplit[3].ToString().Replace(".bundle", "") != hashCheck) //.replace (".image", "") -- change to [4] when hash added -- [5] will be nsfw
                    hashMisMatch = true;
            }
            else
            {
                if (baseNameSplit[4].ToString().Replace(".bundle", "") != hashCheck)
                    hashMisMatch = true;
            }

            if (hashMisMatch)
            {
                DialogResult dialogResult = MessageBox.Show("The hash tag did not match, possibly due to custom variant created with older asset.\n\n" +
                    "Installing this variant might not work in game (changes can be reverted using Restore button)\n\n"
                    +"Do you want to continue?", "Hash mismatch", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    //do nothing, let the process flow
                }
                else if (dialogResult == DialogResult.No)
                {
                    return;
                }
            }

            //Backup the file first if one doesn't exist
            string backupPath = @"Backup\" + pb.Tag.ToString();
            string pastePath = Properties.Settings.Default.snapLocation + @"\SNAP_Data\StreamingAssets\aa\StandaloneWindows64\MockCdn\" + pb.Tag.ToString();
            string copyPath = "b64.bundle";

            Directory.CreateDirectory("Backup");
            if (!File.Exists(backupPath))
                File.Copy(pastePath, backupPath, false);

            //Check if the selected file is local
            if (pb.AccessibleName == "local")
            {
                copyPath = pb.AccessibleDescription + "\\" + pb.Name;
                File.Copy(copyPath, pastePath, true);

                lblInstalledDeck.Text = "Deck: " + nameSplit[2].ToString() + " | By user: " + nameSplit[3].Replace(".png", "")  + " | Status: Installed";
                lblInstalledDeck.Visible = true;
                lblDblClickDeck.Visible = false;
            }
            //GitHub call otherwise
            else
            {
                //Download Bundle File
                WebClient webClient = new WebClient();
                webClient.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/70.0.3538.77 Safari/537.36");
                webClient.Headers.Add(HttpRequestHeader.Authorization, "token "+ Properties.Settings.Default.token);
                webClient.Headers.Add(HttpRequestHeader.Accept, "application/octet-stream");
                webClient.DownloadFile(pb.Name.Replace(".image", ".variant").ToString(), "temp.bundle");

                //Convert Base64 to actual bundle
                var str = File.ReadAllText("temp.bundle");
                File.WriteAllBytes("b64.bundle", Convert.FromBase64String(str));

                //Copy > Overwrite > Delete temp files
                File.Copy(copyPath, pastePath, true);
                File.Delete("b64.bundle");
                File.Delete("temp.bundle");

                lblInstalled.Text = "Variant: " + nameSplit[2].ToString() + " | By user: " + nameSplit[3].Replace(".png", "")  + " | Status: Installed";
                lblInstalled.Visible = true;
                lblDblClick.Visible = false;
            }
        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            if (!chk_skipCaptureMsg.Checked)
                MessageBox.Show("Make sure the game is running fullscreen behind this application. \n\nClick OK to capture card",
                    "Ready to Capture", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

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

                Bitmap croppedBmp = new Bitmap(10, 10);
                croppedBmp = bitmap.Clone(new Rectangle(700, 100, 520, 620), PixelFormat.Format32bppArgb);

                croppedBmp.Save("capture.png", ImageFormat.Png);
                pic_upload.Image = croppedBmp;
                pic_upload.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void btnBrowseBundle_Click(object sender, EventArgs e)
        {
            lblCardSelected.Text = "";
            dlg_fileUpload.InitialDirectory = Properties.Settings.Default.snapLocation + @"\SNAP_Data\StreamingAssets\aa\StandaloneWindows64\MockCdn";
            if (radVariant.Checked)
                dlg_fileUpload.Filter = "Variants|cards_assets*.bundle";
            if (radDeck.Checked)
                dlg_fileUpload.Filter = "CardBacks|cardbacks*.bundle";

            DialogResult result = dlg_fileUpload.ShowDialog();

            if (result == DialogResult.OK)
            {
                //Check if base card is selected
                string[] cardSelectedName = dlg_fileUpload.SafeFileName.Split('_');
                if (radVariant.Checked && cardSelectedName.Count() > 4)
                {
                    MessageBox.Show("Selected bundle is not a 'Base' card.\n\nCurrent version of this tool does not support customization of variant assets (file name tagged with 01-20).", "Base Asset Only", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                txtBundleLoc.Text = dlg_fileUpload.FileName;
                lblCardSelected.Text = cardSelectedName[2].ToString();

                if (radDeck.Checked)
                    lblCardSelected.Text = lblCardSelected.Text + "_" + cardSelectedName[3].ToString();

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
            if (radUpGitHub.Checked && txtToken.Text == null)
            {
                MessageBox.Show("In order to upload to GitHub, you need to enter the GitHub Token under Settings");
                return;
            }

            if (radUpGitHub.Checked)
                UploadToGit();
            else
                UploadToLocal();
        }

        private void UploadToLocal()
        {
            string snapFolder = Properties.Settings.Default.snapLocation + @"\SNAP_Data\StreamingAssets\aa\StandaloneWindows64\MockCdn";

            string destPath = Directory.GetCurrentDirectory();

            if (radVariant.Checked)
                destPath = destPath + @"\Custom\Variants\" + lblCardSelected.Text + @"\";
            else
                destPath = destPath + @"\Custom\Decks\" + lblCardSelected.Text + @"\";

            if (!Directory.Exists(destPath))
            {
                Directory.CreateDirectory(destPath);
            }

            string[] getHash = txtBundleLoc.Text.Split('_');
            string hashVerify = "";
            for (int x = 0; x < getHash.Length; x++)
            {
                if (getHash[x].ToString().Contains(".bundle"))
                    hashVerify = getHash[x].ToString().Replace(".bundle", "");
            }

            string saveAs =  DateTime.Now.ToString("yyMMdd_HHmmss") + "_" + txtVariantName.Text + "_" + Properties.Settings.Default.username + "_" + hashVerify + ".bundle";

            //Copy the bundle from MockCdn to Custom folder
            //Copy the png from the root folder
            File.Copy(txtBundleLoc.Text, Path.Combine(destPath, saveAs));
            saveAs = saveAs.Replace(".bundle", ".png");
            File.Copy("capture.png", Path.Combine(destPath, saveAs));

            //MessageBox.Show("Upload successful");
            var mm = new MainMenu();
            Point mouse_pt = new Point(MousePosition.X, MousePosition.Y-200);
            Message frmMessage = new Message(Properties.Resources.Uploaded_Thanos, 2000);
            frmMessage.StartPosition = FormStartPosition.Manual;
            frmMessage.Location = mouse_pt;
            frmMessage.ShowDialog();

            ResetUpload();

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

                if (radDeck.Checked)
                {
                    filePath = @"Cardbacks/" + lblCardSelected.Text + "/" +
                    DateTime.Now.ToString("yyMMdd_HHmmss") + "_" + txtVariantName.Text + "_" + Properties.Settings.Default.username + "_" + hashVerify;
                }

                if (chkUploadNsfw.Checked)
                    filePath = filePath + "_nsfw";

                //Upload Image
                byte[] imageArray = File.ReadAllBytes("capture.png");
                string base64Image = Convert.ToBase64String(imageArray);
                filePath = filePath + ".image";
                await client.Repository.Content.CreateFile(
                     owner, repoName, filePath,
                     new CreateFileRequest($"Upload Image: " + lblCardSelected.Text, base64Image, branch));

                byte[] bundleArray = File.ReadAllBytes(txtBundleLoc.Text);
                string base64Bundle = Convert.ToBase64String(bundleArray);
                filePath = filePath.Replace(".image",".variant");
                await client.Repository.Content.CreateFile(
                     owner, repoName, filePath,
                     new CreateFileRequest($"Upload Bundle: " + lblCardSelected.Text, base64Bundle, branch));
                File.Delete("capture.png");

                //MessageBox.Show("Upload successful");
                var mm = new MainMenu();
                Point mouse_pt = new Point(MousePosition.X, MousePosition.Y-200);
                Message frmMessage = new Message(Properties.Resources.Uploaded_Thanos, 2000);
                frmMessage.StartPosition = FormStartPosition.Manual;
                frmMessage.Location = mouse_pt;
                frmMessage.ShowDialog();

                ResetUpload();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Upload Error");
            }
        }

        private void btnPatch_Click(object sender, EventArgs e)
        {
            string appDataPath = @"%APPDATA%\..\LocalLow\Second Dinner\Snap\com.unity.addressables\";
            bool access = false;
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

                //Check if user has access to AppData folder
                if (Directory.Exists(Environment.ExpandEnvironmentVariables(appDataPath)))
                {
                    try
                    {
                        StreamWriter file = new StreamWriter(Environment.ExpandEnvironmentVariables(appDataPath) + @"\writeTest.txt");
                        file.WriteLine("Test");
                        file.Close();
                        File.Delete(Environment.ExpandEnvironmentVariables(appDataPath) + @"\writeTest.txt");
                        access = true;
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message.ToString().Contains("A required privilege is not held by the client"))
                            MessageBox.Show("Unable to copy patched JSON to AppData folder.\n\n" +
                                "Either run the tool as 'Admin' and try again or \n" + 
                                "Go to game directory, look for 'MockCdn' folder, copy the file '" + taskFiles[0].Name.ToString() + ".patched' along with the '.hash' file\n" +
                                "and paste it under 'AppData\\LocalLow\\Second Dinner\\Snap\\com.unity.addressables' \n" +
                                "and rename '.patched' to only .json", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        else
                            MessageBox.Show(ex.Message);
                    }
                }

                //if user has access, then delete after copying over to AppData, otherwise let user take manual action
                if (access)
                {
                    if (File.Exists(Environment.ExpandEnvironmentVariables(appDataPath) + taskFiles[0].Name.ToString()))
                        File.Delete(Environment.ExpandEnvironmentVariables(appDataPath) + taskFiles[0].Name.ToString());
                    File.Copy(catalogDir + patchedfile, Environment.ExpandEnvironmentVariables(appDataPath) + taskFiles[0].Name.ToString());
                    File.Copy(catalogDir + taskFiles[0].Name.ToString().Replace(".json",".hash"), Environment.ExpandEnvironmentVariables(appDataPath) + taskFiles[0].Name.ToString().Replace(".json", ".hash"));
                    File.Delete(catalogDir + patchedfile);
                }
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

        private void btnPull_Click(object sender, EventArgs e)
        {
            flow_variants.Controls.Clear();
            lblNoVariants.Visible = false;
            lblInstalled.Visible = false;
            lblDblClick.Visible = false;
            RetrievePreview(@"Variants/", dgv_cards);
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
            dlg_screenshot.Filter = "PNG|*.png";

            DialogResult result = dlg_screenshot.ShowDialog();

            if (result == DialogResult.OK)
            {
                Bitmap bmp = new Bitmap(dlg_screenshot.FileName);
                Console.WriteLine(bmp.Width);
                if (bmp.Width > bmp.Height)
                {
                    MessageBox.Show("Please select a portrait image for thumbnail, see below for optimum image size:\n\n"
                    + "1. Dimension 520 x 620\n2. Aspect Ratio 26:31\n3. Mode Portrait", "Image size issue", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    pic_upload.Image = null;
                    return;
                }
                pic_upload.Image = new Bitmap(dlg_screenshot.FileName);
                pic_upload.SizeMode = PictureBoxSizeMode.Zoom;
            }
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
            Process.Start("https://www.google.com");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.google.com");
        }

        private void btnPullDeck_Click(object sender, EventArgs e)
        {
            flow_deck.Controls.Clear();
            lblNoDecks.Visible = false;
            lblInstalledDeck.Visible = false;
            lblDblClickDeck.Visible = false;
            RetrievePreview(@"Cardbacks/", dgv_decks);
        }

        private void MainMenu_Shown(object sender, EventArgs e)
        {
            var mm = new MainMenu();
            Point mainFrmPoint = new Point(this.Location.X+100, this.Location.Y+200);
            Message frmMessage = new Message(Properties.Resources.App_Banner, 2500);
            frmMessage.Size = this.Size;
            frmMessage.StartPosition = this.StartPosition;
            frmMessage.Location = mainFrmPoint; 
            frmMessage.ShowDialog();
        }

        private void dgv_decks_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            flow_deck.Controls.Clear();
            lblNoDecks.Visible = false;
            lblInstalledDeck.Visible = false;
            lblDblClickDeck.Visible = false;
            RetrievePreview(@"Cardbacks/", dgv_decks);
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            RestoreBackup();
        }

        private void btnRestoreDeck_Click(object sender, EventArgs e)
        {
            RestoreBackup();
        }

        private void RestoreBackup()
        {
            string cardSelected = dgv_cards.CurrentRow.Cells[1].Value.ToString();
            string backupPath = Path.Combine(Environment.CurrentDirectory, "Backup");
            if (File.Exists(backupPath + "\\" + cardSelected))
            {
                //Check MockCdn has this matching backup

                //Option: copy the old hash and replace with new hash
                MessageBox.Show("This will restore the original file that was automatically backed up before a custom variant was installed"+
                    "\nIf the restored backup is not correct in-game, delete the file respective .bundle from the Backup folder" +
                    "\nAnother way to restore all files is via Steam Game Properties and selecting 'Verify integrity of game files'" +
                    "\n\nRestore backup using existing file?", "Backup found", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                //if DialogResult.Ok

                //Copy file from /Backup/
                //Paste to MockCdn, overwrite true
                string snapFolder = Properties.Settings.Default.snapLocation + @"\SNAP_Data\StreamingAssets\aa\StandaloneWindows64\MockCdn";
                File.Copy(Path.Combine(backupPath, cardSelected), Path.Combine(snapFolder, cardSelected), true);

                //Emote Pop Up
                var mm = new MainMenu();
                Point mouse_pt = new Point(MousePosition.X, MousePosition.Y-200);
                Message frmMessage = new Message(Properties.Resources.HulkThing_FistBump, 2000);
                frmMessage.StartPosition = FormStartPosition.Manual;
                frmMessage.Location = mouse_pt;
                frmMessage.ShowDialog();
            }
        }

    }
}
