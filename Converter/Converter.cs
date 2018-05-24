/*
 * Created by SharpDevelop.
 * User: wojciech.kiwilsza
 * Date: 08/05/2018
 * Time: 10:23
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Forms;

namespace Converter
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}

		void Read_file(string FilePathRead,string FilePathWrite){  
			string line; 
			System.IO.StreamReader fileToRead = new System.IO.StreamReader(FilePathRead);
			System.IO.StreamWriter fileToWrite = new System.IO.StreamWriter(FilePathWrite);
			while((line=fileToRead.ReadLine()) !=null){
				Write_file(fileToWrite,line);
			}
			MessageBox.Show("File created!");
			fileToRead.Close();
        	fileToWrite.Close();			
		}
        void Write_file(System.IO.StreamWriter file,string Line){
        	string NewLine;
        	NewLine = Line + " Super !!";
        	file.WriteLine(NewLine);

        }
		void Read_write_buttonClick(object sender, EventArgs e)
		{
			try {
				if(chosenFile.Text!=destFile.Text){
					Read_file(chosenFile.Text,destFile.Text);
				}
				else{
					MessageBox.Show("Filepaths need to be different!");
				}
				
			} catch (Exception ex) {
				MessageBox.Show(ex.Message);
				//MessageBox.Show("No file to convert");
				//throw;
			} 
			
		}
		void Choose_file_to_writeClick(object sender, EventArgs e)
		{
			DialogResult result = saveFileDialog1.ShowDialog();
		    if (result == DialogResult.OK) 
		    {
		       string filepath = saveFileDialog1.FileName;
		       destFile.Text= filepath;		       
		    }
		}
		void Choose_file_to_readClick(object sender, EventArgs e)
		{
		    DialogResult result = openFileDialog1.ShowDialog(); 
		    if (result == DialogResult.OK) 
		    {
		       string filepath = openFileDialog1.FileName;
		       chosenFile.Text= filepath;		       
		    }
		}
	}
}
