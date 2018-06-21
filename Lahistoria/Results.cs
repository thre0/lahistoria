using System;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
namespace Lahistoria
{
	public partial class MainForm : Form
	{
		//Display Results        
        List<Message_Entry> ResultsList; //Results table
		int ResultLocY; //vertical position of result
		void PrintResults()
		{
			//Default parameters
			Point Labelpoint = new Point(0,0);
			Point Boxpoint = new Point(0,15);
			Font Labelfont = new Font("Arial", 8,FontStyle.Bold);
			Font RTBfont = new Font("Times New Roman", 11);
			Font Selectionfont = new Font("Times New Roman", 11,FontStyle.Bold);
        	ResultLocY = 1;
        	
			foreach(Message_Entry Hresult in ResultsList)
			{
				//New result objects
				Panel newPanel = new Panel();
				Label NewLabel = new Label();
				RichTextBox NewtRTBox = new RichTextBox();
				Point Panelpoint = new Point(7,ResultLocY);
				DateTime myDate = DateTime.ParseExact(Hresult.msgDate, "yyyyMMddHHmmssfff", null);
				
				int startIndex;
				
				newPanel.BorderStyle = BorderStyle.None;
				newPanel.Size = new System.Drawing.Size(299, 84);
				newPanel.BackColor = System.Drawing.SystemColors.Info;
				newPanel.Location = Panelpoint;
				newPanel.Parent = ListPanel;
				
				NewLabel.BorderStyle = BorderStyle.None;
				NewLabel.Size = new System.Drawing.Size(299, 15);
				NewLabel.BackColor = System.Drawing.Color.CadetBlue;
				NewLabel.Location = Labelpoint;
				NewLabel.ForeColor = Color.Khaki;
				NewLabel.Font = Labelfont;				 
				NewLabel.Text = myDate.ToString() + "  -  " +Hresult.sender_name + " [" + Hresult.connection+ "]"; 
	    	    NewLabel.Name = "L" + Hresult.uniqueId;
	    	    NewLabel.Click += new EventHandler(NewLabel_Click);
	    	    NewLabel.MouseEnter += new EventHandler(NewLabel_MouseEnter);
	    	    NewLabel.Parent = newPanel;
	    	    
				NewtRTBox.BorderStyle = BorderStyle.None;
				NewtRTBox.Size = new System.Drawing.Size(299, 69);
				NewtRTBox.BackColor = System.Drawing.Color.SteelBlue;
				NewtRTBox.ReadOnly = true;
				NewtRTBox.Multiline = true;
				NewtRTBox.WordWrap = true;				
				NewtRTBox.Location = Boxpoint;			
				NewtRTBox.Font = RTBfont;
				NewtRTBox.Text = Hresult.shortMessage;
	    	    NewtRTBox.Name = "R" + Hresult.uniqueId;
	    	    NewtRTBox.Click+=delegate(object sender2, EventArgs e2){ShowConversationClick(sender2, e2, Hresult.Phrase,Hresult.LineInSession);};
	    	    NewtRTBox.MouseEnter += new EventHandler(NewtBox_MouseEnter);
	    	    NewtRTBox.Parent = newPanel;
	    	    
	    	    startIndex = NewtRTBox.Text.IndexOf(Hresult.Phrase,Hresult.shortPosition,StringComparison.OrdinalIgnoreCase);
	    	    if(startIndex>=0)
	            {
	    	    	NewtRTBox.Select(startIndex, Hresult.Phrase.Length);
	                NewtRTBox.SelectionColor = Color.DarkSalmon;
	                NewtRTBox.SelectionFont = Selectionfont;
			    } 
	    	    
	    	    newPanel.Name = "panel" + Hresult.msgId;
	
	    	    ResultLocY+=84;	
			}
		}
		
