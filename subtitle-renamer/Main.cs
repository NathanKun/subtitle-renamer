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
            ListviewCheckInit();
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

        private void ListviewCheckInit()
        {
            var header = new ColumnHeader();
            header.Text = "";
            listViewCheck.Columns.Add(header);
            header = new ColumnHeader();
            header.Text = "Before";
            listViewCheck.Columns.Add(header);
            header = new ColumnHeader();
            header.Text = "After";
            listViewCheck.Columns.Add(header);

            ListviewCheckAjustWidth();
        }

        private void ListviewCheckAjustWidth()
        {
            listViewCheck.Columns[0].Width = -2;
            listViewCheck.Columns[1].Width = -2;
            listViewCheck.Columns[2].Width = -2;
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

            foreach(string s in canStartsWith)
            {
                Console.WriteLine(s);
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


        /**
         * Check if can rename
         */
        private bool Check()
        {
            if (mediaFiles.Count == 0 || mediaFiles.Count != subFiles.Count)
            {
                MessageBox.Show("Number of media and sub are different", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            string mediaExt = textBoxMediaExtension.Text;
            string subExt = textBoxSubExtension.Text;
            string mediaPrefix = textBoxMediaPrefix.Text;
            string subPrefix = textBoxSubPrefix.Text;
            string mediaSuffix = textBoxMediaSuffix.Text;
            string subSuffix = textBoxSubSuffix.Text;

            var results = new List<string>();

            for (int i = 0; i < mediaFiles.Count; i++)
            {

                int episodeStrLen = textBoxSubEpEnd.Text.Length;

                var tmp = subFiles[i];

                // prefix
                if (checkBoxPrefix.Checked)
                {
                    // remove sub prefix
                    tmp = tmp.Substring(subPrefix.Length);
                    // add media prefix
                    tmp = mediaPrefix + tmp;
                }

                var indexAfterEpisode = mediaPrefix.Length;
                if (checkBoxEpisode.Checked)
                {
                    indexAfterEpisode += episodeStrLen;
                }

                // delete partToDelete
                partToDelete = tmp.Substring(indexAfterEpisode, tmp.Length - indexAfterEpisode - subSuffix.Length - subExt.Length);
                if (partToDelete.Length > 0)
                {
                    var startPart = tmp.Substring(0, indexAfterEpisode);
                    var iStart = indexAfterEpisode + partToDelete.Length;
                    var len = tmp.Length - iStart;
                    var endPart = tmp.Substring(iStart, len);
                    tmp = startPart + endPart;

                    checkBoxDelete.Checked = true;
                }

                // add partToAdd
                var mediaName = mediaFiles[i];
                partToAdd = mediaName.Substring(mediaPrefix.Length + episodeStrLen);
                partToAdd = partToAdd.Substring(0, partToAdd.Length - partToAdd.IndexOf(mediaSuffix));
                if (partToAdd.Length > 0)
                {
                    var startPart = tmp.Substring(0, indexAfterEpisode);
                    var endPart = tmp.Substring(indexAfterEpisode, tmp.Length - indexAfterEpisode);
                    tmp = startPart + partToAdd + endPart;

                    checkBoxAdd.Checked = true;
                }

                // suffix
                if (checkBoxSuffix.Checked)
                {
                    // remove sub prefix
                    tmp = tmp.Substring(0, tmp.IndexOf(subSuffix));
                    // add media prefix
                    tmp += mediaSuffix + subExt;
                }

                if (tmp == subExt)
                {
                    MessageBox.Show("Filename left only it's extension after delete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                results.Add(tmp);
            }

            // update listview check
            listViewCheck.BeginUpdate();
            listViewCheck.Items.Clear();

            for (int i = 0; i < results.Count; i++)
            {
                var lvi = new ListViewItem(i.ToString());
                lvi.SubItems.Add(subFiles[i]);
                lvi.SubItems.Add(results[i]);
                listViewCheck.Items.Add(lvi);
            }

            ListviewCheckAjustWidth();
            listViewCheck.EndUpdate();

            // check if there are same filenames in results
            for (int i = 0; i < results.Count; i++)
            {
                var r = results[i];

                for (int j = i + 1; j < results.Count; j++)
                {
                    if (r == results[j])
                    {
                        MessageBox.Show("Same filename in result", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }

            return true;
        }

        /**
         * Check button onclick
         */
        private void buttonCheck_Click(object sender, EventArgs e)
        {
            try
            {
                if (Check())
                {
                    MessageBox.Show("Success", "Rename Check", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                }
            } catch (Exception ex)
            {
                MessageBox.Show("Exception", "Rename Check", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Console.WriteLine(ex.ToString());
            }
            
        }

        private void buttonRename_Click(object sender, EventArgs e)
        {
            if (Check())
            {

            }
            else
            {

            }
        }
    }
}
