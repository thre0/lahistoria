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
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace Lahistoria
{

	public partial class MainForm : Form
	{	
		//connection parameter
		OracleConnection ora_con;
		
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
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			string filePath = @"./settings.txt";
			StreamReader sr = new StreamReader(filePath);
			ResultsList = new List<HistResult>();
			int Row = 0;
			while (!sr.EndOfStream)
			{
				string[] Line = sr.ReadLine().Split(';');
				//MessageBox.Show(Line[1]);
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
		void ConnectButtonClick(object sender, EventArgs e)
		{

			
			
			if(DBcheckBox.Checked || FScheckBox.Checked)
			{
				try {
					ora_con = new OracleConnection();
					ora_con.ConnectionString = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)" +
														"(HOST="+con_host+")(PORT="+con_port+")))" +
														"(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME="+con_sid+")));" +
														"user id="+con_user+";Password="+con_password;
				    ora_con.Open();
				    ConnectedBox.Checked=true;
				    DBcheckBox.Enabled=false;
				    FScheckBox.Enabled=false;
					FSpanel.Enabled=false;
					DBpanel.Enabled=false;
					ConnectButton.Enabled=false;
					DisConnectButton.Enabled=true;
				    	
				} catch (Exception ex) {
					ConnectedBox.Checked=false;
					MessageBox.Show(ex.Message);
				}
				
			}

			
		}
		void DisConnectButtonClick(object sender, EventArgs e)
		{
			ConnectButton.Enabled=true;
			DisConnectButton.Enabled=false;
			
		    ora_con.Close();
		    ora_con.Dispose();
		    ConnectedBox.Checked=false;
			DBcheckBox.Enabled=true;
			FScheckBox.Enabled=true;
			FSpanel.Enabled=true;
			DBpanel.Enabled=true;
			
		    MessageBox.Show("Disconnected");
		}
		void Button4Click(object sender, EventArgs e)
		{
		    //OracleConnection con = new OracleConnection();
		 
		    //using connection string attributes to connect to Oracle Database
		    //con.ConnectionString = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.227.133)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=XE)));user id=test;Password=password";
		    //con.Open();
		    DataSet dataSet = new DataSet();
		    OracleDataAdapter adapter = new OracleDataAdapter("select * from kid", ora_con);
		    adapter.Fill(dataSet);
			string[] arrvalues = new string[dataSet.Tables[0].Rows.Count];
			
			//loopcounter
			for (int loopcounter = 0; loopcounter< dataSet.Tables[0].Rows.Count; loopcounter++)
			{
			    //assign dataset values to array
			    arrvalues[loopcounter] = dataSet.Tables[0].Rows[loopcounter]["HOUSE"].ToString();
			}
		    //DataRow[] rows = table.Select();
		    for(int i=0;i<arrvalues.Length;i++)
		    MessageBox.Show(arrvalues[i]);
		   // foreach (DataRow row in table.Rows)
		    //{
		    //	MessageBox.Show(row.Field<string>(0));
		    //}
		    
		    //MessageBox.Show(rows[0]["sql"]);
		    
		    // Close and Dispose OracleConnection object
		    //con.Close();
		    //con.Dispose();
		    //MessageBox.Show("Disconnected");		
			
		}
		void FScheckBoxCheckedChanged(object sender, EventArgs e)
		{
			defSrcSettingsBox.Checked= false;
			if(FScheckBox.Checked) FSpanel.Enabled=true;else FSpanel.Enabled=false;
		}
		void DBcheckBoxCheckedChanged(object sender, EventArgs e)
		{
			defSrcSettingsBox.Checked= false;
			if(DBcheckBox.Checked) DBpanel.Enabled=true;else DBpanel.Enabled=false;
		}
		void HostTextBoxTextChanged(object sender, EventArgs e)
		{
			defSrcSettingsBox.Checked= false;
		}
		void PortTextBoxTextChanged(object sender, EventArgs e)
		{
			defSrcSettingsBox.Checked= false;
		}
		void UserTextBoxTextChanged(object sender, EventArgs e)
		{
			defSrcSettingsBox.Checked= false;
		}
		void PassTextBoxTextChanged(object sender, EventArgs e)
		{
			defSrcSettingsBox.Checked= false;
		}
		void SIDTextBoxTextChanged(object sender, EventArgs e)
		{
			defSrcSettingsBox.Checked= false;
		}
		void SourceFolderTextChanged(object sender, EventArgs e)
		{
			defSrcSettingsBox.Checked= false;
		}
	

		void SearchButtonClick(object sender, EventArgs e)
		{
			
			DetailsBrowser.DocumentText = "<html>hello right window</html>";
			
			string filePath = @"./conv.txt";
			int startIndex;
			StreamReader sr = new StreamReader(filePath);
			ResultsList.Clear();
			while (!sr.EndOfStream)
			{
				string[] Line = sr.ReadLine().Split('|');
				startIndex = Line[10].IndexOf(SearchBox.Text,StringComparison.OrdinalIgnoreCase);
				if(SearchBox.Text != "" && startIndex>=0)
				{
					ResultsList.Add(new HistResult(Line[0], Line[2], Line[10],SearchBox.Text));
				}

			}
			PrintResults3();	 
		}
		void RegExpSearchButtonClick(object sender, EventArgs e)
		{
			//SearchResults res1 = new SearchResults(ResultsBrowser);
			
			string filePath = @"./conv.txt";
			Regex regex;
			
			if(RegExpSearchBox.Text=="") regex = new Regex(@".*");
			else regex = new Regex(RegExpSearchBox.Text);
			       	
			StreamReader sr = new StreamReader(filePath);
			ResultsList.Clear();
			while (!sr.EndOfStream)
			{
				string[] Line = sr.ReadLine().Split('|');
				Match m = regex.Match(Line[10]);
				
		       	while (m.Success) 
		       	{
		       		ResultsList.Add(new HistResult(Line[0], Line[2], Line[10], m.Value));
		          	m = m.NextMatch();
		      	}
			}
			PrintResults3();
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
				newPanel.Size = new System.Drawing.Size(270, 41);
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

	    	    string Phrase = Hresult.Phrase;
	    	    int startIndex = NewtBoxB.Text.IndexOf(Phrase,StringComparison.OrdinalIgnoreCase);
	    	    if(startIndex>=0)
	            {
	    	    	NewtBoxB.Select(startIndex, Phrase.Length);
	                NewtBoxB.SelectionColor = Color.DarkSalmon;
			    } 
	    	    
	    	    newPanel.Name = "panel" + Hresult.resId;
	
			
	    	    //ResultNo++;
	    	    ResultLocY+=41;	
			}
		}
		void Panel1Paint(object sender, PaintEventArgs e)
		{
	
		}
		void TextBox1MouseClick(object sender, MouseEventArgs e)
		{
			MessageBox.Show("duup!");
		}

		/*void ResultsBrowserDocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
		{
			this.ResultsBrowser.Document.Body.MouseDown += new HtmlElementEventHandler(Body_MouseDown);
		}
		void Body_MouseDown(Object sender, HtmlElementEventArgs e)
		{
		    switch(e.MouseButtonsPressed)
		    {
		    case MouseButtons.Left:
		    		{	
		    			Point ScreenCoord = new Point(e.MousePosition.X, e.MousePosition.Y);
						Point BrowserCoord = DetailsBrowser.PointToClient(ScreenCoord);	
						//HtmlElement elem = DetailsBrowser.Document.GetElementFromPoint(BrowserCoord);	
						
		    			//Point p = DetailsBrowser.PointToScreen(e.ClientMousePosition);
		    			DetailsBrowser.DocumentText = BrowserCoord.Y.ToString();
		    			}
		    		//e.OffsetMousePosition.ToString()
		    		//{MessageBox.Show(e.MousePosition.ToString());
		        
		    break;
		    case MouseButtons.Right:
		        {MessageBox.Show("Pupa");
		        }
		    break;
		    }
		}*/
		
	}
}
