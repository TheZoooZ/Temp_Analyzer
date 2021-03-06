﻿namespace DataAnalyzer
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.applicationMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dispChartBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.connMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connComMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disableCOMConnectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.authorMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.avgTextBox = new System.Windows.Forms.TextBox();
            this.currentTextBox = new System.Windows.Forms.TextBox();
            this.maxTextBox = new System.Windows.Forms.TextBox();
            this.minTextBox = new System.Windows.Forms.TextBox();
            this.cartesianChart1 = new LiveCharts.WinForms.CartesianChart();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.applicationMenuItem,
            this.connMenuItem,
            this.aboutMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(452, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // applicationMenuItem
            // 
            this.applicationMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logMenuItem,
            this.dispChartBtn});
            this.applicationMenuItem.Name = "applicationMenuItem";
            this.applicationMenuItem.Size = new System.Drawing.Size(80, 20);
            this.applicationMenuItem.Text = "Application";
            // 
            // logMenuItem
            // 
            this.logMenuItem.Name = "logMenuItem";
            this.logMenuItem.Size = new System.Drawing.Size(144, 22);
            this.logMenuItem.Text = "Open log";
            // 
            // dispChartBtn
            // 
            this.dispChartBtn.Name = "dispChartBtn";
            this.dispChartBtn.Size = new System.Drawing.Size(144, 22);
            this.dispChartBtn.Text = "Display Chart";
            this.dispChartBtn.Click += new System.EventHandler(this.DispChartBtn_Click);
            // 
            // connMenuItem
            // 
            this.connMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connComMenuItem,
            this.disableCOMConnectionToolStripMenuItem,
            this.toolStripMenuItem1});
            this.connMenuItem.Name = "connMenuItem";
            this.connMenuItem.Size = new System.Drawing.Size(81, 20);
            this.connMenuItem.Text = "Connection";
            // 
            // connComMenuItem
            // 
            this.connComMenuItem.Name = "connComMenuItem";
            this.connComMenuItem.Size = new System.Drawing.Size(208, 22);
            this.connComMenuItem.Text = "Enable COM Connection";
            this.connComMenuItem.Click += new System.EventHandler(this.EnableCOMConnection);
            // 
            // disableCOMConnectionToolStripMenuItem
            // 
            this.disableCOMConnectionToolStripMenuItem.Enabled = false;
            this.disableCOMConnectionToolStripMenuItem.Name = "disableCOMConnectionToolStripMenuItem";
            this.disableCOMConnectionToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.disableCOMConnectionToolStripMenuItem.Text = "Disable COM Connection";
            this.disableCOMConnectionToolStripMenuItem.Click += new System.EventHandler(this.DisableCOMConnection);
            // 
            // aboutMenuItem
            // 
            this.aboutMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verMenuItem,
            this.authorMenuItem});
            this.aboutMenuItem.Name = "aboutMenuItem";
            this.aboutMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutMenuItem.Text = "About";
            // 
            // verMenuItem
            // 
            this.verMenuItem.Name = "verMenuItem";
            this.verMenuItem.Size = new System.Drawing.Size(112, 22);
            this.verMenuItem.Text = "Version";
            // 
            // authorMenuItem
            // 
            this.authorMenuItem.Name = "authorMenuItem";
            this.authorMenuItem.Size = new System.Drawing.Size(112, 22);
            this.authorMenuItem.Text = "Author";
            this.authorMenuItem.Click += new System.EventHandler(this.AuthorMenuItem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(20, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Actual";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(350, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Max";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(256, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Min";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(131, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 17);
            this.label5.TabIndex = 5;
            this.label5.Text = "Average";
            // 
            // avgTextBox
            // 
            this.avgTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.avgTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.avgTextBox.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.avgTextBox.Location = new System.Drawing.Point(198, 37);
            this.avgTextBox.MaxLength = 20;
            this.avgTextBox.Name = "avgTextBox";
            this.avgTextBox.ReadOnly = true;
            this.avgTextBox.Size = new System.Drawing.Size(52, 13);
            this.avgTextBox.TabIndex = 6;
            this.avgTextBox.TabStop = false;
            this.avgTextBox.Text = "--.-- °C";
            // 
            // currentTextBox
            // 
            this.currentTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.currentTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.currentTextBox.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.currentTextBox.Location = new System.Drawing.Point(73, 37);
            this.currentTextBox.MaxLength = 20;
            this.currentTextBox.Name = "currentTextBox";
            this.currentTextBox.ReadOnly = true;
            this.currentTextBox.Size = new System.Drawing.Size(52, 13);
            this.currentTextBox.TabIndex = 7;
            this.currentTextBox.TabStop = false;
            this.currentTextBox.Text = "--.-- °C";
            // 
            // maxTextBox
            // 
            this.maxTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.maxTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.maxTextBox.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.maxTextBox.Location = new System.Drawing.Point(389, 37);
            this.maxTextBox.MaxLength = 20;
            this.maxTextBox.Name = "maxTextBox";
            this.maxTextBox.ReadOnly = true;
            this.maxTextBox.Size = new System.Drawing.Size(40, 13);
            this.maxTextBox.TabIndex = 8;
            this.maxTextBox.TabStop = false;
            this.maxTextBox.Text = "--.-- °C";
            // 
            // minTextBox
            // 
            this.minTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.minTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.minTextBox.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.minTextBox.Location = new System.Drawing.Point(292, 37);
            this.minTextBox.MaxLength = 20;
            this.minTextBox.Name = "minTextBox";
            this.minTextBox.ReadOnly = true;
            this.minTextBox.Size = new System.Drawing.Size(52, 13);
            this.minTextBox.TabIndex = 9;
            this.minTextBox.TabStop = false;
            this.minTextBox.Text = "--.-- °C";
            // 
            // cartesianChart1
            // 
            this.cartesianChart1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cartesianChart1.Location = new System.Drawing.Point(0, -146);
            this.cartesianChart1.Name = "cartesianChart1";
            this.cartesianChart1.Size = new System.Drawing.Size(452, 227);
            this.cartesianChart1.TabIndex = 10;
            this.cartesianChart1.Text = "cartesianChart1";
            this.cartesianChart1.Visible = false;
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(205, 6);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 81);
            this.Controls.Add(this.minTextBox);
            this.Controls.Add(this.maxTextBox);
            this.Controls.Add(this.currentTextBox);
            this.Controls.Add(this.avgTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.cartesianChart1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Data Analyzer";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem applicationMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connComMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verMenuItem;
        private System.Windows.Forms.ToolStripMenuItem authorMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox avgTextBox;
        private System.Windows.Forms.TextBox currentTextBox;
        private System.Windows.Forms.TextBox maxTextBox;
        private System.Windows.Forms.TextBox minTextBox;
        private LiveCharts.WinForms.CartesianChart cartesianChart1;
        private System.Windows.Forms.ToolStripMenuItem dispChartBtn;
        private System.Windows.Forms.ToolStripMenuItem disableCOMConnectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
    }
}

