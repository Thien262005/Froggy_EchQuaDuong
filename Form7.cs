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
    public partial class Form7 : Form
    {
        private SoundPlayer soundPlayer; // Khai báo biến SoundPlayer
        public Form7()
        {
            InitializeComponent();
            soundPlayer = new SoundPlayer(); // Khởi tạo SoundPlayer
            soundPlayer = new SoundPlayer(Properties.Resources.NhacGame); // Phát nhạc từ Resources
            soundPlayer.PlayLooping(); // Phát nhạc liên tục
        }
    }
}
