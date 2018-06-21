using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;
namespace Lahistoria
{
	public partial class MainForm : Form
	{
		// Search
        string path = "./example4.txt";
        
        //search results list parameters
        int RowsDone = 0;
        int GlobalResults=0;
        int results_limit = 100;
        int SearchOption =0; // 0 - nothing; 1 - regularsearch; 2 regex search
        bool More = false;
		void SearchButtonClick(object sender, EventArgs e)
		{			
			string filePath = path;
			string[] Line = {"1","2"};
			int startIndex;
			StreamReader sr = new StreamReader(filePath);
			
			int results = 0;
			int LineInSession = 0;
			string CurSession = "";
			
			if(!More) 
			{
				RowsDone = 0;
				GlobalResults = 0;
			}
			SearchOption = 1;	
			int resultIndex = 0;
			bool lineDone = false;
		
			
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
				
				if(CurSession!=Line[2]&& Line.Length==12)
				{
					CurSession = Line[2];
					LineInSession = 1;
				}
				else if( Line.Length==12)
				{
					LineInSession++;
				}
				while(!lineDone && Line.Length==12)
				{
					startIndex = Line[11].IndexOf(SearchBox.Text,resultIndex,StringComparison.OrdinalIgnoreCase);						
					if(SearchBox.Text != "" && startIndex>=0)
					{
						//resultEntry=CutLongString(Line[10],SearchBox.Text,resultIndex);
						ResultsList.Add(new Message_Entry(Line[0], Line[6], Line[1], Line[2], Line[5], Line[7], Line[8], Line[9], Line[10], Line[11], SearchBox.Text,startIndex,LineInSession));
						
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
			PrintResults();			
			sr.Close();
			More= false;
		}

		void RegExpSearchButtonClick(object sender, EventArgs e)
		{
			//SearchResults res1 = new SearchResults(ResultsBrowser);
			int results = 0;
			int LineInSession = 0;
			string CurSession = "";
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
					string[] Line = sr.ReadLine().Split('|');
					
					if(CurSession!=Line[2]&& Line.Length==12)
					{
						CurSession = Line[2];
						LineInSession = 1;
					}
					else if( Line.Length==12)
					{
						LineInSession++;
					}
					Match m = regex.Match(Line[11]);					
			       	while (m.Success) 
			       	{
			       		ResultsList.Add(new Message_Entry(Line[0], Line[6], Line[1], Line[2], Line[5], Line[7], Line[8], Line[9], Line[10], Line[11], m.Value, m.Index,LineInSession));
			          	m = m.NextMatch();
			          	results++;
			          	GlobalResults++;
			      	}
			       	RowsDone++;
			       	ResultsCount.Text = results.ToString() + "("+GlobalResults+")";
				}
				PrintResults();
				sr.Close();
				More= false;
			}
			       	

		}
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