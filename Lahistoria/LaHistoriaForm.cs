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
using System.Data.SqlClient;
using System.IO;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace Lahistoria
{

	public partial class MainForm : Form
	{
		OracleConnection ora_con;
		bool def_set;
		bool srcDB;
		bool srcFS;
        string con_host;
        string con_port;
        string con_user;
        string con_password;
        string con_sid;
        //SqlCommand command ;
        
		public MainForm()
		{
			bool def_srcDB;
			bool def_srcFS;
	        string def_con_host;
	        string def_con_port;
	        string def_con_user;
	        string def_con_password;
	        string def_con_sid;
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			string filePath = @"./settings.txt";
			StreamReader sr = new StreamReader(filePath);
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
				}		
			    Row++;
			}
			SIDTextBox.Text=con_sid;
			PassTextBox.Text=con_password;
			UserTextBox.Text=con_user;
			PortTextBox.Text=con_port;
			HostTextBox.Text=con_host;
			
		}
		void ConvertToolStripMenuItemClick(object sender, EventArgs e)
		{
			Converter.MainForm frm=new Converter.MainForm();
			frm.Show();
		}

		void monthCalendar1DateSelected(object sender, DateRangeEventArgs e)
		{
			label16.Text = e.End.ToShortDateString();
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
			ConnectButton.Enabled=false;
			DisConnectButton.Enabled=true;
			
			try {
				ora_con = new OracleConnection();
				ora_con.ConnectionString = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)" +
													"(HOST="+con_host+")(PORT="+con_port+")))" +
													"(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME="+con_sid+")));" +
													"user id="+con_user+";Password="+con_password;
			    ora_con.Open();
			    ConnectedBox.Checked=true;
			} catch (Exception ex) {
				ConnectedBox.Checked=false;
				MessageBox.Show(ex.Message);
			}

			
		}
		void DisConnectButtonClick(object sender, EventArgs e)
		{
			ConnectButton.Enabled=true;
			DisConnectButton.Enabled=false;
			
		    ora_con.Close();
		    ora_con.Dispose();
		    ConnectedBox.Checked=false;
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
	}
}
