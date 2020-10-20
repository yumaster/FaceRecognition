namespace OpenCvSharp
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
            this.btn_play = new System.Windows.Forms.Button();
            this.btn_cam = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pic_cam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_head)).BeginInit();
            this.SuspendLayout();
            // 
            // pic_cam
            // 
            this.pic_cam.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pic_cam.Location = new System.Drawing.Point(12, 12);
            this.pic_cam.Name = "pic_cam";
            this.pic_cam.Size = new System.Drawing.Size(572, 432);
            this.pic_cam.TabIndex = 0;
            this.pic_cam.TabStop = false;
            // 
            // pic_head
            // 
            this.pic_head.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pic_head.Location = new System.Drawing.Point(629, 12);
            this.pic_head.Name = "pic_head";
            this.pic_head.Size = new System.Drawing.Size(150, 150);
            this.pic_head.TabIndex = 1;
            this.pic_head.TabStop = false;
            // 
            // btn_play
            // 
            this.btn_play.Location = new System.Drawing.Point(629, 182);
            this.btn_play.Name = "btn_play";
            this.btn_play.Size = new System.Drawing.Size(75, 23);
            this.btn_play.TabIndex = 2;
            this.btn_play.Text = "打开摄像头";
            this.btn_play.UseVisualStyleBackColor = true;
            this.btn_play.Click += new System.EventHandler(this.btn_play_Click);
            // 
            // btn_cam
            // 
            this.btn_cam.Location = new System.Drawing.Point(728, 182);
            this.btn_cam.Name = "btn_cam";
            this.btn_cam.Size = new System.Drawing.Size(51, 23);
            this.btn_cam.TabIndex = 3;
            this.btn_cam.Text = "拍照";
            this.btn_cam.UseVisualStyleBackColor = true;
            this.btn_cam.Click += new System.EventHandler(this.btn_cam_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_cam);
            this.Controls.Add(this.btn_play);
            this.Controls.Add(this.pic_head);
            this.Controls.Add(this.pic_cam);
            this.Name = "Main";
            this.Text = "摄像头";
            ((System.ComponentModel.ISupportInitialize)(this.pic_cam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_head)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pic_cam;
        private System.Windows.Forms.PictureBox pic_head;
        private System.Windows.Forms.Button btn_play;
        private System.Windows.Forms.Button btn_cam;
    }
}