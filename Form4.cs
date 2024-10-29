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
    public partial class Form4 : Form
    {
        private SoundPlayer soundPlayer; // Khai báo biến SoundPlayer
        bool EndGame;
        public Form4()
        {
            InitializeComponent();
            KhoiTaoGame();

        }
        // Hàm để dừng nhạc
        private void StopMusic()
        {
            if (soundPlayer != null)
            {
                soundPlayer.Stop(); // Dừng nhạc
            }
        }
        private void KhoiTaoGame()
        {
            // thiết lập Timer để di chuyển xe
            Timer carTimer = new Timer();
            carTimer.Interval = 12;// Điều chỉnh tốc độ xe
            carTimer.Tick += CarTimer_Tick;
            carTimer.Start();

            // xử lý để di chuyển ếch
            this.KeyDown += new KeyEventHandler(Form2_KeyDown);

            // đặt vị trí ban đầu của ếch
            ResetGame();
        }
        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            int step = 15; // điều chỉnh bước di chuyển của ếch
            if (ech.Tag.ToString() == "Frog") 
            {
                if (e.KeyCode == Keys.Up) ech.Top -= step;
                if (e.KeyCode == Keys.Down) ech.Top += step;
                if (e.KeyCode == Keys.Left) ech.Left -= step;
                if (e.KeyCode == Keys.Right) ech.Left += step;
                // kiểm tra giới hạn cửa sổ
                if (ech.Left < 0) ech.Left = 0; // không cho phép đi ra ngoài bên trái
                if (ech.Right > this.ClientSize.Width) ech.Left = this.ClientSize.Width - ech.Width; // không cho phép đi ra ngoài bên phải
                if (ech.Top < 0) ech.Top = 0; // không cho phép đi ra ngoài trên cùng
                if (ech.Bottom > this.ClientSize.Height) ech.Top = this.ClientSize.Height - ech.Height; // không cho phép đi ra ngoài dưới cùng
            }
        }

        private void CarTimer_Tick(object sender, EventArgs e)
        {
            if (EndGame) return; // nếu trò chơi đã kết thúc, không thực hiện gì thêm

            // di chuyển các xe
            foreach (Control control in this.Controls)
            {
                if (control is PictureBox && control.Tag != null && control.Tag.ToString().Contains("Car"))
                {
                    // kiểm tra hướng đi dựa trên Tag
                    if (control.Tag.ToString() == "CarLeftToRight")
                    {
                        // Xe đi từ trái sang phải
                        control.Left += 5; // Điều chỉnh tốc độ xe
                        if (control.Left > this.ClientSize.Width)
                        {
                            control.Left = -control.Width; // Đặt lại vị trí xe về bên trái
                        }
                    }
                    else if (control.Tag.ToString() == "CarRightToLeft")
                    {
                        // xe đi từ phải sang trái
                        control.Left -= 5; // Điều chỉnh tốc độ xe
                        if (control.Left < -control.Width)
                        {
                            control.Left = this.ClientSize.Width; // Đặt lại vị trí xe về bên phải
                        }
                    }

                    // Kiểm tra va chạm với ếch
                    if (ech.Bounds.IntersectsWith(control.Bounds))
                    {
                        // Nếu có va chạm giữa ếch và xe
                        EndGame = true; // Kết thúc trò chơi
                        MessageBox.Show("YOU LOSE!"); // Hiển thị thông báo thua
                        ResetGame(); // Đặt lại trò chơi
                        return; // Dừng xử lý thêm
                    }
                }
            }

            // Kiểm tra nếu ếch đã tới đích
            if (ech.Top <= 0)
            {
                EndGame = true; // Đặt trạng thái kết thúc
                StopMusic(); // Dừng phát nhạc nền nếu có
                SoundPlayer winSoundPlayer = new SoundPlayer(Properties.Resources.Win_1); // Đường dẫn đến file âm thanh chiến thắng
                winSoundPlayer.Play(); // Phát âm thanh chiến thắng

                MessageBox.Show("YOU WIN!", "Congratulations", MessageBoxButtons.OK, MessageBoxIcon.Information); // Thông báo thắng

                // Chuyển sang Form3 khi nhấn OK
                this.Hide(); // Ẩn Form2
                Form7 form7 = new Form7(); // Tạo một instance của Form3
                form7.ShowDialog(); // Hiển thị Form3
                return; // Dừng xử lý thêm
            }
        }
        private void ResetGame()
        {
            ech.Location = new Point(this.ClientSize.Width / 2, this.ClientSize.Height - ech.Height);
            EndGame = false; //dat lai trang thai de tiep tuc game
        }
    }
}
