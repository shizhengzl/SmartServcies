namespace Core.GeneratorApp
{
    partial class CodeGenerator
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
            this.listDatabase = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // listDatabase
            // 
            this.listDatabase.Dock = System.Windows.Forms.DockStyle.Left;
            this.listDatabase.HideSelection = false;
            this.listDatabase.Location = new System.Drawing.Point(0, 0);
            this.listDatabase.Name = "listDatabase";
            this.listDatabase.Size = new System.Drawing.Size(299, 557);
            this.listDatabase.TabIndex = 0;
            this.listDatabase.UseCompatibleStateImageBehavior = false;
            // 
            // CodeGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1116, 557);
            this.Controls.Add(this.listDatabase);
            this.Name = "CodeGenerator";
            this.Text = "CodeGenerator";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listDatabase;
    }
}