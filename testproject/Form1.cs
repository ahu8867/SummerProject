using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace testproject
{
    public partial class Form1 : Form
    {
        WMPLib.WindowsMediaPlayer player = new WMPLib.WindowsMediaPlayer();
        int Record = 0;
        Timer timer = new System.Windows.Forms.Timer();
        protected override bool IsInputKey(Keys keydata)
        {
            switch (keydata)
            {
                case Keys.Enter:
                    int x = PaperPlane.Location.X;
                    int y = PaperPlane.Location.Y;
                    y -= 50;
                    PaperPlane.Location = new Point(x, y);
                    return true;
                case Keys.Shift | Keys.Enter:
                    return true;
            }
            return base.IsInputKey(keydata);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            int borderWidth = 5;
            Color borderColor = Color.Pink;
            ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, borderColor,
             borderWidth, ButtonBorderStyle.Solid, borderColor, borderWidth,
            ButtonBorderStyle.Solid, borderColor, borderWidth,
             ButtonBorderStyle.Solid,
            borderColor, borderWidth, ButtonBorderStyle.Solid);
             
        }

        public Form1()
        { 
            InitializeComponent();
            player.URL = "43.mp3";
            player.controls.stop();
            panel1.BackColor = Color.AliceBlue;
            panel2.BackColor = Color.SkyBlue ;
            panel3.BackColor = Color.YellowGreen;
            this.BackColor = System.Drawing.Color.White;
        }
        

        void Form1_KeyDown(object sender, KeyEventArgs e)
        { 
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        { 
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random r = new Random();
            RecordLabel.Text = Convert.ToString(Record);
            Record += 1;
            int random_brick_Y = r.Next(15, 157);
            int X_location = pictureBox2.Location.X;
            int X_brick = BrickRabel.Location.X;
            int Y_brick = BrickRabel.Location.Y;
            int brick = random_brick_Y;

            PaperPlane.Location = new Point(PaperPlane.Location.X, PaperPlane.Location.Y + 5);
            pictureBox2.Location = new Point(X_location - 10, pictureBox2.Location.Y);
            BrickRabel.Location = new Point(X_brick - 10, BrickRabel.Location.Y);
            if (X_location < 0 && X_brick < 0)
            {
                X_location += 600;
                X_brick += 604;
                pictureBox2.Location = new Point(X_location - 1, pictureBox2.Location.Y);
                BrickRabel.Location = new Point(X_brick - 5, random_brick_Y);
            }
            if (pictureBox2.Location.X < 133 && pictureBox2.Location.X > 71)
            {
                if (PaperPlane.Location.Y >= BrickRabel.Location.Y + 70 || PaperPlane.Location.Y <= BrickRabel.Location.Y)
                {
                    timer.Stop();
                    if(MessageBox.Show("게임을 다시 시작하시겠습니까?","Game Over", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        Application.Restart();
                    }
                    else
                    {
                        Application.Exit();
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1_Tick(sender, e);
            timer.Interval = 30;
            timer.Tick += new EventHandler(timer1_Tick);
            timer.Start();
            player.controls.play();
            button1.Enabled = false;
        }
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
        }
        private void label4_Click(object sender, EventArgs e)
        {
        }
        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
