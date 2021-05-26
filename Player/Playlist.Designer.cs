namespace AVPlayer
{
    partial class Playlist
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Playlist));
            this.addButton = new System.Windows.Forms.Button();
            this.miniButton = new System.Windows.Forms.Button();
            this.delAllButton = new System.Windows.Forms.Button();
            this.delLastButton = new System.Windows.Forms.Button();
            this.listOfPlay = new System.Windows.Forms.ListView();
            this.covers = new System.Windows.Forms.ImageList(this.components);
            this.title = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // addButton
            // 
            this.addButton.FlatAppearance.BorderSize = 0;
            this.addButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.addButton.ForeColor = System.Drawing.Color.White;
            this.addButton.Location = new System.Drawing.Point(327, 483);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(40, 40);
            this.addButton.TabIndex = 0;
            this.addButton.Text = "+";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // miniButton
            // 
            this.miniButton.FlatAppearance.BorderSize = 0;
            this.miniButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.miniButton.ForeColor = System.Drawing.Color.White;
            this.miniButton.Location = new System.Drawing.Point(292, 12);
            this.miniButton.Name = "miniButton";
            this.miniButton.Size = new System.Drawing.Size(75, 23);
            this.miniButton.TabIndex = 2;
            this.miniButton.Text = "---";
            this.miniButton.UseVisualStyleBackColor = true;
            this.miniButton.Click += new System.EventHandler(this.miniButton_Click);
            // 
            // delAllButton
            // 
            this.delAllButton.FlatAppearance.BorderSize = 0;
            this.delAllButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.delAllButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.delAllButton.ForeColor = System.Drawing.Color.White;
            this.delAllButton.Location = new System.Drawing.Point(171, 483);
            this.delAllButton.Name = "delAllButton";
            this.delAllButton.Size = new System.Drawing.Size(128, 40);
            this.delAllButton.TabIndex = 3;
            this.delAllButton.Text = "Delete All";
            this.delAllButton.UseVisualStyleBackColor = true;
            this.delAllButton.Click += new System.EventHandler(this.delAllButton_Click);
            // 
            // delLastButton
            // 
            this.delLastButton.FlatAppearance.BorderSize = 0;
            this.delLastButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.delLastButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.delLastButton.ForeColor = System.Drawing.Color.White;
            this.delLastButton.Location = new System.Drawing.Point(18, 483);
            this.delLastButton.Name = "delLastButton";
            this.delLastButton.Size = new System.Drawing.Size(136, 40);
            this.delLastButton.TabIndex = 4;
            this.delLastButton.Text = "Delete Last";
            this.delLastButton.UseVisualStyleBackColor = true;
            this.delLastButton.Click += new System.EventHandler(this.delLastButton_Click);
            // 
            // listOfPlay
            // 
            this.listOfPlay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listOfPlay.BackColor = System.Drawing.SystemColors.MenuText;
            this.listOfPlay.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listOfPlay.ForeColor = System.Drawing.Color.White;
            this.listOfPlay.HideSelection = false;
            this.listOfPlay.Location = new System.Drawing.Point(12, 67);
            this.listOfPlay.Name = "listOfPlay";
            this.listOfPlay.Size = new System.Drawing.Size(355, 410);
            this.listOfPlay.TabIndex = 5;
            this.listOfPlay.UseCompatibleStateImageBehavior = false;
            this.listOfPlay.View = System.Windows.Forms.View.Details;
            // 
            // covers
            // 
            this.covers.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("covers.ImageStream")));
            this.covers.TransparentColor = System.Drawing.Color.Transparent;
            this.covers.Images.SetKeyName(0, "music.png");
            this.covers.Images.SetKeyName(1, "video.png");
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.title.ForeColor = System.Drawing.Color.White;
            this.title.Location = new System.Drawing.Point(13, 17);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(73, 25);
            this.title.TabIndex = 6;
            this.title.Text = "Playlist";
            // 
            // Playlist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(379, 535);
            this.Controls.Add(this.title);
            this.Controls.Add(this.listOfPlay);
            this.Controls.Add(this.delLastButton);
            this.Controls.Add(this.delAllButton);
            this.Controls.Add(this.miniButton);
            this.Controls.Add(this.addButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Playlist";
            this.Text = "Playlist";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Playlist_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Playlist_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Playlist_MouseUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button miniButton;
        private System.Windows.Forms.Button delAllButton;
        private System.Windows.Forms.Button delLastButton;
        private System.Windows.Forms.ListView listOfPlay;
        private System.Windows.Forms.ImageList covers;
        private System.Windows.Forms.Label title;
    }
}