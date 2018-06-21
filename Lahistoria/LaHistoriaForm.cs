/*
 * Created by SharpDevelop.
 * User: wojciech.kiwilsza
 * Date: 24/05/2018
 * Time: 08:18
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;
//using Oracle.ManagedDataAccess.Client;

namespace Lahistoria
{

	public partial class MainForm : Form
	{	
		//parameters
		bool def_set;
		bool srcDB;
		bool srcFS;
        string con_host;
        string con_port;
        string con_user;
        string con_password;
        string con_sid;
        string fs_dir;
              
        //conversation table
        
		public MainForm()
		{
			//default parameters from file
			bool def_srcDB;
			bool def_srcFS;
	        string def_con_host;
	        string def_con_port;
	        string def_con_user;
	        string def_con_password;
	        string def_con_sid;
	        string def_fs_dir;
	        bool def_autoconnect = false;

	        InitializeComponent();
	        
			string filePath = @"./settings.txt";
			StreamReader sr = new StreamReader(filePath);
			ResultsList = new List<Message_Entry>();
			//int Row = 0;
			
			//setting defaults
			while (!sr.EndOfStream)
			{
				string[] Line = sr.ReadLine().Split(';');
				switch(Line[0])
				{
					case "default": {if(Line[1]=="true")def_set=true; else def_set=false;}
					break;
					case "srcDB": {if(Line[1]=="true")def_srcDB=true; else def_srcDB=false;if(def_set)srcDB = def_srcDB;}
					break;	
					case "srcFS": {if(Line[1]=="true")def_srcFS=true; else def_srcFS=false;if(def_set)srcFS = def_srcFS;}
					break;
					case "con_host": {def_con_host=Line[1];if(def_set)con_host = def_con_host;}
					break;	
					case "con_port": {def_con_port=Line[1];if(def_set)con_port = def_con_port;}
					break;
					case "con_user": {def_con_user=Line[1];if(def_set)con_user = def_con_user;}
					break;	
					case "con_password": {def_con_password=Line[1];if(def_set)con_password = def_con_password;}
					break;
					case "con_sid": {def_con_sid=Line[1];if(def_set)con_sid = def_con_sid;}
					break;
					case "fs_dir": {def_fs_dir=Line[1];if(def_set)fs_dir = def_fs_dir;}
					break;
					case "autoconnect": {if(Line[1]=="true")def_autoconnect=true; else def_autoconnect=false;}
					break;
				}		
			    //Row++;
			}
			SIDTextBox.Text=con_sid;
			PassTextBox.Text=con_password;
			UserTextBox.Text=con_user;
			PortTextBox.Text=con_port;
			HostTextBox.Text=con_host;
			
			SourceFolder.Text=fs_dir;
			
			setAllParams();
			if(def_autoconnect) ConnectButtonClick(null,null);
		}
		private void setAllParams()
		{
			if(srcDB) DBcheckBox.Checked=true;else DBcheckBox.Checked=false;
			if(srcFS) FScheckBox.Checked=true;else FScheckBox.Checked=false;
			if(DBcheckBox.Checked) DBpanel.Enabled=true;else DBpanel.Enabled=false;
			if(FScheckBox.Checked) FSpanel.Enabled=true;else FSpanel.Enabled=false;
			
			if(def_set)defSrcSettingsBox.Checked=true;else defSrcSettingsBox.Checked=false;
		}
		void ConvertToolStripMenuItemClick(object sender, EventArgs e)
		{
			Converter.MainForm frm=new Converter.MainForm();
			frm.Show();
		}

		void monthCalendar1DateSelected(object sender, DateRangeEventArgs e)
		{
			//label16.Text = e.End.ToShortDateString();
		}
		//Source folder
		void SelectFolderClick(object sender, EventArgs e)
		{
			DialogResult result = folderBrowserDialog1.ShowDialog();
		    if (result == DialogResult.OK) 
		    {
		       string folderpath = folderBrowserDialog1.SelectedPath;
		       SourceFolder.Text= folderpath;		       
		    }
		}


		void NewLabel_Click (object sender, EventArgs e)
		{				
		    Label tb = sender as Label;
		    string res_id = tb.Name.Substring(1,tb.Name.Length-1);
		    //MessageBox.Show(res_id);
		}
		void NewLabel_Click2 (object sender, EventArgs e, string uid)
		{				
		    Label tb = sender as Label;
		    string res_id = tb.Name.Substring(1,tb.Name.Length-1);
		    //MessageBox.Show(res_id);
		}
		
	}
}
