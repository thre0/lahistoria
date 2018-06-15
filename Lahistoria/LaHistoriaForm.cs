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
        
        //search results list parameters
        int ResultNo=1; //result temp id 
        int ResultLocY = 1; //vertical position of result
        
        //results table
        List<HistResult> ResultsList;
        
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
			ResultsList = new List<HistResult>();
			int Row = 0;
			
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
			    Row++;
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
		
		void SelectFolderClick(object sender, EventArgs e)
		{
			DialogResult result = folderBrowserDialog1.ShowDialog();
		    if (result == DialogResult.OK) 
		    {
		       string folderpath = folderBrowserDialog1.SelectedPath;
		       SourceFolder.Text= folderpath;		       
		    }
		}


		void SearchButtonClick(object sender, EventArgs e)
		{
			
			//DetailsBrowser.DocumentText = "<html>hello right window</html>";
			
			string filePath = @"./conv.txt";
			string[] Line = {"1","2"};
			int startIndex;
			StreamReader sr = new StreamReader(filePath);
			string resultEntry;
			int resultIndex = 0;
			bool lineDone = false;
			
			ResultsList.Clear();
			while (!sr.EndOfStream)
			{
				Line = sr.ReadLine().Split('|');
				while(!lineDone && Line.Length==11)
				{
					startIndex = Line[10].IndexOf(SearchBox.Text,resultIndex,StringComparison.OrdinalIgnoreCase);
					if(SearchBox.Text != "" && startIndex>=0)
					{
						resultEntry=CutLongString(Line[10],SearchBox.Text,resultIndex);
						ResultsList.Add(new HistResult(Line[0], Line[2], resultEntry, SearchBox.Text,startIndex));
						
						resultIndex = startIndex + 1;
					}	
					else
					{
						lineDone = true;
					}
				}
				lineDone = false;
				resultIndex = 0;
			}
			PrintResults3();	 
		}
		string CutLongString(string line, string phrase,int pos)
		{
			string newline = "default";
			int offset = line.IndexOf(phrase,pos,StringComparison.OrdinalIgnoreCase);
			if (offset<=120 && line.Length<=130)
			{
				newline=line.Substring(0,line.Length);
			}
			else if(offset<=65 && line.Length>130)
			{
				newline=line.Substring(0,130) + "...";
			}
			else if(offset>65 && offset<=120 && line.Length>130 && line.Length<offset+65)
			{
				newline="..." + line.Substring(offset-65,line.Length-(offset-65));
			}
			else if(offset>65 && offset<=120 && line.Length>130)
			{
				newline="..." + line.Substring(offset-65,130) + "...";
			}
			else
			{
			}
			return newline;
		}
		void RegExpSearchButtonClick(object sender, EventArgs e)
		{
			//SearchResults res1 = new SearchResults(ResultsBrowser);
			
			string filePath = @"./conv.txt";
			Regex regex;
		
			if(RegExpSearchBox.Text=="" || RegExpSearchBox.Text=="*" || RegExpSearchBox.Text==".*"|| RegExpSearchBox.Text==".*$") 
				MessageBox.Show("Be more specific!");
			else 
			{
				regex = new Regex(RegExpSearchBox.Text);
				StreamReader sr = new StreamReader(filePath);
				ResultsList.Clear();
				while (!sr.EndOfStream)
				{
					string[] Line = sr.ReadLine().Split('|');
					Match m = regex.Match(Line[10]);
					
			       	while (m.Success) 
			       	{
			       		ResultsList.Add(new HistResult(Line[0], Line[2], Line[10], m.Value, m.Index));
			          	m = m.NextMatch();
			      	}
				}
				PrintResults3();
			}
			       	

		}
		void newtbox_Click (object sender, EventArgs e)
		{
		    //TextBox tbox = sender as TextBox;
		    Panel pnl = sender as Panel;
		    MessageBox.Show(pnl.Text);
		}
		void newtboxA_Click (object sender, EventArgs e)
		{				
		    Label tb = sender as Label;
		    string res_id = tb.Name.Substring(9,tb.Name.Length-9);
		    MessageBox.Show(res_id);
		}
		void newtboxB_Click (object sender, EventArgs e)
		{				
		    RichTextBox tb = sender as RichTextBox;
		    string res_id = tb.Name.Substring(8,tb.Name.Length-8);
		    MessageBox.Show(res_id);
		}

		void PrintResults()
		{
			ListPanel.Controls.Clear();
			ResultNo=1;
        	ResultLocY = 1;
			foreach(HistResult Hresult in ResultsList)
			{
				TextBox newtbox = new TextBox();
				
				newtbox.BorderStyle = BorderStyle.None;
				newtbox.ReadOnly = true;
				newtbox.Multiline = true;
				newtbox.WordWrap = true;
				newtbox.Size = new System.Drawing.Size(270, 26);
				newtbox.BackColor = System.Drawing.SystemColors.Info;
				Point newpoint = new Point(7,ResultLocY);
				newtbox.Location = newpoint;
				newtbox.Text = Hresult.resMessage; //+ ResultNo.ToString();
	    	    newtbox.Name = "textbox" + ResultNo.ToString();
	    	    newtbox.Parent = ListPanel;
	    	    
	    	    //newtbox.Click += new EventHandler(newtbox_Click);
			
	    	    ResultNo++;
	    	    ResultLocY+=26;	
			}
		}
		void PrintResults2()
		{
			ListPanel.Controls.Clear();
			//ResultNo=1;
        	ResultLocY = 1;
			foreach(HistResult Hresult in ResultsList)
			{
				Panel newPanel = new Panel();
				newPanel.BorderStyle = BorderStyle.None;
				newPanel.Size = new System.Drawing.Size(270, 41);
				newPanel.BackColor = System.Drawing.SystemColors.Info;
				Point newpoint = new Point(7,ResultLocY);
				newPanel.Location = newpoint;
				
				newPanel.Parent = ListPanel;
				newPanel.Click += new EventHandler(newtbox_Click);			
				
				Label NewLabel = new Label();
				TextBox NewtBoxB = new TextBox();
				
				NewLabel.BorderStyle = BorderStyle.None;
				//NewLabel.ReadOnly = true;
				//NewLabel.Multiline = true;
				//NewLabel.WordWrap = true;
				NewLabel.Size = new System.Drawing.Size(270, 15);
				NewLabel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
				Point boxpointA = new Point(0,0);
				NewLabel.Location = boxpointA;				
				Font fontL = new Font("Arial", 8,FontStyle.Bold);
				NewLabel.Font = fontL;
				DateTime myDate = DateTime.ParseExact(Hresult.resDate, "yyyyMMddHHmmssfff", null); 
				NewLabel.Text = myDate.ToString(); 
	    	    NewLabel.Name = "datelabel" + Hresult.resId;
	    	    NewLabel.Click += new EventHandler(newtboxB_Click);
	    	    NewLabel.Parent = newPanel;
	    	    
				NewtBoxB.BorderStyle = BorderStyle.None;
				NewtBoxB.ReadOnly = true;
				NewtBoxB.Multiline = true;
				NewtBoxB.WordWrap = true;
				NewtBoxB.Size = new System.Drawing.Size(270, 26);
				NewtBoxB.BackColor = System.Drawing.SystemColors.HotTrack;
				Point boxpointB = new Point(0,15);
				NewtBoxB.Location = boxpointB;
				Font fontT = new Font("Times New Roman", 10);
				NewtBoxB.Font = fontT;
				NewtBoxB.Text = Hresult.resMessage;
	    	    NewtBoxB.Name = "textboxB" + Hresult.resId;
	    	    NewtBoxB.Click += new EventHandler(newtboxB_Click);
	    	    NewtBoxB.Parent = newPanel;
	    	    
	    	    newPanel.Name = "panel" + Hresult.resId;
	
			
	    	    //ResultNo++;
	    	    ResultLocY+=41;	
			}
		}
		void PrintResults3()
		{
			ListPanel.Controls.Clear();
			//ResultNo=1;
        	ResultLocY = 1;
			foreach(HistResult Hresult in ResultsList)
			{
				Panel newPanel = new Panel();
				newPanel.BorderStyle = BorderStyle.None;
				newPanel.Size = new System.Drawing.Size(302, 77);
				newPanel.BackColor = System.Drawing.SystemColors.Info;
				Point newpoint = new Point(7,ResultLocY);
				newPanel.Location = newpoint;
				
				newPanel.Parent = ListPanel;
				newPanel.Click += new EventHandler(newtbox_Click);			
				
				Label NewLabel = new Label();
				RichTextBox NewtBoxB = new RichTextBox();
				
				NewLabel.BorderStyle = BorderStyle.None;
				//NewLabel.ReadOnly = true;
				//NewLabel.Multiline = true;
				//NewLabel.WordWrap = true;
				NewLabel.Size = new System.Drawing.Size(270, 15);
				NewLabel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
				Point boxpointA = new Point(0,0);
				NewLabel.Location = boxpointA;				
				Font fontL = new Font("Arial", 8,FontStyle.Bold);
				NewLabel.Font = fontL;
				DateTime myDate = DateTime.ParseExact(Hresult.resDate, "yyyyMMddHHmmssfff", null); 
				NewLabel.Text = myDate.ToString(); 
	    	    NewLabel.Name = "datelabel" + Hresult.resId;
	    	    NewLabel.Click += new EventHandler(newtboxA_Click);
	    	    NewLabel.Parent = newPanel;
	    	    
				NewtBoxB.BorderStyle = BorderStyle.None;
				NewtBoxB.ReadOnly = true;
				NewtBoxB.Multiline = true;
				NewtBoxB.WordWrap = true;
				NewtBoxB.Size = new System.Drawing.Size(302, 62);
				NewtBoxB.BackColor = System.Drawing.SystemColors.HotTrack;
				Point boxpointB = new Point(0,15);
				NewtBoxB.Location = boxpointB;
				Font fontT = new Font("Times New Roman", 11);
				NewtBoxB.Font = fontT;
				NewtBoxB.Text = Hresult.resMessage;
	    	    NewtBoxB.Name = "textboxB" + Hresult.resId;
	    	    NewtBoxB.Click += new EventHandler(newtboxB_Click);
	    	    NewtBoxB.Parent = newPanel;

	    	    string Phrase = Hresult.Phrase;
	    	    int startIndex = NewtBoxB.Text.IndexOf(Phrase,StringComparison.OrdinalIgnoreCase);
	    	    if(startIndex>=0)
	            {
	    	    	NewtBoxB.Select(startIndex, Phrase.Length);
	                NewtBoxB.SelectionColor = Color.DarkSalmon;
			    } 
	    	    
	    	    newPanel.Name = "panel" + Hresult.resId;
	
			
	    	    //ResultNo++;
	    	    ResultLocY+=77;	
			}
		}
		
	}
}
