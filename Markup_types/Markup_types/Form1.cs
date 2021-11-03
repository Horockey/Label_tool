using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Text.Json;

namespace Markup_types
{
	public partial class mainForm : Form
	{
		string DIRECTORY;
		Dictionary<string, string> labels = new Dictionary<string, string>();
		public mainForm()
		{
			InitializeComponent();
			saveToJsonButton.Enabled = false;
			selectLabelCB.Enabled = false;
			currentDirectoryListBox.Enabled = false;
			previousImageButton.Enabled = false;
			nextImageButton.Enabled = false;
		}

		private void changeDirectoryButton_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog fbd = new FolderBrowserDialog();
			if(fbd.ShowDialog() == DialogResult.OK)
			{
				DIRECTORY = fbd.SelectedPath;
				currentDirrectoryLabel.Text = DIRECTORY;
				fillListBox();
				if (currentDirectoryListBox.Items.Count > 0)
				{
					saveToJsonButton.Enabled = true;
					selectLabelCB.Enabled = true;
					currentDirectoryListBox.Enabled = true;
					previousImageButton.Enabled = true;
					nextImageButton.Enabled = true;
					currentDirectoryListBox.Focus();
				}
			}
		}

		private void fillListBox()
		{
			string[] fls = Directory.GetFiles(DIRECTORY);
			foreach(string fl in fls)
			{
				if(fl.EndsWith(".jpg") || fl.EndsWith(".jpeg")
					|| fl.EndsWith(".bmp") || fl.EndsWith(".png"))
				{
					currentDirectoryListBox.Items.Add(fl);
				}
			}
			
		}

		private void currentDirectoryListBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			//Show preview on pictureBox
			currentImgPreviewPB.Image = Image.FromFile(currentDirectoryListBox.SelectedItem.ToString());
			try
			{
				selectLabelCB.SelectedItem = labels[currentDirectoryListBox.SelectedItem.ToString()];
			}
			catch(Exception)
			{
				selectLabelCB.SelectedIndex = 0;
			}
			
		}

		private void selectLabelCB_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (currentDirectoryListBox.SelectedItem == null ||
				selectLabelCB.SelectedItem == null) return;
			if(selectLabelCB.SelectedItem.ToString() == "")
			{
				try
				{
					labels.Remove(currentDirectoryListBox.SelectedItem.ToString());
				}
				catch (ArgumentException) { }
				return;
			}
			try
			{
				labels.Add(currentDirectoryListBox.SelectedItem.ToString(), selectLabelCB.SelectedItem.ToString());
			}
			catch(ArgumentException)
			{
				labels[currentDirectoryListBox.SelectedItem.ToString()] = selectLabelCB.SelectedItem.ToString();
			}
			
		}

		private void previousImageButton_Click(object sender, EventArgs e)
		{
			currentDirectoryListBox.SelectedIndex--;
			
		}

		private void nextImageButton_Click(object sender, EventArgs e)
		{
			currentDirectoryListBox.SelectedIndex++;
			
		}

		private void saveToJsonButton_Click(object sender, EventArgs e)
		{
			try
			{
				if (labels.Count == 0) throw new Exception();
				string jsonFormated = JsonSerializer.Serialize(labels);
				string[] jsonFormatedLined = jsonFormated.Split(",");
				StreamWriter fout = File.CreateText(DIRECTORY + @"\INFO.json");
				for(int i = 0; i < jsonFormatedLined.Length; i++)
				{
					fout.Write(jsonFormatedLined[i]);
					if(i < jsonFormatedLined.Length-1)
					{
						fout.Write(",\n");
					}
				}
				fout.Close();
			}
			catch (Exception)
			{
				MessageBox.Show("You haven't labeled any image yet!", "Error!", MessageBoxButtons.OK);
				
				return;
			}
			MessageBox.Show(labels.Count.ToString() + " labels saved successfully!", "OK", MessageBoxButtons.OK);
			
		}
		
		private void currentDirectoryListBox_KeyDown(object sender, KeyEventArgs e)
		{
			if (currentDirectoryListBox.Items.Count == 0) return;
			if (e.KeyCode == Keys.S)
			{
				if (currentDirectoryListBox.SelectedIndex < currentDirectoryListBox.Items.Count-1)
				{
					currentDirectoryListBox.SelectedIndex++;
				}
				else
				{
					currentDirectoryListBox.SelectedIndex = 0;
				}
			}
			if (e.KeyCode == Keys.W)
			{
				if (currentDirectoryListBox.SelectedIndex > 0)
				{
					currentDirectoryListBox.SelectedIndex--;
				}
				else
				{
					currentDirectoryListBox.SelectedIndex = currentDirectoryListBox.Items.Count - 1;
				}
			}
			if (e.KeyCode == Keys.A && currentDirectoryListBox.SelectedItem != null)
			{
				if (selectLabelCB.SelectedIndex > 0)
				{
					selectLabelCB.SelectedIndex--;
				}
				else
				{
					selectLabelCB.SelectedIndex = selectLabelCB.Items.Count - 1;
				}
			}
			if (e.KeyCode == Keys.D && currentDirectoryListBox.SelectedItem != null)
			{
				if (selectLabelCB.SelectedIndex < selectLabelCB.Items.Count - 1)
				{
					selectLabelCB.SelectedIndex++;
				}
				else
				{
					selectLabelCB.SelectedIndex = 0;
				}
			}
		}

		private void helpButton_Click(object sender, EventArgs e)
		{
			showHelp();
		}
		private void showHelp()
		{
			string msg = "Как пользоваться разметчиком?\n\n" +
					"1. Нажмите кнопку Change directory и выберите папку, " +
					"в которой лежат размечаемые изображения\n\n" +
					"2. Выберите нужное изображение щелчком мыши в появившемся списке\n" +
					"или используя кнопку Next image / Previous image\n" +
					"или используя клавиши W/S на клавиатуре\n\n" +
					"3. Выберите необходимую метку изображения из раскрывающегося списка мышью\n" +
					"или используя клавиши A/D на клавиатуре\n\n" +
					"4. Повторяйте пункты 2-3 для всех необходимых изображений\n\n" +
					"5. По завершении разметки сохраните результат, используя кнопку Save to JSON\n" +
					"Все метки изображений сохранятся в файл INFO.json,\n" +
					"который будет располагаться в той же папке, что и изображения\n\n" +
					"6. При необходимости разметить еще одну папку, повторите пункты 1-5";
			MessageBox.Show(msg, "Info", MessageBoxButtons.OK);
		}
	}
}
