using System;
using System.Windows.Forms;
namespace Lahistoria
{
	public partial class MainForm : Form
	{
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
		void TextBox1MouseClick(object sender, MouseEventArgs e)
		{
			MessageBox.Show("duup!");
		}
		void SearchBoxKeyDown(object sender, KeyEventArgs e)
		{
		    if (e.KeyCode == Keys.Enter){
		        SearchButton.PerformClick();
		    }	
		}
		void RegExpSearchBoxKeyDown(object sender, KeyEventArgs e)
		{
		    if (e.KeyCode == Keys.Enter){
		        RegExSearchButton.PerformClick();
		    }	
		}
		void NewtBox_MouseEnter (object sender, EventArgs e)
		{
			RichTextBox tb = sender as RichTextBox;	
			tb.Parent.Focus();
		}
		void NewLabel_MouseEnter (object sender, EventArgs e)
		{
			Label tb = sender as Label;
			tb.Parent.Focus();
		}
	}

}
