/*
 * Created by SharpDevelop.
 * User: wojciech.kiwilsza
 * Date: 24/05/2018
 * Time: 08:18
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Lahistoria
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.MonthCalendar monthCalendar1;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem baseToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem convertToolStripMenuItem;
		private System.Windows.Forms.Panel ListPanel;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.CheckBox FScheckBox;
		private System.Windows.Forms.CheckBox DBcheckBox;

		private System.Windows.Forms.Panel DBpanel;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
		private System.Windows.Forms.Button SelectSourceFolder;
		private System.Windows.Forms.TextBox SourceFolder;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox SIDTextBox;
		private System.Windows.Forms.TextBox PassTextBox;
		private System.Windows.Forms.TextBox UserTextBox;
		private System.Windows.Forms.TextBox PortTextBox;
		private System.Windows.Forms.TextBox HostTextBox;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.CheckBox defSrcSettingsBox;
		private System.Windows.Forms.Button ConnectButton;
		private System.Windows.Forms.CheckBox ConnectedBox;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Button DisConnectButton;
		private System.Windows.Forms.Panel ConnPanel;
		private System.Windows.Forms.Panel SearchPanel;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Button RegExpSearchButton;
		private System.Windows.Forms.Button SearchButton;
		private System.Windows.Forms.TextBox textBox7;
		private System.Windows.Forms.TextBox textBox6;
		private System.Windows.Forms.Panel HistoryPanel;
		private System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Panel FSpanel;
		private System.Windows.Forms.WebBrowser ResultsBrowser;
		private System.Windows.Forms.WebBrowser DetailsBrowser;
		private System.Windows.Forms.NotifyIcon notifyIcon1;

		
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
		/// 
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.convertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.baseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ListPanel = new System.Windows.Forms.Panel();
			this.ResultsBrowser = new System.Windows.Forms.WebBrowser();
			this.label16 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.FScheckBox = new System.Windows.Forms.CheckBox();
			this.DBcheckBox = new System.Windows.Forms.CheckBox();
			this.FSpanel = new System.Windows.Forms.Panel();
			this.label5 = new System.Windows.Forms.Label();
			this.SelectSourceFolder = new System.Windows.Forms.Button();
			this.SourceFolder = new System.Windows.Forms.TextBox();
			this.DBpanel = new System.Windows.Forms.Panel();
			this.SIDTextBox = new System.Windows.Forms.TextBox();
			this.PassTextBox = new System.Windows.Forms.TextBox();
			this.UserTextBox = new System.Windows.Forms.TextBox();
			this.PortTextBox = new System.Windows.Forms.TextBox();
			this.HostTextBox = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.label12 = new System.Windows.Forms.Label();
			this.defSrcSettingsBox = new System.Windows.Forms.CheckBox();
			this.ConnectButton = new System.Windows.Forms.Button();
			this.ConnectedBox = new System.Windows.Forms.CheckBox();
			this.label13 = new System.Windows.Forms.Label();
			this.DisConnectButton = new System.Windows.Forms.Button();
			this.ConnPanel = new System.Windows.Forms.Panel();
			this.button4 = new System.Windows.Forms.Button();
			this.SearchPanel = new System.Windows.Forms.Panel();
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.button3 = new System.Windows.Forms.Button();
			this.label15 = new System.Windows.Forms.Label();
			this.RegExpSearchButton = new System.Windows.Forms.Button();
			this.label14 = new System.Windows.Forms.Label();
			this.SearchButton = new System.Windows.Forms.Button();
			this.textBox7 = new System.Windows.Forms.TextBox();
			this.textBox6 = new System.Windows.Forms.TextBox();
			this.HistoryPanel = new System.Windows.Forms.Panel();
			this.DetailsBrowser = new System.Windows.Forms.WebBrowser();
			this.label17 = new System.Windows.Forms.Label();
			this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
			this.menuStrip1.SuspendLayout();
			this.ListPanel.SuspendLayout();
			this.FSpanel.SuspendLayout();
			this.DBpanel.SuspendLayout();
			this.ConnPanel.SuspendLayout();
			this.SearchPanel.SuspendLayout();
			this.HistoryPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// monthCalendar1
			// 
			this.monthCalendar1.Location = new System.Drawing.Point(3, 34);
			this.monthCalendar1.Name = "monthCalendar1";
			this.monthCalendar1.ShowWeekNumbers = true;
			this.monthCalendar1.TabIndex = 0;
			this.monthCalendar1.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1DateSelected);
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.menuToolStripMenuItem,
			this.baseToolStripMenuItem,
			this.optionsToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(1280, 24);
			this.menuStrip1.TabIndex = 1;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// menuToolStripMenuItem
			// 
			this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.convertToolStripMenuItem});
			this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
			this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
			this.menuToolStripMenuItem.Text = "Menu";
			// 
			// convertToolStripMenuItem
			// 
			this.convertToolStripMenuItem.Name = "convertToolStripMenuItem";
			this.convertToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
			this.convertToolStripMenuItem.Text = "Convert";
			this.convertToolStripMenuItem.Click += new System.EventHandler(this.ConvertToolStripMenuItemClick);
			// 
			// baseToolStripMenuItem
			// 
			this.baseToolStripMenuItem.Name = "baseToolStripMenuItem";
			this.baseToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
			this.baseToolStripMenuItem.Text = "Base";
			// 
			// optionsToolStripMenuItem
			// 
			this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
			this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
			this.optionsToolStripMenuItem.Text = "Options";
			// 
			// ListPanel
			// 
			this.ListPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.ListPanel.Controls.Add(this.ResultsBrowser);
			this.ListPanel.Controls.Add(this.label16);
			this.ListPanel.Controls.Add(this.label1);
			this.ListPanel.Location = new System.Drawing.Point(264, 34);
			this.ListPanel.Name = "ListPanel";
			this.ListPanel.Size = new System.Drawing.Size(286, 671);
			this.ListPanel.TabIndex = 2;
			// 
			// ResultsBrowser
			// 
			this.ResultsBrowser.Location = new System.Drawing.Point(30, 423);
			this.ResultsBrowser.MinimumSize = new System.Drawing.Size(20, 20);
			this.ResultsBrowser.Name = "ResultsBrowser";
			this.ResultsBrowser.Size = new System.Drawing.Size(249, 246);
			this.ResultsBrowser.TabIndex = 1;
			// 
			// label16
			// 
			this.label16.Location = new System.Drawing.Point(3, 11);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(754, 23);
			this.label16.TabIndex = 0;
			this.label16.Text = "label16";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(3, 11);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(754, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "label1";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(0, 9);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 3;
			this.label2.Text = "Source:";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(34, 41);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 23);
			this.label3.TabIndex = 4;
			this.label3.Text = "File system";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(34, 70);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(100, 23);
			this.label4.TabIndex = 5;
			this.label4.Text = "Oracle DB";
			// 
			// FScheckBox
			// 
			this.FScheckBox.Location = new System.Drawing.Point(9, 35);
			this.FScheckBox.Name = "FScheckBox";
			this.FScheckBox.Size = new System.Drawing.Size(19, 24);
			this.FScheckBox.TabIndex = 6;
			this.FScheckBox.UseVisualStyleBackColor = true;
			this.FScheckBox.CheckedChanged += new System.EventHandler(this.FScheckBoxCheckedChanged);
			// 
			// DBcheckBox
			// 
			this.DBcheckBox.Location = new System.Drawing.Point(9, 65);
			this.DBcheckBox.Name = "DBcheckBox";
			this.DBcheckBox.Size = new System.Drawing.Size(19, 24);
			this.DBcheckBox.TabIndex = 7;
			this.DBcheckBox.UseVisualStyleBackColor = true;
			this.DBcheckBox.CheckedChanged += new System.EventHandler(this.DBcheckBoxCheckedChanged);
			// 
			// FSpanel
			// 
			this.FSpanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.FSpanel.Controls.Add(this.label5);
			this.FSpanel.Controls.Add(this.SelectSourceFolder);
			this.FSpanel.Controls.Add(this.SourceFolder);
			this.FSpanel.Location = new System.Drawing.Point(9, 143);
			this.FSpanel.Name = "FSpanel";
			this.FSpanel.Size = new System.Drawing.Size(240, 95);
			this.FSpanel.TabIndex = 8;
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(4, 4);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(126, 23);
			this.label5.TabIndex = 2;
			this.label5.Text = "Source folder settings";
			// 
			// SelectSourceFolder
			// 
			this.SelectSourceFolder.Location = new System.Drawing.Point(3, 61);
			this.SelectSourceFolder.Name = "SelectSourceFolder";
			this.SelectSourceFolder.Size = new System.Drawing.Size(234, 23);
			this.SelectSourceFolder.TabIndex = 1;
			this.SelectSourceFolder.Text = "Select Source Folder";
			this.SelectSourceFolder.UseVisualStyleBackColor = true;
			this.SelectSourceFolder.Click += new System.EventHandler(this.SelectFolderClick);
			// 
			// SourceFolder
			// 
			this.SourceFolder.Location = new System.Drawing.Point(3, 35);
			this.SourceFolder.Name = "SourceFolder";
			this.SourceFolder.Size = new System.Drawing.Size(234, 20);
			this.SourceFolder.TabIndex = 0;
			this.SourceFolder.TextChanged += new System.EventHandler(this.SourceFolderTextChanged);
			// 
			// DBpanel
			// 
			this.DBpanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.DBpanel.Controls.Add(this.SIDTextBox);
			this.DBpanel.Controls.Add(this.PassTextBox);
			this.DBpanel.Controls.Add(this.UserTextBox);
			this.DBpanel.Controls.Add(this.PortTextBox);
			this.DBpanel.Controls.Add(this.HostTextBox);
			this.DBpanel.Controls.Add(this.label11);
			this.DBpanel.Controls.Add(this.label10);
			this.DBpanel.Controls.Add(this.label9);
			this.DBpanel.Controls.Add(this.label8);
			this.DBpanel.Controls.Add(this.label7);
			this.DBpanel.Controls.Add(this.label6);
			this.DBpanel.Location = new System.Drawing.Point(9, 244);
			this.DBpanel.Name = "DBpanel";
			this.DBpanel.Size = new System.Drawing.Size(240, 140);
			this.DBpanel.TabIndex = 9;
			// 
			// SIDTextBox
			// 
			this.SIDTextBox.Location = new System.Drawing.Point(77, 109);
			this.SIDTextBox.Name = "SIDTextBox";
			this.SIDTextBox.Size = new System.Drawing.Size(156, 20);
			this.SIDTextBox.TabIndex = 10;
			this.SIDTextBox.TextChanged += new System.EventHandler(this.SIDTextBoxTextChanged);
			// 
			// PassTextBox
			// 
			this.PassTextBox.Location = new System.Drawing.Point(77, 92);
			this.PassTextBox.Name = "PassTextBox";
			this.PassTextBox.PasswordChar = '*';
			this.PassTextBox.Size = new System.Drawing.Size(156, 20);
			this.PassTextBox.TabIndex = 9;
			this.PassTextBox.TextChanged += new System.EventHandler(this.PassTextBoxTextChanged);
			// 
			// UserTextBox
			// 
			this.UserTextBox.Location = new System.Drawing.Point(77, 72);
			this.UserTextBox.Name = "UserTextBox";
			this.UserTextBox.Size = new System.Drawing.Size(156, 20);
			this.UserTextBox.TabIndex = 8;
			this.UserTextBox.TextChanged += new System.EventHandler(this.UserTextBoxTextChanged);
			// 
			// PortTextBox
			// 
			this.PortTextBox.Location = new System.Drawing.Point(77, 52);
			this.PortTextBox.Name = "PortTextBox";
			this.PortTextBox.Size = new System.Drawing.Size(156, 20);
			this.PortTextBox.TabIndex = 7;
			this.PortTextBox.TextChanged += new System.EventHandler(this.PortTextBoxTextChanged);
			// 
			// HostTextBox
			// 
			this.HostTextBox.Location = new System.Drawing.Point(77, 32);
			this.HostTextBox.Name = "HostTextBox";
			this.HostTextBox.Size = new System.Drawing.Size(156, 20);
			this.HostTextBox.TabIndex = 6;
			this.HostTextBox.TextChanged += new System.EventHandler(this.HostTextBoxTextChanged);
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(4, 112);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(67, 20);
			this.label11.TabIndex = 5;
			this.label11.Text = "SID";
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(4, 52);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(67, 20);
			this.label10.TabIndex = 4;
			this.label10.Text = "Port:";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(4, 92);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(67, 20);
			this.label9.TabIndex = 3;
			this.label9.Text = "Password:";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(4, 72);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(67, 20);
			this.label8.TabIndex = 2;
			this.label8.Text = "Username:";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(4, 32);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(67, 20);
			this.label7.TabIndex = 1;
			this.label7.Text = "Hostname:";
			// 
			// label6
			// 
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.Location = new System.Drawing.Point(4, 4);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(162, 23);
			this.label6.TabIndex = 0;
			this.label6.Text = "Oracle DB settings";
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(134, 9);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(110, 23);
			this.label12.TabIndex = 10;
			this.label12.Text = "Use default settings";
			// 
			// defSrcSettingsBox
			// 
			this.defSrcSettingsBox.Checked = true;
			this.defSrcSettingsBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.defSrcSettingsBox.Enabled = false;
			this.defSrcSettingsBox.Location = new System.Drawing.Point(115, 4);
			this.defSrcSettingsBox.Name = "defSrcSettingsBox";
			this.defSrcSettingsBox.Size = new System.Drawing.Size(19, 24);
			this.defSrcSettingsBox.TabIndex = 11;
			this.defSrcSettingsBox.UseVisualStyleBackColor = true;
			// 
			// ConnectButton
			// 
			this.ConnectButton.Location = new System.Drawing.Point(157, 112);
			this.ConnectButton.Name = "ConnectButton";
			this.ConnectButton.Size = new System.Drawing.Size(87, 23);
			this.ConnectButton.TabIndex = 12;
			this.ConnectButton.Text = "Connect";
			this.ConnectButton.UseVisualStyleBackColor = true;
			this.ConnectButton.Click += new System.EventHandler(this.ConnectButtonClick);
			// 
			// ConnectedBox
			// 
			this.ConnectedBox.Enabled = false;
			this.ConnectedBox.Location = new System.Drawing.Point(9, 113);
			this.ConnectedBox.Name = "ConnectedBox";
			this.ConnectedBox.Size = new System.Drawing.Size(19, 24);
			this.ConnectedBox.TabIndex = 13;
			this.ConnectedBox.UseVisualStyleBackColor = true;
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(34, 117);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(80, 23);
			this.label13.TabIndex = 14;
			this.label13.Text = "Connected";
			// 
			// DisConnectButton
			// 
			this.DisConnectButton.Enabled = false;
			this.DisConnectButton.Location = new System.Drawing.Point(157, 83);
			this.DisConnectButton.Name = "DisConnectButton";
			this.DisConnectButton.Size = new System.Drawing.Size(87, 23);
			this.DisConnectButton.TabIndex = 15;
			this.DisConnectButton.Text = "DisConnect";
			this.DisConnectButton.UseVisualStyleBackColor = true;
			this.DisConnectButton.Click += new System.EventHandler(this.DisConnectButtonClick);
			// 
			// ConnPanel
			// 
			this.ConnPanel.Controls.Add(this.button4);
			this.ConnPanel.Controls.Add(this.label2);
			this.ConnPanel.Controls.Add(this.DisConnectButton);
			this.ConnPanel.Controls.Add(this.label3);
			this.ConnPanel.Controls.Add(this.label13);
			this.ConnPanel.Controls.Add(this.label4);
			this.ConnPanel.Controls.Add(this.ConnectedBox);
			this.ConnPanel.Controls.Add(this.FScheckBox);
			this.ConnPanel.Controls.Add(this.ConnectButton);
			this.ConnPanel.Controls.Add(this.DBcheckBox);
			this.ConnPanel.Controls.Add(this.defSrcSettingsBox);
			this.ConnPanel.Controls.Add(this.FSpanel);
			this.ConnPanel.Controls.Add(this.label12);
			this.ConnPanel.Controls.Add(this.DBpanel);
			this.ConnPanel.Location = new System.Drawing.Point(3, 316);
			this.ConnPanel.Name = "ConnPanel";
			this.ConnPanel.Size = new System.Drawing.Size(249, 389);
			this.ConnPanel.TabIndex = 16;
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(171, 41);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(75, 23);
			this.button4.TabIndex = 16;
			this.button4.Text = "temp button";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.Button4Click);
			// 
			// SearchPanel
			// 
			this.SearchPanel.Controls.Add(this.progressBar1);
			this.SearchPanel.Controls.Add(this.button3);
			this.SearchPanel.Controls.Add(this.label15);
			this.SearchPanel.Controls.Add(this.RegExpSearchButton);
			this.SearchPanel.Controls.Add(this.label14);
			this.SearchPanel.Controls.Add(this.SearchButton);
			this.SearchPanel.Controls.Add(this.textBox7);
			this.SearchPanel.Controls.Add(this.textBox6);
			this.SearchPanel.Location = new System.Drawing.Point(3, 208);
			this.SearchPanel.Name = "SearchPanel";
			this.SearchPanel.Size = new System.Drawing.Size(249, 100);
			this.SearchPanel.TabIndex = 17;
			// 
			// progressBar1
			// 
			this.progressBar1.Location = new System.Drawing.Point(3, 57);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(137, 17);
			this.progressBar1.TabIndex = 7;
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(147, 74);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(97, 23);
			this.button3.TabIndex = 6;
			this.button3.Text = "Go to next";
			this.button3.UseVisualStyleBackColor = true;
			// 
			// label15
			// 
			this.label15.Location = new System.Drawing.Point(60, 79);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(53, 23);
			this.label15.TabIndex = 5;
			this.label15.Text = "Milions!";
			// 
			// RegExpSearchButton
			// 
			this.RegExpSearchButton.Location = new System.Drawing.Point(147, 31);
			this.RegExpSearchButton.Name = "RegExpSearchButton";
			this.RegExpSearchButton.Size = new System.Drawing.Size(97, 23);
			this.RegExpSearchButton.TabIndex = 3;
			this.RegExpSearchButton.Text = "RegExp Search";
			this.RegExpSearchButton.UseVisualStyleBackColor = true;
			this.RegExpSearchButton.Click += new System.EventHandler(this.RegExpSearchButtonClick);
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(3, 79);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(53, 23);
			this.label14.TabIndex = 4;
			this.label14.Text = "Results: ";
			// 
			// SearchButton
			// 
			this.SearchButton.Location = new System.Drawing.Point(147, 4);
			this.SearchButton.Name = "SearchButton";
			this.SearchButton.Size = new System.Drawing.Size(97, 23);
			this.SearchButton.TabIndex = 2;
			this.SearchButton.Text = "Search";
			this.SearchButton.UseVisualStyleBackColor = true;
			this.SearchButton.Click += new System.EventHandler(this.SearchButtonClick);
			// 
			// textBox7
			// 
			this.textBox7.Location = new System.Drawing.Point(4, 31);
			this.textBox7.Name = "textBox7";
			this.textBox7.Size = new System.Drawing.Size(137, 20);
			this.textBox7.TabIndex = 1;
			// 
			// textBox6
			// 
			this.textBox6.Location = new System.Drawing.Point(4, 4);
			this.textBox6.Name = "textBox6";
			this.textBox6.Size = new System.Drawing.Size(137, 20);
			this.textBox6.TabIndex = 0;
			// 
			// HistoryPanel
			// 
			this.HistoryPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.HistoryPanel.Controls.Add(this.DetailsBrowser);
			this.HistoryPanel.Location = new System.Drawing.Point(567, 34);
			this.HistoryPanel.Name = "HistoryPanel";
			this.HistoryPanel.Size = new System.Drawing.Size(701, 671);
			this.HistoryPanel.TabIndex = 18;
			// 
			// DetailsBrowser
			// 
			this.DetailsBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
			this.DetailsBrowser.Location = new System.Drawing.Point(0, 0);
			this.DetailsBrowser.MinimumSize = new System.Drawing.Size(20, 20);
			this.DetailsBrowser.Name = "DetailsBrowser";
			this.DetailsBrowser.Size = new System.Drawing.Size(697, 667);
			this.DetailsBrowser.TabIndex = 0;
			// 
			// label17
			// 
			this.label17.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label17.Location = new System.Drawing.Point(3, 308);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(249, 2);
			this.label17.TabIndex = 1;
			// 
			// notifyIcon1
			// 
			this.notifyIcon1.Text = "notifyIcon1";
			this.notifyIcon1.Visible = true;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1280, 708);
			this.Controls.Add(this.label17);
			this.Controls.Add(this.HistoryPanel);
			this.Controls.Add(this.SearchPanel);
			this.Controls.Add(this.ConnPanel);
			this.Controls.Add(this.ListPanel);
			this.Controls.Add(this.monthCalendar1);
			this.Controls.Add(this.menuStrip1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.MainMenuStrip = this.menuStrip1;
			this.MaximumSize = new System.Drawing.Size(1300, 750);
			this.MinimumSize = new System.Drawing.Size(1300, 750);
			this.Name = "MainForm";
			this.Text = "Lahistoria";
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ListPanel.ResumeLayout(false);
			this.FSpanel.ResumeLayout(false);
			this.FSpanel.PerformLayout();
			this.DBpanel.ResumeLayout(false);
			this.DBpanel.PerformLayout();
			this.ConnPanel.ResumeLayout(false);
			this.SearchPanel.ResumeLayout(false);
			this.SearchPanel.PerformLayout();
			this.HistoryPanel.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		
	}
}
