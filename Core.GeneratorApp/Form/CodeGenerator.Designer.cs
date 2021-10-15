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
            this.dataBaseTrees = new Core.GeneratorApp.DataBaseTree();
            this.SuspendLayout();
            // 
            // dataBaseTrees
            // 
            this.dataBaseTrees.Companyid = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.dataBaseTrees.Dock = System.Windows.Forms.DockStyle.Left;
            this.dataBaseTrees.Location = new System.Drawing.Point(0, 0);
            this.dataBaseTrees.Name = "dataBaseTrees";
            this.dataBaseTrees.Size = new System.Drawing.Size(329, 557);
            this.dataBaseTrees.TabIndex = 0;
            // 
            // CodeGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1116, 557);
            this.Controls.Add(this.dataBaseTrees);
            this.Name = "CodeGenerator";
            this.Text = "CodeGenerator";
            this.ResumeLayout(false);

        }

        #endregion

        private DataBaseTree dataBaseTrees;
    }
}