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
	public class BetterWebBrowser : System.Windows.Forms.WebBrowser
	{
		//
	}
	
		public class HistResult
		{
			string resId;
			public string resDate;
			public string resMessage;
			public HistResult(string id, string date, string msg)
			{
				resId = id;
				resDate = date;
				resMessage = msg;
			}
			
		}
		public class SearchResults
		{
			List<HistResult> ResultsList;
			int divheight;
			string divresults;
			string divstyle;
			public SearchResults(System.Windows.Forms.WebBrowser wb)
			{
				ResultsList = new List<HistResult>();
				ResultsList.Add(new HistResult("1a","2018/05/25","Row grid lines and column grid lines start at 1 and end at a value that is 1 greater than the number of rows or columns the grid has"));
				ResultsList.Add(new HistResult("2a","2012/04/25","The value for grid-row-start should be the row at which you want the grid item to begin."));
				ResultsList.Add(new HistResult("1t","2013/05/15","It is possible for the value of grid-row-start to be greater than that of "));
				divheight = 210;
				divresults ="<div class=\"grid\">";
				divstyle = "<style>";
				divstyle += ".grid {border: 2px dodgerblue solid;  height: "+divheight+"px;  width: 240px;  display: grid;}";
				divstyle += ".box {height:70px}";
				int i=0;
	        	foreach(HistResult Hresult in ResultsList)
	        	{
					divresults += "<div class=\"box b"+ i +"\">" + Hresult.resDate + "<br>" + Hresult.resMessage + "</div>";
					
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
		}
}
