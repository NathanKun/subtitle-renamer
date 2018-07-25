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

        private string partToAdd = "";
        private string partToDelete = "";

        public Main()
        {
            InitializeComponent();

            DisableInputs();
        }

        private void DisableInputs()
        {
            textBoxDir.Enabled = false;

            checkBoxPrefix.Enabled = false;
            checkBoxEpisode.Enabled = false;
            checkBoxDelete.Enabled = false;
            checkBoxAdd.Enabled = false;
            checkBoxSuffix.Enabled = false;

            textBoxSubSuffix.Enabled = false;
            textBoxMediaSuffix.Enabled = false;

            textBoxSubEpStart.Enabled = false;
            textBoxSubEpEnd.Enabled = false;

            textBoxSubDelete.Enabled = false;
            textBoxSubAdd.Enabled = false;

            textBoxSubPrefix.Enabled = false;
            textBoxMediaPrefix.Enabled = false;

            textBoxSubExtension.Enabled = false;
            textBoxMediaExtension.Enabled = false;
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

        private List<string> GenerateEpisodeArray(string start, string end)
        {
            if (!int.TryParse(start, out int min) || !int.TryParse(end, out int max))
            {
                return null;
            }

            var list = new List<string>();
            int len = end.Length;

            for (int epInt = min; epInt < max + 1; epInt++)
            {
                var epStr = epInt.ToString();
                for (int d = epStr.Length; d < len; d++)
                {
                    epStr = "0" + epStr;
                }
                list.Add(epStr);
            }

            return list;
        }

        /**
         * Files Filters
         */

        private void FilterMediaFiles()
        {
            string ext = textBoxMediaExtension.Text.Trim();
            string prefix = checkBoxPrefix.Checked ? textBoxMediaPrefix.Text : "";
            string suffix = checkBoxSuffix.Checked ? textBoxMediaSuffix.Text : "";
            List<string> eps = checkBoxEpisode.Checked ? GenerateEpisodeArray(textBoxSubEpStart.Text, textBoxSubEpEnd.Text) : null;

            var canStartsWith = new List<string>();
            if (eps == null)
            {
                canStartsWith.Add(prefix);
            }
            else
            {
                foreach (string ep in eps)
                {
                    canStartsWith.Add(prefix + ep);
                }
            }

            var shouldEndsWith = suffix + ext;

            if (ext.Length != 0)
            {
                mediaFiles.Clear();
                foreach (string f in files)
                {
                    if (f.EndsWith(shouldEndsWith))
                    {
                        foreach (string start in canStartsWith)
                        {
                            if (f.StartsWith(start))
                            {
                                mediaFiles.Add(f);
                                break;
                            }
                        }
                    }
                }
                UpdateListView(mediaFiles, listViewMedia);

                // calculate partToAdd
                if (mediaFiles.Count > 0 && canStartsWith.Count > 0)
                {
                    var start = canStartsWith[0].Length;
                    var len = mediaFiles[0].Length - shouldEndsWith.Length - start;
                    partToAdd = mediaFiles[0].Substring(start, len);

                    if (partToAdd.Length > 0)
                    {
                        partToAdd += " etc";
                    }

                    textBoxSubAdd.Text = partToAdd;
                }
            }
        }

        private void FilterSubFiles()
        {
            string ext = textBoxSubExtension.Text.Trim();
            string prefix = checkBoxPrefix.Checked ? textBoxSubPrefix.Text : "";
            string suffix = checkBoxSuffix.Checked ? textBoxSubSuffix.Text : "";
            List<string> eps = checkBoxEpisode.Checked ? GenerateEpisodeArray(textBoxSubEpStart.Text, textBoxSubEpEnd.Text) : null;

            var canStartsWith = new List<string>();
            if (eps == null)
            {
                canStartsWith.Add(prefix);
            }
            else
            {
                foreach (string ep in eps)
                {
                    canStartsWith.Add(prefix + ep);
                }
            }

            var shouldEndsWith = suffix + ext;

            if (ext.Length != 0)
            {
                subFiles.Clear();
                foreach (string f in files)
                {
                    if (f.EndsWith(shouldEndsWith))
                    {
                        foreach (string start in canStartsWith)
                        {
                            if (f.StartsWith(start))
                            {
                                subFiles.Add(f);
                                break;
                            }
                        }
                    }
                }
                UpdateListView(subFiles, listViewSub);

                // calculate partToAdd
                if (subFiles.Count > 0 && canStartsWith.Count > 0)
                {
                    var start = canStartsWith[0].Length;
                    var len = subFiles[0].Length - shouldEndsWith.Length - start;
                    partToDelete = subFiles[0].Substring(start, len);

                    if (partToDelete.Length > 0)
                    {
                        partToDelete += " etc";
                    }

                    textBoxSubDelete.Text = partToDelete;
                }
            }
        }


        /**
         * LISTENERS
         */

        /**
         * Choose file button onclick
         */

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    files.Clear();

                    var filesWithDir = Directory.GetFiles(fbd.SelectedPath);
                    foreach (string f in filesWithDir)
                    {
                        string[] splited = f.Split('\\');

                        files.Add(splited[splited.Length - 1]);
                    }

                    textBoxDir.Text = fbd.SelectedPath;

                    textBoxMediaExtension.Enabled = true;
                    textBoxSubExtension.Enabled = true;

                    checkBoxPrefix.Enabled = true;
                    checkBoxEpisode.Enabled = true;
                    checkBoxSuffix.Enabled = true;

                    //checkBoxAdd.Enabled = true;
                    //checkBoxDelete.Enabled = true;
                }
            }
        }



        /**
         * Extension textboxes changed
         */

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

            FilterMediaFiles();
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

            FilterSubFiles();
        }



        /**
         * Checkboxes changed
         */

        private void checkBoxPrefix_CheckedChanged(object sender, EventArgs e)
        {
            textBoxMediaPrefix.Enabled = checkBoxPrefix.Checked;
            textBoxSubPrefix.Enabled = checkBoxPrefix.Checked;

            FilterMediaFiles();
            FilterSubFiles();
        }

        private void checkBoxEpisode_CheckedChanged(object sender, EventArgs e)
        {
            textBoxSubEpStart.Enabled = checkBoxEpisode.Checked;
            textBoxSubEpEnd.Enabled = checkBoxEpisode.Checked;

            FilterMediaFiles();
            FilterSubFiles();
        }

        private void checkBoxDelete_CheckedChanged(object sender, EventArgs e)
        {
            FilterMediaFiles();
            FilterSubFiles();
        }

        private void checkBoxAdd_CheckedChanged(object sender, EventArgs e)
        {
            FilterMediaFiles();
            FilterSubFiles();
        }

        private void checkBoxSuffix_CheckedChanged(object sender, EventArgs e)
        {
            textBoxMediaSuffix.Enabled = checkBoxSuffix.Checked;
            textBoxSubSuffix.Enabled = checkBoxSuffix.Checked;

            FilterMediaFiles();
            FilterSubFiles();
        }



        /**
         * Media inputs changed
         */

        private void textBoxMediaPrefix_TextChanged(object sender, EventArgs e)
        {
            FilterMediaFiles();
        }

        private void textBoxMediaSuffix_TextChanged(object sender, EventArgs e)
        {
            FilterMediaFiles();
        }



        /**
         * Sub inputs changed
         */

        private void textBoxSubEpStart_TextChanged(object sender, EventArgs e)
        {
            FilterMediaFiles();
            FilterSubFiles();
        }

        private void textBoxSubEpEnd_TextChanged(object sender, EventArgs e)
        {
            FilterMediaFiles();
            FilterSubFiles();
        }

        private void textBoxSubPrefix_TextChanged(object sender, EventArgs e)
        {
            FilterSubFiles();
        }

        private void textBoxSubSuffix_TextChanged(object sender, EventArgs e)
        {
            FilterSubFiles();
        }

        private void buttonCheck_Click(object sender, EventArgs e)
        {
            var results = new List<string>();

        }
    }
}
