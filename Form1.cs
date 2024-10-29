using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;


namespace newform
{
    public partial class Form1 : Form
    {
        private SoundPlayer soundPlayer; // Khai báo biến SoundPlayer

        public Form1()
        {
            InitializeComponent();
            soundPlayer = new SoundPlayer(Properties.Resources.NhacGame); // Phát nhạc từ Resources
            soundPlayer.PlayLooping(); // Phát nhạc liên tục
        }

        // Hàm để dừng nhạc
        private void StopMusic()
        {
            if (soundPlayer != null)
            {
                soundPlayer.Stop(); // Dừng nhạc
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StopMusic(); // Dừng nhạc trước khi chuyển form
            this.Hide();
            Form2 frm2 = new Form2();
            frm2.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form5 frm5 = new Form5();
            frm5.ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form6 frm6 = new Form6();
            frm6.ShowDialog();
            this.Close();
        }
    }
}
