namespace subtitle_renamer
{
    partial class Main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.labelDirpath = new System.Windows.Forms.Label();
            this.textBoxDir = new System.Windows.Forms.TextBox();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.checkBoxPrefix = new System.Windows.Forms.CheckBox();
            this.checkBoxEpisode = new System.Windows.Forms.CheckBox();
            this.checkBoxDelete = new System.Windows.Forms.CheckBox();
            this.checkBoxAdd = new System.Windows.Forms.CheckBox();
            this.checkBoxExtension = new System.Windows.Forms.CheckBox();
            this.textBoxMediaExtension = new System.Windows.Forms.TextBox();
            this.textBoxSubExtension = new System.Windows.Forms.TextBox();
            this.textBoxSubAdd = new System.Windows.Forms.TextBox();
            this.textBoxSubDelete = new System.Windows.Forms.TextBox();
            this.textBoxSubEpStart = new System.Windows.Forms.TextBox();
            this.textBoxSubEpEnd = new System.Windows.Forms.TextBox();
            this.textBoxSubPrefix = new System.Windows.Forms.TextBox();
            this.textBoxSubSuffix = new System.Windows.Forms.TextBox();
            this.checkBoxSuffix = new System.Windows.Forms.CheckBox();
            this.textBoxMediaPrefix = new System.Windows.Forms.TextBox();
            this.textBoxMediaSuffix = new System.Windows.Forms.TextBox();
            this.labelMedia = new System.Windows.Forms.Label();
            this.labelSub = new System.Windows.Forms.Label();
            this.listViewMedia = new System.Windows.Forms.ListView();
            this.listViewSub = new System.Windows.Forms.ListView();
            this.listViewCheck = new System.Windows.Forms.ListView();
            this.buttonCheck = new System.Windows.Forms.Button();
            this.buttonRename = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Location = new System.Drawing.Point(45, 7);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(41, 23);
            this.buttonBrowse.TabIndex = 1;
            this.buttonBrowse.Text = "...";
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
            // 
            // labelDirpath
            // 
            this.labelDirpath.AutoSize = true;
            this.labelDirpath.Location = new System.Drawing.Point(13, 13);
            this.labelDirpath.Name = "labelDirpath";
            this.labelDirpath.Size = new System.Drawing.Size(26, 17);
            this.labelDirpath.TabIndex = 2;
            this.labelDirpath.Text = "Dir";
            // 
            // textBoxDir
            // 
            this.textBoxDir.Location = new System.Drawing.Point(92, 7);
            this.textBoxDir.Name = "textBoxDir";
            this.textBoxDir.Size = new System.Drawing.Size(930, 22);
            this.textBoxDir.TabIndex = 2;
            // 
            // checkBoxPrefix
            // 
            this.checkBoxPrefix.AutoSize = true;
            this.checkBoxPrefix.Location = new System.Drawing.Point(68, 44);
            this.checkBoxPrefix.Name = "checkBoxPrefix";
            this.checkBoxPrefix.Size = new System.Drawing.Size(65, 21);
            this.checkBoxPrefix.TabIndex = 3;
            this.checkBoxPrefix.Text = "Prefix";
            this.checkBoxPrefix.UseVisualStyleBackColor = true;
            this.checkBoxPrefix.CheckedChanged += new System.EventHandler(this.checkBoxPrefix_CheckedChanged);
            // 
            // checkBoxEpisode
            // 
            this.checkBoxEpisode.AutoSize = true;
            this.checkBoxEpisode.Location = new System.Drawing.Point(254, 44);
            this.checkBoxEpisode.Name = "checkBoxEpisode";
            this.checkBoxEpisode.Size = new System.Drawing.Size(81, 21);
            this.checkBoxEpisode.TabIndex = 4;
            this.checkBoxEpisode.Text = "Episode";
            this.checkBoxEpisode.UseVisualStyleBackColor = true;
            this.checkBoxEpisode.CheckedChanged += new System.EventHandler(this.checkBoxEpisode_CheckedChanged);
            // 
            // checkBoxDelete
            // 
            this.checkBoxDelete.AutoSize = true;
            this.checkBoxDelete.Location = new System.Drawing.Point(384, 44);
            this.checkBoxDelete.Name = "checkBoxDelete";
            this.checkBoxDelete.Size = new System.Drawing.Size(71, 21);
            this.checkBoxDelete.TabIndex = 5;
            this.checkBoxDelete.Text = "Delete";
            this.checkBoxDelete.UseVisualStyleBackColor = true;
            this.checkBoxDelete.CheckedChanged += new System.EventHandler(this.checkBoxDelete_CheckedChanged);
            // 
            // checkBoxAdd
            // 
            this.checkBoxAdd.AutoSize = true;
            this.checkBoxAdd.Location = new System.Drawing.Point(570, 44);
            this.checkBoxAdd.Name = "checkBoxAdd";
            this.checkBoxAdd.Size = new System.Drawing.Size(55, 21);
            this.checkBoxAdd.TabIndex = 6;
            this.checkBoxAdd.Text = "Add";
            this.checkBoxAdd.UseVisualStyleBackColor = true;
            this.checkBoxAdd.CheckedChanged += new System.EventHandler(this.checkBoxAdd_CheckedChanged);
            // 
            // checkBoxSuffix
            // 
            this.checkBoxSuffix.AutoSize = true;
            this.checkBoxSuffix.Location = new System.Drawing.Point(758, 44);
            this.checkBoxSuffix.Name = "checkBoxSuffix";
            this.checkBoxSuffix.Size = new System.Drawing.Size(64, 21);
            this.checkBoxSuffix.TabIndex = 7;
            this.checkBoxSuffix.Text = "Suffix";
            this.checkBoxSuffix.UseVisualStyleBackColor = true;
            this.checkBoxSuffix.CheckedChanged += new System.EventHandler(this.checkBoxSuffix_CheckedChanged);
            // 
            // checkBoxExtension
            // 
            this.checkBoxExtension.AutoSize = true;
            this.checkBoxExtension.Checked = true;
            this.checkBoxExtension.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxExtension.Enabled = false;
            this.checkBoxExtension.Location = new System.Drawing.Point(942, 44);
            this.checkBoxExtension.Name = "checkBoxExtension";
            this.checkBoxExtension.Size = new System.Drawing.Size(91, 21);
            this.checkBoxExtension.TabIndex = 8;
            this.checkBoxExtension.Text = "Extension";
            this.checkBoxExtension.UseVisualStyleBackColor = true;
            // 
            // textBoxMediaPrefix
            // 
            this.textBoxMediaPrefix.Location = new System.Drawing.Point(68, 71);
            this.textBoxMediaPrefix.Name = "textBoxMediaPrefix";
            this.textBoxMediaPrefix.Size = new System.Drawing.Size(180, 22);
            this.textBoxMediaPrefix.TabIndex = 9;
            this.textBoxMediaPrefix.TextChanged += new System.EventHandler(this.textBoxMediaPrefix_TextChanged);
            // 
            // textBoxSubPrefix
            // 
            this.textBoxSubPrefix.Location = new System.Drawing.Point(68, 110);
            this.textBoxSubPrefix.Name = "textBoxSubPrefix";
            this.textBoxSubPrefix.Size = new System.Drawing.Size(180, 22);
            this.textBoxSubPrefix.TabIndex = 10;
            this.textBoxSubPrefix.TextChanged += new System.EventHandler(this.textBoxSubPrefix_TextChanged);
            // 
            // textBoxSubEpStart
            // 
            this.textBoxSubEpStart.Location = new System.Drawing.Point(254, 110);
            this.textBoxSubEpStart.Name = "textBoxSubEpStart";
            this.textBoxSubEpStart.Size = new System.Drawing.Size(59, 22);
            this.textBoxSubEpStart.TabIndex = 11;
            this.textBoxSubEpStart.TextChanged += new System.EventHandler(this.textBoxSubEpStart_TextChanged);
            // 
            // textBoxSubEpEnd
            // 
            this.textBoxSubEpEnd.Location = new System.Drawing.Point(319, 110);
            this.textBoxSubEpEnd.Name = "textBoxSubEpEnd";
            this.textBoxSubEpEnd.Size = new System.Drawing.Size(59, 22);
            this.textBoxSubEpEnd.TabIndex = 12;
            this.textBoxSubEpEnd.TextChanged += new System.EventHandler(this.textBoxSubEpEnd_TextChanged);
            // 
            // textBoxSubDelete
            // 
            this.textBoxSubDelete.Location = new System.Drawing.Point(384, 110);
            this.textBoxSubDelete.Name = "textBoxSubDelete";
            this.textBoxSubDelete.Size = new System.Drawing.Size(180, 22);
            this.textBoxSubDelete.TabIndex = 13;
            // 
            // textBoxSubAdd
            // 
            this.textBoxSubAdd.Location = new System.Drawing.Point(570, 110);
            this.textBoxSubAdd.Name = "textBoxSubAdd";
            this.textBoxSubAdd.Size = new System.Drawing.Size(180, 22);
            this.textBoxSubAdd.TabIndex = 14;
            // 
            // textBoxMediaSuffix
            // 
            this.textBoxMediaSuffix.Location = new System.Drawing.Point(756, 71);
            this.textBoxMediaSuffix.Name = "textBoxMediaSuffix";
            this.textBoxMediaSuffix.Size = new System.Drawing.Size(180, 22);
            this.textBoxMediaSuffix.TabIndex = 15;
            this.textBoxMediaSuffix.TextChanged += new System.EventHandler(this.textBoxMediaSuffix_TextChanged);
            // 
            // textBoxSubSuffix
            // 
            this.textBoxSubSuffix.Location = new System.Drawing.Point(756, 110);
            this.textBoxSubSuffix.Name = "textBoxSubSuffix";
            this.textBoxSubSuffix.Size = new System.Drawing.Size(180, 22);
            this.textBoxSubSuffix.TabIndex = 16;
            this.textBoxSubSuffix.TextChanged += new System.EventHandler(this.textBoxSubSuffix_TextChanged);
            // 
            // textBoxMediaExtension
            // 
            this.textBoxMediaExtension.Location = new System.Drawing.Point(942, 71);
            this.textBoxMediaExtension.Name = "textBoxMediaExtension";
            this.textBoxMediaExtension.Size = new System.Drawing.Size(80, 22);
            this.textBoxMediaExtension.TabIndex = 17;
            this.textBoxMediaExtension.TextChanged += new System.EventHandler(this.textBoxMediaExtension_TextChanged);
            // 
            // textBoxSubExtension
            // 
            this.textBoxSubExtension.Location = new System.Drawing.Point(942, 110);
            this.textBoxSubExtension.Name = "textBoxSubExtension";
            this.textBoxSubExtension.Size = new System.Drawing.Size(80, 22);
            this.textBoxSubExtension.TabIndex = 18;
            this.textBoxSubExtension.TextChanged += new System.EventHandler(this.textBoxSubExtension_TextChanged);
            // 
            // labelMedia
            // 
            this.labelMedia.AutoSize = true;
            this.labelMedia.Location = new System.Drawing.Point(13, 74);
            this.labelMedia.Name = "labelMedia";
            this.labelMedia.Size = new System.Drawing.Size(46, 17);
            this.labelMedia.TabIndex = 19;
            this.labelMedia.Text = "Media";
            // 
            // labelSub
            // 
            this.labelSub.AutoSize = true;
            this.labelSub.Location = new System.Drawing.Point(13, 110);
            this.labelSub.Name = "labelSub";
            this.labelSub.Size = new System.Drawing.Size(33, 17);
            this.labelSub.TabIndex = 20;
            this.labelSub.Text = "Sub";
            // 
            // listViewMedia
            // 
            this.listViewMedia.Location = new System.Drawing.Point(16, 149);
            this.listViewMedia.Name = "listViewMedia";
            this.listViewMedia.Size = new System.Drawing.Size(492, 267);
            this.listViewMedia.TabIndex = 21;
            this.listViewMedia.UseCompatibleStateImageBehavior = false;
            this.listViewMedia.View = System.Windows.Forms.View.List;
            // 
            // listViewSub
            // 
            this.listViewSub.Location = new System.Drawing.Point(530, 149);
            this.listViewSub.Name = "listViewSub";
            this.listViewSub.Size = new System.Drawing.Size(492, 267);
            this.listViewSub.TabIndex = 22;
            this.listViewSub.UseCompatibleStateImageBehavior = false;
            this.listViewSub.View = System.Windows.Forms.View.List;
            // 
            // listViewCheck
            // 
            this.listViewCheck.Location = new System.Drawing.Point(16, 429);
            this.listViewCheck.Name = "listViewCheck";
            this.listViewCheck.Size = new System.Drawing.Size(1006, 267);
            this.listViewCheck.TabIndex = 23;
            this.listViewCheck.UseCompatibleStateImageBehavior = false;
            this.listViewCheck.View = System.Windows.Forms.View.Details;
            // 
            // buttonCheck
            // 
            this.buttonCheck.Location = new System.Drawing.Point(13, 706);
            this.buttonCheck.Name = "buttonCheck";
            this.buttonCheck.Size = new System.Drawing.Size(75, 23);
            this.buttonCheck.TabIndex = 24;
            this.buttonCheck.Text = "Check";
            this.buttonCheck.UseVisualStyleBackColor = true;
            this.buttonCheck.Click += new System.EventHandler(this.buttonCheck_Click);
            // 
            // buttonRename
            // 
            this.buttonRename.Location = new System.Drawing.Point(106, 706);
            this.buttonRename.Name = "buttonRename";
            this.buttonRename.Size = new System.Drawing.Size(75, 23);
            this.buttonRename.TabIndex = 25;
            this.buttonRename.Text = "Rename!";
            this.buttonRename.UseVisualStyleBackColor = true;
            this.buttonRename.Click += new System.EventHandler(this.buttonRename_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1037, 741);
            this.Controls.Add(this.buttonRename);
            this.Controls.Add(this.buttonCheck);
            this.Controls.Add(this.listViewCheck);
            this.Controls.Add(this.listViewSub);
            this.Controls.Add(this.listViewMedia);
            this.Controls.Add(this.labelSub);
            this.Controls.Add(this.labelMedia);
            this.Controls.Add(this.textBoxMediaSuffix);
            this.Controls.Add(this.textBoxMediaPrefix);
            this.Controls.Add(this.textBoxSubSuffix);
            this.Controls.Add(this.checkBoxSuffix);
            this.Controls.Add(this.textBoxSubPrefix);
            this.Controls.Add(this.textBoxSubEpEnd);
            this.Controls.Add(this.textBoxSubEpStart);
            this.Controls.Add(this.textBoxSubDelete);
            this.Controls.Add(this.textBoxSubAdd);
            this.Controls.Add(this.textBoxSubExtension);
            this.Controls.Add(this.textBoxMediaExtension);
            this.Controls.Add(this.checkBoxExtension);
            this.Controls.Add(this.checkBoxAdd);
            this.Controls.Add(this.checkBoxDelete);
            this.Controls.Add(this.checkBoxEpisode);
            this.Controls.Add(this.checkBoxPrefix);
            this.Controls.Add(this.buttonBrowse);
            this.Controls.Add(this.textBoxDir);
            this.Controls.Add(this.labelDirpath);
            this.Name = "Main";
            this.Text = "Subtitle Renamer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelDirpath;
        private System.Windows.Forms.TextBox textBoxDir;
        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.CheckBox checkBoxPrefix;
        private System.Windows.Forms.CheckBox checkBoxEpisode;
        private System.Windows.Forms.CheckBox checkBoxDelete;
        private System.Windows.Forms.CheckBox checkBoxAdd;
        private System.Windows.Forms.CheckBox checkBoxExtension;
        private System.Windows.Forms.TextBox textBoxMediaExtension;
        private System.Windows.Forms.TextBox textBoxSubExtension;
        private System.Windows.Forms.TextBox textBoxSubAdd;
        private System.Windows.Forms.TextBox textBoxSubDelete;
        private System.Windows.Forms.TextBox textBoxSubEpStart;
        private System.Windows.Forms.TextBox textBoxSubEpEnd;
        private System.Windows.Forms.TextBox textBoxSubPrefix;
        private System.Windows.Forms.TextBox textBoxSubSuffix;
        private System.Windows.Forms.CheckBox checkBoxSuffix;
        private System.Windows.Forms.TextBox textBoxMediaPrefix;
        private System.Windows.Forms.TextBox textBoxMediaSuffix;
        private System.Windows.Forms.Label labelMedia;
        private System.Windows.Forms.Label labelSub;
        private System.Windows.Forms.ListView listViewMedia;
        private System.Windows.Forms.ListView listViewSub;
        private System.Windows.Forms.ListView listViewCheck;
        private System.Windows.Forms.Button buttonCheck;
        private System.Windows.Forms.Button buttonRename;
    }
}

