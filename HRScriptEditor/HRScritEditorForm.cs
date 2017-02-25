using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;


namespace WindowsFormsApplication1
{
    public partial class HRScritEditorForm : Form
    {
        Dictionary<string, FileContainer> m_Files = new Dictionary<string, FileContainer>();
        string m_SettingsPath = "/home/lvuser/";


        public HRScritEditorForm()
        {
            InitializeComponent();
        }

        // byte[] toBytes = Encoding.ASCII.GetBytes(somestring);
        // string something = Encoding.ASCII.GetString(toBytes);

        private bool Upload(FileContainer f)
        {
            // if user doesn't use a robot ip address, don't try to upload
            if (TextBoxServer.Text.Length == 0)
            {
                return false;
            }

            try
            {

                // Get the object used to communicate with the server.  
                string req_string = "ftp://" + TextBoxServer.Text + m_SettingsPath + f.m_Filename;
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(req_string);
                request.ReadWriteTimeout = 3000;
                request.Timeout = 1000;
                request.Method = WebRequestMethods.Ftp.UploadFile;

                // This example assumes the FTP site uses anonymous logon.  
                request.Credentials = new NetworkCredential("anonymous", "987Rules");

                // Copy the contents of the file to the request stream.  
                byte[] fileContents = Encoding.ASCII.GetBytes(f.m_Text);
                request.ContentLength = fileContents.Length;
                Stream requestStream = request.GetRequestStream();
                requestStream.Write(fileContents, 0, fileContents.Length);
                requestStream.Close();

                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                Console.WriteLine("Upload File Complete, status {0}", response.StatusDescription);
                response.Close();
                f.m_Modified = false;
            }
            catch
            {
                TextBoxServer.Text = "";
                // don't show a message box on every file...
                return false;
            }
            return true;
        }

        private void Download(FileContainer f)
        {
            // if user doesn't use a robot ip address, don't try to upload
            if (TextBoxServer.Text.Length == 0)
            {
                return;
            }

            try
            {
                // Get the object used to communicate with the server.  
                string req_string = "ftp://" + TextBoxServer.Text + m_SettingsPath + f.m_Filename;
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(req_string);
                request.Method = WebRequestMethods.Ftp.DownloadFile;

                // This example assumes the FTP site uses anonymous logon.  
                request.Credentials = new NetworkCredential("anonymous", "987Rules");

                FtpWebResponse response = (FtpWebResponse)request.GetResponse();

                Stream responseStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream);
                f.m_Text = reader.ReadToEnd();

                Console.WriteLine("Download Complete, status {0}", response.StatusDescription);

                reader.Close();
                response.Close();
                f.m_Modified = true;
            }
            catch
            {
                TextBoxServer.Text = "";
            }
        }

        private string GetLocalPath()
        {
            string path = TextBoxPath.Text;
            if (!path.EndsWith("\\"))
            {
                path += "\\";
            }
            return path;
        }

        private bool SaveLocal(FileContainer fcon)
        {
            string local_fname = GetLocalPath();
            local_fname += fcon.m_Filename;

            System.IO.File.WriteAllText(local_fname, fcon.m_Text);
            return true;
        }

        private void LoadLocal(FileContainer fcon)
        {
            string local_fname = GetLocalPath() + fcon.m_Filename;
            fcon.m_Text = System.IO.File.ReadAllText(local_fname);
        }

        private void ButtonLoadRobot_Click(object sender, EventArgs e)
        {
            // scan for files on the host and download or update any of them
            string req_string = "ftp://" + TextBoxServer.Text + m_SettingsPath + "*.hrs";
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(req_string);
            request.Method = WebRequestMethods.Ftp.ListDirectory;
            request.Credentials = new NetworkCredential("anonymous", "987Rules");

            try
            {
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                Stream responseStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream);

                List<string> filenames = new List<string>();
                while (!reader.EndOfStream)
                {
                    string fname = reader.ReadLine();
                    filenames.Add(fname);
                }
                response.Close();

                foreach (string fname in filenames)
                {
                    FileContainer fcon = null;
                    if (!m_Files.ContainsKey(fname))
                    {
                        fcon = new FileContainer();
                        fcon.m_Filename = fname;
                        m_Files.Add(fcon.m_Filename, fcon);
                    }
                    else
                    {
                        fcon = m_Files[fname];
                    }
                    Download(fcon);
                    SaveLocal(fcon);
                }
                Update_File_List_Combo();
            }
            catch {
                MessageBox.Show(TextBoxServer.Text + " could not be reached.");
                TextBoxServer.Text = "";
            }
        }

        private void ButtonLoadLocal_Click(object sender, EventArgs e)
        {
            // get list of HRS files in the local directory
            string[] filenames = Directory.GetFiles(GetLocalPath(),"*.hrs");

            foreach (string fname in filenames)
            {
                FileContainer fcon = null;
                if (!m_Files.ContainsKey(fname))
                {
                    fcon = new FileContainer();
                    fcon.m_Filename = Path.GetFileName(fname);
                    m_Files.Add(fcon.m_Filename, fcon);
                }
                else
                {
                    fcon = m_Files[fname];
                }
                LoadLocal(fcon);
                fcon.m_Modified = true;
            }
            Update_File_List_Combo();
        }

        private void ButtonUpload_Click(object sender, EventArgs e)
        {
            // First save files
            int save_counter = 0;
            foreach (FileContainer f in m_Files.Values)
            {
                if (f.m_Modified)
                {
                    if (SaveLocal(f)) save_counter++;
                }
            }

            // First, upload any files we have modified
            int upload_counter = 0;
            foreach (FileContainer f in m_Files.Values)
            {
                if (f.m_Modified)
                {
                    if (Upload(f)) upload_counter++;
                }
            }
            MessageBox.Show("Saved " + save_counter.ToString() + " files, Uploaded " + upload_counter.ToString() + " files.");
        }


        private void Update_File_List_Combo()
        { 
            string cur_file = Get_Current_Filename();
            FilesCombo.Items.Clear();
            foreach (FileContainer f in m_Files.Values)
            {
                FilesCombo.Items.Add(f.m_Filename);
            }
            if (cur_file == "")
            {
                cur_file = "RobotSettings.hrs";  // Try to pick RobotSettings.hrs
            }
            int index = FilesCombo.Items.IndexOf(cur_file);
            if ((index == -1) && (FilesCombo.Items.Count > 0))
            {
                index = 0;
            }
            FilesCombo.SelectedIndex = index;
        }

        private void ServerTextBox_TextChanged(object sender, EventArgs e)
        {
        }

        private string Get_Current_Filename()
        {
            string fname = FilesCombo.SelectedItem as string;
            if (fname == null)
            {
                fname = "";
            }
            return fname;
        }

        private void FilesCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string filename = Get_Current_Filename();
            if (m_Files.ContainsKey(filename))
            {
                FileEdit.Text = m_Files[filename].m_Text; 
            }
            else
            {
                FileEdit.Clear();
            }
        }

        private void FileEdit_TextChanged(object sender, EventArgs e)
        {
            string filename = Get_Current_Filename();
            if (m_Files.ContainsKey(filename))
            {
                FileContainer fcon = m_Files[filename];
                fcon.m_Text = FileEdit.Text;
                fcon.m_Modified = true;
            }
        }

 
        private void ButtonBrowse_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    TextBoxPath.Text = fbd.SelectedPath;

                    //string[] files = Directory.GetFiles(fbd.SelectedPath);
                    //System.Windows.Forms.MessageBox.Show("Files found: " + files.Length.ToString(), "Message");
                }
            }
        }

 
    }
}
