/*
 * Created by SharpDevelop.
 * User: wojciech.kiwilsza
 * Date: 25/05/2018
 * Time: 15:19
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace Lahistoria
{
	
		public class Message_Entry
		{
			public string uniqueId;
			public string msgId;
			public string msgDate;
			public string sessionId;
			public string connection;
			public string contactId;
			
			public string Message;
			public string shortMessage;
			
			public string sender_id;
			public string sender_name;
			public string receiver_id;
			public string receiver_name;
			
			public string Phrase;
			public int Position;
			public int shortPosition;
			private int refPosition;
			
			public Message_Entry(string id, string date, string conn,string session, string contact,string senderid,string sendern, string receiverid, string receivern, string msg, string phrase,int position)
			{		
				uniqueId = DateTime.Now.ToString("yyyyMMddHHmmssfff") + id + position;
				msgId = id;
				msgDate = date;
				sessionId = session;
				connection = conn;
				contactId = contact;
				
				sender_id = senderid;
				sender_name = sendern;
				receiver_id = receiverid;
				receiver_name = receivern;
				Message = msg;
				Phrase = phrase;
				Position = position;
				
				if (position >= 0)
				{
					uniqueId = DateTime.Now.ToString("yyyyMMddHHmmssfff") + id + position;
					shortMessage = CutLongString(msg,phrase,position);
					shortPosition = shortMessage.IndexOf(phrase,position-refPosition,StringComparison.OrdinalIgnoreCase);	
				}
				else
				{
					uniqueId = "conv" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + id;
				}
			

				
			}
			private string CutLongString(string line, string phrase,int pos)
			{
				string newline = "default";
				int offset = line.IndexOf(phrase,pos,StringComparison.OrdinalIgnoreCase);
				if (line.Length<=150)
				{
					newline=line.Substring(0,line.Length);
					refPosition = 0;
				}
				else if(offset<=75 && line.Length>150)
				{
					newline=line.Substring(0,150) + "...";
					refPosition = 0;
				}
				else if(offset>75 && line.Length<offset+75)
				{
					newline="..." + line.Substring(line.Length-150,150);
					refPosition = (offset-75-3);
				}				
				else
				{
					newline="..." + line.Substring(offset-75,150) + "...";
					refPosition = (offset-75-3);
				}					
				return newline;
			}
			
		}
		/*public class SearchResults
		{
			List<HistResult> ResultsList;
			int divheight;
			string divresults;
			string divstyle;
			public SearchResults(System.Windows.Forms.WebBrowser wb)
			{
				ResultsList = new List<HistResult>();
				//ResultsList.Add(new HistResult("1a","2018/05/25","Row grid lines and column grid lines start at 1 and end at a value that is 1 greater than the number of rows or columns the grid has"));
				//ResultsList.Add(new HistResult("2a","2012/04/25","The value for grid-row-start should be the row at which you want the grid item to begin."));
				//ResultsList.Add(new HistResult("1t","2013/05/15","It is possible for the value of grid-row-start to be greater than that of "));
				//ResultsList.Add(new HistResult("1a","2018/05/25","Row grid lines and column grid lines start at 1 and end at a value that is 1 greater than the number of rows or columns the grid has"));
				//ResultsList.Add(new HistResult("2a","2012/04/25","The value for grid-row-start should be the row at which you want the grid item to begin."));
				//ResultsList.Add(new HistResult("1t","2013/05/15","It is possible for the value of grid-row-start to be greater than that of "));
				//ResultsList.Add(new HistResult("1a","2018/05/25","Row grid lines and column grid lines start at 1 and end at a value that is 1 greater than the number of rows or columns the grid has"));
				//ResultsList.Add(new HistResult("2a","2012/04/25","The value for grid-row-start should be the row at which you want the grid item to begin."));
				//ResultsList.Add(new HistResult("1t","2013/05/15","It is possible for the value of grid-row-start to be greater than that of "));
				//ResultsList.Add(new HistResult("1a","2018/05/25","Row grid lines and column grid lines start at 1 and end at a value that is 1 greater than the number of rows or columns the grid has"));
				//ResultsList.Add(new HistResult("2a","2012/04/25","The value for grid-row-start should be the row at which you want the grid item to begin."));
				//ResultsList.Add(new HistResult("1t","2013/05/15","It is possible for the value of grid-row-start to be greater than that of "));
			
				divheight = 840;
				divresults ="<div class=\"grid\">";
				divstyle = "<style>";
				divstyle += ".grid {border: 2px dodgerblue solid;  height: "+divheight+"px;  width: 240px;  display: grid;}";
				divstyle += ".box {height:70px}";
				int i=0;
	        	foreach(HistResult Hresult in ResultsList)
	        	{
					divresults += "<div class=\"box b"+ i +"\">" + Hresult.resDate + "<br>" + Hresult.Message + "</div>";
					
					if(i%2==1)
						divstyle += ".b" + i + "{ color: red;background-color: white; font-size: 15px; }";
					else 
						divstyle += ".b" + i + "{ color: red;background-color: dodgerblue; font-size: 15px; }";
					i++;
				}
			
				divstyle += "</style>";
				divresults += "</div>";
	        	
				wb.DocumentText =""
				+"<!DOCTYPE html>"
				+"<html>"
				+"<head>"
				+divstyle
				+"</head>"
				+divresults
				+"</html>";			
			}
		}*/
}
