
namespace team4Chess
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
            this.buttonH1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonH1
            // 
            this.buttonH1.BackgroundImage = global::team4Chess.Properties.Resources.chessWhite;
            this.buttonH1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonH1.Location = new System.Drawing.Point(13, 13);
            this.buttonH1.Name = "buttonH1";
            this.buttonH1.Size = new System.Drawing.Size(100, 100);
            this.buttonH1.TabIndex = 0;
            this.buttonH1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonH1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonH1;
    }
}

