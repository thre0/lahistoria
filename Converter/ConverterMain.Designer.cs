/*
 * Created by SharpDevelop.
 * User: wojciech.kiwilsza
 * Date: 08/05/2018
 * Time: 10:23
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Converter
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Button read_write_button;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.TextBox chosenFile;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button choose_file_to_write;
		private System.Windows.Forms.Button choose_file_to_read;
		private System.Windows.Forms.TextBox destFile;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.read_write_button = new System.Windows.Forms.Button();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.chosenFile = new System.Windows.Forms.TextBox();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.destFile = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.choose_file_to_write = new System.Windows.Forms.Button();
			this.choose_file_to_read = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// read_write_button
			// 
			this.read_write_button.Location = new System.Drawing.Point(495, 12);
			this.read_write_button.Name = "read_write_button";
			this.read_write_button.Size = new System.Drawing.Size(94, 46);
			this.read_write_button.TabIndex = 1;
			this.read_write_button.Text = "read  write";
			this.read_write_button.UseVisualStyleBackColor = true;
			this.read_write_button.Click += new System.EventHandler(this.Read_write_buttonClick);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// chosenFile
			// 
			this.chosenFile.Enabled = false;
			this.chosenFile.Location = new System.Drawing.Point(12, 81);
			this.chosenFile.Name = "chosenFile";
			this.chosenFile.Size = new System.Drawing.Size(577, 20);
			this.chosenFile.TabIndex = 3;
			// 
			// destFile
			// 
			this.destFile.Location = new System.Drawing.Point(12, 123);
			this.destFile.Name = "destFile";
			this.destFile.Size = new System.Drawing.Size(577, 20);
			this.destFile.TabIndex = 4;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12, 61);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 17);
			this.label1.TabIndex = 5;
			this.label1.Text = "convert";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(12, 103);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 17);
			this.label2.TabIndex = 6;
			this.label2.Text = "to";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// choose_file_to_write
			// 
			this.choose_file_to_write.Location = new System.Drawing.Point(162, 12);
			this.choose_file_to_write.Name = "choose_file_to_write";
			this.choose_file_to_write.Size = new System.Drawing.Size(123, 46);
			this.choose_file_to_write.TabIndex = 7;
			this.choose_file_to_write.Text = "choose file to write to";
			this.choose_file_to_write.UseVisualStyleBackColor = true;
			this.choose_file_to_write.Click += new System.EventHandler(this.Choose_file_to_writeClick);
			// 
			// choose_file_to_read
			// 
			this.choose_file_to_read.Location = new System.Drawing.Point(12, 12);
			this.choose_file_to_read.Name = "choose_file_to_read";
			this.choose_file_to_read.Size = new System.Drawing.Size(135, 46);
			this.choose_file_to_read.TabIndex = 8;
			this.choose_file_to_read.Text = "choose file to read from";
			this.choose_file_to_read.UseVisualStyleBackColor = true;
			this.choose_file_to_read.Click += new System.EventHandler(this.Choose_file_to_readClick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(601, 171);
			this.Controls.Add(this.choose_file_to_read);
			this.Controls.Add(this.choose_file_to_write);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.destFile);
			this.Controls.Add(this.chosenFile);
			this.Controls.Add(this.read_write_button);
			this.Name = "MainForm";
			this.Text = "History Converter";
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
