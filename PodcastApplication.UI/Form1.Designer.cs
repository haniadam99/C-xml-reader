namespace PodcastApplication.UI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSearchPodcast = new System.Windows.Forms.Button();
            this.txtSearchPodcast = new System.Windows.Forms.TextBox();
            this.listviewPodcast = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.listboxEpisodes = new System.Windows.Forms.ListBox();
            this.btnEpisodes = new System.Windows.Forms.Button();
            this.listboxDescriptionOfEpisode = new System.Windows.Forms.ListBox();
            this.txtTitel = new System.Windows.Forms.TextBox();
            this.txtCategory = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxFrequency = new System.Windows.Forms.ComboBox();
            this.listboxCategory = new System.Windows.Forms.ListBox();
            this.txtInsertCategory = new System.Windows.Forms.TextBox();
            this.btnInsertCategory = new System.Windows.Forms.Button();
            this.btnChangePodcastInfo = new System.Windows.Forms.Button();
            this.btnSavePodcast = new System.Windows.Forms.Button();
            this.btnDeletePodcast = new System.Windows.Forms.Button();
            this.btnSortera = new System.Windows.Forms.Button();
            this.btnChangeCategory = new System.Windows.Forms.Button();
            this.btnDeleteCategory = new System.Windows.Forms.Button();
            this.btnGetCategory = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSearchPodcast
            // 
            this.btnSearchPodcast.Location = new System.Drawing.Point(12, 56);
            this.btnSearchPodcast.Name = "btnSearchPodcast";
            this.btnSearchPodcast.Size = new System.Drawing.Size(167, 23);
            this.btnSearchPodcast.TabIndex = 0;
            this.btnSearchPodcast.Text = "Ladda Podcast";
            this.btnSearchPodcast.UseVisualStyleBackColor = true;
            this.btnSearchPodcast.Click += new System.EventHandler(this.btnSearchPodcast_Click);
            // 
            // txtSearchPodcast
            // 
            this.txtSearchPodcast.Location = new System.Drawing.Point(13, 27);
            this.txtSearchPodcast.Name = "txtSearchPodcast";
            this.txtSearchPodcast.Size = new System.Drawing.Size(242, 23);
            this.txtSearchPodcast.TabIndex = 1;
            // 
            // listviewPodcast
            // 
            this.listviewPodcast.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.listviewPodcast.HideSelection = false;
            this.listviewPodcast.Location = new System.Drawing.Point(12, 85);
            this.listviewPodcast.Name = "listviewPodcast";
            this.listviewPodcast.Size = new System.Drawing.Size(302, 120);
            this.listviewPodcast.TabIndex = 2;
            this.listviewPodcast.UseCompatibleStateImageBehavior = false;
            this.listviewPodcast.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Titel";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Antal Avsnitt";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Frekvens";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Kategori";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "URL";
            // 
            // listboxEpisodes
            // 
            this.listboxEpisodes.FormattingEnabled = true;
            this.listboxEpisodes.ItemHeight = 15;
            this.listboxEpisodes.Location = new System.Drawing.Point(12, 240);
            this.listboxEpisodes.Name = "listboxEpisodes";
            this.listboxEpisodes.Size = new System.Drawing.Size(302, 79);
            this.listboxEpisodes.TabIndex = 3;
            this.listboxEpisodes.SelectedIndexChanged += new System.EventHandler(this.listboxEpisodes_SelectedIndexChanged);
            // 
            // btnEpisodes
            // 
            this.btnEpisodes.Location = new System.Drawing.Point(12, 211);
            this.btnEpisodes.Name = "btnEpisodes";
            this.btnEpisodes.Size = new System.Drawing.Size(167, 23);
            this.btnEpisodes.TabIndex = 4;
            this.btnEpisodes.Text = "Visa Avsnitt";
            this.btnEpisodes.UseVisualStyleBackColor = true;
            this.btnEpisodes.Click += new System.EventHandler(this.btnEpisodes_Click);
            // 
            // listboxDescriptionOfEpisode
            // 
            this.listboxDescriptionOfEpisode.FormattingEnabled = true;
            this.listboxDescriptionOfEpisode.ItemHeight = 15;
            this.listboxDescriptionOfEpisode.Location = new System.Drawing.Point(13, 358);
            this.listboxDescriptionOfEpisode.Name = "listboxDescriptionOfEpisode";
            this.listboxDescriptionOfEpisode.Size = new System.Drawing.Size(724, 64);
            this.listboxDescriptionOfEpisode.TabIndex = 5;
            this.listboxDescriptionOfEpisode.SelectedIndexChanged += new System.EventHandler(this.listboxDescriptionOfEpisode_SelectedIndexChanged);
            // 
            // txtTitel
            // 
            this.txtTitel.Location = new System.Drawing.Point(356, 84);
            this.txtTitel.Name = "txtTitel";
            this.txtTitel.Size = new System.Drawing.Size(100, 23);
            this.txtTitel.TabIndex = 6;
            // 
            // txtCategory
            // 
            this.txtCategory.Location = new System.Drawing.Point(585, 84);
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.Size = new System.Drawing.Size(100, 23);
            this.txtCategory.TabIndex = 6;
            this.txtCategory.TextChanged += new System.EventHandler(this.txtCategory_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(356, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "Titel";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(585, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Kategori";
            // 
            // cbxFrequency
            // 
            this.cbxFrequency.FormattingEnabled = true;
            this.cbxFrequency.Location = new System.Drawing.Point(470, 84);
            this.cbxFrequency.Name = "cbxFrequency";
            this.cbxFrequency.Size = new System.Drawing.Size(100, 23);
            this.cbxFrequency.TabIndex = 8;
            // 
            // listboxCategory
            // 
            this.listboxCategory.FormattingEnabled = true;
            this.listboxCategory.ItemHeight = 15;
            this.listboxCategory.Location = new System.Drawing.Point(356, 155);
            this.listboxCategory.Name = "listboxCategory";
            this.listboxCategory.Size = new System.Drawing.Size(156, 64);
            this.listboxCategory.TabIndex = 9;
            // 
            // txtInsertCategory
            // 
            this.txtInsertCategory.Location = new System.Drawing.Point(356, 263);
            this.txtInsertCategory.Name = "txtInsertCategory";
            this.txtInsertCategory.Size = new System.Drawing.Size(156, 23);
            this.txtInsertCategory.TabIndex = 10;
            // 
            // btnInsertCategory
            // 
            this.btnInsertCategory.Location = new System.Drawing.Point(356, 292);
            this.btnInsertCategory.Name = "btnInsertCategory";
            this.btnInsertCategory.Size = new System.Drawing.Size(156, 23);
            this.btnInsertCategory.TabIndex = 11;
            this.btnInsertCategory.Text = "Skapa ny Kategori";
            this.btnInsertCategory.UseVisualStyleBackColor = true;
            this.btnInsertCategory.Click += new System.EventHandler(this.btnInsertCategory_Click);
            // 
            // btnChangePodcastInfo
            // 
            this.btnChangePodcastInfo.Location = new System.Drawing.Point(356, 113);
            this.btnChangePodcastInfo.Name = "btnChangePodcastInfo";
            this.btnChangePodcastInfo.Size = new System.Drawing.Size(75, 23);
            this.btnChangePodcastInfo.TabIndex = 12;
            this.btnChangePodcastInfo.Text = "Ändra";
            this.btnChangePodcastInfo.UseVisualStyleBackColor = true;
            this.btnChangePodcastInfo.Click += new System.EventHandler(this.btnChangePodcastInfo_Click);
            // 
            // btnSavePodcast
            // 
            this.btnSavePodcast.Location = new System.Drawing.Point(437, 113);
            this.btnSavePodcast.Name = "btnSavePodcast";
            this.btnSavePodcast.Size = new System.Drawing.Size(75, 23);
            this.btnSavePodcast.TabIndex = 13;
            this.btnSavePodcast.Text = "Spara";
            this.btnSavePodcast.UseVisualStyleBackColor = true;
            this.btnSavePodcast.Click += new System.EventHandler(this.btnSavePodcast_Click);
            // 
            // btnDeletePodcast
            // 
            this.btnDeletePodcast.Location = new System.Drawing.Point(518, 113);
            this.btnDeletePodcast.Name = "btnDeletePodcast";
            this.btnDeletePodcast.Size = new System.Drawing.Size(75, 23);
            this.btnDeletePodcast.TabIndex = 14;
            this.btnDeletePodcast.Text = "Radera";
            this.btnDeletePodcast.UseVisualStyleBackColor = true;
            this.btnDeletePodcast.Click += new System.EventHandler(this.btnDeletePodcast_Click);
            // 
            // btnSortera
            // 
            this.btnSortera.Location = new System.Drawing.Point(356, 225);
            this.btnSortera.Name = "btnSortera";
            this.btnSortera.Size = new System.Drawing.Size(75, 23);
            this.btnSortera.TabIndex = 15;
            this.btnSortera.Text = "Sortera";
            this.btnSortera.UseVisualStyleBackColor = true;
            this.btnSortera.Click += new System.EventHandler(this.btnSortera_Click);
            // 
            // btnChangeCategory
            // 
            this.btnChangeCategory.Location = new System.Drawing.Point(437, 225);
            this.btnChangeCategory.Name = "btnChangeCategory";
            this.btnChangeCategory.Size = new System.Drawing.Size(75, 23);
            this.btnChangeCategory.TabIndex = 16;
            this.btnChangeCategory.Text = "Ändra";
            this.btnChangeCategory.UseVisualStyleBackColor = true;
            this.btnChangeCategory.Click += new System.EventHandler(this.btnChangeCategory_Click);
            // 
            // btnDeleteCategory
            // 
            this.btnDeleteCategory.Location = new System.Drawing.Point(518, 225);
            this.btnDeleteCategory.Name = "btnDeleteCategory";
            this.btnDeleteCategory.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteCategory.TabIndex = 17;
            this.btnDeleteCategory.Text = "Radera";
            this.btnDeleteCategory.UseVisualStyleBackColor = true;
            this.btnDeleteCategory.Click += new System.EventHandler(this.btnDeleteCategory_Click);
            // 
            // btnGetCategory
            // 
            this.btnGetCategory.Location = new System.Drawing.Point(356, 321);
            this.btnGetCategory.Name = "btnGetCategory";
            this.btnGetCategory.Size = new System.Drawing.Size(156, 23);
            this.btnGetCategory.TabIndex = 18;
            this.btnGetCategory.Text = "Sätt Kategori till ny Podcast";
            this.btnGetCategory.UseVisualStyleBackColor = true;
            this.btnGetCategory.Click += new System.EventHandler(this.btnGetCategory_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(470, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 15);
            this.label2.TabIndex = 19;
            this.label2.Text = "Frekvens";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 15);
            this.label4.TabIndex = 20;
            this.label4.Text = "Sök";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(757, 461);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnGetCategory);
            this.Controls.Add(this.btnDeleteCategory);
            this.Controls.Add(this.btnChangeCategory);
            this.Controls.Add(this.btnSortera);
            this.Controls.Add(this.btnDeletePodcast);
            this.Controls.Add(this.btnSavePodcast);
            this.Controls.Add(this.btnChangePodcastInfo);
            this.Controls.Add(this.btnInsertCategory);
            this.Controls.Add(this.txtInsertCategory);
            this.Controls.Add(this.listboxCategory);
            this.Controls.Add(this.cbxFrequency);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCategory);
            this.Controls.Add(this.txtTitel);
            this.Controls.Add(this.listboxDescriptionOfEpisode);
            this.Controls.Add(this.btnEpisodes);
            this.Controls.Add(this.listboxEpisodes);
            this.Controls.Add(this.listviewPodcast);
            this.Controls.Add(this.txtSearchPodcast);
            this.Controls.Add(this.btnSearchPodcast);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSearchPodcast;
        private System.Windows.Forms.TextBox txtSearchPodcast;
        private System.Windows.Forms.ListView listviewPodcast;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ListBox listboxEpisodes;
        private System.Windows.Forms.Button btnEpisodes;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ListBox listboxDescriptionOfEpisode;
        private System.Windows.Forms.TextBox txtTitel;
        private System.Windows.Forms.TextBox txtCategory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxFrequency;
        private System.Windows.Forms.ListBox listboxCategory;
        private System.Windows.Forms.TextBox txtInsertCategory;
        private System.Windows.Forms.Button btnInsertCategory;
        private System.Windows.Forms.Button btnChangePodcastInfo;
        private System.Windows.Forms.Button btnSavePodcast;
        private System.Windows.Forms.Button btnDeletePodcast;
        private System.Windows.Forms.Button btnSortera;
        private System.Windows.Forms.Button btnChangeCategory;
        private System.Windows.Forms.Button btnDeleteCategory;
        private System.Windows.Forms.Button btnGetCategory;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
    }
}

