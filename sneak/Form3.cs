using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace sneak
{
    public partial class Form3 : Form
    {
        private int scoreSave = 0;
        public Form3(int score)
        {
            InitializeComponent();
            scoreSave = score;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 newForm = new Form2();
            newForm.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private async void button2_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                string text = scoreSave.ToString();   
                string fileText = folderBrowserDialog1.SelectedPath;
                StreamWriter sw = new StreamWriter(new FileStream(fileText + "\\Результаты.txt", FileMode.Append, FileAccess.Write));
                if (scoreSave < 5 && scoreSave >= 1)
                {
                    sw.WriteLine("Набранный счет: " + text + " очка");
                }

                else
                    sw.WriteLine("Набранный счет: " + text + " очков");
                    sw.Close();
            }
            
        }
    }
}
