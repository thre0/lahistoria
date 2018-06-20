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
        
        string path = "./example4.txt";
        
        //search results list parameters
        int ResultLocY = 1; //vertical position of result
        int RowsDone = 0;
        int GlobalResults=0;
        int results_limit = 100;
        int SearchOption =0; // 0 - nothing; 1 - regularsearch; 2 regex search
        bool More = false;
        //results table
        List<Message_Entry> ResultsList;
        
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

		// Search
		void SearchButtonClick(object sender, EventArgs e)
		{			
			string filePath = path;
			string[] Line = {"1","2"};
			int startIndex;
			StreamReader sr = new StreamReader(filePath);
			
			int results = 0;
			
			if(!More) 
			{
				RowsDone = 0;
				GlobalResults = 0;
			}
			SearchOption = 1;	
			int resultIndex = 0;
			bool lineDone = false;
			
			//Button butt = sender as Button; MessageBox.Show(butt.Name);
			
			if(More)
			{
				while(results<RowsDone)
				{
					sr.ReadLine();
					results++;
				}
				results=0;
			}
			if(More && !sr.EndOfStream || !More)
			{
				ResultsList.Clear();
				
				ListPanel.Dispose();
				this.ListPanel = new System.Windows.Forms.Panel();
				this.ListPanel.AutoScroll = true;
				this.ListPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
				this.ListPanel.Location = new System.Drawing.Point(264, 36);
				this.ListPanel.Name = "ListPanel";
				this.ListPanel.Size = new System.Drawing.Size(328, 669);
				this.ListPanel.TabIndex = 2;
				this.Controls.Add(this.ListPanel);
				
			}
				
			while (!sr.EndOfStream && results <= results_limit)
			{
				Line = sr.ReadLine().Split('|');
				/*
				 [0] id        [6] msg time
				 [1] conn      [7] sender id
				 [2] session   [8] sender name
				 [3] ses start [9] receiver id
				 [4] ses end  [10] receiver name
				 [5] contact  [11] msg
				 */
				while(!lineDone && Line.Length==12)
				{
					startIndex = Line[11].IndexOf(SearchBox.Text,resultIndex,StringComparison.OrdinalIgnoreCase);
					if(SearchBox.Text != "" && startIndex>=0)
					{
						//resultEntry=CutLongString(Line[10],SearchBox.Text,resultIndex);
						ResultsList.Add(new Message_Entry(Line[0], Line[6], Line[1], Line[2], Line[5], Line[7], Line[8], Line[9], Line[10], Line[11], SearchBox.Text,startIndex,1));
						
						resultIndex = startIndex + 1;
						results++;
						GlobalResults++;
					}	
					else
					{
						lineDone = true;
					}
				}
				lineDone = false;
				resultIndex = 0;
				RowsDone++;
				
				ResultsCount.Text = results.ToString() + "("+GlobalResults+")";
			}
			PrintResults3();			
			sr.Close();
			More= false;
		}

		void RegExpSearchButtonClick(object sender, EventArgs e)
		{
			//SearchResults res1 = new SearchResults(ResultsBrowser);
			int results = 0;
			//int results_limit = 100;
			if(!More) 
			{
				RowsDone = 0;
				GlobalResults = 0;
			}
			SearchOption = 2;
			string filePath = path;
			Regex regex;
		
			if(RegExpSearchBox.Text=="" || RegExpSearchBox.Text=="*" || RegExpSearchBox.Text==".*"|| RegExpSearchBox.Text==".*$") 
				MessageBox.Show("Be more specific!");
			else 
			{
				regex = new Regex(RegExpSearchBox.Text);
				StreamReader sr = new StreamReader(filePath);
				if(More)
				{
					while(results<RowsDone)
					{
						sr.ReadLine();
						results++;
					}
					results=0;
				}
				if(More && !sr.EndOfStream || !More)
					ResultsList.Clear();
				
				while (!sr.EndOfStream && results <= results_limit)
				{
					string[] Line = sr.ReadLine().Split('|');
					Match m = regex.Match(Line[11]);
					
			       	while (m.Success) 
			       	{
			       		ResultsList.Add(new Message_Entry(Line[0], Line[6], Line[1], Line[2], Line[5], Line[7], Line[8], Line[9], Line[10], Line[11], m.Value, m.Index,1));
			          	m = m.NextMatch();
			          	results++;
			          	GlobalResults++;
			      	}
			       	RowsDone++;
			       	ResultsCount.Text = results.ToString() + "("+GlobalResults+")";
				}
				PrintResults3();
				sr.Close();
				More= false;
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
		void NewtBox_Click2 (object sender, EventArgs e, string uid)
		{				
		    //MessageBox.Show(uid);
		}
		void NewtBox_Click (object sender, EventArgs e)
		{	
			//MessageBox.Show(uid);
		    RichTextBox tb = sender as RichTextBox;
		    string clickedRTBid = tb.Name.Substring(1,tb.Name.Length-1);
		    //string fullmsg = "default msg";
		    string FocusLine;
		    string sessionid = "id0";
			string filePath = path;
			string[] Line = {"1","2"};
			StreamReader sr = new StreamReader(filePath);
			List<Message_Entry> ConversationList = new List<Message_Entry>();
			int locy = 0;

		    foreach(Message_Entry Hresult in ResultsList)
		    {
		    	if(Hresult.uniqueId == clickedRTBid) 
		    	{
		    		sessionid = Hresult.sessionId;
		    		break;
		    	}
		    }
		    
		    FocusLine=clickedRTBid.Substring(clickedRTBid.IndexOf("L")+1,clickedRTBid.Length-clickedRTBid.IndexOf("L")-1);
			while (!sr.EndOfStream)
			{
				Line = sr.ReadLine().Split('|');
				if(Line[2]==sessionid)
				{
					//FocusLine=clickedRTBid.Substring(clickedRTBid.IndexOf("L")+1,clickedRTBid.Length-clickedRTBid.IndexOf("L")-1);
					if(Line[0]==FocusLine)
						ConversationList.Add(new Message_Entry(Line[0], Line[6], Line[1], Line[2], Line[5], Line[7], Line[8], Line[9], Line[10], Line[11], "", -1,2));
					else
						ConversationList.Add(new Message_Entry(Line[0], Line[6], Line[1], Line[2], Line[5], Line[7], Line[8], Line[9], Line[10], Line[11], "", -1,1));
				}
			}
			sr.Close();
			
			HistoryPanel.Controls.Clear();
		    foreach(Message_Entry msg in ConversationList)
		    {
			    RichTextBox RTBmsg = new RichTextBox();
				RTBmsg.BorderStyle = BorderStyle.None;
				RTBmsg.Size = new System.Drawing.Size(1270, 65);
				RTBmsg.BackColor = System.Drawing.Color.Beige;
				RTBmsg.ReadOnly = true;
				Point pointA = new Point(0,locy);
				RTBmsg.Location = pointA;				
				Font fontL = new Font("Arial", 8,FontStyle.Bold);
				RTBmsg.Font = fontL;	 
				RTBmsg.Text = msg.Message; 
		    	RTBmsg.Name = "RTBmsg" + msg.uniqueId;
		    	RTBmsg.Parent = HistoryPanel;
		    	//if(msg.msgId==msg.uniqueId.Substring(msg.uniqueId.Length-msg.msgId.Length,msg.msgId.Length)) RTBmsg.Focus();
		    	locy = locy + 66;
		    	MessageBox.Show(this.HistoryPanel.Controls["RTBmsg"+msg.uniqueId].Name+"  "+clickedRTBid+ "  " + msg.msgId + "  " +msg.uniqueId );
		    }
		    
		    //this.HistoryPanel.Controls["RTBmsg"+id.ToString()].Focus();
		}
		void PrintResults3()
		{
			//ListPanel.Controls.Clear();
			//ResultNo=1;
        	ResultLocY = 1;
			foreach(Message_Entry Hresult in ResultsList)
			{
				Panel newPanel = new Panel();
				newPanel.BorderStyle = BorderStyle.None;
				newPanel.Size = new System.Drawing.Size(299, 84);
				newPanel.BackColor = System.Drawing.SystemColors.Info;
				Point newpoint = new Point(7,ResultLocY);
				newPanel.Location = newpoint;
				
				newPanel.Parent = ListPanel;

				Label NewLabel = new Label();
				RichTextBox NewtBoxB = new RichTextBox();
				
				NewLabel.BorderStyle = BorderStyle.None;
				NewLabel.Size = new System.Drawing.Size(299, 15);
				NewLabel.BackColor = System.Drawing.Color.CadetBlue;
				Point boxpointA = new Point(0,0);
				NewLabel.Location = boxpointA;				
				Font fontL = new Font("Arial", 8,FontStyle.Bold);
				NewLabel.ForeColor = Color.Khaki;
				NewLabel.Font = fontL;
				DateTime myDate = DateTime.ParseExact(Hresult.msgDate, "yyyyMMddHHmmssfff", null); 
				NewLabel.Text = myDate.ToString() + "  -  " +Hresult.sender_name + " [" + Hresult.connection+ "]"; 
	    	    NewLabel.Name = "L" + Hresult.uniqueId;
	    	    NewLabel.Click += new EventHandler(NewLabel_Click);
	    	    NewLabel.MouseEnter += new EventHandler(NewLabel_MouseEnter);
	    	    NewLabel.Parent = newPanel;
	    	    
				NewtBoxB.BorderStyle = BorderStyle.None;
				NewtBoxB.ReadOnly = true;
				NewtBoxB.Multiline = true;
				NewtBoxB.WordWrap = true;
				NewtBoxB.Size = new System.Drawing.Size(299, 69);
				//NewtBoxB.BackColor = System.Drawing.Color.Khaki;
				NewtBoxB.BackColor = System.Drawing.Color.SteelBlue;
				Point boxpointB = new Point(0,15);
				NewtBoxB.Location = boxpointB;
				Font fontT = new Font("Times New Roman", 11);
				NewtBoxB.Font = fontT;
				NewtBoxB.Text = Hresult.shortMessage;
	    	    NewtBoxB.Name = "R" + Hresult.uniqueId;
	    	    NewtBoxB.Click += new EventHandler(NewtBox_Click);
	    	    NewtBoxB.MouseEnter += new EventHandler(NewtBox_MouseEnter);
	    	    NewtBoxB.Parent = newPanel;
	    	    int startIndex = NewtBoxB.Text.IndexOf(Hresult.Phrase,Hresult.shortPosition,StringComparison.OrdinalIgnoreCase);
	    	    if(startIndex>=0)
	            {
	    	    	Font fontS = new Font("Times New Roman", 11,FontStyle.Bold);
	    	    	NewtBoxB.Select(startIndex, Hresult.Phrase.Length);
	                NewtBoxB.SelectionColor = Color.DarkSalmon;
	                NewtBoxB.SelectionFont = fontS;
			    } 
	    	    
	    	    newPanel.Name = "panel" + Hresult.msgId;
	
	    	    ResultLocY+=84;	
			}
		}
		/*void PrintResults4()
		{
			//ListPanel.Controls.Clear();
			//ResultNo=1;
        	
        	
        	string uniqueID = "default";
        	DateTime myDate;
        	int actRec=1;
        	
        	if(ResultFirstRun)
        	{
        		ResultLocY = 1;
        		for(int i = 1; i<150; i++)
        		{
					Panel newPanel = new Panel();
					Label NewLabel = new Label();
					RichTextBox NewtBox = new RichTextBox();
					Font fontL = new Font("Arial", 8,FontStyle.Bold);
					Font fontT = new Font("Times New Roman", 11);
					Point newPanelpoint = new Point(7,ResultLocY);
					Point boxLabelpoint = new Point(0,0);
					Point boxTextpoint = new Point(0,15);
					//DateTime myDate = DateTime.ParseExact(Hresult.msgDate, "yyyyMMddHHmmssfff", null);
					
					newPanel.BorderStyle = BorderStyle.None;
					newPanel.Size = new System.Drawing.Size(299, 84);
					newPanel.BackColor = System.Drawing.SystemColors.Info;
					newPanel.Location = newPanelpoint;					
					newPanel.Name = "P" + i.ToString();
					//newPanel.AccessibleName = "P" + i.ToString();
					newPanel.Parent = ListPanel;
					//if(i%2==0)newPanel.Visible = false;
					
					NewLabel.BorderStyle = BorderStyle.None;
					NewLabel.Size = new System.Drawing.Size(299, 15);
					NewLabel.BackColor = System.Drawing.Color.CadetBlue;				
					NewLabel.Location = boxLabelpoint;	
					NewLabel.ForeColor = Color.Khaki;
					NewLabel.Font = fontL;				 
					//NewLabel.Text = myDate.ToString() + "  -  " +Hresult.sender_name + " [" + Hresult.connection+ "]"; 
		    	    //NewLabel.Click += new EventHandler(NewLabel_Click);
		    	    NewLabel.Click+=delegate(object sender2, EventArgs e2){NewLabel_Click2(sender2, e2, uniqueID);};
		    	    NewLabel.MouseEnter += new EventHandler(NewLabel_MouseEnter);
		    	    NewLabel.Parent = newPanel;
		    	    NewLabel.Name = "L" + i.ToString(); //Hresult.uniqueId;
		    	    
					NewtBox.BorderStyle = BorderStyle.None;
					NewtBox.ReadOnly = true;
					NewtBox.Multiline = true;
					NewtBox.WordWrap = true;
					NewtBox.Size = new System.Drawing.Size(299, 69);
					NewtBox.BackColor = System.Drawing.Color.SteelBlue;				
					NewtBox.Location = boxTextpoint;
					NewtBox.Font = fontT;
					//NewtBoxB.Text = Hresult.shortMessage;
		    	    // NewtBox.Click += new EventHandler(NewtBox_Click);		    	    
		    	    NewtBox.Click+=delegate(object sender2, EventArgs e2){NewtBox_Click2(sender2, e2, uniqueID);};
		    	    NewtBox.MouseEnter += new EventHandler(NewtBox_MouseEnter);
		    	    NewtBox.Parent = newPanel;
		    	    NewtBox.Name = "R" + i.ToString(); //Hresult.uniqueId;
		    	    ResultLocY+=84;
        		}
				foreach (Message_Entry Hresult in ResultsList)
        		{
					myDate = DateTime.ParseExact(Hresult.msgDate, "yyyyMMddHHmmssfff", null);
        			this.ListPanel.Controls["P"+actRec.ToString()].Controls["R"+actRec.ToString()].Text = Hresult.shortMessage;
        			this.ListPanel.Controls["P"+actRec.ToString()].Controls["L"+actRec.ToString()].Text = myDate.ToString() + "  -  " +Hresult.sender_name + " [" + Hresult.connection+ "]";
        			actRec++;
				}
        		ResultFirstRun = false;
        	}
        	else
        	{   
        		int startIndex =0;
        		int counter =1;
        		Font fontRTB = new Font("Times New Roman", 11,FontStyle.Bold);
        		foreach (Message_Entry Hresult in ResultsList)
        		{
        			this.ListPanel.Controls["P"+actRec.ToString()].Controls["R"+actRec.ToString()].Text = Hresult.shortMessage;
        			//int startIndex = this.ListPanel.Controls["P"+actRec.ToString()].Text.IndexOf(Hresult.Phrase,Hresult.shortPosition,StringComparison.OrdinalIgnoreCase);
        			//this.ListPanel.Controls["P"+actRec.ToString()].Visible=true;
					if(startIndex>=0) 
		            {
		    	    	Font fontS = new Font("Times New Roman", 11,FontStyle.Bold);
		    	    	(RichtTextBox)this.ListPanel.Controls["P"+actRec.ToString()].Controls["R"+actRec.ToString()].Select(startIndex, Hresult.Phrase.Length);
		    	    	// NewtBoxB.SelectionColor = Color.DarkSalmon;
		                //NewtBoxB.SelectionFont = fontS;
				    } 
					actRec++;
        		}
        		
        		foreach(RichTextBox rtb in this.ListPanel.Controls)
        		{	if(counter <= actRec)
        			{
        				//startIndex = rtb.Text.IndexOf(Hresult.Phrase,Hresult.shortPosition,StringComparison.OrdinalIgnoreCase);
        			}
	    	    	//rtb.Select(startIndex, Hresult.Phrase.Length);
	                rtb.SelectionColor = Color.DarkSalmon;
	                rtb.SelectionFont = fontRTB;
        		}
        			//{
        				//list+=" "+ctl.Name;
        				//ctl.Visible= false;
        				//if(ctl.Parent==ListPanel)
        				//MessageBox.Show(P1.Name);
        				//Control found = FindControl(ctl,"P1");
        				//MessageBox.Show(ctl.Name);
        			//}
        			//Panel pan =this.Controls.Find("P"+i.ToString(),true).first as Panel;
        			//if(i%2==1)this.ListPanel.Controls["P"+i.ToString()].Visible=false;
        		//}
        	}
        	
			foreach(Message_Entry Hresult in ResultsList)
			{

	    	    int startIndex = NewtBoxB.Text.IndexOf(Hresult.Phrase,Hresult.shortPosition,StringComparison.OrdinalIgnoreCase);
	    	    if(startIndex>=0)
	            {
	    	    	Font fontS = new Font("Times New Roman", 11,FontStyle.Bold);
	    	    	NewtBoxB.Select(startIndex, Hresult.Phrase.Length);
	                NewtBoxB.SelectionColor = Color.DarkSalmon;
	                NewtBoxB.SelectionFont = fontS;
			    } 
	    	    
	
	    	    	
			}
		}*/
		void FindMoreClick(object sender, EventArgs e)
		{
		    if (SearchOption==1)
		    {
		    	More= true;
		        SearchButton.PerformClick();
		    }
			if (SearchOption==2)
		    {
				More= true;
		        RegExSearchButton.PerformClick();
		    }		    
		}
		
	}
}
