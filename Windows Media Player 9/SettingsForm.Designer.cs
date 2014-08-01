namespace Windows_Media_Player_9
{
    partial class SettingsForm
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
            this.colorChooserView1 = new Windows_Media_Player_9.ColorChooserView();
            this.SuspendLayout();
            // 
            // colorChooserView1
            // 
            this.colorChooserView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.colorChooserView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.colorChooserView1.ForeColor = System.Drawing.Color.White;
            this.colorChooserView1.Location = new System.Drawing.Point(0, 0);
            this.colorChooserView1.Name = "colorChooserView1";
            this.colorChooserView1.Size = new System.Drawing.Size(1305, 562);
            this.colorChooserView1.TabIndex = 1;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1305, 562);
            this.Controls.Add(this.colorChooserView1);
            this.Name = "SettingsForm";
            this.Text = "SettingsForm";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ColorChooserView colorChooserView1;

    }
}