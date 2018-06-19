using System;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using System.Data;
namespace Lahistoria
{
	public partial class MainForm : Form
	{
		//connection parameter
		OracleConnection ora_con;
			
		void ConnectButtonClick(object sender, EventArgs e)
		{		
			
			if(DBcheckBox.Checked)
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
			if(FScheckBox.Checked) FSpanel.Enabled=true;
			if(DBcheckBox.Checked) DBpanel.Enabled=true;
			
		    MessageBox.Show("Disconnected");
		}
		void Button4Click(object sender, EventArgs e)
		{
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
		    for(int i=0;i<arrvalues.Length;i++)
		    MessageBox.Show(arrvalues[i]);	
		}
	}
}