		//Dispay conversation
		List<Message_Entry> ConversationList = new List<Message_Entry>(); 
		RichTextBox tmptb;
		string LastRTBClicked = "";
		string LastPhrase="";
		int LastLineSession=1;
		void ShowConversationClick (object sender, EventArgs e, string phrase, int lineinsession)
		{
			tmptb = sender as RichTextBox;
			LastRTBClicked = tmptb.Name;
			LastPhrase = phrase;
			LastLineSession = lineinsession;
			ShowConversation (phrase, lineinsession, false);
			
		}
		void ShowConversation (string phrase, int lineinsession, bool ExpandConv)
		{	
		    //Loading data parameters
		    string filePath = path;
		    StreamReader sr = new StreamReader(filePath);
			string[] Line = {"1","2"};
			string clickedRTBid = LastRTBClicked.Substring(1,LastRTBClicked.Length-1);
			
			//Display parameters
			//int msgHeight = 6;
			int locy = 0;
			int startIndex=0;
			int lineSpread;
			try 
			{
				lineSpread = int.Parse(LineSpreadTB.Text);
			}
			catch 
			{
				lineSpread = 1;
				LineSpreadTB.Text = "1";
			}
			//Conversation Details
			string FocusLine;
			string sessionid = "id0";
			int SessionLineCounter = 1;

			ConversationList.Clear();
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
					if((SessionLineCounter+lineSpread<lineinsession || SessionLineCounter-lineSpread>lineinsession) && ExpandConv)
					{
						ConversationList.Add(new Message_Entry(Line[0], Line[6], Line[1], Line[2], Line[5], Line[7], Line[8], Line[9], Line[10], Line[11], "", -1,0));
					}
					else if(Line[0]==FocusLine)
						ConversationList.Add(new Message_Entry(Line[0], Line[6], Line[1], Line[2], Line[5], Line[7], Line[8], Line[9], Line[10], Line[11], "", -1,2));
					else if(SessionLineCounter+lineSpread>=lineinsession && SessionLineCounter-lineSpread<=lineinsession)
						ConversationList.Add(new Message_Entry(Line[0], Line[6], Line[1], Line[2], Line[5], Line[7], Line[8], Line[9], Line[10], Line[11], "", -1,1));
					SessionLineCounter++;
				}
			}
			sr.Close();
			ExpandConv = false;
			HistoryPanel.Controls.Clear();
		    foreach(Message_Entry msg in ConversationList)
		    {
			    RichTextBox RTBmsg = new RichTextBox();
			    Point pointA = new Point(0,locy);
			    Font fontL = new Font("Arial", 8,FontStyle.Bold);
			    Font fontS = new Font("Times New Roman", 11,FontStyle.Bold);
				RTBmsg.BorderStyle = BorderStyle.None;
				RTBmsg.Size = new System.Drawing.Size(647, 1);
				RTBmsg.BackColor = System.Drawing.Color.Beige;
				RTBmsg.ReadOnly = true;	
				RTBmsg.WordWrap = true;					
				RTBmsg.Location = pointA;				
				RTBmsg.Font = fontL;	 
				//RTBmsg.Text = msg.Message; 
		    	RTBmsg.Name = msg.Show + "RTBmsg" + msg.uniqueId;
		    	//RTBmsg.HideSelection=true;
		    	RTBmsg.Parent = HistoryPanel;
		    	RTBmsg.MouseEnter += new EventHandler(RTBmsg_MouseEnter);
		    	RTBmsg.DoubleClick+= new EventHandler(RTBmsg_DoubleClick);
		    	//RTBmsg.ContentsResized+= new EventHandler(RTBmsg_ContentsResized);
		        RTBmsg.ContentsResized += (object sender, ContentsResizedEventArgs e) =>
		        {
		            var richTextBox = (RichTextBox)sender;
		            //richTextBox.Width = e.NewRectangle.Width;
		            richTextBox.Height = e.NewRectangle.Height;
		            //RTBmsg.Width += RTBmsg.Margin.Horizontal + SystemInformation.HorizontalResizeBorderThickness;
		        };
		        RTBmsg.Text = msg.Message; 

	    	    startIndex = msg.Message.IndexOf(phrase,StringComparison.OrdinalIgnoreCase);
	    	    if(startIndex>=0)
	            {	    	    	
	    	    	RTBmsg.Select(startIndex, phrase.Length);
	                RTBmsg.SelectionColor = Color.Salmon;
	                RTBmsg.SelectionFont = fontS;
			    } 
		    	
		    	locy = locy + RTBmsg.Height+1;
		    }
		    foreach(Control ctl in HistoryPanel.Controls)
		    {
		    	if(ctl.Name.Substring(0,1)=="0")
		    	{
		    		ctl.BackColor=Color.Wheat;
		    	}
		    	if(ctl.Name.Substring(0,1)=="2")ctl.Focus();
		    }
		}
	}
}