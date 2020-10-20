namespace OpenCvSharpV4
{
    partial class Main
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
            this.pic_cam = new System.Windows.Forms.PictureBox();
            this.pic_head = new System.Windows.Forms.PictureBox();
            this.btn_cam = new System.Windows.Forms.Button();
            this.btn_play = new System.Windows.Forms.Button();
            this.pic_IdCard = new System.Windows.Forms.PictureBox();
            this.btn_compare = new System.Windows.Forms.Button();
            this.lbl_msg = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pic_cam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_head)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_IdCard)).BeginInit();
            this.SuspendLayout();
            // 
            // pic_cam
            // 
            this.pic_cam.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pic_cam.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic_cam.Location = new System.Drawing.Point(13, 13);
            this.pic_cam.Name = "pic_cam";
            this.pic_cam.Size = new System.Drawing.Size(550, 425);
            this.pic_cam.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_cam.TabIndex = 0;
            this.pic_cam.TabStop = false;
            // 
            // pic_head
            // 
            this.pic_head.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pic_head.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic_head.Location = new System.Drawing.Point(606, 12);
            this.pic_head.Name = "pic_head";
            this.pic_head.Size = new System.Drawing.Size(170, 170);
            this.pic_head.TabIndex = 2;
            this.pic_head.TabStop = false;
            // 
            // btn_cam
            // 
            this.btn_cam.Location = new System.Drawing.Point(673, 193);
            this.btn_cam.Name = "btn_cam";
            this.btn_cam.Size = new System.Drawing.Size(51, 23);
            this.btn_cam.TabIndex = 5;
            this.btn_cam.Text = "拍照";
            this.btn_cam.UseVisualStyleBackColor = true;
            this.btn_cam.Click += new System.EventHandler(this.btn_cam_Click);
            // 
            // btn_play
            // 
            this.btn_play.Location = new System.Drawing.Point(592, 193);
            this.btn_play.Name = "btn_play";
            this.btn_play.Size = new System.Drawing.Size(75, 23);
            this.btn_play.TabIndex = 4;
            this.btn_play.Text = "打开摄像头";
            this.btn_play.UseVisualStyleBackColor = true;
            this.btn_play.Click += new System.EventHandler(this.btn_play_Click);
            // 
            // pic_IdCard
            // 
            this.pic_IdCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic_IdCard.Location = new System.Drawing.Point(622, 222);
            this.pic_IdCard.Name = "pic_IdCard";
            this.pic_IdCard.Size = new System.Drawing.Size(132, 181);
            this.pic_IdCard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_IdCard.TabIndex = 6;
            this.pic_IdCard.TabStop = false;
            // 
            // btn_compare
            // 
            this.btn_compare.Location = new System.Drawing.Point(742, 193);
            this.btn_compare.Name = "btn_compare";
            this.btn_compare.Size = new System.Drawing.Size(48, 23);
            this.btn_compare.TabIndex = 7;
            this.btn_compare.Text = "比较";
            this.btn_compare.UseVisualStyleBackColor = true;
            this.btn_compare.Click += new System.EventHandler(this.btn_compare_Click);
            // 
            // lbl_msg
            // 
            this.lbl_msg.AutoSize = true;
            this.lbl_msg.Location = new System.Drawing.Point(592, 425);
            this.lbl_msg.Name = "lbl_msg";
            this.lbl_msg.Size = new System.Drawing.Size(29, 12);
            this.lbl_msg.TabIndex = 8;
            this.lbl_msg.Text = "结果";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbl_msg);
            this.Controls.Add(this.btn_compare);
            this.Controls.Add(this.pic_IdCard);
            this.Controls.Add(this.btn_cam);
            this.Controls.Add(this.btn_play);
            this.Controls.Add(this.pic_head);
            this.Controls.Add(this.pic_cam);
            this.Name = "Main";
            this.Text = "摄像头";
            ((System.ComponentModel.ISupportInitialize)(this.pic_cam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_head)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_IdCard)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pic_cam;
        private System.Windows.Forms.PictureBox pic_head;
        private System.Windows.Forms.Button btn_cam;
        private System.Windows.Forms.Button btn_play;
        private System.Windows.Forms.PictureBox pic_IdCard;
        private System.Windows.Forms.Button btn_compare;
        private System.Windows.Forms.Label lbl_msg;
    }
}