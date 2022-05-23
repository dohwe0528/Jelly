
namespace KakaoMSG
{
    partial class ProgressWnd
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
            this.prgCnt = new System.Windows.Forms.ProgressBar();
            this.sendCnt = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // prgCnt
            // 
            this.prgCnt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.prgCnt.Location = new System.Drawing.Point(12, 53);
            this.prgCnt.Name = "prgCnt";
            this.prgCnt.Size = new System.Drawing.Size(393, 30);
            this.prgCnt.TabIndex = 0;
            // 
            // sendCnt
            // 
            this.sendCnt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sendCnt.Location = new System.Drawing.Point(12, 87);
            this.sendCnt.Name = "sendCnt";
            this.sendCnt.Size = new System.Drawing.Size(393, 13);
            this.sendCnt.TabIndex = 1;
            this.sendCnt.Text = "1 / 1";
            this.sendCnt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(397, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "발송 중 키보드 / 마우스를 조작 하지 마세요.";
            // 
            // ProgressWnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 109);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sendCnt);
            this.Controls.Add(this.prgCnt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProgressWnd";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Progress";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar prgCnt;
        private System.Windows.Forms.Label sendCnt;
        private System.Windows.Forms.Label label1;
    }
}