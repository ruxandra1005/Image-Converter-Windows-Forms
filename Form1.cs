using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tema1_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //citim din fisier pt list box

            StreamReader reader = new StreamReader("formats.txt");
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                listBox1.Items.Add(line);
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string inputFile = openFileDialog.FileName;
                Image originalImage = Image.FromFile(inputFile);
                pictureBox1.Image = originalImage;
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                // aici in Filter ne zice ce fel de formate sa afiseze in bara save as type
                saveFileDialog.Filter = "JPEG Image|*.jpg|PNG Image|*.png|GIF Image|*.gif";

                //in functie de radiobuton pune automat formatul in bara
                if (radioButton8.Checked)
                {
                    saveFileDialog.FilterIndex = 1; 
                }
                else if (radioButton5.Checked)
                {
                    saveFileDialog.FilterIndex = 2;
                }
                else if (radioButton7.Checked)
                {
                    saveFileDialog.FilterIndex = 3; 
                }

                // in functie de ce e selectat mai sus, converteste formatul
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    ImageFormat format = null;

                    if (radioButton8.Checked)
                    {
                        format = ImageFormat.Jpeg;
                    }
                    else if (radioButton5.Checked)
                    {
                        format = ImageFormat.Png;
                    }
                    else if (radioButton7.Checked)
                    {
                        format = ImageFormat.Gif;
                    }
                    
                    //daca a reusit formatarea salveaza
                    if (format != null)
                    {
                        pictureBox1.Image.Save(saveFileDialog.FileName, format);
                    }
                   
                }
            }
            else
            {
                MessageBox.Show("Please select an image first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string format = listBox1.SelectedItem.ToString();
            switch (format)
            {
                case "JPEG":
                    pictureBox1.Image = Image.FromFile(@"C:\Users\Ruxandra\C# tutorial\Tema1 II\Tema1_2\pisi1.jpg");
                    break;
                case "GIF":
                    pictureBox1.Image = Image.FromFile(@"C:\Users\Ruxandra\C# tutorial\Tema1 II\Tema1_2\pisi4.gif");
                    break;
                case "PNG":
                    pictureBox1.Image = Image.FromFile(@"C:\Users\Ruxandra\C# tutorial\Tema1 II\Tema1_2\pisi3.PNG");
                    break;
            }
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                // aici in Filter ne zice ce fel de formate sa afiseze in bara save as type
                saveFileDialog.Filter = "JPEG Image|*.jpg|PNG Image|*.png|GIF Image|*.gif";

                //in functie de radiobuton pune automat formatul in bara
                if (radioButton8.Checked)
                {
                    saveFileDialog.FilterIndex = 1;
                }
                else if (radioButton5.Checked)
                {
                    saveFileDialog.FilterIndex = 2;
                }
                else if (radioButton7.Checked)
                {
                    saveFileDialog.FilterIndex = 3;
                }

                // in functie de ce e selectat mai sus, converteste formatul
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    ImageFormat format = null;

                    if (radioButton8.Checked)
                    {
                        format = ImageFormat.Jpeg;
                    }
                    else if (radioButton5.Checked)
                    {
                        format = ImageFormat.Png;
                    }
                    else if (radioButton7.Checked)
                    {
                        format = ImageFormat.Gif;
                    }

                    //daca a reusit formatarea salveaza
                    if (format != null)
                    {
                        pictureBox1.Image.Save(saveFileDialog.FileName, format);
                    }

                }
            }
            else
            {
                MessageBox.Show("Please select an image first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
