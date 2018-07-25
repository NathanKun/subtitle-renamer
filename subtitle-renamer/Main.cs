using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace subtitle_renamer
{
    public partial class Main : Form
    {
        private List<string> files = new List<string>();
        private List<string> mediaFiles = new List<string>();
        private List<string> subFiles = new List<string>();

        public Main()
        {
            InitializeComponent();

            textBoxDir.Enabled = false;
            textBoxSubDelete.Enabled = false;
            textBoxSubAdd.Enabled = false;
            EnableInputs(false);
        }

        private void EnableInputs(bool enabled)
        {
            checkBoxPrefix.Enabled = enabled;
            checkBoxEpisode.Enabled = enabled;
            checkBoxDelete.Enabled = enabled;
            checkBoxAdd.Enabled = enabled;
            checkBoxSuffix.Enabled = enabled;

            textBoxSubSuffix.Enabled = enabled;
            textBoxMediaSuffix.Enabled = enabled;

            textBoxSubEpStart.Enabled = enabled;
            textBoxSubEpEnd.Enabled = enabled;

            //textBoxSubDelete.Enabled = enabled;
            //textBoxSubAdd.Enabled = enabled;

            textBoxSubPrefix.Enabled = enabled;
            textBoxMediaPrefix.Enabled = enabled;

            textBoxSubExtension.Enabled = enabled;
            textBoxMediaExtension.Enabled = enabled;
        }

        private void UpdateListView(List<string> filenames, ListView lv)
        {
            lv.BeginUpdate();
            lv.Items.Clear();

            foreach (string f in filenames)
            {
                lv.Items.Add(new ListViewItem(f));
            }

            lv.EndUpdate();
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    files.Clear();
                    files.AddRange(Directory.GetFiles(fbd.SelectedPath));

                    textBoxDir.Text = fbd.SelectedPath;
                    textBoxMediaExtension.Enabled = true;
                    textBoxSubExtension.Enabled = true;
                }
            }
        }

        private void textBoxMediaExtension_TextChanged(object sender, EventArgs e)
        {
            string ext = textBoxMediaExtension.Text.Trim();

            // auto add . at start
            if (!ext.StartsWith("."))
            {
                textBoxMediaExtension.Text = "." + textBoxMediaExtension.Text;
                textBoxMediaExtension.SelectionStart = textBoxMediaExtension.Text.Length;
                return;
            }

            // search files with input extension and update listview
            if (ext.Length != 0)
            {
                mediaFiles.Clear();
                foreach(string f in files)
                {
                    if (f.EndsWith(ext))
                    {
                        mediaFiles.Add(f);
                    }
                }
                UpdateListView(mediaFiles, listViewMedia);
            }
        }

        private void textBoxSubExtension_TextChanged(object sender, EventArgs e)
        {
            string ext = textBoxSubExtension.Text.Trim();

            // auto add . at start
            if (!ext.StartsWith("."))
            {
                textBoxSubExtension.Text = "." + textBoxSubExtension.Text;
                textBoxSubExtension.SelectionStart = textBoxSubExtension.Text.Length;
                return;
            }

            // search files with input extension and update listview
            if (ext.Length != 0)
            {
                subFiles.Clear();
                foreach (string f in files)
                {
                    if (f.EndsWith(ext))
                    {
                        subFiles.Add(f);
                    }
                }
                UpdateListView(subFiles, listViewSub);
            }
        }

        private void checkBoxPrefix_CheckedChanged(object sender, EventArgs e)
        {
            textBoxMediaPrefix.Enabled = checkBoxPrefix.Checked;
            textBoxSubPrefix.Enabled = checkBoxPrefix.Checked;
        }

        private void checkBoxEpisode_CheckedChanged(object sender, EventArgs e)
        {
            textBoxSubEpStart.Enabled = checkBoxEpisode.Checked;
            textBoxSubEpEnd.Enabled = checkBoxEpisode.Checked;
        }

        private void checkBoxDelete_CheckedChanged(object sender, EventArgs e)
        {
            textBoxSubDelete.Enabled = checkBoxDelete.Checked;
        }

        private void checkBoxAdd_CheckedChanged(object sender, EventArgs e)
        {
            textBoxSubAdd.Enabled = checkBoxAdd.Checked;
        }

        private void checkBoxSuffix_CheckedChanged(object sender, EventArgs e)
        {
            textBoxMediaSuffix.Enabled = checkBoxSuffix.Checked;
            textBoxSubSuffix.Enabled = checkBoxSuffix.Checked;
        }
    }
}
